using System;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Entity;
using System.Windows.Forms;
using ShoppingCart.Business.Log;
using log4net.Config;
using ShoppingCart.Forms;
using ShoppingCart.Constants;
using ShoppingCart.Extensions;

namespace ShoppingCart
{
    static class Program
    {
        static void Main()
        {
            BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
