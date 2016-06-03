namespace AlreySolutions
{
    partial class frmSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetup));
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWSAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.dgvItemList = new System.Windows.Forms.DataGridView();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RetailAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WSAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalInventory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyRem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImgPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Critical = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openDlg = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearchString = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.subPan = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCapital = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkInStorage = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.btnRemoveInventory = new System.Windows.Forms.Button();
            this.dgvInventoryHistory = new System.Windows.Forms.DataGridView();
            this.DateAdded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCapital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelItemsRemaining = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCriticalLevel = new System.Windows.Forms.TextBox();
            this.chkDontDisplay = new System.Windows.Forms.CheckBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPurchases = new System.Windows.Forms.Button();
            this.btnPrintBarcode = new System.Windows.Forms.Button();
            this.btnChangeBarcode = new System.Windows.Forms.Button();
            this.mainPan = new System.Windows.Forms.Panel();
            this.dtInventory = new System.Windows.Forms.DateTimePicker();
            this.labelDate = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).BeginInit();
            this.subPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            this.mainPan.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBarcode
            // 
            this.txtBarcode.AcceptsReturn = true;
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.ForeColor = System.Drawing.Color.Black;
            this.txtBarcode.Location = new System.Drawing.Point(261, 9);
            this.txtBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(569, 27);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);
            this.txtBarcode.Leave += new System.EventHandler(this.txtBarcode_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Bar Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Description";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.ForeColor = System.Drawing.Color.Black;
            this.txtDesc.Location = new System.Drawing.Point(261, 63);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(569, 27);
            this.txtDesc.TabIndex = 1;
            this.txtDesc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDesc_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(492, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Retail Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.ForeColor = System.Drawing.Color.Black;
            this.txtAmount.Location = new System.Drawing.Point(661, 97);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(169, 27);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValidateValue_KeyDown);
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnOk.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(126, 331);
            this.btnOk.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(124, 49);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "&Save";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnSaveProductItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnCancel.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(716, 331);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(124, 49);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(15, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "WholeSale Amount";
            // 
            // txtWSAmount
            // 
            this.txtWSAmount.BackColor = System.Drawing.Color.White;
            this.txtWSAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWSAmount.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWSAmount.ForeColor = System.Drawing.Color.Black;
            this.txtWSAmount.Location = new System.Drawing.Point(261, 128);
            this.txtWSAmount.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtWSAmount.Name = "txtWSAmount";
            this.txtWSAmount.Size = new System.Drawing.Size(221, 27);
            this.txtWSAmount.TabIndex = 4;
            this.txtWSAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValidateValue_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(15, 155);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Total Quantity";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.White;
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Enabled = false;
            this.txtTotalQty.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.ForeColor = System.Drawing.Color.Black;
            this.txtTotalQty.Location = new System.Drawing.Point(261, 162);
            this.txtTotalQty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(221, 27);
            this.txtTotalQty.TabIndex = 5;
            this.txtTotalQty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValidateValue_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(15, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Image Path";
            // 
            // txtImagePath
            // 
            this.txtImagePath.BackColor = System.Drawing.Color.White;
            this.txtImagePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImagePath.Font = new System.Drawing.Font("Century Schoolbook", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImagePath.ForeColor = System.Drawing.Color.Black;
            this.txtImagePath.Location = new System.Drawing.Point(261, 234);
            this.txtImagePath.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtImagePath.Multiline = true;
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.ReadOnly = true;
            this.txtImagePath.Size = new System.Drawing.Size(466, 66);
            this.txtImagePath.TabIndex = 7;
            this.txtImagePath.TextChanged += new System.EventHandler(this.txtImagePath_TextChanged);
            this.txtImagePath.Enter += new System.EventHandler(this.txtImagePath_Enter);
            this.txtImagePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtImagePath_KeyDown);
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.SteelBlue;
            this.btnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnBrowse.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ForeColor = System.Drawing.Color.White;
            this.btnBrowse.Location = new System.Drawing.Point(737, 234);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(113, 29);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // dgvItemList
            // 
            this.dgvItemList.AllowUserToAddRows = false;
            this.dgvItemList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvItemList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItemList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItemList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvItemList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvItemList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvItemList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvItemList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgvItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItemList.ColumnHeadersHeight = 50;
            this.dgvItemList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Barcode,
            this.Description,
            this.Capital,
            this.RetailAmount,
            this.WSAmount,
            this.TotalInventory,
            this.Unit,
            this.QtyRem,
            this.ImgPath,
            this.Critical,
            this.Category});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItemList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItemList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvItemList.Location = new System.Drawing.Point(6, 49);
            this.dgvItemList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgvItemList.MultiSelect = false;
            this.dgvItemList.Name = "dgvItemList";
            this.dgvItemList.ReadOnly = true;
            this.dgvItemList.RowTemplate.Height = 24;
            this.dgvItemList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItemList.Size = new System.Drawing.Size(1319, 277);
            this.dgvItemList.TabIndex = 22;
            this.dgvItemList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellClick);
            this.dgvItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPurchase_CellContentClick);
            this.dgvItemList.SelectionChanged += new System.EventHandler(this.dgvPurchase_SelectionChanged);
            // 
            // Barcode
            // 
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Capital
            // 
            this.Capital.HeaderText = "Capital";
            this.Capital.Name = "Capital";
            this.Capital.ReadOnly = true;
            // 
            // RetailAmount
            // 
            this.RetailAmount.HeaderText = "Retail Amount";
            this.RetailAmount.Name = "RetailAmount";
            this.RetailAmount.ReadOnly = true;
            // 
            // WSAmount
            // 
            this.WSAmount.HeaderText = "Wholesale Amount";
            this.WSAmount.Name = "WSAmount";
            this.WSAmount.ReadOnly = true;
            // 
            // TotalInventory
            // 
            this.TotalInventory.HeaderText = "Total Inventory";
            this.TotalInventory.Name = "TotalInventory";
            this.TotalInventory.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // QtyRem
            // 
            this.QtyRem.HeaderText = "Qty Remaining";
            this.QtyRem.Name = "QtyRem";
            this.QtyRem.ReadOnly = true;
            // 
            // ImgPath
            // 
            this.ImgPath.HeaderText = "Image";
            this.ImgPath.Name = "ImgPath";
            this.ImgPath.ReadOnly = true;
            // 
            // Critical
            // 
            this.Critical.HeaderText = "Critical";
            this.Critical.Name = "Critical";
            this.Critical.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // openDlg
            // 
            this.openDlg.Filter = "JPEG|*.jpg|GIF|*.gif";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(5, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 19);
            this.label7.TabIndex = 24;
            this.label7.Text = "Product Search";
            // 
            // txtSearchString
            // 
            this.txtSearchString.AcceptsReturn = true;
            this.txtSearchString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchString.BackColor = System.Drawing.Color.White;
            this.txtSearchString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchString.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchString.ForeColor = System.Drawing.Color.Black;
            this.txtSearchString.Location = new System.Drawing.Point(208, 8);
            this.txtSearchString.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSearchString.Name = "txtSearchString";
            this.txtSearchString.Size = new System.Drawing.Size(960, 27);
            this.txtSearchString.TabIndex = 23;
            this.txtSearchString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchString_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Red;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnSearch.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1176, 8);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(149, 32);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // subPan
            // 
            this.subPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subPan.BackColor = System.Drawing.Color.SteelBlue;
            this.subPan.Controls.Add(this.label7);
            this.subPan.Controls.Add(this.btnSearch);
            this.subPan.Controls.Add(this.dgvItemList);
            this.subPan.Controls.Add(this.txtSearchString);
            this.subPan.Location = new System.Drawing.Point(5, 389);
            this.subPan.Name = "subPan";
            this.subPan.Size = new System.Drawing.Size(1331, 331);
            this.subPan.TabIndex = 26;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Tomato;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnAdd.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(856, 176);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 32);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAddInventory_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(15, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "Capital Amount";
            // 
            // txtCapital
            // 
            this.txtCapital.BackColor = System.Drawing.Color.White;
            this.txtCapital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCapital.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCapital.ForeColor = System.Drawing.Color.Black;
            this.txtCapital.Location = new System.Drawing.Point(261, 95);
            this.txtCapital.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCapital.Name = "txtCapital";
            this.txtCapital.Size = new System.Drawing.Size(221, 27);
            this.txtCapital.TabIndex = 2;
            this.txtCapital.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValidateValue_KeyDown);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnClear.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(737, 271);
            this.btnClear.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(113, 29);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkInStorage
            // 
            this.chkInStorage.AutoSize = true;
            this.chkInStorage.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInStorage.ForeColor = System.Drawing.Color.White;
            this.chkInStorage.Location = new System.Drawing.Point(590, 131);
            this.chkInStorage.Name = "chkInStorage";
            this.chkInStorage.Size = new System.Drawing.Size(206, 30);
            this.chkInStorage.TabIndex = 8;
            this.chkInStorage.Text = "Item in Storage";
            this.chkInStorage.UseVisualStyleBackColor = true;
            this.chkInStorage.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 203);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 35;
            this.label9.Text = "Unit of Qty";
            // 
            // cboUnit
            // 
            this.cboUnit.Font = new System.Drawing.Font("Century Schoolbook", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Items.AddRange(new object[] {
            "pc",
            "m",
            "ft",
            "yrd",
            "kl"});
            this.cboUnit.Location = new System.Drawing.Point(261, 195);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(221, 34);
            this.cboUnit.TabIndex = 6;
            this.cboUnit.SelectedIndexChanged += new System.EventHandler(this.cboUnit_SelectedIndexChanged);
            // 
            // btnRemoveInventory
            // 
            this.btnRemoveInventory.BackColor = System.Drawing.Color.Tomato;
            this.btnRemoveInventory.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnRemoveInventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnRemoveInventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnRemoveInventory.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveInventory.ForeColor = System.Drawing.Color.White;
            this.btnRemoveInventory.Location = new System.Drawing.Point(939, 176);
            this.btnRemoveInventory.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRemoveInventory.Name = "btnRemoveInventory";
            this.btnRemoveInventory.Size = new System.Drawing.Size(84, 32);
            this.btnRemoveInventory.TabIndex = 39;
            this.btnRemoveInventory.Text = "Remove";
            this.btnRemoveInventory.UseVisualStyleBackColor = false;
            this.btnRemoveInventory.Click += new System.EventHandler(this.btnRemoveInventory_Click);
            // 
            // dgvInventoryHistory
            // 
            this.dgvInventoryHistory.AllowUserToAddRows = false;
            this.dgvInventoryHistory.AllowUserToDeleteRows = false;
            this.dgvInventoryHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventoryHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventoryHistory.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvInventoryHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventoryHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateAdded,
            this.Iqty,
            this.Icapital,
            this.TotalCapital,
            this.ExpiryDate,
            this.remarks});
            this.dgvInventoryHistory.Location = new System.Drawing.Point(854, 215);
            this.dgvInventoryHistory.Name = "dgvInventoryHistory";
            this.dgvInventoryHistory.ReadOnly = true;
            this.dgvInventoryHistory.Size = new System.Drawing.Size(482, 168);
            this.dgvInventoryHistory.TabIndex = 40;
            // 
            // DateAdded
            // 
            this.DateAdded.HeaderText = "Date Added";
            this.DateAdded.Name = "DateAdded";
            this.DateAdded.ReadOnly = true;
            // 
            // Iqty
            // 
            this.Iqty.HeaderText = "Quantity";
            this.Iqty.Name = "Iqty";
            this.Iqty.ReadOnly = true;
            // 
            // Icapital
            // 
            this.Icapital.HeaderText = "Capital per unit";
            this.Icapital.Name = "Icapital";
            this.Icapital.ReadOnly = true;
            // 
            // TotalCapital
            // 
            this.TotalCapital.HeaderText = "Total Capital";
            this.TotalCapital.Name = "TotalCapital";
            this.TotalCapital.ReadOnly = true;
            // 
            // ExpiryDate
            // 
            this.ExpiryDate.HeaderText = "Expiry Date";
            this.ExpiryDate.Name = "ExpiryDate";
            this.ExpiryDate.ReadOnly = true;
            // 
            // remarks
            // 
            this.remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remarks.HeaderText = "Remarks";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // labelItemsRemaining
            // 
            this.labelItemsRemaining.AutoSize = true;
            this.labelItemsRemaining.BackColor = System.Drawing.Color.Transparent;
            this.labelItemsRemaining.Font = new System.Drawing.Font("Century Schoolbook", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelItemsRemaining.ForeColor = System.Drawing.Color.White;
            this.labelItemsRemaining.Location = new System.Drawing.Point(255, 302);
            this.labelItemsRemaining.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelItemsRemaining.Name = "labelItemsRemaining";
            this.labelItemsRemaining.Size = new System.Drawing.Size(222, 25);
            this.labelItemsRemaining.TabIndex = 41;
            this.labelItemsRemaining.Text = "Items Remaining: 0";
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnNew.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(3, 331);
            this.btnNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(124, 49);
            this.btnNew.TabIndex = 43;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // picItem
            // 
            this.picItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picItem.BackColor = System.Drawing.Color.White;
            this.picItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picItem.ErrorImage = null;
            this.picItem.ImageLocation = "";
            this.picItem.InitialImage = null;
            this.picItem.Location = new System.Drawing.Point(854, 4);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(476, 171);
            this.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picItem.TabIndex = 27;
            this.picItem.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(491, 165);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(110, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Critical Level";
            // 
            // txtCriticalLevel
            // 
            this.txtCriticalLevel.BackColor = System.Drawing.Color.White;
            this.txtCriticalLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCriticalLevel.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCriticalLevel.ForeColor = System.Drawing.Color.Black;
            this.txtCriticalLevel.Location = new System.Drawing.Point(661, 162);
            this.txtCriticalLevel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCriticalLevel.Name = "txtCriticalLevel";
            this.txtCriticalLevel.Size = new System.Drawing.Size(169, 27);
            this.txtCriticalLevel.TabIndex = 44;
            // 
            // chkDontDisplay
            // 
            this.chkDontDisplay.AutoSize = true;
            this.chkDontDisplay.Checked = true;
            this.chkDontDisplay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDontDisplay.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDontDisplay.ForeColor = System.Drawing.Color.White;
            this.chkDontDisplay.Location = new System.Drawing.Point(20, 302);
            this.chkDontDisplay.Name = "chkDontDisplay";
            this.chkDontDisplay.Size = new System.Drawing.Size(191, 23);
            this.chkDontDisplay.TabIndex = 47;
            this.chkDontDisplay.Text = "Don\'t display Items";
            this.chkDontDisplay.UseVisualStyleBackColor = true;
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Century Schoolbook", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(580, 199);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(250, 24);
            this.cboCategory.TabIndex = 48;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(491, 199);
            this.label11.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 20);
            this.label11.TabIndex = 49;
            this.label11.Text = "Category";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnDelete.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(248, 331);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(124, 49);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPurchases
            // 
            this.btnPurchases.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPurchases.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPurchases.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPurchases.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnPurchases.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPurchases.ForeColor = System.Drawing.Color.White;
            this.btnPurchases.Location = new System.Drawing.Point(595, 331);
            this.btnPurchases.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPurchases.Name = "btnPurchases";
            this.btnPurchases.Size = new System.Drawing.Size(124, 49);
            this.btnPurchases.TabIndex = 51;
            this.btnPurchases.Text = "&Add Purchases";
            this.btnPurchases.UseVisualStyleBackColor = false;
            this.btnPurchases.Click += new System.EventHandler(this.btnPurchases_Click);
            // 
            // btnPrintBarcode
            // 
            this.btnPrintBarcode.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrintBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPrintBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnPrintBarcode.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBarcode.ForeColor = System.Drawing.Color.White;
            this.btnPrintBarcode.Location = new System.Drawing.Point(482, 331);
            this.btnPrintBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPrintBarcode.Name = "btnPrintBarcode";
            this.btnPrintBarcode.Size = new System.Drawing.Size(114, 49);
            this.btnPrintBarcode.TabIndex = 52;
            this.btnPrintBarcode.Text = "&Print Barcode";
            this.btnPrintBarcode.UseVisualStyleBackColor = false;
            this.btnPrintBarcode.Click += new System.EventHandler(this.btnPrintBarcode_Click);
            // 
            // btnChangeBarcode
            // 
            this.btnChangeBarcode.BackColor = System.Drawing.Color.SteelBlue;
            this.btnChangeBarcode.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnChangeBarcode.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnChangeBarcode.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnChangeBarcode.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeBarcode.ForeColor = System.Drawing.Color.White;
            this.btnChangeBarcode.Location = new System.Drawing.Point(369, 331);
            this.btnChangeBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnChangeBarcode.Name = "btnChangeBarcode";
            this.btnChangeBarcode.Size = new System.Drawing.Size(114, 49);
            this.btnChangeBarcode.TabIndex = 53;
            this.btnChangeBarcode.Text = "&Change Barcode";
            this.btnChangeBarcode.UseVisualStyleBackColor = false;
            this.btnChangeBarcode.Click += new System.EventHandler(this.btnChangeBarcode_Click);
            // 
            // mainPan
            // 
            this.mainPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPan.Controls.Add(this.label12);
            this.mainPan.Controls.Add(this.dtInventory);
            this.mainPan.Controls.Add(this.labelDate);
            this.mainPan.Controls.Add(this.btnChangeBarcode);
            this.mainPan.Controls.Add(this.label1);
            this.mainPan.Controls.Add(this.btnPrintBarcode);
            this.mainPan.Controls.Add(this.picItem);
            this.mainPan.Controls.Add(this.btnPurchases);
            this.mainPan.Controls.Add(this.txtBarcode);
            this.mainPan.Controls.Add(this.cboCategory);
            this.mainPan.Controls.Add(this.txtDesc);
            this.mainPan.Controls.Add(this.label11);
            this.mainPan.Controls.Add(this.label2);
            this.mainPan.Controls.Add(this.chkDontDisplay);
            this.mainPan.Controls.Add(this.txtAmount);
            this.mainPan.Controls.Add(this.label10);
            this.mainPan.Controls.Add(this.label3);
            this.mainPan.Controls.Add(this.txtCriticalLevel);
            this.mainPan.Controls.Add(this.btnOk);
            this.mainPan.Controls.Add(this.btnNew);
            this.mainPan.Controls.Add(this.btnCancel);
            this.mainPan.Controls.Add(this.labelItemsRemaining);
            this.mainPan.Controls.Add(this.btnDelete);
            this.mainPan.Controls.Add(this.dgvInventoryHistory);
            this.mainPan.Controls.Add(this.txtWSAmount);
            this.mainPan.Controls.Add(this.btnRemoveInventory);
            this.mainPan.Controls.Add(this.label5);
            this.mainPan.Controls.Add(this.cboUnit);
            this.mainPan.Controls.Add(this.txtTotalQty);
            this.mainPan.Controls.Add(this.label9);
            this.mainPan.Controls.Add(this.label4);
            this.mainPan.Controls.Add(this.chkInStorage);
            this.mainPan.Controls.Add(this.txtImagePath);
            this.mainPan.Controls.Add(this.btnClear);
            this.mainPan.Controls.Add(this.label6);
            this.mainPan.Controls.Add(this.label8);
            this.mainPan.Controls.Add(this.btnBrowse);
            this.mainPan.Controls.Add(this.txtCapital);
            this.mainPan.Controls.Add(this.subPan);
            this.mainPan.Controls.Add(this.btnAdd);
            this.mainPan.Location = new System.Drawing.Point(0, 0);
            this.mainPan.Name = "mainPan";
            this.mainPan.Size = new System.Drawing.Size(1353, 732);
            this.mainPan.TabIndex = 54;
            // 
            // dtInventory
            // 
            this.dtInventory.Location = new System.Drawing.Point(1089, 181);
            this.dtInventory.Name = "dtInventory";
            this.dtInventory.Size = new System.Drawing.Size(200, 21);
            this.dtInventory.TabIndex = 55;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDate.ForeColor = System.Drawing.Color.White;
            this.labelDate.Location = new System.Drawing.Point(1033, 181);
            this.labelDate.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(48, 19);
            this.labelDate.TabIndex = 54;
            this.labelDate.Text = "Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Century Schoolbook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(257, 40);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(293, 20);
            this.label12.TabIndex = 56;
            this.label12.Text = "Brand | Item Description |  Vol \\ Size";
            // 
            // frmSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1348, 733);
            this.Controls.Add(this.mainPan);
            this.Font = new System.Drawing.Font("Century Schoolbook", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            this.Activated += new System.EventHandler(this.frmSetup_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSetup_FormClosing);
            this.Load += new System.EventHandler(this.frmSetup_Load);
            this.Shown += new System.EventHandler(this.frmSetup_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemList)).EndInit();
            this.subPan.ResumeLayout(false);
            this.subPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventoryHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            this.mainPan.ResumeLayout(false);
            this.mainPan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWSAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtImagePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView dgvItemList;
        private System.Windows.Forms.OpenFileDialog openDlg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearchString;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel subPan;
        private System.Windows.Forms.PictureBox picItem;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCapital;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox chkInStorage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Button btnRemoveInventory;
        private System.Windows.Forms.DataGridView dgvInventoryHistory;
        private System.Windows.Forms.Label labelItemsRemaining;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCriticalLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateAdded;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Icapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCapital;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpiryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.CheckBox chkDontDisplay;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capital;
        private System.Windows.Forms.DataGridViewTextBoxColumn RetailAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn WSAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyRem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImgPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Critical;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnPurchases;
        private System.Windows.Forms.Button btnPrintBarcode;
        private System.Windows.Forms.Button btnChangeBarcode;
        private System.Windows.Forms.Panel mainPan;
        private System.Windows.Forms.DateTimePicker dtInventory;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label label12;
    }
}