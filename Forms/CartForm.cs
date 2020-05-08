using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Helper;
using System;
using System.Collections.Generic;
using ShoppingCart.Business.Log;
using System.Linq;
using System.Windows.Forms;
using System.Transactions;
using ShoppingCart.Forms.Interfaces;

namespace ShoppingCart.Forms
{
    public partial class CartForm : Form, ICartForm
    {
        private IManager<Item> ItemManager { get; } = new ItemManager();
        private IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();

        private IManager<Purchase> PurchaseManager { get; } = new PurchaseManager();

        private Purchase Purchase { get; }
        private List<PurchaseDetails> Purchases { get; }

        public CartForm(List<PurchaseDetails> purchaseDetails, Purchase purchase)
        {
            InitializeComponent();
            Purchases = purchaseDetails;
            Purchase = purchase;
            LoadData();
        }

        public void LoadData()
        {
            itemListView.Items.Clear();
            cartListView.Items.Clear();

            foreach (PurchaseDetails purchaseDetails in Purchases)
            {
                ListViewItem listViewItem = new ListViewItem(new[] { "",
                                                                     purchaseDetails.PurchaseItem.ItemId.ToString(),
                                                                     purchaseDetails.Name,
                                                                     purchaseDetails.Price.ToString(),
                                                                     purchaseDetails.PurchaseItem.Quantity.ToString(),
                                                                     purchaseDetails.PurchaseItem.SubTotal.ToString()});
                listViewItem.Checked = false;
                cartListView.Items.Add(listViewItem);
            }

            foreach (Item item in ItemManager.GetAll())
            {
                ListViewItem listViewItem = new ListViewItem(new[] {"",
                                                             item.Id.ToString(),
                                                             item.Name,
                                                             item.Price.ToString(),
                                                             item.Stocks.ToString()});
                
                if (Purchases.Find(x => x.PurchaseItem.ItemId == item.Id) != null || item.Stocks == 0)
                {
                    listViewItem.BackColor = System.Drawing.Color.Gray;
                }

                itemListView.Items.Add(listViewItem);
            }

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
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                textBoxQuantity.Text = "";
                textBoxSubtotal.Text = "";
                Logger.log.Info($"No selected items in cart.\n {e}");
            }

            textBoxTotal.Text = ComputeTotalPrice().ToString();
        }

        public float ComputeTotalPrice()
        {
            double total = Purchases.Sum(x => x.PurchaseItem.SubTotal);
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

        private void ItemListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int id = e.Item.SubItems[1].Text.ToInt(-1);

            if (Purchases.Find(x => x.PurchaseItem.ItemId == id) != null || ItemManager.GetById(id).Stocks == 0)
            {
                e.Item.Checked = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (itemListView.CheckedItems.Count > 0)
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    foreach (ListViewItem listViewItem in itemListView.CheckedItems)
                    {
                        Item item = ItemManager.GetById(listViewItem.SubItems[1].Text.ToInt(-1));
                        PurchaseItem purchaseItem = new PurchaseItem(GenerateID.GetGeneratedID(), Purchase.Id, item.Id, 1, item.Price);
                        item.Stocks -= 1;

                        if (PurchaseItemManager.Add(purchaseItem) && ItemManager.Update(item))
                        {
                            Purchases.Add(new PurchaseDetails(purchaseItem, item));
                            textBoxTotal.Text = ComputeTotalPrice().ToString();
                            LoadData();
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

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (cartListView.SelectedItems.Count > 0)
            {
                try
                {
                    Item item = ItemManager.GetById(cartListView.SelectedItems[0].SubItems[1].Text.ToInt(-1));
                    PurchaseDetails purchaseDetails = Purchases.Find(x => x.PurchaseItem.ItemId == item.Id);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        int quantity = textBoxQuantity.Text.ToInt(-1);

                        if (quantity > 0 && quantity <= (item.Stocks + purchaseDetails.PurchaseItem.Quantity))
                        {
                            item.Stocks -= (quantity - purchaseDetails.PurchaseItem.Quantity);
                            purchaseDetails.PurchaseItem.Quantity = quantity;
                            purchaseDetails.PurchaseItem.SubTotal = quantity * item.Price;

                            if (!PurchaseItemManager.Update(purchaseDetails.PurchaseItem) || !ItemManager.Update(item))
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
                string caption = "";
                string message = "Please select an item in your cart.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (cartListView.CheckedItems.Count > 0)
            {
                List<string> failures = new List<string>();

                foreach (ListViewItem listViewItem in cartListView.CheckedItems)
                {
                    try
                    {
                        Item item = ItemManager.GetById(listViewItem.SubItems[1].Text.ToInt(-1));
                        PurchaseDetails purchaseDetails = Purchases.Find(x => x.PurchaseItem.ItemId == item.Id);

                        int[] ids = { purchaseDetails.PurchaseItem.Id };
                        List<PurchaseItem> purchaseItem = new List<PurchaseItem>() { new PurchaseItem(ids[0], -1, -1, -1, -1) };
                        item.Stocks += purchaseDetails.PurchaseItem.Quantity;

                        if (PurchaseItemManager.Delete(purchaseItem) && ItemManager.Update(item))
                        {
                            Purchases.Remove(purchaseDetails);
                            textBoxTotal.Text = ComputeTotalPrice().ToString();
                            LoadData();
                        }
                        else
                        {
                            failures.Add(item.Name);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.log.Error(ex.ToString());
                    }
                }

                if (failures.Count > 0)
                {
                    string items = "";

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

        private void CheckoutButton_Click(object sender, EventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                if (ComputeTotalPrice() > 0)
                {
                    Purchase.Status = "Purchased";
                    Purchase.Date = DateTime.Now.ToString();
                    Purchase.Total = ComputeTotalPrice();

                    if (PurchaseManager.Update(Purchase))
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

        private void CartForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ComputeTotalPrice() <= 0)
            {
                List<Purchase> purchases = new List<Purchase>() { new Purchase(Purchase.Id, -1, null, null, -1) };

                if (!PurchaseManager.Delete(purchases))
                {
                    Logger.log.Error($"A pending purchase with id {Purchase.Id} can't be deleted.");
                }
            }

            IForm profileForm = Application.OpenForms.OfType<ProfileForm>().FirstOrDefault();
            ((ProfileForm)profileForm).LoadData();
            ((ProfileForm)profileForm).EnableNewPurchaseButton(true);
        }
    }
}
