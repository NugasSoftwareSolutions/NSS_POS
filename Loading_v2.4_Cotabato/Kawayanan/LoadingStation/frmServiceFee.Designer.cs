namespace AlreySolutions.LoadingStation
{
    partial class frmServiceFee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiceFee));
            this.dgvSvcFees = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentBal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAmtTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAmtFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtP2P = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEcashFee = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRebatePercentage = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.ctrlLoadAccount = new AlreySolutions.LoadingStation.ctrlLoadAccount();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvcFees)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSvcFees
            // 
            this.dgvSvcFees.AllowUserToAddRows = false;
            this.dgvSvcFees.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvSvcFees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSvcFees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSvcFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSvcFees.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvSvcFees.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvSvcFees.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSvcFees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSvcFees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Category,
            this.MobileNum,
            this.Description,
            this.CurrentBal,
            this.Column1,
            this.remarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSvcFees.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSvcFees.Location = new System.Drawing.Point(4, 4);
            this.dgvSvcFees.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvSvcFees.MultiSelect = false;
            this.dgvSvcFees.Name = "dgvSvcFees";
            this.dgvSvcFees.ReadOnly = true;
            this.dgvSvcFees.RowHeadersVisible = false;
            this.dgvSvcFees.RowTemplate.Height = 24;
            this.dgvSvcFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSvcFees.Size = new System.Drawing.Size(497, 525);
            this.dgvSvcFees.TabIndex = 31;
            this.dgvSvcFees.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSvcFees_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "Service Fee ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Amount From";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // MobileNum
            // 
            this.MobileNum.HeaderText = "Amount To";
            this.MobileNum.Name = "MobileNum";
            this.MobileNum.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Ecash Fee";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // CurrentBal
            // 
            this.CurrentBal.HeaderText = "P2P Fee";
            this.CurrentBal.Name = "CurrentBal";
            this.CurrentBal.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Rebate";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Visible = false;
            // 
            // txtAmtTo
            // 
            this.txtAmtTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmtTo.Location = new System.Drawing.Point(732, 197);
            this.txtAmtTo.Name = "txtAmtTo";
            this.txtAmtTo.Size = new System.Drawing.Size(108, 26);
            this.txtAmtTo.TabIndex = 41;
            this.txtAmtTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmtTo_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(696, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "To ";
            // 
            // txtAmtFrom
            // 
            this.txtAmtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmtFrom.Location = new System.Drawing.Point(572, 197);
            this.txtAmtFrom.Name = "txtAmtFrom";
            this.txtAmtFrom.Size = new System.Drawing.Size(108, 26);
            this.txtAmtFrom.TabIndex = 39;
            this.txtAmtFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmtFrom_KeyDown);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 20);
            this.label5.TabIndex = 38;
            this.label5.Text = "From";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(518, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "P2P";
            // 
            // txtP2P
            // 
            this.txtP2P.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtP2P.Location = new System.Drawing.Point(576, 316);
            this.txtP2P.Name = "txtP2P";
            this.txtP2P.Size = new System.Drawing.Size(264, 26);
            this.txtP2P.TabIndex = 35;
            this.txtP2P.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtP2P_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 283);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "ECash";
            // 
            // txtEcashFee
            // 
            this.txtEcashFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEcashFee.Location = new System.Drawing.Point(576, 280);
            this.txtEcashFee.Name = "txtEcashFee";
            this.txtEcashFee.Size = new System.Drawing.Size(264, 26);
            this.txtEcashFee.TabIndex = 33;
            this.txtEcashFee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEcashFee_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(506, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Service Fee";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(506, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 42;
            this.label4.Text = "Amount";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(513, 462);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 31);
            this.btnNew.TabIndex = 46;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(513, 495);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 31);
            this.btnDelete.TabIndex = 45;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(628, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 64);
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(742, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(97, 31);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpload.Location = new System.Drawing.Point(742, 462);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(96, 31);
            this.btnUpload.TabIndex = 49;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 51;
            this.label7.Text = "Rebate";
            // 
            // txtRebatePercentage
            // 
            this.txtRebatePercentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRebatePercentage.Location = new System.Drawing.Point(576, 364);
            this.txtRebatePercentage.Name = "txtRebatePercentage";
            this.txtRebatePercentage.Size = new System.Drawing.Size(265, 26);
            this.txtRebatePercentage.TabIndex = 50;
            this.txtRebatePercentage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRebatePercentage_KeyDown);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(503, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 52;
            this.label8.Text = "Remarks";
            this.label8.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(576, 410);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(265, 35);
            this.txtRemarks.TabIndex = 53;
            this.txtRemarks.Visible = false;
            // 
            // ctrlLoadAccount
            // 
            this.ctrlLoadAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLoadAccount.BackColor = System.Drawing.Color.RoyalBlue;
            this.ctrlLoadAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLoadAccount.Description = "G-Cash";
            this.ctrlLoadAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLoadAccount.LoadId = 0;
            this.ctrlLoadAccount.LoadType = AlreySolutions.Class.Load.LoadAccountType.GCash;
            this.ctrlLoadAccount.Location = new System.Drawing.Point(511, 3);
            this.ctrlLoadAccount.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLoadAccount.Name = "ctrlLoadAccount";
            this.ctrlLoadAccount.Picture = null;
            this.ctrlLoadAccount.Size = new System.Drawing.Size(330, 145);
            this.ctrlLoadAccount.TabIndex = 47;
            // 
            // frmServiceFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 533);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRebatePercentage);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.ctrlLoadAccount);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmtTo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAmtFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtP2P);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEcashFee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSvcFees);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmServiceFee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service Fee";
            this.Load += new System.EventHandler(this.frmServiceFee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSvcFees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSvcFees;
        private System.Windows.Forms.TextBox txtAmtTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAmtFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtP2P;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEcashFee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private ctrlLoadAccount ctrlLoadAccount;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRebatePercentage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentBal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;

    }
}