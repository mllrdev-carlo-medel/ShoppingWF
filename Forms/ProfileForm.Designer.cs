namespace ShoppingCart.Forms
{
    partial class ProfileForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGender = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.historyLabel = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.newPurchaseButton = new System.Windows.Forms.Button();
            this.historyListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itemListView = new System.Windows.Forms.ListView();
            this.itemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subtotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EditProfileButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(78, 5);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(425, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.Location = new System.Drawing.Point(78, 35);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(425, 22);
            this.textBoxAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(523, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gender";
            // 
            // textBoxGender
            // 
            this.textBoxGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGender.Location = new System.Drawing.Point(585, 2);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.ReadOnly = true;
            this.textBoxGender.Size = new System.Drawing.Size(184, 22);
            this.textBoxGender.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(523, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPhone.Location = new System.Drawing.Point(585, 30);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.ReadOnly = true;
            this.textBoxPhone.Size = new System.Drawing.Size(184, 22);
            this.textBoxPhone.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.Location = new System.Drawing.Point(78, 63);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(425, 22);
            this.textBoxEmail.TabIndex = 11;
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Location = new System.Drawing.Point(12, 97);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(52, 17);
            this.historyLabel.TabIndex = 14;
            this.historyLabel.Text = "History";
            // 
            // itemsLabel
            // 
            this.itemsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(11, 291);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(41, 17);
            this.itemsLabel.TabIndex = 15;
            this.itemsLabel.Text = "Items";
            // 
            // newPurchaseButton
            // 
            this.newPurchaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newPurchaseButton.Location = new System.Drawing.Point(654, 492);
            this.newPurchaseButton.Name = "newPurchaseButton";
            this.newPurchaseButton.Size = new System.Drawing.Size(115, 27);
            this.newPurchaseButton.TabIndex = 16;
            this.newPurchaseButton.Text = "New Purchase";
            this.newPurchaseButton.UseVisualStyleBackColor = true;
            this.newPurchaseButton.Click += new System.EventHandler(this.NewPurchaseButton_Click);
            // 
            // historyListView
            // 
            this.historyListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.customerId,
            this.status,
            this.date,
            this.total});
            this.historyListView.FullRowSelect = true;
            this.historyListView.GridLines = true;
            this.historyListView.HideSelection = false;
            this.historyListView.Location = new System.Drawing.Point(14, 118);
            this.historyListView.MultiSelect = false;
            this.historyListView.Name = "historyListView";
            this.historyListView.Size = new System.Drawing.Size(755, 170);
            this.historyListView.TabIndex = 17;
            this.historyListView.UseCompatibleStateImageBehavior = false;
            this.historyListView.View = System.Windows.Forms.View.Details;
            this.historyListView.SelectedIndexChanged += new System.EventHandler(this.historyListView_SelectedIndexChanged);
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 120;
            // 
            // customerId
            // 
            this.customerId.Text = "Customer Id";
            this.customerId.Width = 120;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 120;
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 120;
            // 
            // total
            // 
            this.total.Text = "Total";
            this.total.Width = 120;
            // 
            // itemListView
            // 
            this.itemListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itemId,
            this.name,
            this.price,
            this.quantity,
            this.subtotal});
            this.itemListView.GridLines = true;
            this.itemListView.HideSelection = false;
            this.itemListView.Location = new System.Drawing.Point(15, 312);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(755, 172);
            this.itemListView.TabIndex = 18;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.View = System.Windows.Forms.View.Details;
            // 
            // itemId
            // 
            this.itemId.Text = "Id";
            this.itemId.Width = 120;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 120;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 120;
            // 
            // quantity
            // 
            this.quantity.Text = "Quantity";
            this.quantity.Width = 100;
            // 
            // subtotal
            // 
            this.subtotal.Text = "Subtotal";
            this.subtotal.Width = 120;
            // 
            // EditProfileButton
            // 
            this.EditProfileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditProfileButton.Location = new System.Drawing.Point(15, 492);
            this.EditProfileButton.Name = "EditProfileButton";
            this.EditProfileButton.Size = new System.Drawing.Size(140, 27);
            this.EditProfileButton.TabIndex = 19;
            this.EditProfileButton.Text = "Edit Profile";
            this.EditProfileButton.UseVisualStyleBackColor = true;
            this.EditProfileButton.Click += new System.EventHandler(this.EditProfileButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Location = new System.Drawing.Point(536, 492);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(112, 27);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 523);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.EditProfileButton);
            this.Controls.Add(this.itemListView);
            this.Controls.Add(this.historyListView);
            this.Controls.Add(this.newPurchaseButton);
            this.Controls.Add(this.itemsLabel);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxGender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(800, 570);
            this.Name = "ProfileForm";
            this.Text = "Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxGender;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Button newPurchaseButton;
        private System.Windows.Forms.ListView historyListView;
        private System.Windows.Forms.ListView itemListView;
        private System.Windows.Forms.Button EditProfileButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader customerId;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader total;
        private System.Windows.Forms.ColumnHeader itemId;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.ColumnHeader subtotal;
    }
}