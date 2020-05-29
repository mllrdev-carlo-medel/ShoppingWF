using ShoppingCart.Business.Entities;
using ShoppingCart.Business.Log;
using ShoppingCart.Extensions;
using System;
using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    public partial class ItemPromptForm : Form
    {
        public Item Item { get; set; }
        public bool IsSuccess { get; set; } = false;

        public ItemPromptForm(Item item)
        {
            InitializeComponent();
            Item = item;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxName.Text) && textBoxPrice.Text.ToFloat(-1) > 0 && numericUpDownStocks.Value >= 0)
            {
                Item.Name = textBoxName.Text;
                Item.Price = textBoxPrice.Text.ToFloat(-1);
                Item.Stocks = numericUpDownStocks.Text.ToInt(-1);
                IsSuccess = true;
                this.Close();
            }
            else
            {
                string caption = "Error";
                string message = "Please check indiviual fields and try again.";
                MessageBox.Show(message, caption, MessageBoxButtons.OK);
            }
        }

        private void ItemPromptForm_Load(object sender, EventArgs e)
        {
            try
            {
                textBoxName.Text = Item.Name;
                textBoxPrice.Text = Item.Price.ToString();
                numericUpDownStocks.Value = Item.Stocks;
            }
            catch (Exception ex)
            {
                textBoxName.Text = string.Empty;
                textBoxPrice.Text = string.Empty;
                numericUpDownStocks.Value = 0;
                Logger.log.Error(ex.ToString());
            }
        }
    }
}
