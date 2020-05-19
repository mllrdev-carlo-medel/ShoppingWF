using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Constants;
using ShoppingCart.Factory;
using ShoppingCart.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class ProfileForm : Form
    {
        private readonly int _id;
        private readonly IManager<Customer> _customerManager = new CustomerManager();
        private readonly IManager<Item> _itemManager = new ItemManager();
        private readonly IManager<PurchaseItem> _purchaseItemManager = new PurchaseItemManager();
        private readonly IManager<Purchase> _purchaseManager = new PurchaseManager();

        private CustomerDetails _customer;

        public ProfileForm(int id)
        {
            InitializeComponent();
            _id = id;
        }
  
        public void LoadData()
        {
            try
            {
                _customer = CustomerFactory.GetCustomer(_id);

                if (_customer == null)
                {
                    string message = "Can't find the customer details.";
                    string caption = "Error.";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    this.Close();
                }

                textBoxName.Text = $"{_customer.Info.FirstName} {_customer.Info.MiddleName} {_customer.Info.LastName}";
                textBoxAddress.Text = $"{_customer.Info.Address}";
                textBoxGender.Text = $"{_customer.Info.Gender}";
                textBoxPhone.Text = $"{_customer.Info.ContactNo}";
                textBoxEmail.Text = $"{_customer.Info.Email}";

                historyListView.Items.Clear();
                itemListView.Items.Clear();

                List<ListViewItem> listViewItems = new List<ListViewItem>();

                foreach (PurchaseHistory purchaseHistory in _customer.PurchaseHistory.OrderByDescending(x => DateTime.Parse(x.Purchase.Date)))
                {
                    listViewItems.Add(new ListViewItem(new[] { purchaseHistory.Purchase.Id.ToString(),
                                                          purchaseHistory.Purchase.CustomerId.ToString(),
                                                          purchaseHistory.Purchase.Status,
                                                          purchaseHistory.Purchase.Date,
                                                          purchaseHistory.Purchase.Total.ToString()}));
                }

                historyListView.Items.AddRange(listViewItems.ToArray());
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        public void EnableNewPurchaseButton(bool value)
        {
            newPurchaseButton.Enabled = value;
            deleteButton.Enabled = value;
        }

        private void HistoryListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = historyListView.SelectedItems[0].Text.ToInt(-1);
                itemListView.Items.Clear();
                List<ListViewItem> listViewItems = new List<ListViewItem>();
                PurchaseHistory purchaseHistory = _customer.PurchaseHistory.Find(x => x.Purchase.Id == id);

                foreach (PurchaseDetails purchaseDetails in purchaseHistory.PurchaseDetails)
                {
                    listViewItems.Add(new ListViewItem(new[] { purchaseDetails.PurchaseItem.ItemId.ToString(),
                                                               purchaseDetails.Name,
                                                               purchaseDetails.Price.ToString(),
                                                               purchaseDetails.PurchaseItem.Quantity.ToString(),
                                                               purchaseDetails.PurchaseItem.SubTotal.ToString()}));
                }

                itemListView.Items.AddRange(listViewItems.ToArray());
            }
            catch (Exception ex)
            {
                itemListView.Items.Clear();
                Logger.log.Error(ex.ToString());
            }
        }

        private void NewPurchaseButton_Click(object sender, EventArgs e)
        {
            try
            {
                PurchaseHistory purchaseHistory = _customer.PurchaseHistory.Find(x => x.Purchase.Status == ProfileStringConstants.PENDING.FirstCharToUpper());
                Purchase purchase;

                if (purchaseHistory == null)
                {
                    purchase = new Purchase(PrimaryId.GetGeneratedID(), _customer.Info.Id, ProfileStringConstants.PENDING.FirstCharToUpper(), DateTime.Now.ToString(), 0);

                    if (_purchaseManager.Add(purchase))
                    {
                        LoadData();
                        EnableNewPurchaseButton(false);
                        CartForm cartForm = new CartForm(_customer.PurchaseHistory.Find(x => x.Purchase.Id == purchase.Id).PurchaseDetails, purchase);
                        cartForm.MdiParent = this.ParentForm;
                        cartForm.Show();
                    }
                    else
                    {
                        string message = "Can't create new purchase.";
                        string caption = "Please try again.";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    string message = "You have a pending purchase. Would you like to restore it? Selecting no will delete that purchase.";
                    string caption = string.Empty;
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        purchase = purchaseHistory.Purchase;
                        EnableNewPurchaseButton(false);
                        CartForm cartForm = new CartForm(purchaseHistory.PurchaseDetails, purchase);
                        cartForm.MdiParent = this.ParentForm;
                        cartForm.Show();
                    }
                    else
                    {
                        int[] ids = { purchaseHistory.Purchase.Id };
                        List<PurchaseItem> purchaseItemDel = new List<PurchaseItem>() { new PurchaseItem { PurchaseId = ids[0] } };
                        List<Purchase> purchaseDel = new List<Purchase>() { new Purchase { Id = ids[0] } };

                        List<PurchaseItem> purchaseItems = _purchaseItemManager.GetAllWhere(purchaseItemDel[0]);

                        if (purchaseItems.Count > 0)
                        {
                            if (_customer.PurchaseHistory.Find(x => x.Purchase.Id == ids[0]).Purchase.Status == ProfileStringConstants.PENDING.FirstCharToUpper())
                            {
                                foreach (PurchaseItem purchaseItem in purchaseItems)
                                {
                                    Item item = _itemManager.GetById(purchaseItem.ItemId);
                                    item.Stocks += purchaseItem.Quantity;
                                    _itemManager.Update(item);
                                }
                            }

                            _purchaseItemManager.Delete(purchaseItemDel);
                        }

                        if (_purchaseManager.Delete(purchaseDel))
                        {
                            LoadData();
                            purchase = new Purchase(PrimaryId.GetGeneratedID(), _customer.Info.Id, ProfileStringConstants.PENDING.FirstCharToUpper(), DateTime.Now.ToString(), 0);

                            if (_purchaseManager.Add(purchase))
                            {
                                LoadData();
                                EnableNewPurchaseButton(false);
                                CartForm cartForm = new CartForm(_customer.PurchaseHistory.Find(x => x.Purchase.Id == purchase.Id).PurchaseDetails, purchase);
                                cartForm.MdiParent = this.ParentForm;
                                cartForm.Show();
                            }
                            else
                            {
                                message = "Can't create new purchase.";
                                caption = "Please try again.";
                                result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            message = "Can't delete.";
                            caption = "Please try again.";
                            result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (historyListView.SelectedItems.Count > 0)
                {
                    int[] ids = { historyListView.SelectedItems[0].Text.ToInt(-1) };

                    if (ids[0] >= 0)
                    {
                        List<PurchaseItem> purchaseItemDel = new List<PurchaseItem>() { new PurchaseItem { PurchaseId = ids[0] } };
                        List<Purchase> purchaseDel = new List<Purchase>() { new Purchase { Id = ids[0] } };

                        using (TransactionScope scope = new TransactionScope())
                        {
                            List<PurchaseItem> purchaseItems = _purchaseItemManager.GetAllWhere(purchaseItemDel[0]);

                            if (purchaseItems.Count > 0)
                            {
                                if (_customer.PurchaseHistory.Find(x => x.Purchase.Id == ids[0]).Purchase.Status == ProfileStringConstants.PENDING.FirstCharToUpper())
                                {
                                    foreach (PurchaseItem purchaseItem in purchaseItems)
                                    {
                                        Item item = _itemManager.GetById(purchaseItem.ItemId);
                                        item.Stocks += purchaseItem.Quantity;
                                        _itemManager.Update(item);
                                    }
                                }

                                _purchaseItemManager.Delete(purchaseItemDel);
                            }

                            if (_purchaseManager.Delete(purchaseDel))
                            {
                                LoadData();
                                scope.Complete();
                            }
                            else
                            {
                                string message = "Can't delete. Please try again.";
                                string caption = "Error";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        string message = "Can't delete. Please try again.";
                        string caption = "Error";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
                else
                {
                    string message = "Please select a purchase history first.";
                    string caption = "Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditProfileButton.Text.Equals(ProfileStringConstants.EDIT_PROFILE, StringComparison.OrdinalIgnoreCase))
                {
                    EditProfileButton.Text = ProfileStringConstants.SAVE_BUTTON.FirstCharToUpper();
                    textBoxName.ReadOnly = false;
                    textBoxAddress.ReadOnly = false;
                    textBoxEmail.ReadOnly = false;
                    textBoxPhone.ReadOnly = false;
                }
                else
                {
                    string[] name = textBoxName.Text.Split(' ');

                    if (name.Length == 3 && !string.IsNullOrWhiteSpace(name[0]) && !string.IsNullOrWhiteSpace(name[2]))
                    {
                        using (TransactionScope scope = new TransactionScope())
                        {
                            _customer.Info.FirstName = name[0];
                            _customer.Info.MiddleName = name[1];
                            _customer.Info.LastName = name[2];
                            _customer.Info.Address = textBoxAddress.Text;
                            _customer.Info.Email = textBoxEmail.Text;
                            _customer.Info.ContactNo = textBoxPhone.Text;

                            if (_customerManager.Update(_customer.Info))
                            {
                                CustomerForm logInForm = Application.OpenForms.OfType<CustomerForm>().FirstOrDefault();
                                logInForm.LoadData();
                                scope.Complete();
                            }
                            else
                            {
                                string message = "Can't update profile. Please try again.";
                                string caption = "Error";
                                MessageBox.Show(message, caption, MessageBoxButtons.OK);
                            }
                        }
                    }
                    else
                    {
                        string message = "Entered Name should follow format \"firstname middlename lastname\"";
                        string caption = "Error";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }

                    EditProfileButton.Text = ProfileStringConstants.EDIT_PROFILE.FirstCharToUpper();
                    textBoxName.ReadOnly = true;
                    textBoxAddress.ReadOnly = true;
                    textBoxEmail.ReadOnly = true;
                    textBoxPhone.ReadOnly = true;
                }

                LoadData();
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void ProfileForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Application.OpenForms.OfType<CartForm>().Count() > 0)
            {
                e.Cancel = true;
                string message = "You have a pending purchase.";
                string caption = "Please checkout/close your cart first.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                CustomerForm logInForm = Application.OpenForms.OfType<CustomerForm>().FirstOrDefault();
                logInForm.EnableButtons(true);
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
