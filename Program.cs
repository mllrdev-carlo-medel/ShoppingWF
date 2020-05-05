using System;
using ShoppingCart.Business.Manager;
using ShoppingCart.Business.Entity;
using System.Windows.Forms;
using ShoppingCart.Business.Log;
using log4net.Config;
using ShoppingCart.Forms;

namespace ShoppingCart
{
    static class Program
    {
        static void Main()
        {
            BasicConfigurator.Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogInForm());
        }
    }
}
