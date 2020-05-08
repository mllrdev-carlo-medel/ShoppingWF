using System.Windows.Forms;

namespace ShoppingCart.Forms
{
    partial class CartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cartListView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phpLabel = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.totalLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.textBoxSubtotal = new System.Windows.Forms.TextBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.subtotalLabel = new System.Windows.Forms.Label();
            this.checkoutButton = new System.Windows.Forms.Button();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.itemListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stocks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(633, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Items you can purchase.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cartListView);
            this.groupBox1.Controls.Add(this.phpLabel);
            this.groupBox1.Controls.Add(this.textBoxTotal);
            this.groupBox1.Controls.Add(this.totalLabel);
            this.groupBox1.Controls.Add(this.removeButton);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.textBoxSubtotal);
            this.groupBox1.Controls.Add(this.textBoxQuantity);
            this.groupBox1.Controls.Add(this.textBoxPrice);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.subtotalLabel);
            this.groupBox1.Controls.Add(this.checkoutButton);
            this.groupBox1.Controls.Add(this.quantityLabel);
            this.groupBox1.Controls.Add(this.priceLabel);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 482);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "My Cart";
            // 
            // cartListView
            // 
            this.cartListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cartListView.CheckBoxes = true;
            this.cartListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.itemId,
            this.itemName,
            this.itemPrice,
            this.itemQuantity,
            this.subtotal});
            this.cartListView.FullRowSelect = true;
            this.cartListView.GridLines = true;
            this.cartListView.HideSelection = false;
            this.cartListView.Location = new System.Drawing.Point(7, 21);
            this.cartListView.MultiSelect = false;
            this.cartListView.Name = "cartListView";
            this.cartListView.Size = new System.Drawing.Size(601, 271);
            this.cartListView.TabIndex = 15;
            this.cartListView.UseCompatibleStateImageBehavior = false;
            this.cartListView.View = System.Windows.Forms.View.Details;
            this.cartListView.Click += new System.EventHandler(this.CartListView_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 30;
            // 
            // itemId
            // 
            this.itemId.Text = "Id";
            // 
            // itemName
            // 
            this.itemName.Text = "Name";
            this.itemName.Width = 100;
            // 
            // itemPrice
            // 
            this.itemPrice.Text = "Price";
            this.itemPrice.Width = 100;
            // 
            // itemQuantity
            // 
            this.itemQuantity.Text = "Quantity";
            // 
            // subtotal
            // 
            this.subtotal.Text = "Subtotal";
            this.subtotal.Width = 100;
            // 
            // phpLabel
            // 
            this.phpLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.phpLabel.AutoSize = true;
            this.phpLabel.Location = new System.Drawing.Point(175, 449);
            this.phpLabel.Name = "phpLabel";
            this.phpLabel.Size = new System.Drawing.Size(33, 17);
            this.phpLabel.TabIndex = 14;
            this.phpLabel.Text = "Php";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTotal.Location = new System.Drawing.Point(214, 446);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(221, 22);
            this.textBoxTotal.TabIndex = 13;
            // 
            // totalLabel
            // 
            this.totalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalLabel.AutoSize = true;
            this.totalLabel.Location = new System.Drawing.Point(211, 426);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(88, 17);
            this.totalLabel.TabIndex = 12;
            this.totalLabel.Text = "Grand Total:";
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(444, 356);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(164, 52);
            this.removeButton.TabIndex = 11;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(444, 298);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(164, 52);
            this.updateButton.TabIndex = 10;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // textBoxSubtotal
            // 
            this.textBoxSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSubtotal.Location = new System.Drawing.Point(73, 386);
            this.textBoxSubtotal.Name = "textBoxSubtotal";
            this.textBoxSubtotal.ReadOnly = true;
            this.textBoxSubtotal.Size = new System.Drawing.Size(362, 22);
            this.textBoxSubtotal.TabIndex = 9;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxQuantity.Location = new System.Drawing.Point(74, 358);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(361, 22);
            this.textBoxQuantity.TabIndex = 8;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPrice.Location = new System.Drawing.Point(73, 328);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.ReadOnly = true;
            this.textBoxPrice.Size = new System.Drawing.Size(362, 22);
            this.textBoxPrice.TabIndex = 7;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(73, 300);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(362, 22);
            this.textBoxName.TabIndex = 6;
            // 
            // subtotalLabel
            // 
            this.subtotalLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.subtotalLabel.AutoSize = true;
            this.subtotalLabel.Location = new System.Drawing.Point(7, 388);
            this.subtotalLabel.Name = "subtotalLabel";
            this.subtotalLabel.Size = new System.Drawing.Size(60, 17);
            this.subtotalLabel.TabIndex = 5;
            this.subtotalLabel.Text = "Subtotal";
            // 
            // checkoutButton
            // 
            this.checkoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkoutButton.Location = new System.Drawing.Point(444, 426);
            this.checkoutButton.Name = "checkoutButton";
            this.checkoutButton.Size = new System.Drawing.Size(164, 42);
            this.checkoutButton.TabIndex = 4;
            this.checkoutButton.Text = "Checkout";
            this.checkoutButton.UseVisualStyleBackColor = true;
            this.checkoutButton.Click += new System.EventHandler(this.CheckoutButton_Click);
            // 
            // quantityLabel
            // 
            this.quantityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(7, 361);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(61, 17);
            this.quantityLabel.TabIndex = 3;
            this.quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            this.priceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(7, 330);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(40, 17);
            this.priceLabel.TabIndex = 2;
            this.priceLabel.Text = "Price";
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(7, 300);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(45, 17);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(636, 472);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(416, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add Item";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // itemListView
            // 
            this.itemListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemListView.CheckBoxes = true;
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.id,
            this.name,
            this.price,
            this.stocks});
            this.itemListView.GridLines = true;
            this.itemListView.HideSelection = false;
            this.itemListView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.itemListView.Location = new System.Drawing.Point(636, 34);
            this.itemListView.MultiSelect = false;
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(416, 432);
            this.itemListView.TabIndex = 4;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            this.itemListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.ItemListView_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 30;
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 50;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 100;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 80;
            // 
            // stocks
            // 
            this.stocks.Text = "Stocks";
            // 
            // CartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 503);
            this.Controls.Add(this.itemListView);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(950, 550);
            this.Name = "CartForm";
            this.Text = "CartForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CartForm_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ItemListView_ItemChecked1(object sender, ItemCheckedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSubtotal;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label subtotalLabel;
        private System.Windows.Forms.Button checkoutButton;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label phpLabel;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label totalLabel;
        private System.Windows.Forms.ListView cartListView;
        private System.Windows.Forms.ListView itemListView;
        private ColumnHeader columnHeader2;
        private ColumnHeader itemId;
        private ColumnHeader itemName;
        private ColumnHeader itemPrice;
        private ColumnHeader itemQuantity;
        private ColumnHeader subtotal;
        private ColumnHeader columnHeader1;
        private ColumnHeader id;
        private ColumnHeader name;
        private ColumnHeader price;
        private ColumnHeader stocks;
    }
}