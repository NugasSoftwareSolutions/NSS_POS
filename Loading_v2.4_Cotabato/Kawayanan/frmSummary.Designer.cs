namespace Kawayanan
{
    partial class frmSummary
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
            this.dtPick = new System.Windows.Forms.DateTimePicker();
            this.lstReceipts = new System.Windows.Forms.ListBox();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.txtSales = new System.Windows.Forms.TextBox();
            this.lblTotalIncome = new System.Windows.Forms.Label();
            this.txtIncome = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstProductsSold = new System.Windows.Forms.ListBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstPurchases = new System.Windows.Forms.ListBox();
            this.btnShowBal = new System.Windows.Forms.Button();
            this.lstInventory = new System.Windows.Forms.ListBox();
            this.lstSales = new System.Windows.Forms.ListBox();
            this.lstTotal = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.chkAcceptPayment = new System.Windows.Forms.CheckBox();
            this.btnShowIncome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Date";
            // 
            // dtPick
            // 
            this.dtPick.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPick.Location = new System.Drawing.Point(66, 12);
            this.dtPick.Name = "dtPick";
            this.dtPick.Size = new System.Drawing.Size(234, 26);
            this.dtPick.TabIndex = 7;
            this.dtPick.ValueChanged += new System.EventHandler(this.dtPick_ValueChanged);
            // 
            // lstReceipts
            // 
            this.lstReceipts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReceipts.BackColor = System.Drawing.Color.White;
            this.lstReceipts.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstReceipts.ForeColor = System.Drawing.Color.Black;
            this.lstReceipts.FormattingEnabled = true;
            this.lstReceipts.ItemHeight = 19;
            this.lstReceipts.Location = new System.Drawing.Point(8, 38);
            this.lstReceipts.Name = "lstReceipts";
            this.lstReceipts.Size = new System.Drawing.Size(855, 232);
            this.lstReceipts.TabIndex = 12;
            this.lstReceipts.SelectedIndexChanged += new System.EventHandler(this.lstReceipts_SelectedIndexChanged);
            this.lstReceipts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstReceipts_MouseDoubleClick);
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.Black;
            this.lblTotalSales.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(12, 647);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(75, 19);
            this.lblTotalSales.TabIndex = 20;
            this.lblTotalSales.Text = "Total Sales";
            this.lblTotalSales.Visible = false;
            // 
            // txtSales
            // 
            this.txtSales.AcceptsReturn = true;
            this.txtSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSales.BackColor = System.Drawing.Color.White;
            this.txtSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSales.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSales.ForeColor = System.Drawing.Color.Black;
            this.txtSales.Location = new System.Drawing.Point(8, 670);
            this.txtSales.Name = "txtSales";
            this.txtSales.Size = new System.Drawing.Size(223, 44);
            this.txtSales.TabIndex = 19;
            this.txtSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSales.Visible = false;
            // 
            // lblTotalIncome
            // 
            this.lblTotalIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalIncome.AutoSize = true;
            this.lblTotalIncome.BackColor = System.Drawing.Color.Black;
            this.lblTotalIncome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIncome.ForeColor = System.Drawing.Color.White;
            this.lblTotalIncome.Location = new System.Drawing.Point(234, 647);
            this.lblTotalIncome.Name = "lblTotalIncome";
            this.lblTotalIncome.Size = new System.Drawing.Size(88, 19);
            this.lblTotalIncome.TabIndex = 22;
            this.lblTotalIncome.Text = "Total Income";
            this.lblTotalIncome.Visible = false;
            // 
            // txtIncome
            // 
            this.txtIncome.AcceptsReturn = true;
            this.txtIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtIncome.BackColor = System.Drawing.Color.White;
            this.txtIncome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncome.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncome.ForeColor = System.Drawing.Color.Black;
            this.txtIncome.Location = new System.Drawing.Point(237, 670);
            this.txtIncome.Name = "txtIncome";
            this.txtIncome.Size = new System.Drawing.Size(223, 44);
            this.txtIncome.TabIndex = 21;
            this.txtIncome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIncome.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(767, 655);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 62);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstProductsSold
            // 
            this.lstProductsSold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstProductsSold.BackColor = System.Drawing.Color.White;
            this.lstProductsSold.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProductsSold.ForeColor = System.Drawing.Color.Black;
            this.lstProductsSold.FormattingEnabled = true;
            this.lstProductsSold.ItemHeight = 19;
            this.lstProductsSold.Location = new System.Drawing.Point(8, 466);
            this.lstProductsSold.Name = "lstProductsSold";
            this.lstProductsSold.Size = new System.Drawing.Size(314, 175);
            this.lstProductsSold.TabIndex = 24;
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleDescription = "bv bbvbv v bbbbbvvbvv";
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(563, 655);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(96, 62);
            this.btnPrint.TabIndex = 25;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstPurchases
            // 
            this.lstPurchases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPurchases.BackColor = System.Drawing.Color.White;
            this.lstPurchases.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPurchases.ForeColor = System.Drawing.Color.Black;
            this.lstPurchases.FormattingEnabled = true;
            this.lstPurchases.ItemHeight = 19;
            this.lstPurchases.Location = new System.Drawing.Point(8, 310);
            this.lstPurchases.Name = "lstPurchases";
            this.lstPurchases.Size = new System.Drawing.Size(314, 118);
            this.lstPurchases.TabIndex = 26;
            // 
            // btnShowBal
            // 
            this.btnShowBal.AccessibleDescription = "";
            this.btnShowBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowBal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowBal.Location = new System.Drawing.Point(665, 655);
            this.btnShowBal.Name = "btnShowBal";
            this.btnShowBal.Size = new System.Drawing.Size(96, 62);
            this.btnShowBal.TabIndex = 27;
            this.btnShowBal.Text = "Show Balance";
            this.btnShowBal.UseVisualStyleBackColor = true;
            this.btnShowBal.Click += new System.EventHandler(this.btnShowBal_Click);
            // 
            // lstInventory
            // 
            this.lstInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstInventory.BackColor = System.Drawing.Color.White;
            this.lstInventory.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstInventory.ForeColor = System.Drawing.Color.Black;
            this.lstInventory.FormattingEnabled = true;
            this.lstInventory.ItemHeight = 19;
            this.lstInventory.Location = new System.Drawing.Point(328, 310);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(285, 137);
            this.lstInventory.TabIndex = 28;
            // 
            // lstSales
            // 
            this.lstSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSales.BackColor = System.Drawing.Color.White;
            this.lstSales.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSales.ForeColor = System.Drawing.Color.Black;
            this.lstSales.FormattingEnabled = true;
            this.lstSales.ItemHeight = 19;
            this.lstSales.Location = new System.Drawing.Point(619, 310);
            this.lstSales.Name = "lstSales";
            this.lstSales.Size = new System.Drawing.Size(244, 327);
            this.lstSales.TabIndex = 29;
            // 
            // lstTotal
            // 
            this.lstTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTotal.BackColor = System.Drawing.Color.White;
            this.lstTotal.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTotal.ForeColor = System.Drawing.Color.Black;
            this.lstTotal.FormattingEnabled = true;
            this.lstTotal.ItemHeight = 19;
            this.lstTotal.Location = new System.Drawing.Point(328, 485);
            this.lstTotal.Name = "lstTotal";
            this.lstTotal.Size = new System.Drawing.Size(285, 156);
            this.lstTotal.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(620, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 31;
            this.label2.Text = "Products Left";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(324, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 32;
            this.label3.Text = "Products Sold";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(324, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 19);
            this.label4.TabIndex = 33;
            this.label4.Text = "Total Products";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(5, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Reciept Details";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 444);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "Summary";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(361, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 26);
            this.txtName.TabIndex = 36;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(306, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(46, 19);
            this.lblName.TabIndex = 37;
            this.lblName.Text = "Name";
            // 
            // chkAcceptPayment
            // 
            this.chkAcceptPayment.AutoSize = true;
            this.chkAcceptPayment.BackColor = System.Drawing.Color.Black;
            this.chkAcceptPayment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAcceptPayment.ForeColor = System.Drawing.Color.White;
            this.chkAcceptPayment.Location = new System.Drawing.Point(477, 11);
            this.chkAcceptPayment.Name = "chkAcceptPayment";
            this.chkAcceptPayment.Size = new System.Drawing.Size(128, 23);
            this.chkAcceptPayment.TabIndex = 38;
            this.chkAcceptPayment.Text = "Accept Payment";
            this.chkAcceptPayment.UseVisualStyleBackColor = false;
            // 
            // btnShowIncome
            // 
            this.btnShowIncome.AccessibleDescription = "";
            this.btnShowIncome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowIncome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowIncome.Location = new System.Drawing.Point(461, 655);
            this.btnShowIncome.Name = "btnShowIncome";
            this.btnShowIncome.Size = new System.Drawing.Size(96, 62);
            this.btnShowIncome.TabIndex = 39;
            this.btnShowIncome.Text = "Show Income";
            this.btnShowIncome.UseVisualStyleBackColor = true;
            this.btnShowIncome.Click += new System.EventHandler(this.btnShowIncome_Click);
            // 
            // frmSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kawayanan.Properties.Resources.silver_stainless_steel_mesh1;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(870, 722);
            this.Controls.Add(this.btnShowIncome);
            this.Controls.Add(this.chkAcceptPayment);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstTotal);
            this.Controls.Add(this.lstSales);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.btnShowBal);
            this.Controls.Add(this.lstPurchases);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.lstProductsSold);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTotalIncome);
            this.Controls.Add(this.txtIncome);
            this.Controls.Add(this.lblTotalSales);
            this.Controls.Add(this.txtSales);
            this.Controls.Add(this.lstReceipts);
            this.Controls.Add(this.dtPick);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(564, 445);
            this.Name = "frmSummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Summary";
            this.Load += new System.EventHandler(this.frmSummary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPick;
        private System.Windows.Forms.ListBox lstReceipts;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.TextBox txtSales;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.TextBox txtIncome;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstProductsSold;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lstPurchases;
        private System.Windows.Forms.Button btnShowBal;
        private System.Windows.Forms.ListBox lstInventory;
        private System.Windows.Forms.ListBox lstSales;
        private System.Windows.Forms.ListBox lstTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox chkAcceptPayment;
        private System.Windows.Forms.Button btnShowIncome;
    }
}