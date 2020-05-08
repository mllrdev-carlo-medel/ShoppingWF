using ShoppingCart.Forms.Interfaces;
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
    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();   
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IForm logInForm = new LogInForm();
            ((LogInForm)logInForm).Dock = DockStyle.Right;
            ((LogInForm)logInForm).MdiParent = this;
            ((LogInForm)logInForm).TopLevel = false;
            ((LogInForm)logInForm).Disposed += ChildForm_Disposed;
            ((LogInForm)logInForm).Show();
        }

        public void ChildForm_Disposed(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
