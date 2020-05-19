using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Extensions;
using System;
using System.Collections.Generic;
using ShoppingCart.Business.Log;
using System.Linq;
using System.Windows.Forms;
using System.Transactions;
using ShoppingCart.Constants;

namespace ShoppingCart.Forms
{
    public partial class CartForm : Form
    {
        private readonly IManager<Item> _itemManager = new ItemManager();
        private readonly IManager<PurchaseItem> _purchaseItemManager = new PurchaseItemManager();

        private readonly IManager<Purchase> _purchaseManager = new PurchaseManager();

        private readonly Purchase _purchase;
        private readonly List<PurchaseDetails> _purchases;

        public CartForm(List<PurchaseDetails> purchaseDetails, Purchase purchase)
        {
            InitializeComponent();
            _purchases = purchaseDetails;
            _purchase = purchase;
        }

        public void LoadData()
        {
            try
            {
                cartListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (PurchaseDetails purchaseDetails in _purchases)
                {
                    listViewItems.Add(new ListViewItem(new[] { string.Empty,
                                                            purchaseDetails.PurchaseItem.ItemId.ToString(),
                                                            purchaseDetails.Name,
                                                            purchaseDetails.Price.ToString(),
                                                            purchaseDetails.PurchaseItem.Quantity.ToString(),
                                                            purchaseDetails.PurchaseItem.SubTotal.ToString()})
                    {
                        Checked = false
                    });
                }

                cartListView.Items.AddRange(listViewItems.ToArray());

                try
                {
                    cartListView.Items[0].Selected = true;
                    textBoxName.Text = cartListView.SelectedItems[0].SubItems[2].Text;
                    textBoxPrice.Text = cartListView.SelectedItems[0].SubItems[3].Text;
                    textBoxQuantity.Text = cartListView.SelectedItems[0].SubItems[4].Text;
                    textBoxSubtotal.Text = cartListView.SelectedItems[0].SubItems[5].Text;
                }
                catch (Exception e)
                {
                    textBoxName.Text = string.Empty;
                    textBoxPrice.Text = string.Empty;
                    textBoxQuantity.Text = string.Empty;
                    textBoxSubtotal.Text = string.Empty;
                    Logger.log.Info($"No selected items in cart.\n {e}");
                }

                textBoxTotal.Text = ComputeTotalPrice().ToString();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        public void EnableAddItemButton(bool value)
        {
            AddButton.Enabled = value;
        }

        public float ComputeTotalPrice()
        {
            double total = _purchases.Sum(x => x.PurchaseItem.SubTotal);
            return (float)Math.Round(total, 2);
        }

        private void CartListView_Click(object sender, System.EventArgs e)
        {
            if (cartListView.SelectedItems.Count > 0)
            {
                textBoxName.Text = cartListView.SelectedItems[0].SubItems[2].Text;
                textBoxPrice.Text = cartListView.SelectedItems[0].SubItems[3].Text;
                textBoxQuantity.Text = cartListView.SelectedItems[0].SubItems[4].Text;
                textBoxSubtotal.Text = cartListView.SelectedItems[0].SubItems[5].Text;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            EnableAddItemButton(false);
            ItemsForm itemsForm = new ItemsForm(_purchases, _purchase);
            itemsForm.MdiParent = this.ParentForm;
            itemsForm.Show();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (cartListView.SelectedItems.Count > 0)
            {
                try
                {
                    Item item = _itemManager.GetById(cartListView.SelectedItems[0].SubItems[1].Text.ToInt(-1));
                    PurchaseDetails purchaseDetails = _purchases.Find(x => x.PurchaseItem.ItemId == item.Id);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        int quantity = textBoxQuantity.Text.ToInt(-1);

                        if (quantity > 0 && quantity <= (item.Stocks + purchaseDetails.PurchaseItem.Quantity))
                        {
                            item.Stocks -= (quantity - purchaseDetails.PurchaseItem.Quantity);
                            purchaseDetails.PurchaseItem.Quantity = quantity;
                            purchaseDetails.PurchaseItem.SubTotal = quantity * item.Price;

                            if (!_purchaseItemManager.Update(purchaseDetails.PurchaseItem) || !_itemManager.Update(item))
                            {
                                string message = "Can't update item.";
                                string caption = "Please try again.";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                                return;
                            }
                        }
                        else
                        {
                            string caption = "Please try again.";
                            string message = "Can't update item for that value.";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }

                        textBoxTotal.Text = ComputeTotalPrice().ToString();
                        LoadData();
                        ItemsForm itemsForm = Application.OpenForms.OfType<ItemsForm>().FirstOrDefault();

                        if (itemsForm != null)
                        {
                            itemsForm.LoadData();
                        }

                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Logger.log.Error(ex.ToString());
                }
            }
            else
            {
                string caption = string.Empty;
                string message = "Please select an item in your cart.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (cartListView.CheckedItems.Count > 0)
                {
                    List<string> failures = new List<string>();

                    foreach (ListViewItem listViewItem in cartListView.CheckedItems)
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            Item item = _itemManager.GetById(listViewItem.SubItems[1].Text.ToInt(-1));
                            PurchaseDetails purchaseDetails = _purchases.Find(x => x.PurchaseItem.ItemId == item.Id);

                            int[] id = { purchaseDetails.PurchaseItem.Id };
                            List<PurchaseItem> purchaseItem = new List<PurchaseItem>() { new PurchaseItem { Id = id[0] } };
                            item.Stocks += purchaseDetails.PurchaseItem.Quantity;

                            if (_purchaseItemManager.Delete(purchaseItem) && _itemManager.Update(item))
                            {
                                _purchases.Remove(purchaseDetails);
                                textBoxTotal.Text = ComputeTotalPrice().ToString();
                                scope.Complete();
                            }
                            else
                            {
                                failures.Add(item.Name);
                            }
                        }
                    }

                    ItemsForm itemsForm = Application.OpenForms.OfType<ItemsForm>().FirstOrDefault();

                    if (itemsForm != null)
                    {
                        itemsForm.LoadData();
                    }

                    LoadData();

                    if (failures.Count > 0)
                    {
                        string items = string.Empty;

                        foreach (string failure in failures)
                        {
                            items += $"{items}, {failure}";
                        }

                        string message = $"Item/s {items} can't be deleted";
                        string caption = "Please try again.";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    string caption = "Error";
                    string message = "Please toggle the checkbox for the\nitem(s) in your cart to remove.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    if (ComputeTotalPrice() > 0)
                    {
                        _purchase.Status = ProfileStringConstants.PURCHASED;
                        _purchase.Date = DateTime.Now.ToString();
                        _purchase.Total = ComputeTotalPrice();

                        if (_purchaseManager.Update(_purchase))
                        {
                            string caption = "Success";
                            string message = "Thank you. Please come again.";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                            this.Close();
                        }
                        else
                        {
                            string caption = "Can't proceed.";
                            string message = "Please try again.";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                            return;
                        }
                    }
                    else
                    {
                        string message = "Please add items to your cart.";
                        string caption = "Empty cart";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }

                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void CartForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ComputeTotalPrice() <= 0)
            {
                List<Purchase> purchases = new List<Purchase>() { new Purchase { Id = _purchase.Id} };

                if (!_purchaseManager.Delete(purchases))
                {
                    Logger.log.Error($"A pending purchase with id {_purchase.Id} can't be deleted.");
                }
            }

            ItemsForm itemsForm = Application.OpenForms.OfType<ItemsForm>().FirstOrDefault();
            
            if(itemsForm != null)
            {
                itemsForm.Close();
            }

            ProfileForm profileForm = Application.OpenForms.OfType<ProfileForm>().FirstOrDefault();
            profileForm.LoadData();
            profileForm.EnableNewPurchaseButton(true);
        }

        private void CartForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
