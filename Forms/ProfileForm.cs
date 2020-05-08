using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Log;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Business.Model;
using ShoppingCart.Forms.Interfaces;
using ShoppingCart.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class ProfileForm : Form, IProfileForm
    {
        private readonly string saveButton = "Save";
        private readonly string editButton = "Edit Profile";
        private readonly string pending = "Pending";

        private int Id { get; }
        private IManager<Customer> CustomerManager { get; } = new CustomerManager();
        private IManager<Item> ItemManager { get; } = new ItemManager();
        private IManager<PurchaseItem> PurchaseItemManager { get; } = new PurchaseItemManager();
        private IManager<Purchase> PurchaseManager { get; } = new PurchaseManager();

        private CustomerDetails Customer { get; set; }

        public ProfileForm(int id)
        {
            InitializeComponent();
            Id = id;
            LoadData();
        }

        public void LoadData()
        {
            Customer = new CustomerDetails(CustomerManager.GetById(Id));
            textBoxName.Text = $"{Customer.Info.FirstName} {Customer.Info.MiddleName} {Customer.Info.LastName}";
            textBoxAddress.Text = $"{Customer.Info.Address}";
            textBoxGender.Text = $"{Customer.Info.Gender}";
            textBoxPhone.Text = $"{Customer.Info.ContactNo}";
            textBoxEmail.Text = $"{Customer.Info.Email}";

            Customer.PurchaseHistory.Clear();
            historyListView.Items.Clear();
            itemListView.Items.Clear();

            Purchase conditionPurchase = new Purchase(-1, Customer.Info.Id, null, null, -1);
            PurchaseItem conditionPurchaseItem = new PurchaseItem(-1, -1, -1, -1, -1);

            foreach (Purchase purchase in PurchaseManager.GetAllWhere(conditionPurchase))
            {
                Customer.PurchaseHistory.Add(new PurchaseHistory(purchase));
            }

            foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory)
            {
                conditionPurchaseItem.PurchaseId = purchaseHistory.Purchase.Id;

                foreach (PurchaseItem purchaseItem in PurchaseItemManager.GetAllWhere(conditionPurchaseItem))
                {
                    purchaseHistory.PurchaseDetails.Add(new PurchaseDetails(purchaseItem, ItemManager.GetById(purchaseItem.ItemId)));
                }
            }

            foreach (PurchaseHistory purchaseHistory in Customer.PurchaseHistory.OrderByDescending (x => DateTime.Parse(x.Purchase.Date)))
            {
               historyListView.Items.Add(new ListViewItem(new[] { purchaseHistory.Purchase.Id.ToString(),
                                                                  purchaseHistory.Purchase.CustomerId.ToString(),
                                                                  purchaseHistory.Purchase.Status,
                                                                  purchaseHistory.Purchase.Date,
                                                                  purchaseHistory.Purchase.Total.ToString()}));
            }
        }

        public void EnableNewPurchaseButton(bool value)
        {
            newPurchaseButton.Enabled = value;
            deleteButton.Enabled = value;
        }

        private void historyListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int id = historyListView.SelectedItems[0].Text.ToInt(-1);
                itemListView.Items.Clear();
                PurchaseHistory purchaseHistory = Customer.PurchaseHistory.Find(x => x.Purchase.Id == id);

                foreach (PurchaseDetails purchaseDetails in purchaseHistory.PurchaseDetails)
                {
                    itemListView.Items.Add(new ListViewItem(new[] { purchaseDetails.PurchaseItem.ItemId.ToString(),
                                                                    purchaseDetails.Name,
                                                                    purchaseDetails.Price.ToString(),
                                                                    purchaseDetails.PurchaseItem.Quantity.ToString(),
                                                                    purchaseDetails.PurchaseItem.SubTotal.ToString()}));
                }
            }
            catch (Exception ex)
            {
                itemListView.Items.Clear();
                Logger.log.Error(ex.ToString());
            }
        }

        private void NewPurchaseButton_Click(object sender, EventArgs e)
        {
            PurchaseHistory purchaseHistory = Customer.PurchaseHistory.Find(x => x.Purchase.Status == pending);
            Purchase purchase;

            if (purchaseHistory == null)
            {
                purchase = new Purchase(GenerateID.GetGeneratedID(), Customer.Info.Id, pending, DateTime.Now.ToString(), 0);
               
                if (PurchaseManager.Add(purchase))
                {
                    LoadData();
                    EnableNewPurchaseButton(false);
                    IForm cartForm = new CartForm(Customer.PurchaseHistory.Find(x => x.Purchase.Id == purchase.Id).PurchaseDetails, purchase);
                    ((CartForm)cartForm).MdiParent = this.ParentForm;
                    ((CartForm)cartForm).Show();
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
                string caption = "";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    purchase = purchaseHistory.Purchase;
                    EnableNewPurchaseButton(false);
                    IForm cartForm = new CartForm(purchaseHistory.PurchaseDetails, purchase);
                    ((CartForm)cartForm).MdiParent = this.ParentForm;
                    ((CartForm)cartForm).Show();
                }
                else
                {
                    int[] ids = { purchaseHistory.Purchase.Id };
                    List<PurchaseItem> purchaseItemDel = new List<PurchaseItem>() { new PurchaseItem(-1, ids[0], -1, -1, -1) };
                    List<Purchase> purchaseDel = new List<Purchase>() { new Purchase(ids[0], -1, null, null, -1) };

                    List<PurchaseItem> purchaseItems = PurchaseItemManager.GetAllWhere(purchaseItemDel[0]);

                    if (purchaseItems.Count > 0)
                    {
                        if (Customer.PurchaseHistory.Find(x => x.Purchase.Id == ids[0]).Purchase.Status == pending)
                        {
                            foreach (PurchaseItem purchaseItem in purchaseItems)
                            {
                                Item item = ItemManager.GetById(purchaseItem.ItemId);
                                item.Stocks += purchaseItem.Quantity;
                                ItemManager.Update(item);
                            }
                        }

                        PurchaseItemManager.Delete(purchaseItemDel);
                    }

                    if (PurchaseManager.Delete(purchaseDel))
                    {
                        LoadData();
                        purchase = new Purchase(GenerateID.GetGeneratedID(), Customer.Info.Id, pending, DateTime.Now.ToString(), 0);

                        if (PurchaseManager.Add(purchase))
                        {
                            LoadData();
                            EnableNewPurchaseButton(false);
                            IForm cartForm = new CartForm(Customer.PurchaseHistory.Find(x => x.Purchase.Id == purchase.Id).PurchaseDetails, purchase);
                            ((CartForm)cartForm).MdiParent = this.ParentForm;
                            ((CartForm)cartForm).Show();
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

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (historyListView.SelectedItems.Count > 0)
            {
                int[] ids = { historyListView.SelectedItems[0].Text.ToInt(-1) };

                if (ids[0] >= 0)
                {
                    List<PurchaseItem> purchaseItemDel = new List<PurchaseItem>() { new PurchaseItem(-1, ids[0], -1, -1, -1) };
                    List<Purchase> purchaseDel = new List<Purchase>() { new Purchase(ids[0], -1, null, null, -1) };

                    using (TransactionScope scope = new TransactionScope())
                    {
                        
                        List<PurchaseItem> purchaseItems = PurchaseItemManager.GetAllWhere(purchaseItemDel[0]);
                        if (purchaseItems.Count > 0)
                        {
                            if (Customer.PurchaseHistory.Find(x => x.Purchase.Id == ids[0]).Purchase.Status == pending)
                            {
                                foreach (PurchaseItem purchaseItem in purchaseItems)
                                {
                                    Item item = ItemManager.GetById(purchaseItem.ItemId);
                                    item.Stocks += purchaseItem.Quantity;
                                    ItemManager.Update(item);
                                }
                            }

                            PurchaseItemManager.Delete(purchaseItemDel);
                        }

                        if (PurchaseManager.Delete(purchaseDel))
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

        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            if (EditProfileButton.Text == editButton)
            {
                EditProfileButton.Text = saveButton;
                textBoxName.ReadOnly = false;
                textBoxAddress.ReadOnly = false;
                textBoxEmail.ReadOnly = false;
                textBoxPhone.ReadOnly = false;
            }
            else
            {    
                string[] name = textBoxName.Text.Split(' ');

                if (name.Length == 3 && !string.IsNullOrEmpty(name[0]) && !string.IsNullOrEmpty(name[2]))
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Customer.Info.FirstName = name[0];
                        Customer.Info.MiddleName = name[1];
                        Customer.Info.LastName = name[2];
                        Customer.Info.Address = textBoxAddress.Text;
                        Customer.Info.Email = textBoxEmail.Text;
                        Customer.Info.ContactNo = textBoxPhone.Text;

                        if (CustomerManager.Update(Customer.Info))
                        {
                            IForm logInForm = Application.OpenForms.OfType<LogInForm>().FirstOrDefault();
                            ((LogInForm)logInForm).LoadData();
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

                EditProfileButton.Text = editButton;
                textBoxName.ReadOnly = true;
                textBoxAddress.ReadOnly = true;
                textBoxEmail.ReadOnly = true;
                textBoxPhone.ReadOnly = true;
            }

            LoadData();
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
                IForm logInForm = Application.OpenForms.OfType<LogInForm>().FirstOrDefault();
                ((LogInForm)logInForm).EnableButtons(true);
            }
        }
    }
}
