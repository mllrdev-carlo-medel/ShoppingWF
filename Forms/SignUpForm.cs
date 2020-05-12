using ShoppingCart.Business.Log;
using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Extensions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class SignUpForm : Form
    {
        private readonly IManager<Customer> _manager = new CustomerManager();

        private bool _success = false;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxFirstName.Text) || string.IsNullOrWhiteSpace(textBoxMiddleName.Text) || string.IsNullOrWhiteSpace(textBoxLastName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxAddress.Text) || string.IsNullOrWhiteSpace(textBoxEmail.Text) || string.IsNullOrWhiteSpace(textBoxPhone.Text) ||
                    Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked) == null)
                {
                    string message = "All fields must be fill up.";
                    string caption = "Please try again.";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
                else
                {
                    Customer customer = new Customer();
                    customer.Id = PrimaryId.GetGeneratedID();
                    customer.FirstName = textBoxFirstName.Text;
                    customer.MiddleName = textBoxMiddleName.Text;
                    customer.LastName = textBoxLastName.Text;
                    customer.Gender = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Text;
                    customer.ContactNo = textBoxPhone.Text;
                    customer.Email = textBoxEmail.Text;
                    customer.Address = textBoxAddress.Text;

                    if (_manager.Add(customer))
                    {
                        _success = true;
                        CustomerForm logInForm = Application.OpenForms.OfType<CustomerForm>().FirstOrDefault();
                        logInForm.LoadData();

                        ProfileForm profileForm = new ProfileForm(customer.Id);
                        profileForm.MdiParent = this.ParentForm;
                        profileForm.Show();
                        this.Close();
                    }
                    else
                    {
                        string message = string.Empty;
                        string caption = "Please try again.";
                        DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.log.Error(ex.ToString());
            }
        }

        private void SignUpForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!_success)
            {
                CustomerForm logInForm = Application.OpenForms.OfType<CustomerForm>().FirstOrDefault();
                logInForm.EnableButtons(true);
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {

        }
    }
}
