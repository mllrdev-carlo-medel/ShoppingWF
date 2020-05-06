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
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.purchaseHistoryGridView = new System.Windows.Forms.DataGridView();
            this.purchaseItemsGridView = new System.Windows.Forms.DataGridView();
            this.historyLabel = new System.Windows.Forms.Label();
            this.itemsLabel = new System.Windows.Forms.Label();
            this.newPurchaseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseHistoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseItemsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(78, 30);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(374, 22);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(78, 58);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.ReadOnly = true;
            this.textBoxAddress.Size = new System.Drawing.Size(374, 22);
            this.textBoxAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gender";
            // 
            // textBoxGender
            // 
            this.textBoxGender.Location = new System.Drawing.Point(534, 2);
            this.textBoxGender.Name = "textBoxGender";
            this.textBoxGender.ReadOnly = true;
            this.textBoxGender.Size = new System.Drawing.Size(184, 22);
            this.textBoxGender.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "ID";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(78, 2);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(374, 22);
            this.textBoxId.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Phone";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(534, 30);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.ReadOnly = true;
            this.textBoxPhone.Size = new System.Drawing.Size(184, 22);
            this.textBoxPhone.TabIndex = 10;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(534, 58);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.ReadOnly = true;
            this.textBoxEmail.Size = new System.Drawing.Size(184, 22);
            this.textBoxEmail.TabIndex = 11;
            // 
            // purchaseHistoryGridView
            // 
            this.purchaseHistoryGridView.AllowUserToAddRows = false;
            this.purchaseHistoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchaseHistoryGridView.Location = new System.Drawing.Point(12, 117);
            this.purchaseHistoryGridView.MultiSelect = false;
            this.purchaseHistoryGridView.Name = "purchaseHistoryGridView";
            this.purchaseHistoryGridView.ReadOnly = true;
            this.purchaseHistoryGridView.RowHeadersWidth = 51;
            this.purchaseHistoryGridView.RowTemplate.Height = 24;
            this.purchaseHistoryGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.purchaseHistoryGridView.Size = new System.Drawing.Size(706, 156);
            this.purchaseHistoryGridView.TabIndex = 12;
            this.purchaseHistoryGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PurchaseHistoryGridView_CellClick);
            // 
            // purchaseItemsGridView
            // 
            this.purchaseItemsGridView.AllowUserToAddRows = false;
            this.purchaseItemsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.purchaseItemsGridView.Location = new System.Drawing.Point(12, 311);
            this.purchaseItemsGridView.Name = "purchaseItemsGridView";
            this.purchaseItemsGridView.ReadOnly = true;
            this.purchaseItemsGridView.RowHeadersWidth = 51;
            this.purchaseItemsGridView.RowTemplate.Height = 24;
            this.purchaseItemsGridView.Size = new System.Drawing.Size(706, 172);
            this.purchaseItemsGridView.TabIndex = 13;
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
            this.itemsLabel.AutoSize = true;
            this.itemsLabel.Location = new System.Drawing.Point(11, 291);
            this.itemsLabel.Name = "itemsLabel";
            this.itemsLabel.Size = new System.Drawing.Size(41, 17);
            this.itemsLabel.TabIndex = 15;
            this.itemsLabel.Text = "Items";
            // 
            // newPurchaseButton
            // 
            this.newPurchaseButton.Location = new System.Drawing.Point(593, 490);
            this.newPurchaseButton.Name = "newPurchaseButton";
            this.newPurchaseButton.Size = new System.Drawing.Size(125, 27);
            this.newPurchaseButton.TabIndex = 16;
            this.newPurchaseButton.Text = "New Purchase";
            this.newPurchaseButton.UseVisualStyleBackColor = true;
            this.newPurchaseButton.Click += new System.EventHandler(this.NewPurchaseButton_Click);
            // 
            // ProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 521);
            this.Controls.Add(this.newPurchaseButton);
            this.Controls.Add(this.itemsLabel);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.purchaseItemsGridView);
            this.Controls.Add(this.purchaseHistoryGridView);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxGender);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ProfileForm";
            this.Text = "Profile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfileForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.purchaseHistoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseItemsGridView)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.DataGridView purchaseHistoryGridView;
        private System.Windows.Forms.DataGridView purchaseItemsGridView;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.Label itemsLabel;
        private System.Windows.Forms.Button newPurchaseButton;
    }
}