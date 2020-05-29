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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();   
        }

        private void CustomerMenu_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();

            if (Application.OpenForms.OfType<ProfileForm>().FirstOrDefault() != null)
            {
                customerForm.EnableButtons(false);
            }    

            customerForm.Dock = DockStyle.Right;
            customerForm.MdiParent = this;
            customerForm.TopLevel = false;
            customerForm.Closed += CustomerForm_Closed;
            EnableCustomerMenu(false);
            customerForm.Show();
        }

        public void EnableCustomerMenu(bool value)
        {
            customerMenu.Enabled = value;
        }

        private void CustomerForm_Closed(object sender, EventArgs e)
        {
            EnableCustomerMenu(true);
        }

        private void ItemsMenu_Click(object sender, EventArgs e)
        {
            AddItemsForm addItemForm = new AddItemsForm();
            addItemForm.MdiParent = this;
            addItemForm.Closed += AddItemForm_Closed;

            if (Application.OpenForms.OfType<ProfileForm>().FirstOrDefault() != null)
            {
                string caption = string.Empty;
                string message = "Please close profile first.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                addItemForm.Show();
                itemsMenu.Enabled = false;
            }
        }

        private void AddItemForm_Closed(object sender, EventArgs e)
        {
            itemsMenu.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Dock = DockStyle.Right;
            customerForm.MdiParent = this;
            customerForm.TopLevel = false;
            customerForm.Closed += CustomerForm_Closed;
            customerMenu.Enabled = false;
            customerForm.Show();
        }

        private void PurchasesMenu_Click(object sender, EventArgs e)
        {
            PurchaseHistoryForm purchaseHistoryForm = new PurchaseHistoryForm();
            purchaseHistoryForm.MdiParent = this;
            purchasesMenu.Enabled = false;
            purchaseHistoryForm.Closed += PurchaseHistoryForm_Closed;
            purchaseHistoryForm.Show();
        }

        private void PurchaseHistoryForm_Closed(object sender, EventArgs e)
        {
            purchasesMenu.Enabled = true;
        }
    }
}
