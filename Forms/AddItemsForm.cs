using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using System;
using System.Collections.Generic;
using ShoppingCart.Business.Entities;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ShoppingCart.Business.Model;
using ShoppingCart.Business.Log;
using ShoppingCart.Extensions;
using System.Transactions;
using ShoppingCartWebAPI.HttpClients.Interfaces;
using ShoppingCartWebAPI.HttpClients;

namespace ShoppingCart.Forms
{
    public partial class AddItemsForm : Form
    {
        private readonly IHttpClients<Item> _itemClient = new ItemHttpClient();

        public AddItemsForm()
        {
            InitializeComponent();
        }

        private void AddItemForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                itemListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (Item item in _itemClient.GetAll())
                {
                    ListViewItem listViewItem = new ListViewItem(new[] {string.Empty,
                                                                        item.Id.ToString(),
                                                                        item.Name,
                                                                        item.Price.ToString(),
                                                                        item.Stocks.ToString()});
                    if (item.Stocks == 0)
                    {
                        listViewItem.BackColor = Color.Red;
                    }

                    listViewItems.Add(listViewItem);
                }

                itemListView.Items.AddRange(listViewItems.ToArray());
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void ItemListView_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (itemListView.SelectedItems.Count > 0)
                {
                    int id = itemListView.SelectedItems[0].SubItems[1].Text.ToInt(-1);
                    Item item = _itemClient.GetById(id);
                    Item returnedItem = ShowDialogNewItem(item);

                    if (returnedItem != null)
                    {
                        if (_itemClient.Update(item))
                        {
                            LoadData();
                        }
                        else
                        {
                            string caption = "Error.";
                            string message = $"Can't update item {item.Name}.";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void AddItemButton_Click(object sender, EventArgs e)
        {
            try
            {
                Item item = new Item();
                Item returnedItem = ShowDialogNewItem(item);

                if (returnedItem != null)
                {
                    if (_itemClient.Add(returnedItem) > 0)
                    {
                        LoadData();
                    }
                    else
                    {
                        string caption = "Error.";
                        string message = "Can't add item. Please try again.";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
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

                    foreach (Item item in _itemClient.Find(searchItem))
                    {
                        ListViewItem listViewItem = new ListViewItem(new[] {string.Empty,
                                                                        item.Id.ToString(),
                                                                        item.Name,
                                                                        item.Price.ToString(),
                                                                        item.Stocks.ToString()});
                        if (item.Stocks == 0)
                        {
                            listViewItem.BackColor = Color.Red;
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

        private void AddItemsForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemListView.CheckedItems.Count > 0)
                {
                    List<Item> items = new List<Item>();

                    foreach (ListViewItem listViewItem in itemListView.CheckedItems)
                    {
                        items.Add(new Item { Id = listViewItem.SubItems[1].Text.ToInt(-1) });
                    }

                    using (TransactionScope scope = new TransactionScope())
                    {
                        if (_itemClient.Delete(items))
                        {
                            LoadData();
                            scope.Complete();
                        }
                        else
                        {
                            string message = "The item is already in used.\nCan't proceed.";
                            string caption = "Error.";
                            MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    string message = "Select items to remove.";
                    string caption = "Empty.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }
    }
}
