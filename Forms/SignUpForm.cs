using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using ShoppingCart.Forms.Interfaces;
using ShoppingCart.Helper;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class SignUpForm : Form, ISignUpForm
    {
        public IManager<Customer> Manager { get; } = new CustomerManager();

        private bool success = false;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (textBoxFirstName.Text == null || textBoxMiddleName.Text == null || textBoxLastName.Text == null ||
                textBoxAddress.Text == null || textBoxEmail.Text == null || textBoxPhone.Text == null ||
                Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked) == null)
            {
                string message = "All fields must be fill up.";
                string caption = "Please try again.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                Customer customer = new Customer();
                customer.Id = GenerateID.GetGeneratedID();
                customer.FirstName = textBoxFirstName.Text;
                customer.MiddleName = textBoxMiddleName.Text;
                customer.LastName = textBoxLastName.Text;
                customer.Gender = Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Text;
                customer.ContactNo = textBoxPhone.Text;
                customer.Email = textBoxEmail.Text;
                customer.Address = textBoxAddress.Text;

                if (Manager.Add(customer))
                {
                    success = true;
                    IForm logInForm = Application.OpenForms.OfType<LogInForm>().FirstOrDefault();
                    ((LogInForm)logInForm).LoadData();

                    IForm profileForm = new ProfileForm(customer.Id);
                    ((ProfileForm)profileForm).MdiParent = this.ParentForm;
                    ((ProfileForm)profileForm).Show();
                    this.Close();
                }
                else
                {
                    string message = "";
                    string caption = "Please try again.";
                    DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
                }
            }
        }

        private void SignUpForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!success)
            {
                IForm logInForm = Application.OpenForms.OfType<LogInForm>().FirstOrDefault();
                ((LogInForm)logInForm).EnableButtons(true);
            }
        }
    }
}
