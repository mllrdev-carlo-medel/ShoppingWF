using ShoppingCart.Business.Entity;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Manager.Interfaces;
using System.Collections.Generic;
using System.Windows.Forms;
using ShoppingCart.Helper;
using ShoppingCart.Forms.Interfaces;

namespace ShoppingCart.Forms
{
    public partial class LogInForm : Form, ILogInForm
    {
        public IManager<Customer> Manager { get; } = new CustomerManager();

        private readonly BindingSource bindingSource = new BindingSource();

        public LogInForm()
        {
            InitializeComponent();
            LoadData();  
        }

        public void LoadData()
        {
            customerGridView.Rows.Clear();
            bindingSource.DataSource = typeof(Customer);

            foreach (Customer customer in Manager.GetAll())
            {
                bindingSource.Add(customer);
            }

            customerGridView.DataSource = bindingSource;
            customerGridView.AutoGenerateColumns = true;
        }

        public void EnableButtons (bool value)
        {
            confirmButton.Enabled = value;
            signUpButton.Enabled = value;
        }

        private void ConfirmButton_Click(object sender, System.EventArgs e)
        {
            int id = textBoxMemberId.Text.ToInt(-1);
            Customer customer = Manager.GetById(id, "Id");

            if (customer == null)
            {
                string message = "Entered ID can't be found.";
                string caption = "Please try again."; 
                DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
            else
            {
                EnableButtons(false);
                IForm profileForm = new ProfileForm(customer);
                ((ProfileForm)profileForm).Show();
            }
        }

        private void SignUpButton_Click(object sender, System.EventArgs e)
        {
            EnableButtons(false);
            IForm signUpForm = new SignUpForm();
            ((SignUpForm)signUpForm).Show();
        }

        private void customerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (customerGridView.SelectedRows.Count > 0 && e.RowIndex >= 0)
            {
                textBoxMemberId.Text = customerGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
    }
}