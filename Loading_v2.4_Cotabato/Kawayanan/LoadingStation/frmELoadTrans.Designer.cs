namespace AlreySolutions.LoadingStation
{
    partial class frmELoadTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmELoadTrans));
            this.cmbLoadAmt = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmtDue = new System.Windows.Forms.TextBox();
            this.txtRebate = new System.Windows.Forms.TextBox();
            this.lblAvailableBal = new System.Windows.Forms.Label();
            this.txtTransAmount = new System.Windows.Forms.TextBox();
            this.txtLoadAmount = new System.Windows.Forms.TextBox();
            this.ctrlLoadAccount1 = new AlreySolutions.LoadingStation.ctrlLoadAccount();
            this.SuspendLayout();
            // 
            // cmbLoadAmt
            // 
            this.cmbLoadAmt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoadAmt.Font = new System.Drawing.Font("Rockwell", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLoadAmt.FormattingEnabled = true;
            this.cmbLoadAmt.IntegralHeight = false;
            this.cmbLoadAmt.ItemHeight = 31;
            this.cmbLoadAmt.Location = new System.Drawing.Point(12, 325);
            this.cmbLoadAmt.MaxDropDownItems = 6;
            this.cmbLoadAmt.Name = "cmbLoadAmt";
            this.cmbLoadAmt.Size = new System.Drawing.Size(359, 39);
            this.cmbLoadAmt.TabIndex = 3;
            this.cmbLoadAmt.SelectedIndexChanged += new System.EventHandler(this.cmbLoadAmt_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(201, 454);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(172, 63);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(12, 264);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(359, 36);
            this.txtMobile.TabIndex = 1;
            this.txtMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMobile_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mobile Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 303);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reload Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 378);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 14;
            this.label3.Text = "Amount Due";
            // 
            // txtAmtDue
            // 
            this.txtAmtDue.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtDue.Location = new System.Drawing.Point(11, 400);
            this.txtAmtDue.Name = "txtAmtDue";
            this.txtAmtDue.ReadOnly = true;
            this.txtAmtDue.Size = new System.Drawing.Size(359, 36);
            this.txtAmtDue.TabIndex = 13;
            // 
            // txtRebate
            // 
            this.txtRebate.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRebate.Location = new System.Drawing.Point(114, 454);
            this.txtRebate.Name = "txtRebate";
            this.txtRebate.Size = new System.Drawing.Size(81, 36);
            this.txtRebate.TabIndex = 15;
            this.txtRebate.Visible = false;
            // 
            // lblAvailableBal
            // 
            this.lblAvailableBal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBal.Location = new System.Drawing.Point(13, 201);
            this.lblAvailableBal.Name = "lblAvailableBal";
            this.lblAvailableBal.Size = new System.Drawing.Size(357, 26);
            this.lblAvailableBal.TabIndex = 28;
            this.lblAvailableBal.Text = "Available Balance";
            this.lblAvailableBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTransAmount
            // 
            this.txtTransAmount.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransAmount.Location = new System.Drawing.Point(17, 454);
            this.txtTransAmount.Name = "txtTransAmount";
            this.txtTransAmount.Size = new System.Drawing.Size(81, 36);
            this.txtTransAmount.TabIndex = 29;
            this.txtTransAmount.Visible = false;
            // 
            // txtLoadAmount
            // 
            this.txtLoadAmount.Font = new System.Drawing.Font("Rockwell", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoadAmount.Location = new System.Drawing.Point(13, 326);
            this.txtLoadAmount.Name = "txtLoadAmount";
            this.txtLoadAmount.Size = new System.Drawing.Size(359, 36);
            this.txtLoadAmount.TabIndex = 2;
            this.txtLoadAmount.TextChanged += new System.EventHandler(this.txtLoadAmount_TextChanged);
            this.txtLoadAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLoadAmount_KeyDown);
            // 
            // ctrlLoadAccount1
            // 
            this.ctrlLoadAccount1.BackColor = System.Drawing.Color.RoyalBlue;
            this.ctrlLoadAccount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLoadAccount1.Description = null;
            this.ctrlLoadAccount1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLoadAccount1.LoadId = 0;
            this.ctrlLoadAccount1.LoadType = AlreySolutions.Class.Load.LoadAccountType.GCash;
            this.ctrlLoadAccount1.Location = new System.Drawing.Point(13, 8);
            this.ctrlLoadAccount1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLoadAccount1.Name = "ctrlLoadAccount1";
            this.ctrlLoadAccount1.Picture = null;
            this.ctrlLoadAccount1.Size = new System.Drawing.Size(357, 191);
            this.ctrlLoadAccount1.TabIndex = 12;
            // 
            // frmELoadTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 525);
            this.Controls.Add(this.txtTransAmount);
            this.Controls.Add(this.lblAvailableBal);
            this.Controls.Add(this.txtRebate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAmtDue);
            this.Controls.Add(this.ctrlLoadAccount1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtLoadAmount);
            this.Controls.Add(this.cmbLoadAmt);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmELoadTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "E-Load";
            this.Load += new System.EventHandler(this.frmELoadTrans_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLoadAmt;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private ctrlLoadAccount ctrlLoadAccount1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmtDue;
        private System.Windows.Forms.TextBox txtRebate;
        private System.Windows.Forms.Label lblAvailableBal;
        private System.Windows.Forms.TextBox txtTransAmount;
        private System.Windows.Forms.TextBox txtLoadAmount;
    }
}