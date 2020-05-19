using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Extensions;
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
    public partial class PurchaseHistoryForm : Form
    {
        private readonly IManager<Purchase> _purchaseManager = new PurchaseManager();
        private readonly IManager<Customer> _customerManager = new CustomerManager();

        public PurchaseHistoryForm()
        {
            InitializeComponent();
        }

        private void PurchaseHostoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                purchaseListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (Purchase purchase in _purchaseManager.GetAll().OrderByDescending(x => DateTime.Parse(x.Date)))
                {
                    Customer customer = _customerManager.GetById(purchase.CustomerId);

                    listViewItems.Add(new ListViewItem(new[] {$"{customer.FirstName} {customer.MiddleName} {customer.LastName}",
                                                              purchase.CustomerId.ToString(),
                                                              purchase.Id.ToString(),
                                                              purchase.Status,
                                                              purchase.Date,
                                                              purchase.Total.ToString()}));
                }

                purchaseListView.Items.AddRange(listViewItems.ToArray());

            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void PurchaseHistoryListView_DoubleClick(object sender, System.EventArgs e)
        {
            if (purchaseListView.SelectedItems.Count > 0)
            {
                int id = purchaseListView.SelectedItems[0].SubItems[1].Text.ToInt(-1);
                CustomerForm customerForm = Application.OpenForms.OfType<CustomerForm>().FirstOrDefault();

                if (customerForm != null)
                {
                    customerForm.EnableButtons(false);
                }

                ProfileForm profileForm = Application.OpenForms.OfType<ProfileForm>().FirstOrDefault();

                if (profileForm == null)
                {
                    ProfileForm profileNewForm = new ProfileForm(id);
                    profileNewForm.MdiParent = this.ParentForm;
                    profileNewForm.Show();
                    this.Close();
                }
                else
                {
                    string caption = "Error.";
                    string message = "Please close the current profile.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
        }
    }
}
