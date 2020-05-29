using System;
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

            MainForm mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
