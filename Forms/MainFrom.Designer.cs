namespace ShoppingCart.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.customerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itemsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.purchasesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerMenu,
            this.itemsMenu,
            this.purchasesMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // customerMenu
            // 
            this.customerMenu.Name = "customerMenu";
            this.customerMenu.Size = new System.Drawing.Size(86, 24);
            this.customerMenu.Text = "Customer";
            this.customerMenu.Click += new System.EventHandler(this.CustomerMenu_Click);
            // 
            // itemsMenu
            // 
            this.itemsMenu.Name = "itemsMenu";
            this.itemsMenu.Size = new System.Drawing.Size(59, 24);
            this.itemsMenu.Text = "Items";
            this.itemsMenu.Click += new System.EventHandler(this.ItemsMenu_Click);
            // 
            // purchasesMenu
            // 
            this.purchasesMenu.Name = "purchasesMenu";
            this.purchasesMenu.Size = new System.Drawing.Size(87, 24);
            this.purchasesMenu.Text = "Purchases";
            this.purchasesMenu.Click += new System.EventHandler(this.PurchasesMenu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 626);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem customerMenu;
        private System.Windows.Forms.ToolStripMenuItem itemsMenu;
        private System.Windows.Forms.ToolStripMenuItem purchasesMenu;
    }
}