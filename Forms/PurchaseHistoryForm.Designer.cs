namespace ShoppingCart.Forms
{
    partial class PurchaseHistoryForm
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
            this.purchaseListView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.customerId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.total = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // purchaseListView
            // 
            this.purchaseListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.customerId,
            this.id,
            this.status,
            this.date,
            this.total});
            this.purchaseListView.FullRowSelect = true;
            this.purchaseListView.HideSelection = false;
            this.purchaseListView.Location = new System.Drawing.Point(12, 12);
            this.purchaseListView.Name = "purchaseListView";
            this.purchaseListView.Size = new System.Drawing.Size(690, 553);
            this.purchaseListView.TabIndex = 0;
            this.purchaseListView.UseCompatibleStateImageBehavior = false;
            this.purchaseListView.View = System.Windows.Forms.View.Details;
            this.purchaseListView.DoubleClick += new System.EventHandler(this.PurchaseHistoryListView_DoubleClick);
            // 
            // name
            // 
            this.name.Text = "Name";
            this.name.Width = 120;
            // 
            // customerId
            // 
            this.customerId.Text = "Customer Id";
            this.customerId.Width = 100;
            // 
            // id
            // 
            this.id.Text = "Id";
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 100;
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // total
            // 
            this.total.Text = "Total";
            // 
            // PurchaseHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 577);
            this.Controls.Add(this.purchaseListView);
            this.MinimumSize = new System.Drawing.Size(619, 624);
            this.Name = "PurchaseHistoryForm";
            this.Text = "Purchase History";
            this.Load += new System.EventHandler(this.PurchaseHostoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView purchaseListView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader customerId;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader total;
    }
}