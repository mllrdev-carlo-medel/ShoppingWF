using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Forms.Interfaces;
using ShoppingCart.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class ProfileForm : Form, IProfileForm
    {

        public IManager<Customer> CustomerManager { get; } = new CustomerManager();
        public IManager<Item> ItemManager { get; } = new ItemManager();
        public IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();
        public IManager<Purchase> PurchaseManager { get; } = new PurchaseManager();

        public BindingSource PurchaseHistoryBS { get; } = new BindingSource();

        public CustomerDetails Customer { get; }

        public ProfileForm(Customer customer)
        {
            InitializeComponent();

            purchaseHistoryGridView.AutoGenerateColumns = true;
            purchaseItemsGridView.AutoGenerateColumns = true;

            purchaseItemsGridView.ColumnCount = 5;
            purchaseItemsGridView.Columns[0].Name = "Barcode";
            purchaseItemsGridView.Columns[1].Name = "Name";
            purchaseItemsGridView.Columns[2].Name = "Price";
            purchaseItemsGridView.Columns[3].Name = "Quantity";
            purchaseItemsGridView.Columns[4].Name = "Subtotal";

            Customer = new CustomerDetails(customer);

            textBoxId.Text = $"{Customer.Info.Id}";
            textBoxName.Text = $"{Customer.Info.FirstName} {Customer.Info.MiddleName} {Customer.Info.LastName}";
            textBoxAddress.Text = $"{Customer.Info.Address}";
            textBoxGender.Text = $"{Customer.Info.Gender}";
            textBoxPhone.Text = $"{Customer.Info.ContactNo}";
            textBoxEmail.Text = $"{Customer.Info.Email}";

            LoadData();
        }

        public void LoadData()
        {
            Customer.PurchaseHistory.Clear();
            purchaseHistoryGridView.Rows.Clear();

            foreach (Purchase purchase in PurchaseManager.GetAllById(Customer.Info.Id, "CustomerId"))
            {
                Customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
            }

            foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory)
            {
                foreach (PurchaseItem purchaseItem in PurchaseItemManager.GetAllById(purchaseHistory.Purchase.Id, "PurchaseId"))
                {
                    purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, ItemManager.GetById(purchaseItem.ItemId, "Id")));
                }
            }

            PurchaseHistoryBS.DataSource = typeof(Purchase);

            foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory)
            {
                PurchaseHistoryBS.Add(purchaseHistory.Purchase);
            }

            purchaseHistoryGridView.DataSource = PurchaseHistoryBS;
        }

        public void EnableNewPurchaseButton (bool value)
        {
            newPurchaseButton.Enabled = value;
        }

        private void PurchaseHistoryGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = purchaseHistoryGridView.Rows[e.RowIndex].Cells[0].Value.ToString().ToInt(-1);
                purchaseItemsGridView.Rows.Clear();
                PurchaseHistory purchaseHistory = Customer.PurchaseHistory.Find(x => x.Purchase.Id == id);

                foreach (PurchaseDetails purchaseDetails in purchaseHistory.PurchaseDetails)
                {
                    purchaseItemsGridView.Rows.Add($"{purchaseDetails.Item.Id}", $"{purchaseDetails.Item.Name}", $"{purchaseDetails.Item.Price}",
                                                   $"{purchaseDetails.PurchaseItem.Quantity}", $"{purchaseDetails.PurchaseItem.SubTotal}");
                }
            }
            catch (Exception ex)
            {
                Logging.log.Error(ex.ToString());
            }
        }

        private void NewPurchaseButton_Click(object sender, EventArgs e)
        {
            PurchaseHistory purchaseHistory = Customer.PurchaseHistory.Find(x => x.Purchase.Status == "Pending");
            Purchase purchase;

            if (purchaseHistory == null)
            {
                purchase = new Purchase(GenerateID.GetGeneratedID(), Customer.Info.Id, "Pending", DateTime.Now.ToString(), 0);

                if (PurchaseManager.Add(purchase))
                {
                    LoadData();
                    EnableNewPurchaseButton(false);
                    IForm cartForm = new CartForm(new List<PurchaseDetails>(), purchase);
                    ((CartForm)cartForm).Show();
                }
                else 
                {
                    string message = "Can't create new purchase.";
                    string caption = "Please try again.";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            else
            {
                string message = "You have a pending purchase. Would you like to restore it? Selecting no will delete that purchase.";
                string caption = "";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    purchase = purchaseHistory.Purchase;
                    EnableNewPurchaseButton(false);
                    IForm cartForm = new CartForm(purchaseHistory.PurchaseDetails, purchase);
                    ((CartForm)cartForm).Show();
                }
                else
                {
                    int[] ids = { purchaseHistory.Purchase.Id };

                    PurchaseItemManager.Delete(ids, "PurchaseId");
                    PurchaseManager.Delete(ids, "Id");
                    LoadData();
                    
                    purchase = new Purchase(GenerateID.GetGeneratedID(), Customer.Info.Id, "Pending", DateTime.Now.ToString(), 0);

                    if (PurchaseManager.Add(purchase))
                    {
                        LoadData();
                        EnableNewPurchaseButton(false);
                        IForm cartForm = new CartForm(new List<PurchaseDetails>(), purchase);
                        ((CartForm)cartForm).Show();
                    }
                    else
                    {
                        message = "Can't create new purchase.";
                        caption = "Please try again.";
                        result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void ProfileForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.OpenForms.OfType<CartForm>().Count() > 0)
            {
                e.Cancel = true;
                string message = "you have a pending purchase.";
                string caption = "Please checkout/close your cart first.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                IForm logInForm = (LogInForm)Application.OpenForms["LogInForm"];
                ((LogInForm)logInForm).EnableButtons(true);
            }
        }
    }
}
