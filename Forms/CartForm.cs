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

namespace ShoppingCart.Forms
{
    public partial class CartForm : Form
    {
        private readonly BindingSource bindingSource = new BindingSource();

        public IManager<Item> ItemManager { get; } = new ItemManager();
        public IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();

        public IManager<Purchase> PurchaseManager { get; } = new PurchaseManager();

        public Purchase Purchase { get; set; }
        public List<PurchaseDetails> Purchases { get; }

        public CartForm(List<PurchaseDetails> purchaseDetails, Purchase purchase)
        {
            InitializeComponent();

            Purchases = purchaseDetails;
            Purchase = purchase;

            bindingSource.DataSource = typeof(Item);

            foreach (Item item in ItemManager.GetAll())
            {
                bindingSource.Add(item);
            }

            itemsGridView.DataSource = bindingSource;

            itemsGridView.AutoGenerateColumns = true;
            cartGridView.AutoGenerateColumns = true;

            cartGridView.ColumnCount = 5;
            cartGridView.Columns[0].Name = "Barcode";
            cartGridView.Columns[1].Name = "Name";
            cartGridView.Columns[2].Name = "Price";
            cartGridView.Columns[3].Name = "Quantity";
            cartGridView.Columns[4].Name = "Subtotal";

            LoadData();
        }

        public void LoadData()
        {
            cartGridView.Rows.Clear();

            foreach (PurchaseDetails purchaseDetails in Purchases)
            {
                cartGridView.Rows.Add($"{purchaseDetails.Item.Id}", $"{purchaseDetails.Item.Name}", $"{purchaseDetails.Item.Price}",
                                               $"{purchaseDetails.PurchaseItem.Quantity}", $"{purchaseDetails.PurchaseItem.SubTotal}");
            }

            cartGridView.Rows[0].Selected = true;

            try
            {
                textBoxName.Text = cartGridView.SelectedRows[0].Cells[1].Value.ToString();
                textBoxPrice.Text = cartGridView.SelectedRows[0].Cells[2].Value.ToString();
                textBoxQuantity.Text = cartGridView.SelectedRows[0].Cells[3].Value.ToString();
                textBoxSubtotal.Text = cartGridView.SelectedRows[0].Cells[4].Value.ToString();
            }
            catch (Exception e)
            {
                textBoxName.Text = "";
                textBoxPrice.Text = "";
                textBoxQuantity.Text = "";
                textBoxSubtotal.Text = "";
                Logging.log.Info($"No items in cart yet.\n {e}");
            }

            textBoxTotal.Text = ComputeTotalPrice().ToString();
        }

        public float ComputeTotalPrice()
        {
            float total = Purchases.Sum(x => x.PurchaseItem.SubTotal);
            return total;
        }

        private void CartGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxName.Text = cartGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBoxPrice.Text = cartGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBoxQuantity.Text = cartGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBoxSubtotal.Text = cartGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (itemsGridView.SelectedCells.Count > 0)
            {
                Item item = ItemManager.GetById(itemsGridView.SelectedRows[0].Cells[0].Value.ToString().ToInt(-1), "Id");

                PurchaseDetails purchaseDetails = null;

                try
                {
                    purchaseDetails = Purchases.Find(x => x.Item.Id == item.Id);
                }
                catch (Exception ex)
                {
                    Logging.log.Error(ex);
                }

                if (purchaseDetails != null)
                {
                    string caption = "Item already in cart.";
                    string message = "Please select another item.";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                else
                {
                    PurchaseItem purchaseItem = new PurchaseItem(GenerateID.GetGeneratedID(), Purchase.Id, item.Id, 1, item.Price);

                    if (PurchaseItemManager.Add(purchaseItem))
                    {
                        Purchases.Add(new PurchaseDetails(purchaseItem, item));
                        textBoxTotal.Text = ComputeTotalPrice().ToString();
                        LoadData();
                    }
                    else
                    {
                        string caption = "Can't add item.";
                        string message = "Please try again.";
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                string caption = "No item selected.";
                string message = "Please select an item to be added in your cart.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (cartGridView.SelectedRows.Count > 0)
            {
                try
                {
                    Item item = ItemManager.GetById(cartGridView.SelectedRows[0].Cells[0].Value.ToString().ToInt(-1), "Id");
                    int index = Purchases.FindIndex(x => x.PurchaseItem.ItemId == item.Id);

                    using (TransactionScope scope = new TransactionScope())
                    {
                        int quantity = textBoxQuantity.Text.ToInt(-1);

                        if (quantity > 0)
                        {
                            Purchases[index].PurchaseItem.Quantity = quantity;
                            Purchases[index].PurchaseItem.SubTotal = quantity * item.Price;

                            if (!PurchaseItemManager.Update(Purchases[index].PurchaseItem))
                            {
                                string message = "Can't update item.";
                                string caption = "Please try again.";
                                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);

                                return;
                            }
                        }
                        else
                        {
                            string caption = "Please try again.";
                            string message = "Can't update item for that value.";
                            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }

                        textBoxTotal.Text = ComputeTotalPrice().ToString();
                        LoadData();
                        scope.Complete();
                    }
                }
                catch (Exception ex)
                {
                    Logging.log.Error(ex.ToString());
                }
            }
            else
            {
                string caption = "";
                string message = "Please select an item in your cart.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (cartGridView.SelectedCells.Count > 0)
            {
                try
                {
                    Item item = ItemManager.GetById(cartGridView.SelectedRows[0].Cells[0].Value.ToString().ToInt(-1), "Id");
                    int index = Purchases.FindIndex(x => x.PurchaseItem.ItemId == item.Id);
                    int[] ids = { Purchases[index].PurchaseItem.Id };

                    if (PurchaseItemManager.Delete(ids, "Id"))
                    {
                        Purchases.RemoveAt(index);
                        textBoxTotal.Text = ComputeTotalPrice().ToString();
                        LoadData();
                    }
                    else
                    {
                        string message = "Can't remove item.";
                        string caption = "Please try again.";
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
                catch(Exception ex)
                {
                    Logging.log.Error(ex.ToString());
                }
            }
            else
            {
                string caption = "";
                string message = "Please select an item in your cart.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
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
                        this.Close();
                    }
                    else
                    {
                        string caption = "Can't proceed.";
                        string message = "Please try again.";
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        return;
                    }
                }
                else
                {
                    string message = "Please add items to your cart.";
                    string caption = "Empty cart";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }

                scope.Complete();
            }
        }

        private void CartForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProfileForm profileForm = (ProfileForm)Application.OpenForms["ProfileForm"];
            profileForm.LoadData();
            profileForm.EnableNewPurchaseButton(true);
        }
    }
}
