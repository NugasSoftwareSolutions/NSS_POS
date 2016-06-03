namespace AlreySolutions
{
    partial class frmWholeSaleUnit
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
            this.lstDiscount = new System.Windows.Forms.ListBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstDiscount
            // 
            this.lstDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstDiscount.BackColor = System.Drawing.Color.Snow;
            this.lstDiscount.Font = new System.Drawing.Font("Century Schoolbook", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDiscount.ForeColor = System.Drawing.Color.Black;
            this.lstDiscount.FormattingEnabled = true;
            this.lstDiscount.ItemHeight = 38;
            this.lstDiscount.Items.AddRange(new object[] {
            "Per Item",
            "Ream (x10)",
            "Ream (x20)",
            "Case (x6)",
            "Case (x12)",
            "Case (x24)"});
            this.lstDiscount.Location = new System.Drawing.Point(9, 73);
            this.lstDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.lstDiscount.Name = "lstDiscount";
            this.lstDiscount.Size = new System.Drawing.Size(346, 270);
            this.lstDiscount.TabIndex = 0;
            this.lstDiscount.SelectedIndexChanged += new System.EventHandler(this.lstDiscount_SelectedIndexChanged);
            this.lstDiscount.DoubleClick += new System.EventHandler(this.lstDiscount_DoubleClick);
            this.lstDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstDiscount_KeyDown);
            // 
            // lblChange
            // 
            this.lblChange.Font = new System.Drawing.Font("Century Schoolbook", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.White;
            this.lblChange.Location = new System.Drawing.Point(9, 7);
            this.lblChange.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(345, 56);
            this.lblChange.TabIndex = 2;
            this.lblChange.Text = "WholeSale Unit";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmWholeSaleUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(363, 356);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.lstDiscount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmWholeSaleUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Discount";
            this.Load += new System.EventHandler(this.frmDiscount_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDiscount;
        private System.Windows.Forms.Label lblChange;
    }
}