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

        private void MainForm_Load(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Dock = DockStyle.Right;
            customerForm.MdiParent = this;
            customerForm.TopLevel = false;
            customerForm.Disposed += ChildForm_Disposed;
            customerForm.Show();
        }

        public void ChildForm_Disposed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
