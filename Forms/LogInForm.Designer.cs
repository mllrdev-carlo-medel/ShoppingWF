using System.Runtime.CompilerServices;

namespace ShoppingCart.Forms
{
    partial class LogInForm
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
            this.membershipIdLabel = new System.Windows.Forms.Label();
            this.textBoxMemberId = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            this.customerListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.address = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // membershipIdLabel
            // 
            this.membershipIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.membershipIdLabel.AutoSize = true;
            this.membershipIdLabel.Location = new System.Drawing.Point(12, 412);
            this.membershipIdLabel.Name = "membershipIdLabel";
            this.membershipIdLabel.Size = new System.Drawing.Size(102, 17);
            this.membershipIdLabel.TabIndex = 1;
            this.membershipIdLabel.Text = "Membership ID";
            // 
            // textBoxMemberId
            // 
            this.textBoxMemberId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMemberId.Location = new System.Drawing.Point(120, 409);
            this.textBoxMemberId.Name = "textBoxMemberId";
            this.textBoxMemberId.Size = new System.Drawing.Size(171, 22);
            this.textBoxMemberId.TabIndex = 2;
            // 
            // confirmButton
            // 
            this.confirmButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.confirmButton.Location = new System.Drawing.Point(297, 406);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 27);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Log In";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // signUpButton
            // 
            this.signUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.signUpButton.Location = new System.Drawing.Point(408, 406);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(102, 27);
            this.signUpButton.TabIndex = 4;
            this.signUpButton.Text = "Sign up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // customerListView
            // 
            this.customerListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.name,
            this.address});
            this.customerListView.FullRowSelect = true;
            this.customerListView.GridLines = true;
            this.customerListView.HideSelection = false;
            this.customerListView.Location = new System.Drawing.Point(12, 39);
            this.customerListView.MultiSelect = false;
            this.customerListView.Name = "customerListView";
            this.customerListView.Size = new System.Drawing.Size(498, 361);
            this.customerListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.customerListView.TabIndex = 5;
            this.customerListView.UseCompatibleStateImageBehavior = false;
            this.customerListView.View = System.Windows.Forms.View.Details;
            this.customerListView.Click += new System.EventHandler(this.CustomerListView_Click);
            //
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 120;
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 200;
            // 
            // address
            // 
            this.address.Text = "Address";
            this.address.Width = 174;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSearch.Location = new System.Drawing.Point(71, 11);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(439, 22);
            this.textBoxSearch.TabIndex = 6;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.TextBoxSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search";
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.customerListView);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.textBoxMemberId);
            this.Controls.Add(this.membershipIdLabel);
            this.MinimumSize = new System.Drawing.Size(540, 490);
            this.Name = "LogInForm";
            this.Text = "Log In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label membershipIdLabel;
        private System.Windows.Forms.TextBox textBoxMemberId;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.ListView customerListView;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader address;
        private System.Windows.Forms.Label label1;
        
    }
}