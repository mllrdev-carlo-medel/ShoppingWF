using System;
using ShoppingCart.Business.Entities;
using System.Windows.Forms;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Manager;
using System.Collections.Generic;
using ShoppingCart.Business.Model;
using System.Transactions;
using ShoppingCart.Extensions;
using System.Linq;
using ShoppingCart.Business.Log;
using System.Drawing;

namespace ShoppingCart.Forms
{
    public partial class ItemsForm : Form
    {
        private readonly IManager<Item> _itemManager = new ItemManager();
        private readonly IManager<PurchaseItem> _purchaseItemManager = new PurchaseItemManager();

        private readonly List<PurchaseDetails> _purchases;
        private readonly Purchase _purchase;

        public ItemsForm(List<PurchaseDetails> purchaseDetails, Purchase purchase)
        {
            InitializeComponent();
            _purchases = purchaseDetails;
            _purchase = purchase;
        }

        private void ItemsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                itemListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (Item item in _itemManager.GetAll())
                {
                    if (item.Stocks > 0)
                    {
                        ListViewItem listViewItem = new ListViewItem(new[] {string.Empty,
                                                                        item.Id.ToString(),
                                                                        item.Name,
                                                                        item.Price.ToString(),
                                                                        item.Stocks.ToString()});

                        if (_purchases.Find(x => x.PurchaseItem.ItemId == item.Id) != null)
                        {
                            listViewItem.BackColor = Color.Green;
                        }

                        listViewItems.Add(listViewItem);
                    }
                }

                itemListView.Items.AddRange(listViewItems.ToArray());
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemListView.CheckedItems.Count > 0)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        foreach (ListViewItem listViewItem in itemListView.CheckedItems)
                        {
                            Item item = _itemManager.GetById(listViewItem.SubItems[1].Text.ToInt(-1));
                            PurchaseItem purchaseItem = new PurchaseItem { PurchaseId = _purchase.Id, ItemId = item.Id, Price = item.Price, Quantity = 1, SubTotal = item.Price };
                            item.Stocks -= 1;

                            if ((purchaseItem.Id = _purchaseItemManager.Add(purchaseItem)) > 0 && _itemManager.Update(item))
                            {
                                _purchases.Add(new PurchaseDetails(purchaseItem, item));
                                LoadData();
                                CartForm cartForm = Application.OpenForms.OfType<CartForm>().FirstOrDefault();
                                cartForm.LoadData();
                            }
                            else
                            {
                                string caption = "Can't add item(s).";
                                string message = "Please try again.";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                                return;
                            }
                        }

                        scope.Complete();
                    }
                }
                else
                {
                    string caption = "No item selected.";
                    string message = "Please select an item to be added in your cart.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void ItemListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                int id = e.Item.SubItems[1].Text.ToInt(-1);

                if (_purchases.Find(x => x.PurchaseItem.ItemId == id) != null || _itemManager.GetById(id).Stocks == 0)
                {
                    e.Item.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private Item ShowDialogNewItem(Item item)
        {
            try
            {
                ItemPromptForm itemPromptForm = new ItemPromptForm(item);
                itemPromptForm.ShowDialog();

                return itemPromptForm.IsSuccess ? itemPromptForm.Item : null;
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
                return null;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = textBoxSearch.Text;

                if (!string.IsNullOrWhiteSpace(searchName))
                {
                    List<ListViewItem> listViewItems = new List<ListViewItem>();
                    Item searchItem = new Item { Name = searchName };

                    foreach (Item item in _itemManager.GetAllWhere(searchItem))
                    {
                        ListViewItem listViewItem = new ListViewItem(new[] {string.Empty,
                                                                        item.Id.ToString(),
                                                                        item.Name,
                                                                        item.Price.ToString(),
                                                                        item.Stocks.ToString()});

                        if (_purchases.Find(x => x.PurchaseItem.ItemId == item.Id) != null)
                        {
                            listViewItem.BackColor = Color.Green;
                        }

                        listViewItems.Add(listViewItem);
                    }

                    if (listViewItems.Count > 0)
                    {
                        itemListView.Items.Clear();
                        itemListView.Items.AddRange(listViewItems.ToArray());
                    }
                    else
                    {
                        string message = "Can't find item.";
                        string caption = "Empty.";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            textBoxSearch.Text = string.Empty;
            LoadData();
        }

        private void ItemsForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CartForm cartForm = Application.OpenForms.OfType<CartForm>().FirstOrDefault();
            cartForm.LoadData();
            cartForm.EnableAddItemButton(true);
        }
    }
}
