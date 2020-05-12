using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using ShoppingCart.Extensions;
using System;
using System.Linq;
using ShoppingCart.Business.Log;

namespace ShoppingCart.Forms
{
    public partial class CustomerForm : Form
    {
        private readonly IManager<Customer> _manager = new CustomerManager();

        public CustomerForm()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            try
            {
                customerListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (Customer customer in _manager.GetAll())
                {
                    listViewItems.Add(new ListViewItem(new[] {customer.Id.ToString(),
                                                          $"{customer.FirstName} {customer.MiddleName} {customer.LastName}",
                                                          customer.Address}));
                }

                customerListView.Items.AddRange(listViewItems.ToArray());
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        public void EnableButtons (bool value)
        {
            confirmButton.Enabled = value;
            signUpButton.Enabled = value;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            try
            {
                int id = textBoxMemberId.Text.ToInt(-1);
                Customer customer = _manager.GetById(id);

                if (customer == null)
                {
                    string message = "Entered ID can't be found.";
                    string caption = "Please try again.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                else
                {
                    EnableButtons(false);
                    ProfileForm profileForm = new ProfileForm(id);
                    profileForm.MdiParent = this.ParentForm;
                    profileForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void SignUpButton_Click(object sender, System.EventArgs e)
        {
            EnableButtons(false);
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.MdiParent = this.ParentForm;
            signUpForm.Show();
        }

        private void CustomerListView_Click(object sender, System.EventArgs e)
        {
            if (customerListView.SelectedItems.Count > 0)
            {
                textBoxMemberId.Text = customerListView.SelectedItems[0].Text;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                string searchName = textBoxSearchName.Text;
                string searchAddress = textBoxSearchAddress.Text;

                if (!string.IsNullOrWhiteSpace(searchName) || !string.IsNullOrWhiteSpace(searchAddress))
                {
                    List<ListViewItem> listViewItems = new List<ListViewItem>();

                    foreach (Customer customer in _manager.GetAll())
                    {
                        string name = $"{customer.FirstName} {customer.MiddleName} {customer.LastName}";

                        if (name.Contains(searchName, StringComparison.OrdinalIgnoreCase) &&
                            customer.Address.Contains(searchAddress, StringComparison.OrdinalIgnoreCase))
                        {
                            listViewItems.Add(new ListViewItem(new[] {customer.Id.ToString(),
                                                                   $"{customer.FirstName} {customer.MiddleName} {customer.LastName}",
                                                                   customer.Address}));
                        }
                    }

                    if (listViewItems.Count > 0)
                    {
                        customerListView.Items.Clear();
                        customerListView.Items.AddRange(listViewItems.ToArray());
                    }
                    else
                    {
                        string message = "Can't find search.";
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
            LoadData();
            textBoxSearchName.Text = string.Empty;
            textBoxSearchAddress.Text = string.Empty;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}