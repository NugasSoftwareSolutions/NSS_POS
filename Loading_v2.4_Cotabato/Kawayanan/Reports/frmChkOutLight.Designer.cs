namespace AlreySolutions
{
    partial class frmChkOutLight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChkOutLight));
            this.label1 = new System.Windows.Forms.Label();
            this.dtPickStart = new System.Windows.Forms.DateTimePicker();
            this.lblTotalPayments = new System.Windows.Forms.Label();
            this.lblReceivable = new System.Windows.Forms.Label();
            this.lblDiff = new System.Windows.Forms.Label();
            this.lblExpectedCOH = new System.Windows.Forms.Label();
            this.lblActualCash = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblInitCash = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.dtPickEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboCashier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.subPan = new System.Windows.Forms.Panel();
            this.lblTotalCashoutLoading = new System.Windows.Forms.Label();
            this.lblTotalCashinLoading = new System.Windows.Forms.Label();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.dgvChkOut = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashTendered = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subPan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChkOut)).BeginInit();
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
            this.dtPickStart.Location = new System.Drawing.Point(159, 12);
            this.dtPickStart.Name = "dtPickStart";
            this.dtPickStart.Size = new System.Drawing.Size(374, 24);
            this.dtPickStart.TabIndex = 2;
            this.dtPickStart.ValueChanged += new System.EventHandler(this.dtPick_ValueChanged);
            // 
            // lblTotalPayments
            // 
            this.lblTotalPayments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalPayments.AutoSize = true;
            this.lblTotalPayments.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPayments.ForeColor = System.Drawing.Color.White;
            this.lblTotalPayments.Location = new System.Drawing.Point(14, 158);
            this.lblTotalPayments.Name = "lblTotalPayments";
            this.lblTotalPayments.Size = new System.Drawing.Size(171, 23);
            this.lblTotalPayments.TabIndex = 13;
            this.lblTotalPayments.Text = "Total Payments:";
            // 
            // lblReceivable
            // 
            this.lblReceivable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivable.AutoSize = true;
            this.lblReceivable.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivable.ForeColor = System.Drawing.Color.White;
            this.lblReceivable.Location = new System.Drawing.Point(14, 135);
            this.lblReceivable.Name = "lblReceivable";
            this.lblReceivable.Size = new System.Drawing.Size(156, 23);
            this.lblReceivable.TabIndex = 12;
            this.lblReceivable.Text = "Total Charges:";
            // 
            // lblDiff
            // 
            this.lblDiff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiff.AutoSize = true;
            this.lblDiff.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiff.ForeColor = System.Drawing.Color.White;
            this.lblDiff.Location = new System.Drawing.Point(14, 313);
            this.lblDiff.Name = "lblDiff";
            this.lblDiff.Size = new System.Drawing.Size(202, 23);
            this.lblDiff.TabIndex = 11;
            this.lblDiff.Text = "Amount Difference:";
            // 
            // lblExpectedCOH
            // 
            this.lblExpectedCOH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExpectedCOH.AutoSize = true;
            this.lblExpectedCOH.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedCOH.ForeColor = System.Drawing.Color.White;
            this.lblExpectedCOH.Location = new System.Drawing.Point(14, 267);
            this.lblExpectedCOH.Name = "lblExpectedCOH";
            this.lblExpectedCOH.Size = new System.Drawing.Size(253, 23);
            this.lblExpectedCOH.TabIndex = 10;
            this.lblExpectedCOH.Text = "Expected Cash on Hand:";
            // 
            // lblActualCash
            // 
            this.lblActualCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActualCash.AutoSize = true;
            this.lblActualCash.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualCash.ForeColor = System.Drawing.Color.White;
            this.lblActualCash.Location = new System.Drawing.Point(14, 290);
            this.lblActualCash.Name = "lblActualCash";
            this.lblActualCash.Size = new System.Drawing.Size(225, 23);
            this.lblActualCash.TabIndex = 9;
            this.lblActualCash.Text = "Actual Cash on Hand:";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.ForeColor = System.Drawing.Color.White;
            this.lblTotalSales.Location = new System.Drawing.Point(14, 112);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(126, 23);
            this.lblTotalSales.TabIndex = 8;
            this.lblTotalSales.Text = "Total Sales:";
            // 
            // lblInitCash
            // 
            this.lblInitCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitCash.AutoSize = true;
            this.lblInitCash.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitCash.ForeColor = System.Drawing.Color.White;
            this.lblInitCash.Location = new System.Drawing.Point(14, 14);
            this.lblInitCash.Name = "lblInitCash";
            this.lblInitCash.Size = new System.Drawing.Size(132, 23);
            this.lblInitCash.TabIndex = 7;
            this.lblInitCash.Text = "Initial Cash:";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.White;
            this.lblTotalExpenses.Location = new System.Drawing.Point(14, 37);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(109, 23);
            this.lblTotalExpenses.TabIndex = 6;
            this.lblTotalExpenses.Text = "Expenses:";
            // 
            // dtPickEnd
            // 
            this.dtPickEnd.Location = new System.Drawing.Point(159, 46);
            this.dtPickEnd.Name = "dtPickEnd";
            this.dtPickEnd.Size = new System.Drawing.Size(374, 24);
            this.dtPickEnd.TabIndex = 6;
            this.dtPickEnd.Visible = false;
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
            this.label2.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(13, 504);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(152, 46);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboCashier
            // 
            this.cboCashier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCashier.FormattingEnabled = true;
            this.cboCashier.Location = new System.Drawing.Point(159, 80);
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
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(497, 504);
            this.btnClose.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(152, 46);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCheckOut.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCheckOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCheckOut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnCheckOut.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnCheckOut.ForeColor = System.Drawing.Color.White;
            this.btnCheckOut.Location = new System.Drawing.Point(177, 504);
            this.btnCheckOut.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(150, 46);
            this.btnCheckOut.TabIndex = 12;
            this.btnCheckOut.Text = "Checkout";
            this.btnCheckOut.UseVisualStyleBackColor = false;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightCoral;
            this.btnPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Tomato;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(339, 504);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(150, 46);
            this.btnPrint.TabIndex = 12;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // subPan
            // 
            this.subPan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.subPan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.subPan.Controls.Add(this.lblTotalCashoutLoading);
            this.subPan.Controls.Add(this.lblTotalCashinLoading);
            this.subPan.Controls.Add(this.lblDeposit);
            this.subPan.Controls.Add(this.lblInitCash);
            this.subPan.Controls.Add(this.lblTotalPayments);
            this.subPan.Controls.Add(this.lblTotalExpenses);
            this.subPan.Controls.Add(this.lblTotalSales);
            this.subPan.Controls.Add(this.lblReceivable);
            this.subPan.Controls.Add(this.lblActualCash);
            this.subPan.Controls.Add(this.lblExpectedCOH);
            this.subPan.Controls.Add(this.lblDiff);
            this.subPan.Location = new System.Drawing.Point(395, 483);
            this.subPan.Name = "subPan";
            this.subPan.Size = new System.Drawing.Size(0, 19);
            this.subPan.TabIndex = 14;
            // 
            // lblTotalCashoutLoading
            // 
            this.lblTotalCashoutLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCashoutLoading.AutoSize = true;
            this.lblTotalCashoutLoading.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCashoutLoading.ForeColor = System.Drawing.Color.White;
            this.lblTotalCashoutLoading.Location = new System.Drawing.Point(14, 219);
            this.lblTotalCashoutLoading.Name = "lblTotalCashoutLoading";
            this.lblTotalCashoutLoading.Size = new System.Drawing.Size(262, 23);
            this.lblTotalCashoutLoading.TabIndex = 16;
            this.lblTotalCashoutLoading.Text = "Loading station cash out:";
            // 
            // lblTotalCashinLoading
            // 
            this.lblTotalCashinLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCashinLoading.AutoSize = true;
            this.lblTotalCashinLoading.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCashinLoading.ForeColor = System.Drawing.Color.White;
            this.lblTotalCashinLoading.Location = new System.Drawing.Point(14, 196);
            this.lblTotalCashinLoading.Name = "lblTotalCashinLoading";
            this.lblTotalCashinLoading.Size = new System.Drawing.Size(249, 23);
            this.lblTotalCashinLoading.TabIndex = 15;
            this.lblTotalCashinLoading.Text = "Loading station cash in:";
            // 
            // lblDeposit
            // 
            this.lblDeposit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Font = new System.Drawing.Font("Century Schoolbook", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeposit.ForeColor = System.Drawing.Color.White;
            this.lblDeposit.Location = new System.Drawing.Point(14, 60);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(147, 23);
            this.lblDeposit.TabIndex = 14;
            this.lblDeposit.Text = "Cash Deposit:";
            // 
            // dgvChkOut
            // 
            this.dgvChkOut.AllowUserToAddRows = false;
            this.dgvChkOut.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose;
            this.dgvChkOut.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChkOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChkOut.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChkOut.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvChkOut.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvChkOut.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvChkOut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChkOut.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CashTendered,
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChkOut.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChkOut.Location = new System.Drawing.Point(13, 111);
            this.dgvChkOut.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvChkOut.Name = "dgvChkOut";
            this.dgvChkOut.ReadOnly = true;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dgvChkOut.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChkOut.RowTemplate.Height = 24;
            this.dgvChkOut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChkOut.Size = new System.Drawing.Size(636, 391);
            this.dgvChkOut.TabIndex = 52;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Description";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Expected Amount";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CashTendered
            // 
            this.CashTendered.HeaderText = "Actual Amount";
            this.CashTendered.Name = "CashTendered";
            this.CashTendered.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Remarks";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // frmChkOutLight
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(665, 552);
            this.Controls.Add(this.dgvChkOut);
            this.Controls.Add(this.subPan);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCashier);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtPickEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtPickStart);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChkOutLight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkout Report";
            this.Load += new System.EventHandler(this.frmInventory_Load);
            this.subPan.ResumeLayout(false);
            this.subPan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChkOut)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtPickStart;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.DateTimePicker dtPickEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboCashier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Label lblActualCash;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblInitCash;
        private System.Windows.Forms.Label lblExpectedCOH;
        private System.Windows.Forms.Label lblDiff;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblReceivable;
        private System.Windows.Forms.Label lblTotalPayments;
        private System.Windows.Forms.Panel subPan;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.Label lblTotalCashinLoading;
        private System.Windows.Forms.Label lblTotalCashoutLoading;
        private System.Windows.Forms.DataGridView dgvChkOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashTendered;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}