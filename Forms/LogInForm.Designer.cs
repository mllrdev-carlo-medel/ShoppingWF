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
            this.customerGridView = new System.Windows.Forms.DataGridView();
            this.membershipIdLabel = new System.Windows.Forms.Label();
            this.MemberIdTxtBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.signUpButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customerGridView
            // 
            this.customerGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerGridView.Location = new System.Drawing.Point(12, 12);
            this.customerGridView.Name = "customerGridView";
            this.customerGridView.ReadOnly = true;
            this.customerGridView.RowHeadersWidth = 51;
            this.customerGridView.RowTemplate.Height = 24;
            this.customerGridView.Size = new System.Drawing.Size(498, 382);
            this.customerGridView.TabIndex = 0;
            //
            // membershipIdLabel
            // 
            this.membershipIdLabel.AutoSize = true;
            this.membershipIdLabel.Location = new System.Drawing.Point(12, 412);
            this.membershipIdLabel.Name = "membershipIdLabel";
            this.membershipIdLabel.Size = new System.Drawing.Size(102, 17);
            this.membershipIdLabel.TabIndex = 1;
            this.membershipIdLabel.Text = "Membership ID";
            // 
            // MemberIdTxtBox
            // 
            this.MemberIdTxtBox.Location = new System.Drawing.Point(120, 409);
            this.MemberIdTxtBox.Name = "MemberIdTxtBox";
            this.MemberIdTxtBox.Size = new System.Drawing.Size(171, 22);
            this.MemberIdTxtBox.TabIndex = 2;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(297, 406);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(105, 27);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // signUpButton
            // 
            this.signUpButton.Location = new System.Drawing.Point(408, 406);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(102, 27);
            this.signUpButton.TabIndex = 4;
            this.signUpButton.Text = "Sign up";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.SignUpButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 441);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.MemberIdTxtBox);
            this.Controls.Add(this.membershipIdLabel);
            this.Controls.Add(this.customerGridView);
            this.Name = "LogInForm";
            this.Text = "Log In";
            ((System.ComponentModel.ISupportInitialize)(this.customerGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customerGridView;
        private System.Windows.Forms.Label membershipIdLabel;
        private System.Windows.Forms.TextBox MemberIdTxtBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button signUpButton;
    }
}