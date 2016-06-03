namespace Kawayanan
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.lblTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnSummary = new System.Windows.Forms.Button();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnRetrieve = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.radRemove = new System.Windows.Forms.RadioButton();
            this.radAdd = new System.Windows.Forms.RadioButton();
            this.lblChange = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCash = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblOR = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnA = new System.Windows.Forms.Button();
            this.btnROASTA = new System.Windows.Forms.Button();
            this.btnRCHICKEN = new System.Windows.Forms.Button();
            this.btnX4 = new System.Windows.Forms.Button();
            this.btnX2 = new System.Windows.Forms.Button();
            this.btnX1 = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.btnAIT = new System.Windows.Forms.Button();
            this.btnRoastAIT = new System.Windows.Forms.Button();
            this.lstPending = new System.Windows.Forms.ListBox();
            this.btnSPARKLE = new System.Windows.Forms.Button();
            this.btnPANCIT = new System.Windows.Forms.Button();
            this.btnM1 = new System.Windows.Forms.Button();
            this.btnM2 = new System.Windows.Forms.Button();
            this.lstItems = new System.Windows.Forms.ListBox();
            this.btnCAM = new System.Windows.Forms.Button();
            this.btnRAM = new System.Windows.Forms.Button();
            this.btnMineral = new System.Windows.Forms.Button();
            this.btnThankYou = new System.Windows.Forms.Button();
            this.btnGoodDay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.picAd = new System.Windows.Forms.PictureBox();
            this.cboName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAd)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.LimeGreen;
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTotal.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTotal.Location = new System.Drawing.Point(187, 591);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(191, 51);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "P 90.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Broadway", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Lime;
            this.label8.Location = new System.Drawing.Point(33, 594);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 32);
            this.label8.TabIndex = 27;
            this.label8.Text = "Total";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Description,
            this.Amount,
            this.Qty,
            this.SubTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Baskerville Old Face", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Location = new System.Drawing.Point(13, 352);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Baskerville Old Face", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(566, 136);
            this.dgv.TabIndex = 29;
            this.dgv.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellEnter);
            this.dgv.SelectionChanged += new System.EventHandler(this.dgv_SelectionChanged);
            this.dgv.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstOrders_KeyDown);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Code";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 70;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 200;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 50;
            // 
            // SubTotal
            // 
            this.SubTotal.HeaderText = "Sub Total";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSettings.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.Location = new System.Drawing.Point(412, 58);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(100, 40);
            this.btnSettings.TabIndex = 37;
            this.btnSettings.Text = "Settings (F11)";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.Color.Black;
            this.btnPrint.Location = new System.Drawing.Point(312, 58);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 40);
            this.btnPrint.TabIndex = 36;
            this.btnPrint.Text = "Print (F10)";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnSummary
            // 
            this.btnSummary.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSummary.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummary.ForeColor = System.Drawing.Color.Black;
            this.btnSummary.Location = new System.Drawing.Point(212, 58);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Size = new System.Drawing.Size(100, 40);
            this.btnSummary.TabIndex = 35;
            this.btnSummary.Text = "Summary (F9)";
            this.btnSummary.UseVisualStyleBackColor = false;
            this.btnSummary.Click += new System.EventHandler(this.btnSummary_Click);
            // 
            // btnSetup
            // 
            this.btnSetup.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSetup.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.ForeColor = System.Drawing.Color.Black;
            this.btnSetup.Location = new System.Drawing.Point(112, 58);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(100, 40);
            this.btnSetup.TabIndex = 34;
            this.btnSetup.Text = "Setup Barcode (F8)";
            this.btnSetup.UseVisualStyleBackColor = false;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnRetrieve
            // 
            this.btnRetrieve.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRetrieve.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetrieve.ForeColor = System.Drawing.Color.Black;
            this.btnRetrieve.Location = new System.Drawing.Point(313, 12);
            this.btnRetrieve.Name = "btnRetrieve";
            this.btnRetrieve.Size = new System.Drawing.Size(100, 40);
            this.btnRetrieve.TabIndex = 32;
            this.btnRetrieve.Text = "Retrieve Order (F5)";
            this.btnRetrieve.UseVisualStyleBackColor = false;
            this.btnRetrieve.Click += new System.EventHandler(this.btnRetrieve_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCancel.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(213, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Quantity (F4)";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAccept.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.Black;
            this.btnAccept.Location = new System.Drawing.Point(113, 12);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 40);
            this.btnAccept.TabIndex = 31;
            this.btnAccept.Text = "Accept Order (F3)";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNewCustomer.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCustomer.ForeColor = System.Drawing.Color.Black;
            this.btnNewCustomer.Location = new System.Drawing.Point(13, 12);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.Size = new System.Drawing.Size(100, 40);
            this.btnNewCustomer.TabIndex = 30;
            this.btnNewCustomer.Text = "New Customer (F2)";
            this.btnNewCustomer.UseVisualStyleBackColor = false;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // radRemove
            // 
            this.radRemove.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRemove.BackColor = System.Drawing.Color.SteelBlue;
            this.radRemove.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRemove.ForeColor = System.Drawing.Color.Black;
            this.radRemove.Location = new System.Drawing.Point(13, 58);
            this.radRemove.Name = "radRemove";
            this.radRemove.Size = new System.Drawing.Size(100, 40);
            this.radRemove.TabIndex = 39;
            this.radRemove.Text = "Remove Items (F7)";
            this.radRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRemove.UseVisualStyleBackColor = false;
            this.radRemove.Click += new System.EventHandler(this.radAdd_CheckedChanged);
            // 
            // radAdd
            // 
            this.radAdd.Appearance = System.Windows.Forms.Appearance.Button;
            this.radAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.radAdd.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAdd.ForeColor = System.Drawing.Color.Black;
            this.radAdd.Location = new System.Drawing.Point(413, 12);
            this.radAdd.Name = "radAdd";
            this.radAdd.Size = new System.Drawing.Size(100, 40);
            this.radAdd.TabIndex = 38;
            this.radAdd.Text = "Add Items (F6)";
            this.radAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radAdd.UseVisualStyleBackColor = false;
            this.radAdd.Click += new System.EventHandler(this.radAdd_CheckedChanged);
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.LimeGreen;
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblChange.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(187, 718);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(191, 40);
            this.lblChange.TabIndex = 43;
            this.lblChange.Text = "P 10.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Broadway", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Lime;
            this.label10.Location = new System.Drawing.Point(34, 719);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 32);
            this.label10.TabIndex = 41;
            this.label10.Text = "Change";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCash
            // 
            this.lblCash.BackColor = System.Drawing.Color.LimeGreen;
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCash.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCash.Location = new System.Drawing.Point(187, 660);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(191, 43);
            this.lblCash.TabIndex = 42;
            this.lblCash.Text = "P 100.00";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Broadway", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Lime;
            this.label7.Location = new System.Drawing.Point(34, 660);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 32);
            this.label7.TabIndex = 40;
            this.label7.Text = "Cash";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(9, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 19);
            this.label5.TabIndex = 47;
            this.label5.Text = "Enter BarCode";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtInput
            // 
            this.txtInput.BackColor = System.Drawing.Color.LimeGreen;
            this.txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInput.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ForeColor = System.Drawing.Color.Snow;
            this.txtInput.Location = new System.Drawing.Point(149, 157);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(208, 26);
            this.txtInput.TabIndex = 1;
            this.txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            // 
            // lblQuantity
            // 
            this.lblQuantity.BackColor = System.Drawing.Color.Lime;
            this.lblQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(224, 535);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(154, 46);
            this.lblQuantity.TabIndex = 53;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.Lime;
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAmount.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(21, 535);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(197, 46);
            this.lblAmount.TabIndex = 52;
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.BackColor = System.Drawing.Color.Lime;
            this.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescription.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(14, 304);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(565, 46);
            this.lblDescription.TabIndex = 51;
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Broadway", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(219, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "Quantity";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Broadway", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(21, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 24);
            this.label3.TabIndex = 49;
            this.label3.Text = "Amount";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Broadway", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 24);
            this.label2.TabIndex = 48;
            this.label2.Text = "Item Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblOR
            // 
            this.lblOR.AutoSize = true;
            this.lblOR.BackColor = System.Drawing.Color.Transparent;
            this.lblOR.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOR.ForeColor = System.Drawing.Color.White;
            this.lblOR.Location = new System.Drawing.Point(12, 192);
            this.lblOR.Name = "lblOR";
            this.lblOR.Size = new System.Drawing.Size(179, 19);
            this.lblOR.TabIndex = 55;
            this.lblOR.Text = "Official Receipt No.:";
            this.lblOR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.BackColor = System.Drawing.Color.Transparent;
            this.lblCustomer.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomer.ForeColor = System.Drawing.Color.White;
            this.lblCustomer.Location = new System.Drawing.Point(11, 224);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(99, 19);
            this.lblCustomer.TabIndex = 57;
            this.lblCustomer.Text = "Customer:";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.BackColor = System.Drawing.Color.Transparent;
            this.lblTable.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.White;
            this.lblTable.Location = new System.Drawing.Point(11, 250);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(65, 19);
            this.lblTable.TabIndex = 58;
            this.lblTable.Text = "Table:";
            this.lblTable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.Color.Red;
            this.btnA.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnA.ForeColor = System.Drawing.Color.Black;
            this.btnA.Location = new System.Drawing.Point(3, 3);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(104, 50);
            this.btnA.TabIndex = 59;
            this.btnA.Text = "CHICK A SPARKLE";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Visible = false;
            this.btnA.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnROASTA
            // 
            this.btnROASTA.BackColor = System.Drawing.Color.SpringGreen;
            this.btnROASTA.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnROASTA.ForeColor = System.Drawing.Color.Black;
            this.btnROASTA.Location = new System.Drawing.Point(3, 52);
            this.btnROASTA.Name = "btnROASTA";
            this.btnROASTA.Size = new System.Drawing.Size(104, 50);
            this.btnROASTA.TabIndex = 63;
            this.btnROASTA.Text = "ROAST A SPARKLE";
            this.btnROASTA.UseVisualStyleBackColor = false;
            this.btnROASTA.Visible = false;
            this.btnROASTA.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRCHICKEN
            // 
            this.btnRCHICKEN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRCHICKEN.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRCHICKEN.ForeColor = System.Drawing.Color.Black;
            this.btnRCHICKEN.Location = new System.Drawing.Point(310, 52);
            this.btnRCHICKEN.Name = "btnRCHICKEN";
            this.btnRCHICKEN.Size = new System.Drawing.Size(104, 50);
            this.btnRCHICKEN.TabIndex = 74;
            this.btnRCHICKEN.Text = "Roast Chicken";
            this.btnRCHICKEN.UseVisualStyleBackColor = false;
            this.btnRCHICKEN.Visible = false;
            this.btnRCHICKEN.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnX4
            // 
            this.btnX4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnX4.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX4.ForeColor = System.Drawing.Color.Black;
            this.btnX4.Location = new System.Drawing.Point(104, 150);
            this.btnX4.Name = "btnX4";
            this.btnX4.Size = new System.Drawing.Size(104, 50);
            this.btnX4.TabIndex = 73;
            this.btnX4.Text = "Large Iced Tea";
            this.btnX4.UseVisualStyleBackColor = false;
            this.btnX4.Visible = false;
            this.btnX4.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnX2
            // 
            this.btnX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnX2.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX2.ForeColor = System.Drawing.Color.Black;
            this.btnX2.Location = new System.Drawing.Point(3, 150);
            this.btnX2.Name = "btnX2";
            this.btnX2.Size = new System.Drawing.Size(104, 50);
            this.btnX2.TabIndex = 71;
            this.btnX2.Text = "Regular Rice";
            this.btnX2.UseVisualStyleBackColor = false;
            this.btnX2.Visible = false;
            this.btnX2.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnX1
            // 
            this.btnX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnX1.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX1.ForeColor = System.Drawing.Color.Black;
            this.btnX1.Location = new System.Drawing.Point(310, 3);
            this.btnX1.Name = "btnX1";
            this.btnX1.Size = new System.Drawing.Size(104, 50);
            this.btnX1.TabIndex = 70;
            this.btnX1.Text = "Chicken";
            this.btnX1.UseVisualStyleBackColor = false;
            this.btnX1.Visible = false;
            this.btnX1.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.BackColor = System.Drawing.Color.SteelBlue;
            this.btnInventory.Font = new System.Drawing.Font("Lucida Bright", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.ForeColor = System.Drawing.Color.Black;
            this.btnInventory.Location = new System.Drawing.Point(12, 104);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(100, 40);
            this.btnInventory.TabIndex = 88;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = false;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // btnAIT
            // 
            this.btnAIT.BackColor = System.Drawing.Color.Red;
            this.btnAIT.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAIT.ForeColor = System.Drawing.Color.Black;
            this.btnAIT.Location = new System.Drawing.Point(105, 3);
            this.btnAIT.Name = "btnAIT";
            this.btnAIT.Size = new System.Drawing.Size(104, 50);
            this.btnAIT.TabIndex = 90;
            this.btnAIT.Text = "CHICK A ICEDTEA";
            this.btnAIT.UseVisualStyleBackColor = false;
            this.btnAIT.Visible = false;
            this.btnAIT.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRoastAIT
            // 
            this.btnRoastAIT.BackColor = System.Drawing.Color.SpringGreen;
            this.btnRoastAIT.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoastAIT.ForeColor = System.Drawing.Color.Black;
            this.btnRoastAIT.Location = new System.Drawing.Point(105, 52);
            this.btnRoastAIT.Name = "btnRoastAIT";
            this.btnRoastAIT.Size = new System.Drawing.Size(104, 50);
            this.btnRoastAIT.TabIndex = 92;
            this.btnRoastAIT.Text = "ROAST A ICEDTEA";
            this.btnRoastAIT.UseVisualStyleBackColor = false;
            this.btnRoastAIT.Visible = false;
            this.btnRoastAIT.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lstPending
            // 
            this.lstPending.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lstPending.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstPending.Font = new System.Drawing.Font("Californian FB", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstPending.ForeColor = System.Drawing.Color.Black;
            this.lstPending.FormattingEnabled = true;
            this.lstPending.ItemHeight = 24;
            this.lstPending.Location = new System.Drawing.Point(420, 3);
            this.lstPending.MultiColumn = true;
            this.lstPending.Name = "lstPending";
            this.lstPending.Size = new System.Drawing.Size(156, 194);
            this.lstPending.TabIndex = 95;
            this.lstPending.Visible = false;

            // 
            // btnSPARKLE
            // 
            this.btnSPARKLE.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSPARKLE.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSPARKLE.ForeColor = System.Drawing.Color.Black;
            this.btnSPARKLE.Location = new System.Drawing.Point(3, 101);
            this.btnSPARKLE.Name = "btnSPARKLE";
            this.btnSPARKLE.Size = new System.Drawing.Size(104, 50);
            this.btnSPARKLE.TabIndex = 96;
            this.btnSPARKLE.Text = "SoftDrink";
            this.btnSPARKLE.UseVisualStyleBackColor = false;
            this.btnSPARKLE.Visible = false;
            this.btnSPARKLE.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnPANCIT
            // 
            this.btnPANCIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPANCIT.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPANCIT.ForeColor = System.Drawing.Color.Black;
            this.btnPANCIT.Location = new System.Drawing.Point(105, 101);
            this.btnPANCIT.Name = "btnPANCIT";
            this.btnPANCIT.Size = new System.Drawing.Size(104, 50);
            this.btnPANCIT.TabIndex = 97;
            this.btnPANCIT.Text = "Pancit";
            this.btnPANCIT.UseVisualStyleBackColor = false;
            this.btnPANCIT.Visible = false;
            this.btnPANCIT.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnM1
            // 
            this.btnM1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnM1.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM1.ForeColor = System.Drawing.Color.Black;
            this.btnM1.Location = new System.Drawing.Point(208, 101);
            this.btnM1.Name = "btnM1";
            this.btnM1.Size = new System.Drawing.Size(104, 50);
            this.btnM1.TabIndex = 98;
            this.btnM1.Text = "HALO2";
            this.btnM1.UseVisualStyleBackColor = false;
            this.btnM1.Visible = false;
            this.btnM1.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnM2
            // 
            this.btnM2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnM2.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM2.ForeColor = System.Drawing.Color.Black;
            this.btnM2.Location = new System.Drawing.Point(310, 101);
            this.btnM2.Name = "btnM2";
            this.btnM2.Size = new System.Drawing.Size(104, 50);
            this.btnM2.TabIndex = 99;
            this.btnM2.Text = "SAGING";
            this.btnM2.UseVisualStyleBackColor = false;
            this.btnM2.Visible = false;
            this.btnM2.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // lstItems
            // 
            this.lstItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstItems.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstItems.ColumnWidth = 30;
            this.lstItems.Font = new System.Drawing.Font("Californian FB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstItems.ForeColor = System.Drawing.Color.Black;
            this.lstItems.FormattingEnabled = true;
            this.lstItems.ItemHeight = 16;
            this.lstItems.Location = new System.Drawing.Point(3, 213);
            this.lstItems.MultiColumn = true;
            this.lstItems.Name = "lstItems";
            this.lstItems.Size = new System.Drawing.Size(526, 194);
            this.lstItems.TabIndex = 100;
            this.lstItems.Visible = false;
            this.lstItems.SelectedIndexChanged += new System.EventHandler(this.lstItems_SelectedIndexChanged);
            // 
            // btnCAM
            // 
            this.btnCAM.BackColor = System.Drawing.Color.Red;
            this.btnCAM.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCAM.ForeColor = System.Drawing.Color.Black;
            this.btnCAM.Location = new System.Drawing.Point(208, 3);
            this.btnCAM.Name = "btnCAM";
            this.btnCAM.Size = new System.Drawing.Size(104, 50);
            this.btnCAM.TabIndex = 101;
            this.btnCAM.Text = "CHICK A MINERAL";
            this.btnCAM.UseVisualStyleBackColor = false;
            this.btnCAM.Visible = false;
            this.btnCAM.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnRAM
            // 
            this.btnRAM.BackColor = System.Drawing.Color.SpringGreen;
            this.btnRAM.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRAM.ForeColor = System.Drawing.Color.Black;
            this.btnRAM.Location = new System.Drawing.Point(208, 52);
            this.btnRAM.Name = "btnRAM";
            this.btnRAM.Size = new System.Drawing.Size(104, 50);
            this.btnRAM.TabIndex = 102;
            this.btnRAM.Text = "ROAST A MINERAL";
            this.btnRAM.UseVisualStyleBackColor = false;
            this.btnRAM.Visible = false;
            this.btnRAM.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnMineral
            // 
            this.btnMineral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnMineral.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMineral.ForeColor = System.Drawing.Color.Black;
            this.btnMineral.Location = new System.Drawing.Point(207, 150);
            this.btnMineral.Name = "btnMineral";
            this.btnMineral.Size = new System.Drawing.Size(104, 50);
            this.btnMineral.TabIndex = 103;
            this.btnMineral.Text = "Mineral";
            this.btnMineral.UseVisualStyleBackColor = false;
            this.btnMineral.Visible = false;
            this.btnMineral.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnThankYou
            // 
            this.btnThankYou.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnThankYou.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThankYou.ForeColor = System.Drawing.Color.Black;
            this.btnThankYou.Location = new System.Drawing.Point(73, 21);
            this.btnThankYou.Name = "btnThankYou";
            this.btnThankYou.Size = new System.Drawing.Size(104, 50);
            this.btnThankYou.TabIndex = 104;
            this.btnThankYou.Text = "Thank You";
            this.btnThankYou.UseVisualStyleBackColor = false;
            this.btnThankYou.Click += new System.EventHandler(this.btnThankYou_Click);
            // 
            // btnGoodDay
            // 
            this.btnGoodDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGoodDay.Font = new System.Drawing.Font("Broadway", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoodDay.ForeColor = System.Drawing.Color.Black;
            this.btnGoodDay.Location = new System.Drawing.Point(36, 21);
            this.btnGoodDay.Name = "btnGoodDay";
            this.btnGoodDay.Size = new System.Drawing.Size(104, 50);
            this.btnGoodDay.TabIndex = 105;
            this.btnGoodDay.Text = "Good Day";
            this.btnGoodDay.UseVisualStyleBackColor = false;
            this.btnGoodDay.Click += new System.EventHandler(this.btnGoodDay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnA);
            this.panel1.Controls.Add(this.btnGoodDay);
            this.panel1.Controls.Add(this.btnROASTA);
            this.panel1.Controls.Add(this.btnThankYou);
            this.panel1.Controls.Add(this.btnX1);
            this.panel1.Controls.Add(this.btnMineral);
            this.panel1.Controls.Add(this.btnX2);
            this.panel1.Controls.Add(this.btnRAM);
            this.panel1.Controls.Add(this.btnX4);
            this.panel1.Controls.Add(this.btnCAM);
            this.panel1.Controls.Add(this.btnRCHICKEN);
            this.panel1.Controls.Add(this.lstItems);
            this.panel1.Controls.Add(this.btnAIT);
            this.panel1.Controls.Add(this.btnM2);
            this.panel1.Controls.Add(this.btnRoastAIT);
            this.panel1.Controls.Add(this.btnM1);
            this.panel1.Controls.Add(this.lstPending);
            this.panel1.Controls.Add(this.btnPANCIT);
            this.panel1.Controls.Add(this.btnSPARKLE);
            this.panel1.Location = new System.Drawing.Point(819, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(153, 86);
            this.panel1.TabIndex = 106;
            this.panel1.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // picAd
            // 
            this.picAd.Image = ((System.Drawing.Image)(resources.GetObject("picAd.Image")));
            this.picAd.Location = new System.Drawing.Point(624, 12);
            this.picAd.Name = "picAd";
            this.picAd.Size = new System.Drawing.Size(1017, 776);
            this.picAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAd.TabIndex = 106;
            this.picAd.TabStop = false;
            // 
            // cboName
            // 
            this.cboName.BackColor = System.Drawing.Color.Lime;
            this.cboName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboName.FormattingEnabled = true;
            this.cboName.Location = new System.Drawing.Point(149, 214);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(208, 30);
            this.cboName.Sorted = true;
            this.cboName.TabIndex = 108;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.cboName_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Kawayanan.Properties.Resources.silver_stainless_steel_mesh1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1436, 861);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.picAd);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.lblOR);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblChange);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCash);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radRemove);
            this.Controls.Add(this.radAdd);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSummary);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnRetrieve);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.Enter += new System.EventHandler(this.Main_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInput_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnSummary;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnRetrieve;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.RadioButton radRemove;
        private System.Windows.Forms.RadioButton radAdd;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnROASTA;
        private System.Windows.Forms.Button btnRCHICKEN;
        private System.Windows.Forms.Button btnX4;
        private System.Windows.Forms.Button btnX2;
        private System.Windows.Forms.Button btnX1;
        private System.Windows.Forms.Button btnInventory;
        private System.Windows.Forms.Button btnAIT;
        private System.Windows.Forms.Button btnRoastAIT;
        private System.Windows.Forms.ListBox lstPending;
        private System.Windows.Forms.Button btnSPARKLE;
        private System.Windows.Forms.Button btnPANCIT;
        private System.Windows.Forms.Button btnM1;
        private System.Windows.Forms.Button btnM2;
        private System.Windows.Forms.ListBox lstItems;
        private System.Windows.Forms.Button btnCAM;
        private System.Windows.Forms.Button btnRAM;
        private System.Windows.Forms.Button btnMineral;
        private System.Windows.Forms.Button btnThankYou;
        private System.Windows.Forms.Button btnGoodDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picAd;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ComboBox cboName;
    }
}