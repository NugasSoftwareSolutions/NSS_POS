namespace AlreySolutions.LoadingStation
{
    partial class frmLoadAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadAccounts));
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.txtCurBal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAvailBal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLoadType = new System.Windows.Forms.ComboBox();
            this.txtAccountNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.fileDlg = new System.Windows.Forms.OpenFileDialog();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dgvLoadAccounts = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSvcFee = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnFundTransfer = new System.Windows.Forms.Button();
            this.btnSubD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadAccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(169, 121);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(401, 26);
            this.txtDesc.TabIndex = 1;
            // 
            // txtCurBal
            // 
            this.txtCurBal.Enabled = false;
            this.txtCurBal.Location = new System.Drawing.Point(169, 157);
            this.txtCurBal.Name = "txtCurBal";
            this.txtCurBal.Size = new System.Drawing.Size(401, 26);
            this.txtCurBal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Current Balance";
            // 
            // txtAvailBal
            // 
            this.txtAvailBal.Enabled = false;
            this.txtAvailBal.Location = new System.Drawing.Point(169, 193);
            this.txtAvailBal.Name = "txtAvailBal";
            this.txtAvailBal.Size = new System.Drawing.Size(401, 26);
            this.txtAvailBal.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Available Balance";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Load Type";
            // 
            // cboLoadType
            // 
            this.cboLoadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoadType.FormattingEnabled = true;
            this.cboLoadType.Items.AddRange(new object[] {
            "Globe E-Cash",
            "Smart E-Cash",
            "Load Wallet",
            "E-Load"});
            this.cboLoadType.Location = new System.Drawing.Point(169, 12);
            this.cboLoadType.Name = "cboLoadType";
            this.cboLoadType.Size = new System.Drawing.Size(401, 27);
            this.cboLoadType.TabIndex = 7;
            // 
            // txtAccountNum
            // 
            this.txtAccountNum.Location = new System.Drawing.Point(169, 49);
            this.txtAccountNum.Name = "txtAccountNum";
            this.txtAccountNum.Size = new System.Drawing.Size(401, 26);
            this.txtAccountNum.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Account Num";
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(169, 85);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(401, 26);
            this.txtMobile.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mobile Num";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(778, 190);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(245, 29);
            this.btnBrowse.TabIndex = 26;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // fileDlg
            // 
            this.fileDlg.FileName = "openFileDialog1";
            this.fileDlg.Filter = "Image files|*.jpg|All files|*.*";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(949, 413);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 58);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(751, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 58);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(850, 413);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 58);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dgvLoadAccounts
            // 
            this.dgvLoadAccounts.AllowUserToAddRows = false;
            this.dgvLoadAccounts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvLoadAccounts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoadAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLoadAccounts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLoadAccounts.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvLoadAccounts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvLoadAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLoadAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoadAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Category,
            this.MobileNum,
            this.Description,
            this.CurrentBal,
            this.AvailBal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLoadAccounts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLoadAccounts.Location = new System.Drawing.Point(21, 244);
            this.dgvLoadAccounts.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvLoadAccounts.MultiSelect = false;
            this.dgvLoadAccounts.Name = "dgvLoadAccounts";
            this.dgvLoadAccounts.ReadOnly = true;
            this.dgvLoadAccounts.RowTemplate.Height = 24;
            this.dgvLoadAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoadAccounts.Size = new System.Drawing.Size(1011, 163);
            this.dgvLoadAccounts.TabIndex = 30;
            this.dgvLoadAccounts.SelectionChanged += new System.EventHandler(this.dgvLoadAccounts_SelectionChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "Load ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Account Number";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // MobileNum
            // 
            this.MobileNum.HeaderText = "Mobile Number";
            this.MobileNum.Name = "MobileNum";
            this.MobileNum.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // CurrentBal
            // 
            this.CurrentBal.HeaderText = "Current Balance";
            this.CurrentBal.Name = "CurrentBal";
            this.CurrentBal.ReadOnly = true;
            // 
            // AvailBal
            // 
            this.AvailBal.HeaderText = "Available Balance";
            this.AvailBal.Name = "AvailBal";
            this.AvailBal.ReadOnly = true;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(652, 413);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(83, 58);
            this.btnNew.TabIndex = 31;
            this.btnNew.Text = "New Account";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnReload
            // 
            this.btnReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReload.Location = new System.Drawing.Point(110, 413);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(83, 58);
            this.btnReload.TabIndex = 32;
            this.btnReload.Text = "Reload Account";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSvcFee
            // 
            this.btnSvcFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSvcFee.Location = new System.Drawing.Point(22, 413);
            this.btnSvcFee.Name = "btnSvcFee";
            this.btnSvcFee.Size = new System.Drawing.Size(83, 58);
            this.btnSvcFee.TabIndex = 33;
            this.btnSvcFee.Text = "Service Fees";
            this.btnSvcFee.UseVisualStyleBackColor = true;
            this.btnSvcFee.Click += new System.EventHandler(this.btnSvcFee_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReset.Location = new System.Drawing.Point(286, 413);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(83, 58);
            this.btnReset.TabIndex = 34;
            this.btnReset.Text = "Reset Balance";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.Location = new System.Drawing.Point(778, 7);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(245, 177);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 25;
            this.picImage.TabStop = false;
            // 
            // btnFundTransfer
            // 
            this.btnFundTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFundTransfer.Location = new System.Drawing.Point(198, 413);
            this.btnFundTransfer.Name = "btnFundTransfer";
            this.btnFundTransfer.Size = new System.Drawing.Size(83, 58);
            this.btnFundTransfer.TabIndex = 35;
            this.btnFundTransfer.Text = "Fund Transfer";
            this.btnFundTransfer.UseVisualStyleBackColor = true;
            this.btnFundTransfer.Click += new System.EventHandler(this.btnFundTransfer_Click);
            // 
            // btnSubD
            // 
            this.btnSubD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubD.Location = new System.Drawing.Point(375, 413);
            this.btnSubD.Name = "btnSubD";
            this.btnSubD.Size = new System.Drawing.Size(83, 58);
            this.btnSubD.TabIndex = 36;
            this.btnSubD.Text = "Sub-D Accounts";
            this.btnSubD.UseVisualStyleBackColor = true;
            this.btnSubD.Click += new System.EventHandler(this.btnSubD_Click);
            // 
            // frmLoadAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1044, 483);
            this.Controls.Add(this.btnSubD);
            this.Controls.Add(this.btnFundTransfer);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSvcFee);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvLoadAccounts);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAccountNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboLoadType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAvailBal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCurBal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLoadAccounts";
            this.Text = "Setup Load Accounts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoadAccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.TextBox txtCurBal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAvailBal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboLoadType;
        private System.Windows.Forms.TextBox txtAccountNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.OpenFileDialog fileDlg;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dgvLoadAccounts;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvailBal;
        private System.Windows.Forms.Button btnSvcFee;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFundTransfer;
        private System.Windows.Forms.Button btnSubD;
    }
}