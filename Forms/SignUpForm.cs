using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
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
    public partial class SignUpForm : Form
    {
        public IManager<Customer> Manager { get; } = new CustomerManager();

        private bool success = false;

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
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
                LogInForm logInForm = (LogInForm)Application.OpenForms["LogInForm"];
                logInForm.LoadData();
                
                ProfileForm profileForm = new ProfileForm(customer);
                profileForm.Show();
                this.Close();
            }
            else
            {
                string message = "";
                string caption = "Please try again.";
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }   
        }

        private void SignUpForm_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!success)
            {
                LogInForm logInForm = (LogInForm)Application.OpenForms["LogInForm"];
                logInForm.EnableButtons(true);
            }
        }
    }
}
