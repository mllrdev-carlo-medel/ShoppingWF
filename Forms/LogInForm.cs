using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using ShoppingCart.Helper;
using ShoppingCart.Forms.Interfaces;
using System;
using System.Linq;

namespace ShoppingCart.Forms
{
    public partial class LogInForm : Form, ILogInForm
    {
        private IManager<Customer> Manager { get; } = new CustomerManager();

        public LogInForm()
        {
            InitializeComponent();
            LoadData();  
        }

        public void LoadData()
        {
            customerListView.Items.Clear();

            foreach (Customer customer in Manager.GetAll())
            {
                customerListView.Items.Add(new ListViewItem(new[] {customer.Id.ToString(),
                                                                   $"{customer.FirstName} {customer.MiddleName} {customer.LastName}",
                                                                   customer.Address}));
            }
        }

        public void EnableButtons (bool value)
        {
            confirmButton.Enabled = value;
            signUpButton.Enabled = value;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            int id = textBoxMemberId.Text.ToInt(-1);
            Customer customer = Manager.GetById(id);

            if (customer == null)
            {
                string message = "Entered ID can't be found.";
                string caption = "Please try again."; 
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                EnableButtons(false);
                IForm profileForm = new ProfileForm(id);
                ((ProfileForm)profileForm).MdiParent = this.ParentForm;
                ((ProfileForm)profileForm).Show();
            }
        }

        private void SignUpButton_Click(object sender, System.EventArgs e)
        {
            EnableButtons(false);
            IForm signUpForm = new SignUpForm();
            ((SignUpForm)signUpForm).MdiParent = this.ParentForm;
            ((SignUpForm)signUpForm).Show();
        }

        private void CustomerListView_Click(object sender, System.EventArgs e)
        {
            if (customerListView.SelectedItems.Count > 0)
            {
                textBoxMemberId.Text = customerListView.SelectedItems[0].Text;
            }
        }

        private void TextBoxSearch_TextChanged(object sender, System.EventArgs e)
        {
            string searchString = textBoxSearch.Text;

            if (string.IsNullOrEmpty(searchString))
            {
                LoadData();
            }
            else
            {
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (Customer customer in Manager.GetAll())
                {
                    string name = $"{customer.FirstName} {customer.MiddleName} {customer.LastName}";

                    if (name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                        customer.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    {
                        listViewItems.Add(new ListViewItem(new[] {customer.Id.ToString(),
                                                                   $"{customer.FirstName} {customer.MiddleName} {customer.LastName}",
                                                                   customer.Address}));
                    }
                }

                if (listViewItems.Count > 0)
                {
                    customerListView.Items.Clear();

                    foreach (ListViewItem item in listViewItems)
                    {
                        customerListView.Items.Add(item);
                    }
                }
                else
                {
                    customerListView.Items.Clear();
                }
            }
        }
    }
}