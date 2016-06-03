namespace AlreySolutions
{
    partial class frmSalesReportLite
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickStart = new System.Windows.Forms.DateTimePicker();
            this.subPan = new System.Windows.Forms.Panel();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.lblActualCOH = new System.Windows.Forms.Label();
            this.lblDiff = new System.Windows.Forms.Label();
            this.lblInitCash = new System.Windows.Forms.Label();
            this.lblCOH = new System.Windows.Forms.Label();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblReceivable = new System.Windows.Forms.Label();
            this.lblNetProfit = new System.Windows.Forms.Label();
            this.lblGrossSales = new System.Windows.Forms.Label();
            this.lblTotalDisc = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.dtPickEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboCashier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvReceipt = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashTendered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceiptID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cashier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.subPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // dtPickStart
            // 
            this.dtPickStart.Location = new System.Drawing.Point(137, 9);
            this.dtPickStart.Name = "dtPickStart";
            this.dtPickStart.Size = new System.Drawing.Size(374, 24);
            this.dtPickStart.TabIndex = 2;
            this.dtPickStart.ValueChanged += new System.EventHandler(this.dtPick_ValueChanged);
            // 
            // subPan
            // 
            this.subPan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.subPan.BackColor = System.Drawing.Color.SteelBlue;
            this.subPan.Controls.Add(this.lblDeposit);
            this.subPan.Controls.Add(this.lblActualCOH);
            this.subPan.Controls.Add(this.lblDiff);
            this.subPan.Controls.Add(this.lblInitCash);
            this.subPan.Controls.Add(this.lblCOH);
            this.subPan.Controls.Add(this.lblExp);
            this.subPan.Controls.Add(this.lblPayment);
            this.subPan.Controls.Add(this.lblReceivable);
            this.subPan.Controls.Add(this.lblNetProfit);
            this.subPan.Controls.Add(this.lblGrossSales);
            this.subPan.ForeColor = System.Drawing.Color.White;
            this.subPan.Location = new System.Drawing.Point(546, 9);
            this.subPan.Name = "subPan";
            this.subPan.Size = new System.Drawing.Size(677, 130);
            this.subPan.TabIndex = 4;
            // 
            // lblDeposit
            // 
            this.lblDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.Color.White;
            this.lblDeposit.Location = new System.Drawing.Point(9, 98);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(103, 16);
            this.lblDeposit.TabIndex = 15;
            this.lblDeposit.Text = "Cash Deposit:";
            // 
            // lblActualCOH
            // 
            this.lblActualCOH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualCOH.AutoSize = true;
            this.lblActualCOH.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualCOH.ForeColor = System.Drawing.Color.White;
            this.lblActualCOH.Location = new System.Drawing.Point(276, 84);
            this.lblActualCOH.Name = "lblActualCOH";
            this.lblActualCOH.Size = new System.Drawing.Size(93, 16);
            this.lblActualCOH.TabIndex = 14;
            this.lblActualCOH.Text = "Actual COH:";
            // 
            // lblDiff
            // 
            this.lblDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiff.AutoSize = true;
            this.lblDiff.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiff.ForeColor = System.Drawing.Color.White;
            this.lblDiff.Location = new System.Drawing.Point(276, 104);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(120, 16);
            this.lblDiff.TabIndex = 13;
            this.lblDiff.Text = "Cash Difference:";
            // 
            // lblInitCash
            // 
            this.lblInitCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitCash.AutoSize = true;
            this.lblInitCash.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitCash.ForeColor = System.Drawing.Color.White;
            this.lblInitCash.Location = new System.Drawing.Point(9, 75);
            this.lblInitCash.Name = "lblInitCash";
            this.lblInitCash.Size = new System.Drawing.Size(93, 16);
            this.lblInitCash.TabIndex = 12;
            this.lblInitCash.Text = "Initial Cash:";
            // 
            // lblCOH
            // 
            this.lblCOH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCOH.AutoSize = true;
            this.lblCOH.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOH.ForeColor = System.Drawing.Color.White;
            this.lblCOH.Location = new System.Drawing.Point(276, 61);
            this.lblCOH.Name = "lblCOH";
            this.lblCOH.Size = new System.Drawing.Size(108, 16);
            this.lblCOH.TabIndex = 11;
            this.lblCOH.Text = "Expected COH:";
            // 
            // lblExp
            // 
            this.lblExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExp.AutoSize = true;
            this.lblExp.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExp.ForeColor = System.Drawing.Color.White;
            this.lblExp.Location = new System.Drawing.Point(9, 29);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(74, 16);
            this.lblExp.TabIndex = 10;
            this.lblExp.Text = "Expenses:";
            // 
            // lblPayment
            // 
            this.lblPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPayment.AutoSize = true;
            this.lblPayment.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.ForeColor = System.Drawing.Color.White;
            this.lblPayment.Location = new System.Drawing.Point(9, 52);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(80, 16);
            this.lblPayment.TabIndex = 9;
            this.lblPayment.Text = "Payments:";
            // 
            // lblReceivable
            // 
            this.lblReceivable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivable.AutoSize = true;
            this.lblReceivable.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivable.ForeColor = System.Drawing.Color.White;
            this.lblReceivable.Location = new System.Drawing.Point(9, 6);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.Size = new System.Drawing.Size(86, 16);
            this.lblReceivable.TabIndex = 8;
            this.lblReceivable.Text = "Receivable:";
            // 
            // lblNetProfit
            // 
            this.lblNetProfit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNetProfit.AutoSize = true;
            this.lblNetProfit.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetProfit.ForeColor = System.Drawing.Color.White;
            this.lblNetProfit.Location = new System.Drawing.Point(276, 34);
            this.lblNetProfit.Name = "lblNetProfit";
            this.lblNetProfit.Size = new System.Drawing.Size(97, 16);
            this.lblNetProfit.TabIndex = 7;
            this.lblNetProfit.Text = "Gross Profit:";
            // 
            // lblGrossSales
            // 
            this.lblGrossSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrossSales.AutoSize = true;
            this.lblGrossSales.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrossSales.ForeColor = System.Drawing.Color.White;
            this.lblGrossSales.Location = new System.Drawing.Point(276, 11);
            this.lblGrossSales.Name = "lblGrossSales";
            this.lblGrossSales.Size = new System.Drawing.Size(92, 16);
            this.lblGrossSales.TabIndex = 6;
            this.lblGrossSales.Text = "Gross Sales:";
            // 
            // lblTotalDisc
            // 
            this.lblTotalDisc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalDisc.AutoSize = true;
            this.lblTotalDisc.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDisc.ForeColor = System.Drawing.Color.White;
            this.lblTotalDisc.Location = new System.Drawing.Point(954, 47);
            this.lblTotalDisc.Name = "lblTotalDisc";
            this.lblTotalDisc.Size = new System.Drawing.Size(163, 23);
            this.lblTotalDisc.TabIndex = 14;
            this.lblTotalDisc.Text = "Total Discount:";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(954, 24);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(126, 23);
            this.lblTotalSales.TabIndex = 13;
            this.lblTotalSales.Text = "Total Sales:";
            // 
            // dtPickEnd
            // 
            this.dtPickEnd.Location = new System.Drawing.Point(137, 43);
            this.dtPickEnd.Name = "dtPickEnd";
            this.dtPickEnd.Size = new System.Drawing.Size(374, 24);
            this.dtPickEnd.TabIndex = 6;
            this.dtPickEnd.ValueChanged += new System.EventHandler(this.dtPickEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(746, 490);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 46);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboCashier
            // 
            this.cboCashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCashier.FormattingEnabled = true;
            this.cboCashier.Location = new System.Drawing.Point(137, 77);
            this.cboCashier.Name = "cboCashier";
            this.cboCashier.Size = new System.Drawing.Size(374, 25);
            this.cboCashier.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cashier";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1070, 490);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(150, 46);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.SteelBlue;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(908, 490);
            this.btnExport.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(150, 46);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvReceipt
            // 
            this.dgvReceipt.AllowUserToAddRows = false;
            this.dgvReceipt.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvReceipt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReceipt.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReceipt.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvReceipt.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReceipt.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.TotalAmount,
            this.CashTendered,
            this.dataGridViewTextBoxColumn10,
            this.AccountName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceipt.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceipt.Location = new System.Drawing.Point(16, 171);
            this.dgvReceipt.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvReceipt.Name = "dgvReceipt";
            this.dgvReceipt.ReadOnly = true;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgvReceipt.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceipt.RowTemplate.Height = 24;
            this.dgvReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReceipt.Size = new System.Drawing.Size(625, 310);
            this.dgvReceipt.TabIndex = 13;
            this.dgvReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReceipt_CellClick);
            this.dgvReceipt.SelectionChanged += new System.EventHandler(this.dgvReceipt_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Date";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Invoice Number";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // CashTendered
            // 
            this.CashTendered.HeaderText = "Cash Tendered";
            this.CashTendered.Name = "CashTendered";
            this.CashTendered.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Cashier";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // AccountName
            // 
            this.AccountName.HeaderText = "AccountName";
            this.AccountName.Name = "AccountName";
            this.AccountName.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Receipt Info";
            // 
            // lblItems
            // 
            this.lblItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItems.ForeColor = System.Drawing.Color.Yellow;
            this.lblItems.Location = new System.Drawing.Point(11, 485);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(105, 19);
            this.lblItems.TabIndex = 22;
            this.lblItems.Text = "Total Items";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(647, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Purchases Info";
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.MistyRose;
            this.dgvPurchase.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPurchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvPurchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPurchase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.ReceiptID,
            this.Barcode,
            this.Description,
            this.Qty,
            this.Amount,
            this.Discount,
            this.Total,
            this.Cashier,
            this.Account});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchase.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPurchase.Location = new System.Drawing.Point(651, 171);
            this.dgvPurchase.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dgvPurchase.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPurchase.RowTemplate.Height = 24;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(572, 310);
            this.dgvPurchase.TabIndex = 23;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 64;
            // 
            // ReceiptID
            // 
            this.ReceiptID.HeaderText = "ReceiptID";
            this.ReceiptID.Name = "ReceiptID";
            this.ReceiptID.ReadOnly = true;
            this.ReceiptID.Width = 97;
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.MinimumWidth = 100;
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 200;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 57;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 85;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            this.Discount.Width = 90;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 66;
            // 
            // Cashier
            // 
            this.Cashier.HeaderText = "Cashier";
            this.Cashier.Name = "Cashier";
            this.Cashier.ReadOnly = true;
            this.Cashier.Width = 83;
            // 
            // Account
            // 
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Width = 85;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOut.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCheckOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCheckOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCheckOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(584, 490);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 46);
            this.btnCheckOut.TabIndex = 8;
            this.btnCheckOut.Text = "Check Out";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 19);
            this.label6.TabIndex = 26;
            this.label6.Text = "Mode of Payment";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "ALL",
            "CASH",
            "ACCOUNT"});
            this.cboMode.Location = new System.Drawing.Point(187, 113);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(324, 25);
            this.cboMode.TabIndex = 25;
            // 
            // frmSalesReportLite
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1235, 550);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboMode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvPurchase);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvReceipt);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCashier);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtPickEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subPan);
            this.Controls.Add(this.dtPickStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalDisc);
            this.Controls.Add(this.lblTotalSales);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmSalesReportLite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Report";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesReportLite_FormClosing);
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.subPan.ResumeLayout(false);
            this.subPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceipt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickStart;
        private System.Windows.Forms.Panel subPan;
        private System.Windows.Forms.Label lblGrossSales;
        private System.Windows.Forms.DateTimePicker dtPickEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboCashier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblNetProfit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView dgvReceipt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblReceivable;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.Label lblCOH;
        private System.Windows.Forms.Label lblInitCash;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashTendered;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.Label lblTotalDisc;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.Label lblActualCOH;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceiptID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cashier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMode;

    }
}