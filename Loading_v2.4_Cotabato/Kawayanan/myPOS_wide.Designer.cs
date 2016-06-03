namespace AlreySolutions
{
    partial class myPosWide
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(myPosWide));
            this.dgvPurchase = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subLabel1 = new System.Windows.Forms.Label();
            this.txtOR = new System.Windows.Forms.Label();
            this.lbl13 = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.lbl14 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.lbl11 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblProdDesc = new System.Windows.Forms.Label();
            this.lbl10 = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.mainInvoice = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.Label();
            this.subLabel9 = new System.Windows.Forms.Label();
            this.txtChargeAmount = new System.Windows.Forms.Label();
            this.subLabel10 = new System.Windows.Forms.Label();
            this.txtDiscounted = new System.Windows.Forms.Label();
            this.subLabel3 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.Label();
            this.subLabel7 = new System.Windows.Forms.Label();
            this.txtChange = new System.Windows.Forms.Label();
            this.txtCashTendered = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtItems = new System.Windows.Forms.Label();
            this.subLabel5 = new System.Windows.Forms.Label();
            this.subLabel4 = new System.Windows.Forms.Label();
            this.subLabel6 = new System.Windows.Forms.Label();
            this.subLabel2 = new System.Windows.Forms.Label();
            this.subPAn1 = new System.Windows.Forms.Panel();
            this.btnLoadingStation = new System.Windows.Forms.Button();
            this.btnCancelPayment = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnVoidReceipt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUtilities = new System.Windows.Forms.Button();
            this.btnModTransaction = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.btnQuantity = new System.Windows.Forms.Button();
            this.btnProdSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnAcceptPayment = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.mainGreetings = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.main1 = new System.Windows.Forms.Panel();
            this.lbl12 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.dtNow = new System.Windows.Forms.DateTimePicker();
            this.btnNow = new System.Windows.Forms.Button();
            this.mainPan = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).BeginInit();
            this.mainInvoice.SuspendLayout();
            this.subPAn1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.main1.SuspendLayout();
            this.mainPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPurchase
            // 
            this.dgvPurchase.AllowUserToAddRows = false;
            this.dgvPurchase.AllowUserToDeleteRows = false;
            this.dgvPurchase.AllowUserToResizeRows = false;
            this.dgvPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPurchase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPurchase.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvPurchase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPurchase.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPurchase.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPurchase.ColumnHeadersHeight = 30;
            this.dgvPurchase.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.Description,
            this.Qty,
            this.Unit,
            this.Amount,
            this.Discount,
            this.Total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPurchase.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPurchase.EnableHeadersVisualStyles = false;
            this.dgvPurchase.GridColor = System.Drawing.Color.Black;
            this.dgvPurchase.Location = new System.Drawing.Point(4, 82);
            this.dgvPurchase.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvPurchase.MultiSelect = false;
            this.dgvPurchase.Name = "dgvPurchase";
            this.dgvPurchase.ReadOnly = true;
            this.dgvPurchase.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GrayText;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPurchase.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPurchase.RowHeadersVisible = false;
            this.dgvPurchase.RowHeadersWidth = 10;
            this.dgvPurchase.RowTemplate.Height = 24;
            this.dgvPurchase.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPurchase.Size = new System.Drawing.Size(772, 404);
            this.dgvPurchase.TabIndex = 0;
            this.dgvPurchase.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellClick);
            this.dgvPurchase.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellContentClick);
            this.dgvPurchase.SelectionChanged += new System.EventHandler(this.dgvPurchase_SelectionChanged);
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
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Discount
            // 
            this.Discount.HeaderText = "Discount";
            this.Discount.Name = "Discount";
            this.Discount.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // subLabel1
            // 
            this.subLabel1.AutoSize = true;
            this.subLabel1.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel1.ForeColor = System.Drawing.Color.White;
            this.subLabel1.Location = new System.Drawing.Point(8, 37);
            this.subLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel1.Name = "subLabel1";
            this.subLabel1.Size = new System.Drawing.Size(169, 23);
            this.subLabel1.TabIndex = 14;
            this.subLabel1.Text = "Invoice Number";
            // 
            // txtOR
            // 
            this.txtOR.AutoEllipsis = true;
            this.txtOR.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtOR.Font = new System.Drawing.Font("Britannic Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOR.ForeColor = System.Drawing.Color.Black;
            this.txtOR.Location = new System.Drawing.Point(235, 36);
            this.txtOR.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtOR.Name = "txtOR";
            this.txtOR.Size = new System.Drawing.Size(213, 30);
            this.txtOR.TabIndex = 13;
            this.txtOR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl13
            // 
            this.lbl13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl13.AutoSize = true;
            this.lbl13.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl13.ForeColor = System.Drawing.Color.Black;
            this.lbl13.Location = new System.Drawing.Point(511, 7);
            this.lbl13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl13.Name = "lbl13";
            this.lbl13.Size = new System.Drawing.Size(46, 23);
            this.lbl13.TabIndex = 12;
            this.lbl13.Text = "Qty";
            // 
            // lblQty
            // 
            this.lblQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQty.AutoEllipsis = true;
            this.lblQty.BackColor = System.Drawing.Color.White;
            this.lblQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQty.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(504, 39);
            this.lblQty.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(72, 39);
            this.lblQty.TabIndex = 11;
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl14
            // 
            this.lbl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl14.AutoSize = true;
            this.lbl14.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl14.ForeColor = System.Drawing.Color.Black;
            this.lbl14.Location = new System.Drawing.Point(618, 7);
            this.lbl14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl14.Name = "lbl14";
            this.lbl14.Size = new System.Drawing.Size(63, 23);
            this.lbl14.TabIndex = 10;
            this.lbl14.Text = "Total";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPrice.AutoEllipsis = true;
            this.lblTotalPrice.BackColor = System.Drawing.Color.White;
            this.lblTotalPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalPrice.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(583, 39);
            this.lblTotalPrice.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(193, 39);
            this.lblTotalPrice.TabIndex = 9;
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl11
            // 
            this.lbl11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl11.AutoSize = true;
            this.lbl11.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl11.ForeColor = System.Drawing.Color.Black;
            this.lbl11.Location = new System.Drawing.Point(301, 7);
            this.lbl11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl11.Name = "lbl11";
            this.lbl11.Size = new System.Drawing.Size(112, 23);
            this.lbl11.TabIndex = 8;
            this.lbl11.Text = "Unit Price";
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoEllipsis = true;
            this.lblAmount.BackColor = System.Drawing.Color.White;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(291, 39);
            this.lblAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(132, 39);
            this.lblAmount.TabIndex = 7;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProdDesc
            // 
            this.lblProdDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProdDesc.AutoEllipsis = true;
            this.lblProdDesc.BackColor = System.Drawing.Color.White;
            this.lblProdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProdDesc.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdDesc.Location = new System.Drawing.Point(3, 39);
            this.lblProdDesc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProdDesc.Name = "lblProdDesc";
            this.lblProdDesc.Size = new System.Drawing.Size(284, 39);
            this.lblProdDesc.TabIndex = 6;
            this.lblProdDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl10
            // 
            this.lbl10.AutoSize = true;
            this.lbl10.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl10.ForeColor = System.Drawing.Color.Black;
            this.lbl10.Location = new System.Drawing.Point(6, 7);
            this.lbl10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl10.Name = "lbl10";
            this.lbl10.Size = new System.Drawing.Size(128, 23);
            this.lbl10.TabIndex = 2;
            this.lbl10.Text = "Description";
            // 
            // txtBarcode
            // 
            this.txtBarcode.AcceptsReturn = true;
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Britannic Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(146, 13);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(2);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(624, 46);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarcode.ForeColor = System.Drawing.Color.Black;
            this.lblBarcode.Location = new System.Drawing.Point(15, 21);
            this.lblBarcode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(117, 30);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "Barcode";
            // 
            // mainInvoice
            // 
            this.mainInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainInvoice.BackColor = System.Drawing.Color.Black;
            this.mainInvoice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainInvoice.Controls.Add(this.label2);
            this.mainInvoice.Controls.Add(this.txtDate);
            this.mainInvoice.Controls.Add(this.label10);
            this.mainInvoice.Controls.Add(this.txtAccount);
            this.mainInvoice.Controls.Add(this.subLabel9);
            this.mainInvoice.Controls.Add(this.txtChargeAmount);
            this.mainInvoice.Controls.Add(this.subLabel10);
            this.mainInvoice.Controls.Add(this.subLabel1);
            this.mainInvoice.Controls.Add(this.txtOR);
            this.mainInvoice.Controls.Add(this.txtDiscounted);
            this.mainInvoice.Controls.Add(this.subLabel3);
            this.mainInvoice.Controls.Add(this.txtDiscount);
            this.mainInvoice.Controls.Add(this.subLabel7);
            this.mainInvoice.Controls.Add(this.txtChange);
            this.mainInvoice.Controls.Add(this.txtCashTendered);
            this.mainInvoice.Controls.Add(this.txtTotal);
            this.mainInvoice.Controls.Add(this.txtItems);
            this.mainInvoice.Controls.Add(this.subLabel5);
            this.mainInvoice.Controls.Add(this.subLabel4);
            this.mainInvoice.Controls.Add(this.subLabel6);
            this.mainInvoice.Controls.Add(this.subLabel2);
            this.mainInvoice.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainInvoice.Location = new System.Drawing.Point(794, 295);
            this.mainInvoice.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.mainInvoice.Name = "mainInvoice";
            this.mainInvoice.Size = new System.Drawing.Size(457, 424);
            this.mainInvoice.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(8, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Date";
            // 
            // txtDate
            // 
            this.txtDate.AutoEllipsis = true;
            this.txtDate.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDate.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Location = new System.Drawing.Point(235, 4);
            this.txtDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(213, 30);
            this.txtDate.TabIndex = 20;
            this.txtDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(9, 234);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Charged Transaction";
            // 
            // txtAccount
            // 
            this.txtAccount.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtAccount.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccount.ForeColor = System.Drawing.Color.Black;
            this.txtAccount.Location = new System.Drawing.Point(237, 261);
            this.txtAccount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(213, 30);
            this.txtAccount.TabIndex = 18;
            this.txtAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subLabel9
            // 
            this.subLabel9.AutoSize = true;
            this.subLabel9.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel9.ForeColor = System.Drawing.Color.Silver;
            this.subLabel9.Location = new System.Drawing.Point(30, 259);
            this.subLabel9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel9.Name = "subLabel9";
            this.subLabel9.Size = new System.Drawing.Size(130, 19);
            this.subLabel9.TabIndex = 17;
            this.subLabel9.Text = "Account Name";
            // 
            // txtChargeAmount
            // 
            this.txtChargeAmount.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtChargeAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChargeAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtChargeAmount.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChargeAmount.ForeColor = System.Drawing.Color.Black;
            this.txtChargeAmount.Location = new System.Drawing.Point(237, 292);
            this.txtChargeAmount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtChargeAmount.Name = "txtChargeAmount";
            this.txtChargeAmount.Size = new System.Drawing.Size(213, 30);
            this.txtChargeAmount.TabIndex = 16;
            this.txtChargeAmount.Text = "P 0.00";
            this.txtChargeAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subLabel10
            // 
            this.subLabel10.AutoSize = true;
            this.subLabel10.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel10.ForeColor = System.Drawing.Color.Silver;
            this.subLabel10.Location = new System.Drawing.Point(30, 289);
            this.subLabel10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel10.Name = "subLabel10";
            this.subLabel10.Size = new System.Drawing.Size(151, 19);
            this.subLabel10.TabIndex = 15;
            this.subLabel10.Text = "Charged Amount";
            // 
            // txtDiscounted
            // 
            this.txtDiscounted.BackColor = System.Drawing.Color.Gold;
            this.txtDiscounted.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscounted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDiscounted.Font = new System.Drawing.Font("Century Schoolbook", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscounted.ForeColor = System.Drawing.Color.Black;
            this.txtDiscounted.Location = new System.Drawing.Point(235, 162);
            this.txtDiscounted.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtDiscounted.Name = "txtDiscounted";
            this.txtDiscounted.Size = new System.Drawing.Size(213, 30);
            this.txtDiscounted.TabIndex = 12;
            this.txtDiscounted.Text = "P 0.00";
            this.txtDiscounted.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subLabel3
            // 
            this.subLabel3.AutoSize = true;
            this.subLabel3.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel3.ForeColor = System.Drawing.Color.GhostWhite;
            this.subLabel3.Location = new System.Drawing.Point(154, 166);
            this.subLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel3.Name = "subLabel3";
            this.subLabel3.Size = new System.Drawing.Size(71, 26);
            this.subLabel3.TabIndex = 11;
            this.subLabel3.Text = "Total";
            // 
            // txtDiscount
            // 
            this.txtDiscount.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDiscount.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Black;
            this.txtDiscount.Location = new System.Drawing.Point(235, 129);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(213, 30);
            this.txtDiscount.TabIndex = 10;
            this.txtDiscount.Text = "P 0.00";
            this.txtDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subLabel7
            // 
            this.subLabel7.AutoSize = true;
            this.subLabel7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subLabel7.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel7.ForeColor = System.Drawing.Color.DarkGray;
            this.subLabel7.Location = new System.Drawing.Point(28, 135);
            this.subLabel7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel7.Name = "subLabel7";
            this.subLabel7.Size = new System.Drawing.Size(134, 19);
            this.subLabel7.TabIndex = 9;
            this.subLabel7.Text = "Total Discount";
            // 
            // txtChange
            // 
            this.txtChange.BackColor = System.Drawing.Color.Gold;
            this.txtChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtChange.Font = new System.Drawing.Font("Century Schoolbook", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.ForeColor = System.Drawing.Color.Black;
            this.txtChange.Location = new System.Drawing.Point(237, 332);
            this.txtChange.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(213, 55);
            this.txtChange.TabIndex = 8;
            this.txtChange.Text = "P 0.00";
            this.txtChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCashTendered
            // 
            this.txtCashTendered.BackColor = System.Drawing.Color.Gold;
            this.txtCashTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashTendered.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtCashTendered.Font = new System.Drawing.Font("Century Schoolbook", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashTendered.ForeColor = System.Drawing.Color.Black;
            this.txtCashTendered.Location = new System.Drawing.Point(235, 194);
            this.txtCashTendered.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtCashTendered.Name = "txtCashTendered";
            this.txtCashTendered.Size = new System.Drawing.Size(213, 30);
            this.txtCashTendered.TabIndex = 7;
            this.txtCashTendered.Text = "P 0.00";
            this.txtCashTendered.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtTotal.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTotal.Location = new System.Drawing.Point(235, 98);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(213, 30);
            this.txtTotal.TabIndex = 6;
            this.txtTotal.Text = "P 0.00";
            this.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItems
            // 
            this.txtItems.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtItems.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItems.ForeColor = System.Drawing.Color.Black;
            this.txtItems.Location = new System.Drawing.Point(235, 67);
            this.txtItems.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.txtItems.Name = "txtItems";
            this.txtItems.Size = new System.Drawing.Size(213, 30);
            this.txtItems.TabIndex = 5;
            this.txtItems.Text = "0";
            this.txtItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // subLabel5
            // 
            this.subLabel5.AutoSize = true;
            this.subLabel5.Font = new System.Drawing.Font("Century Schoolbook", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel5.ForeColor = System.Drawing.Color.GhostWhite;
            this.subLabel5.Location = new System.Drawing.Point(14, 332);
            this.subLabel5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel5.Name = "subLabel5";
            this.subLabel5.Size = new System.Drawing.Size(213, 55);
            this.subLabel5.TabIndex = 4;
            this.subLabel5.Text = "Change";
            // 
            // subLabel4
            // 
            this.subLabel4.AutoSize = true;
            this.subLabel4.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel4.ForeColor = System.Drawing.Color.White;
            this.subLabel4.Location = new System.Drawing.Point(7, 198);
            this.subLabel4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel4.Name = "subLabel4";
            this.subLabel4.Size = new System.Drawing.Size(219, 26);
            this.subLabel4.TabIndex = 3;
            this.subLabel4.Text = "Tendered Amount";
            // 
            // subLabel6
            // 
            this.subLabel6.AutoSize = true;
            this.subLabel6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subLabel6.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel6.ForeColor = System.Drawing.Color.DarkGray;
            this.subLabel6.Location = new System.Drawing.Point(29, 107);
            this.subLabel6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel6.Name = "subLabel6";
            this.subLabel6.Size = new System.Drawing.Size(170, 17);
            this.subLabel6.TabIndex = 2;
            this.subLabel6.Text = "Total Before Discount";
            // 
            // subLabel2
            // 
            this.subLabel2.AutoSize = true;
            this.subLabel2.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subLabel2.ForeColor = System.Drawing.Color.White;
            this.subLabel2.Location = new System.Drawing.Point(7, 67);
            this.subLabel2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.subLabel2.Name = "subLabel2";
            this.subLabel2.Size = new System.Drawing.Size(76, 26);
            this.subLabel2.TabIndex = 1;
            this.subLabel2.Text = "Items";
            // 
            // subPAn1
            // 
            this.subPAn1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subPAn1.BackColor = System.Drawing.Color.MidnightBlue;
            this.subPAn1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.subPAn1.Controls.Add(this.btnLoadingStation);
            this.subPAn1.Controls.Add(this.btnCancelPayment);
            this.subPAn1.Controls.Add(this.btnCheckout);
            this.subPAn1.Controls.Add(this.btnOpen);
            this.subPAn1.Controls.Add(this.btnSave);
            this.subPAn1.Controls.Add(this.btnPayments);
            this.subPAn1.Controls.Add(this.btnVoidReceipt);
            this.subPAn1.Controls.Add(this.btnExit);
            this.subPAn1.Controls.Add(this.btnUtilities);
            this.subPAn1.Controls.Add(this.btnModTransaction);
            this.subPAn1.Controls.Add(this.btnDiscount);
            this.subPAn1.Controls.Add(this.btnQuantity);
            this.subPAn1.Controls.Add(this.btnProdSearch);
            this.subPAn1.Controls.Add(this.btnPrint);
            this.subPAn1.Controls.Add(this.btnAcceptPayment);
            this.subPAn1.Controls.Add(this.btnNew);
            this.subPAn1.Font = new System.Drawing.Font("Courier New", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subPAn1.ForeColor = System.Drawing.Color.Cornsilk;
            this.subPAn1.Location = new System.Drawing.Point(8, 611);
            this.subPAn1.Margin = new System.Windows.Forms.Padding(2);
            this.subPAn1.Name = "subPAn1";
            this.subPAn1.Size = new System.Drawing.Size(782, 108);
            this.subPAn1.TabIndex = 3;
            // 
            // btnLoadingStation
            // 
            this.btnLoadingStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadingStation.BackColor = System.Drawing.Color.Black;
            this.btnLoadingStation.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnLoadingStation.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnLoadingStation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnLoadingStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadingStation.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadingStation.ForeColor = System.Drawing.Color.White;
            this.btnLoadingStation.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLoadingStation.Location = new System.Drawing.Point(585, 2);
            this.btnLoadingStation.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadingStation.Name = "btnLoadingStation";
            this.btnLoadingStation.Padding = new System.Windows.Forms.Padding(3);
            this.btnLoadingStation.Size = new System.Drawing.Size(95, 51);
            this.btnLoadingStation.TabIndex = 31;
            this.btnLoadingStation.Text = "Loading Station";
            this.btnLoadingStation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLoadingStation.UseCompatibleTextRendering = true;
            this.btnLoadingStation.UseVisualStyleBackColor = false;
            this.btnLoadingStation.Click += new System.EventHandler(this.btnLoadingStation_Click);
            // 
            // btnCancelPayment
            // 
            this.btnCancelPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelPayment.BackColor = System.Drawing.Color.Black;
            this.btnCancelPayment.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnCancelPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnCancelPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelPayment.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelPayment.ForeColor = System.Drawing.Color.White;
            this.btnCancelPayment.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancelPayment.Location = new System.Drawing.Point(294, 54);
            this.btnCancelPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelPayment.Name = "btnCancelPayment";
            this.btnCancelPayment.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancelPayment.Size = new System.Drawing.Size(95, 51);
            this.btnCancelPayment.TabIndex = 30;
            this.btnCancelPayment.Text = "[Alt+F8] - Cancel Payment";
            this.btnCancelPayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCancelPayment.UseCompatibleTextRendering = true;
            this.btnCancelPayment.UseVisualStyleBackColor = false;
            this.btnCancelPayment.Click += new System.EventHandler(this.btnCancelPayment_Click);
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckout.BackColor = System.Drawing.Color.Black;
            this.btnCheckout.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnCheckout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCheckout.Location = new System.Drawing.Point(585, 53);
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Padding = new System.Windows.Forms.Padding(3);
            this.btnCheckout.Size = new System.Drawing.Size(95, 51);
            this.btnCheckout.TabIndex = 29;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCheckout.UseCompatibleTextRendering = true;
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.BackColor = System.Drawing.Color.Black;
            this.btnOpen.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.ForeColor = System.Drawing.Color.White;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOpen.Location = new System.Drawing.Point(3, 54);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Padding = new System.Windows.Forms.Padding(3);
            this.btnOpen.Size = new System.Drawing.Size(95, 51);
            this.btnOpen.TabIndex = 28;
            this.btnOpen.Text = "[Ctrl+O] - Retrieve Temp";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpen.UseCompatibleTextRendering = true;
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(488, 2);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(3);
            this.btnSave.Size = new System.Drawing.Size(95, 51);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "[Ctrl+S] - Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseCompatibleTextRendering = true;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPayments
            // 
            this.btnPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPayments.BackColor = System.Drawing.Color.Black;
            this.btnPayments.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnPayments.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPayments.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPayments.Location = new System.Drawing.Point(197, 54);
            this.btnPayments.Margin = new System.Windows.Forms.Padding(2);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Padding = new System.Windows.Forms.Padding(3);
            this.btnPayments.Size = new System.Drawing.Size(95, 51);
            this.btnPayments.TabIndex = 26;
            this.btnPayments.Text = "[F8] - Accounts Payment";
            this.btnPayments.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPayments.UseCompatibleTextRendering = true;
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);
            // 
            // btnVoidReceipt
            // 
            this.btnVoidReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoidReceipt.BackColor = System.Drawing.Color.Black;
            this.btnVoidReceipt.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnVoidReceipt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnVoidReceipt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnVoidReceipt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoidReceipt.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoidReceipt.ForeColor = System.Drawing.Color.White;
            this.btnVoidReceipt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnVoidReceipt.Location = new System.Drawing.Point(391, 54);
            this.btnVoidReceipt.Margin = new System.Windows.Forms.Padding(2);
            this.btnVoidReceipt.Name = "btnVoidReceipt";
            this.btnVoidReceipt.Padding = new System.Windows.Forms.Padding(3);
            this.btnVoidReceipt.Size = new System.Drawing.Size(95, 51);
            this.btnVoidReceipt.TabIndex = 24;
            this.btnVoidReceipt.Text = "[F9] - Void Receipt";
            this.btnVoidReceipt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVoidReceipt.UseCompatibleTextRendering = true;
            this.btnVoidReceipt.UseVisualStyleBackColor = false;
            this.btnVoidReceipt.Click += new System.EventHandler(this.btnVoidReceipt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExit.Location = new System.Drawing.Point(680, 53);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(3);
            this.btnExit.Size = new System.Drawing.Size(95, 51);
            this.btnExit.TabIndex = 15;
            this.btnExit.Text = "[Alt+F4] Exit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExit.UseCompatibleTextRendering = true;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUtilities
            // 
            this.btnUtilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUtilities.BackColor = System.Drawing.Color.Black;
            this.btnUtilities.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnUtilities.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUtilities.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnUtilities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtilities.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtilities.ForeColor = System.Drawing.Color.White;
            this.btnUtilities.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUtilities.Location = new System.Drawing.Point(488, 54);
            this.btnUtilities.Margin = new System.Windows.Forms.Padding(2);
            this.btnUtilities.Name = "btnUtilities";
            this.btnUtilities.Padding = new System.Windows.Forms.Padding(3);
            this.btnUtilities.Size = new System.Drawing.Size(95, 51);
            this.btnUtilities.TabIndex = 11;
            this.btnUtilities.Text = "[F10] -Utilities";
            this.btnUtilities.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUtilities.UseCompatibleTextRendering = true;
            this.btnUtilities.UseVisualStyleBackColor = false;
            this.btnUtilities.Click += new System.EventHandler(this.btnUtility_Click);
            // 
            // btnModTransaction
            // 
            this.btnModTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnModTransaction.BackColor = System.Drawing.Color.Black;
            this.btnModTransaction.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnModTransaction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnModTransaction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnModTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModTransaction.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModTransaction.ForeColor = System.Drawing.Color.White;
            this.btnModTransaction.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnModTransaction.Location = new System.Drawing.Point(100, 54);
            this.btnModTransaction.Margin = new System.Windows.Forms.Padding(2);
            this.btnModTransaction.Name = "btnModTransaction";
            this.btnModTransaction.Padding = new System.Windows.Forms.Padding(3);
            this.btnModTransaction.Size = new System.Drawing.Size(95, 51);
            this.btnModTransaction.TabIndex = 4;
            this.btnModTransaction.Text = "[F7] - Retrieve Receipt";
            this.btnModTransaction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModTransaction.UseCompatibleTextRendering = true;
            this.btnModTransaction.UseVisualStyleBackColor = false;
            this.btnModTransaction.Click += new System.EventHandler(this.btnModTransaction_Click);
            // 
            // btnDiscount
            // 
            this.btnDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDiscount.BackColor = System.Drawing.Color.Black;
            this.btnDiscount.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnDiscount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDiscount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnDiscount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDiscount.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDiscount.ForeColor = System.Drawing.Color.White;
            this.btnDiscount.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDiscount.Location = new System.Drawing.Point(391, 2);
            this.btnDiscount.Margin = new System.Windows.Forms.Padding(2);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Padding = new System.Windows.Forms.Padding(3);
            this.btnDiscount.Size = new System.Drawing.Size(95, 51);
            this.btnDiscount.TabIndex = 13;
            this.btnDiscount.Text = "[F6] - Item Discount";
            this.btnDiscount.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDiscount.UseCompatibleTextRendering = true;
            this.btnDiscount.UseVisualStyleBackColor = false;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // btnQuantity
            // 
            this.btnQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuantity.BackColor = System.Drawing.Color.Black;
            this.btnQuantity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnQuantity.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnQuantity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnQuantity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnQuantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuantity.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuantity.ForeColor = System.Drawing.Color.White;
            this.btnQuantity.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnQuantity.Location = new System.Drawing.Point(197, 2);
            this.btnQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuantity.Name = "btnQuantity";
            this.btnQuantity.Padding = new System.Windows.Forms.Padding(3);
            this.btnQuantity.Size = new System.Drawing.Size(95, 51);
            this.btnQuantity.TabIndex = 5;
            this.btnQuantity.Text = "[F4/*] - Change Quantity";
            this.btnQuantity.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnQuantity.UseCompatibleTextRendering = true;
            this.btnQuantity.UseVisualStyleBackColor = false;
            this.btnQuantity.Click += new System.EventHandler(this.btnQuantity_Click);
            // 
            // btnProdSearch
            // 
            this.btnProdSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnProdSearch.BackColor = System.Drawing.Color.Black;
            this.btnProdSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnProdSearch.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnProdSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnProdSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnProdSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdSearch.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdSearch.ForeColor = System.Drawing.Color.White;
            this.btnProdSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnProdSearch.Location = new System.Drawing.Point(100, 2);
            this.btnProdSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnProdSearch.Name = "btnProdSearch";
            this.btnProdSearch.Padding = new System.Windows.Forms.Padding(3);
            this.btnProdSearch.Size = new System.Drawing.Size(95, 51);
            this.btnProdSearch.TabIndex = 3;
            this.btnProdSearch.Text = "[F3] - Search Product";
            this.btnProdSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProdSearch.UseCompatibleTextRendering = true;
            this.btnProdSearch.UseVisualStyleBackColor = false;
            this.btnProdSearch.Click += new System.EventHandler(this.btnProdSearch_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPrint.Location = new System.Drawing.Point(294, 2);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Padding = new System.Windows.Forms.Padding(3);
            this.btnPrint.Size = new System.Drawing.Size(95, 51);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "[F5] - Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPrint.UseCompatibleTextRendering = true;
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAcceptPayment
            // 
            this.btnAcceptPayment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcceptPayment.BackColor = System.Drawing.Color.Black;
            this.btnAcceptPayment.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnAcceptPayment.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAcceptPayment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnAcceptPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAcceptPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcceptPayment.ForeColor = System.Drawing.Color.White;
            this.btnAcceptPayment.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAcceptPayment.Location = new System.Drawing.Point(680, 2);
            this.btnAcceptPayment.Margin = new System.Windows.Forms.Padding(2);
            this.btnAcceptPayment.Name = "btnAcceptPayment";
            this.btnAcceptPayment.Padding = new System.Windows.Forms.Padding(3);
            this.btnAcceptPayment.Size = new System.Drawing.Size(95, 50);
            this.btnAcceptPayment.TabIndex = 1;
            this.btnAcceptPayment.Text = "Accept Payment [space]";
            this.btnAcceptPayment.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnAcceptPayment.UseVisualStyleBackColor = false;
            this.btnAcceptPayment.Click += new System.EventHandler(this.btnAcceptPayment_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.Black;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Rockwell Condensed", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 2);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Padding = new System.Windows.Forms.Padding(3);
            this.btnNew.Size = new System.Drawing.Size(95, 51);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "[F2] - New Customer";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNew.UseCompatibleTextRendering = true;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.picProduct);
            this.panel4.Location = new System.Drawing.Point(794, 11);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(457, 201);
            this.panel4.TabIndex = 4;
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.Color.White;
            this.picProduct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picProduct.ErrorImage = global::AlreySolutions.Properties.Resources.Logo_small;
            this.picProduct.ImageLocation = "";
            this.picProduct.InitialImage = null;
            this.picProduct.Location = new System.Drawing.Point(0, 0);
            this.picProduct.Margin = new System.Windows.Forms.Padding(2);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(455, 199);
            this.picProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // mainGreetings
            // 
            this.mainGreetings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mainGreetings.BackColor = System.Drawing.Color.Turquoise;
            this.mainGreetings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainGreetings.Font = new System.Drawing.Font("Century Schoolbook", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainGreetings.ForeColor = System.Drawing.Color.White;
            this.mainGreetings.Location = new System.Drawing.Point(795, 246);
            this.mainGreetings.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.mainGreetings.Name = "mainGreetings";
            this.mainGreetings.Size = new System.Drawing.Size(455, 45);
            this.mainGreetings.TabIndex = 0;
            this.mainGreetings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // main1
            // 
            this.main1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.main1.BackColor = System.Drawing.Color.DimGray;
            this.main1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.main1.Controls.Add(this.lblBarcode);
            this.main1.Controls.Add(this.txtBarcode);
            this.main1.ForeColor = System.Drawing.Color.Cornsilk;
            this.main1.Location = new System.Drawing.Point(9, 11);
            this.main1.Name = "main1";
            this.main1.Size = new System.Drawing.Size(781, 81);
            this.main1.TabIndex = 13;
            this.main1.Paint += new System.Windows.Forms.PaintEventHandler(this.main1_Paint);
            // 
            // lbl12
            // 
            this.lbl12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl12.AutoSize = true;
            this.lbl12.Font = new System.Drawing.Font("Century Schoolbook", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl12.ForeColor = System.Drawing.Color.Black;
            this.lbl12.Location = new System.Drawing.Point(435, 7);
            this.lbl12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl12.Name = "lbl12";
            this.lbl12.Size = new System.Drawing.Size(54, 23);
            this.lbl12.TabIndex = 15;
            this.lbl12.Text = "Unit";
            // 
            // lblUnit
            // 
            this.lblUnit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUnit.AutoEllipsis = true;
            this.lblUnit.BackColor = System.Drawing.Color.White;
            this.lblUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblUnit.Font = new System.Drawing.Font("Britannic Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnit.Location = new System.Drawing.Point(428, 39);
            this.lblUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(72, 39);
            this.lblUnit.TabIndex = 14;
            this.lblUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtNow
            // 
            this.dtNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtNow.Location = new System.Drawing.Point(1023, 216);
            this.dtNow.Name = "dtNow";
            this.dtNow.Size = new System.Drawing.Size(228, 26);
            this.dtNow.TabIndex = 16;
            this.dtNow.ValueChanged += new System.EventHandler(this.dtNow_ValueChanged);
            // 
            // btnNow
            // 
            this.btnNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnNow.FlatAppearance.BorderColor = System.Drawing.Color.SlateGray;
            this.btnNow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkOrange;
            this.btnNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNow.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNow.ForeColor = System.Drawing.Color.Black;
            this.btnNow.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNow.Location = new System.Drawing.Point(795, 215);
            this.btnNow.Margin = new System.Windows.Forms.Padding(2);
            this.btnNow.Name = "btnNow";
            this.btnNow.Padding = new System.Windows.Forms.Padding(3);
            this.btnNow.Size = new System.Drawing.Size(223, 29);
            this.btnNow.TabIndex = 27;
            this.btnNow.Text = "Current Date";
            this.btnNow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNow.UseCompatibleTextRendering = true;
            this.btnNow.UseVisualStyleBackColor = false;
            this.btnNow.Click += new System.EventHandler(this.btnNow_Click);
            // 
            // mainPan
            // 
            this.mainPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPan.Controls.Add(this.lbl12);
            this.mainPan.Controls.Add(this.lblUnit);
            this.mainPan.Controls.Add(this.lbl13);
            this.mainPan.Controls.Add(this.dgvPurchase);
            this.mainPan.Controls.Add(this.lblQty);
            this.mainPan.Controls.Add(this.lbl10);
            this.mainPan.Controls.Add(this.lblTotalPrice);
            this.mainPan.Controls.Add(this.lbl14);
            this.mainPan.Controls.Add(this.lbl11);
            this.mainPan.Controls.Add(this.lblAmount);
            this.mainPan.Controls.Add(this.lblProdDesc);
            this.mainPan.Location = new System.Drawing.Point(8, 98);
            this.mainPan.Name = "mainPan";
            this.mainPan.Size = new System.Drawing.Size(782, 507);
            this.mainPan.TabIndex = 28;
            // 
            // myPosWide
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1262, 733);
            this.Controls.Add(this.mainPan);
            this.Controls.Add(this.btnNow);
            this.Controls.Add(this.dtNow);
            this.Controls.Add(this.subPAn1);
            this.Controls.Add(this.main1);
            this.Controls.Add(this.mainGreetings);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.mainInvoice);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1278, 726);
            this.Name = "myPosWide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSS POS System - Alrey Solutions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.myPosWide_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.myPosWide_FormClosing);
            this.Load += new System.EventHandler(this.iPOS_Load);
            this.Shown += new System.EventHandler(this.iPOS_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPurchase)).EndInit();
            this.mainInvoice.ResumeLayout(false);
            this.mainInvoice.PerformLayout();
            this.subPAn1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.main1.ResumeLayout(false);
            this.main1.PerformLayout();
            this.mainPan.ResumeLayout(false);
            this.mainPan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPurchase;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.Panel mainInvoice;
        private System.Windows.Forms.Label txtChange;
        private System.Windows.Forms.Label txtCashTendered;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label txtItems;
        private System.Windows.Forms.Label subLabel5;
        private System.Windows.Forms.Label subLabel4;
        private System.Windows.Forms.Label subLabel6;
        private System.Windows.Forms.Label subLabel2;
        private System.Windows.Forms.Label lbl13;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lbl14;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label lbl11;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblProdDesc;
        private System.Windows.Forms.Label lbl10;
        private System.Windows.Forms.Panel subPAn1;
        private System.Windows.Forms.Button btnQuantity;
        private System.Windows.Forms.Button btnModTransaction;
        private System.Windows.Forms.Button btnProdSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnAcceptPayment;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Label txtDiscounted;
        private System.Windows.Forms.Label subLabel3;
        private System.Windows.Forms.Label txtDiscount;
        private System.Windows.Forms.Label subLabel7;
        private System.Windows.Forms.Label mainGreetings;
        private System.Windows.Forms.Label subLabel1;
        private System.Windows.Forms.Label txtOR;
        private System.Windows.Forms.Button btnUtilities;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnVoidReceipt;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel main1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label lbl12;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label txtAccount;
        private System.Windows.Forms.Label subLabel9;
        private System.Windows.Forms.Label txtChargeAmount;
        private System.Windows.Forms.Label subLabel10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtNow;
        private System.Windows.Forms.Button btnNow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Panel mainPan;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancelPayment;
        private System.Windows.Forms.Button btnLoadingStation;

    }
}