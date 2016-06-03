namespace AlreySolutions.LoadingStation
{
    partial class frmLoadWalletTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadWalletTrans));
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMobileNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoadAmount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmtDue = new System.Windows.Forms.TextBox();
            this.lblAvailableBal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlLoadAccount1 = new AlreySolutions.LoadingStation.ctrlLoadAccount();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(18, 502);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(185, 39);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtMobileNum
            // 
            this.txtMobileNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobileNum.Location = new System.Drawing.Point(18, 339);
            this.txtMobileNum.Name = "txtMobileNum";
            this.txtMobileNum.Size = new System.Drawing.Size(256, 35);
            this.txtMobileNum.TabIndex = 1;
            this.txtMobileNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobileNum_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mobile Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 378);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reload Amount";
            // 
            // txtLoadAmount
            // 
            this.txtLoadAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoadAmount.Location = new System.Drawing.Point(18, 400);
            this.txtLoadAmount.Name = "txtLoadAmount";
            this.txtLoadAmount.Size = new System.Drawing.Size(256, 35);
            this.txtLoadAmount.TabIndex = 2;
            this.txtLoadAmount.TextChanged += new System.EventHandler(this.txtLoadAmount_TextChanged);
            this.txtLoadAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Discount %";
            // 
            // txtDisCount
            // 
            this.txtDisCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisCount.Location = new System.Drawing.Point(280, 400);
            this.txtDisCount.Name = "txtDisCount";
            this.txtDisCount.Size = new System.Drawing.Size(91, 35);
            this.txtDisCount.TabIndex = 3;
            this.txtDisCount.Text = "0";
            this.txtDisCount.TextChanged += new System.EventHandler(this.txtDisCount_TextChanged);
            this.txtDisCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDisCount_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Total Amount Due";
            // 
            // txtAmtDue
            // 
            this.txtAmtDue.Enabled = false;
            this.txtAmtDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtDue.Location = new System.Drawing.Point(18, 461);
            this.txtAmtDue.Name = "txtAmtDue";
            this.txtAmtDue.Size = new System.Drawing.Size(256, 35);
            this.txtAmtDue.TabIndex = 17;
            this.txtAmtDue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmtDue_KeyDown);
            // 
            // lblAvailableBal
            // 
            this.lblAvailableBal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBal.Location = new System.Drawing.Point(14, 201);
            this.lblAvailableBal.Name = "lblAvailableBal";
            this.lblAvailableBal.Size = new System.Drawing.Size(357, 26);
            this.lblAvailableBal.TabIndex = 29;
            this.lblAvailableBal.Text = "Available Balance";
            this.lblAvailableBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 32;
            this.label5.Text = "Customer";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomer.Location = new System.Drawing.Point(18, 245);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(256, 35);
            this.txtCustomer.TabIndex = 31;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(281, 245);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(91, 35);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlLoadAccount1
            // 
            this.ctrlLoadAccount1.BackColor = System.Drawing.Color.RoyalBlue;
            this.ctrlLoadAccount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLoadAccount1.Description = "Load Wallet";
            this.ctrlLoadAccount1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLoadAccount1.LoadId = 0;
            this.ctrlLoadAccount1.LoadType = AlreySolutions.Class.Load.LoadAccountType.GCash;
            this.ctrlLoadAccount1.Location = new System.Drawing.Point(10, 9);
            this.ctrlLoadAccount1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLoadAccount1.Name = "ctrlLoadAccount1";
            this.ctrlLoadAccount1.Picture = null;
            this.ctrlLoadAccount1.Size = new System.Drawing.Size(362, 190);
            this.ctrlLoadAccount1.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(209, 502);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(161, 39);
            this.btnClose.TabIndex = 33;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Location = new System.Drawing.Point(17, 283);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(134, 20);
            this.lblBalance.TabIndex = 32;
            this.lblBalance.Text = "Account Balance:";
            // 
            // frmLoadWalletTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 567);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblBalance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblAvailableBal);
            this.Controls.Add(this.txtAmtDue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDisCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLoadAmount);
            this.Controls.Add(this.ctrlLoadAccount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMobileNum);
            this.Controls.Add(this.btnLoad);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadWalletTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Load Wallet";
            this.Load += new System.EventHandler(this.frmLoadWalletTrans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtMobileNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ctrlLoadAccount ctrlLoadAccount1;
        private System.Windows.Forms.TextBox txtLoadAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDisCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmtDue;
        private System.Windows.Forms.Label lblAvailableBal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblBalance;
    }
}