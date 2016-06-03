namespace AlreySolutions.LoadingStation
{
    partial class frmGlobeGCashTrans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGlobeGCashTrans));
            this.tabCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.optSendOthers = new System.Windows.Forms.RadioButton();
            this.optCashOut = new System.Windows.Forms.RadioButton();
            this.optCashIn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRebate1 = new System.Windows.Forms.TextBox();
            this.btnProcessGCash = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSvcFee1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRefNum1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGCashMobNum = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.optRecDom = new System.Windows.Forms.RadioButton();
            this.optRecInt = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRebate2 = new System.Windows.Forms.TextBox();
            this.btnProcessRemit = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSvcFee2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAmount2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRefNum2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtCountry = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.optCancelP2P = new System.Windows.Forms.RadioButton();
            this.optSendP2P = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRebate3 = new System.Windows.Forms.TextBox();
            this.btnProcessSend = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSvcFee3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAmount3 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtReceiverMobile = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtSenderMobile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenderNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRecipientName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRecipientNum = new System.Windows.Forms.TextBox();
            this.btnClearSend = new System.Windows.Forms.Button();
            this.lblAvailableBal = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ctrlLoadAccount = new AlreySolutions.LoadingStation.ctrlLoadAccount();
            this.label21 = new System.Windows.Forms.Label();
            this.tabCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCtrl
            // 
            this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCtrl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabCtrl.Controls.Add(this.tabPage1);
            this.tabCtrl.Controls.Add(this.tabPage2);
            this.tabCtrl.Controls.Add(this.tabPage3);
            this.tabCtrl.Location = new System.Drawing.Point(7, 194);
            this.tabCtrl.Multiline = true;
            this.tabCtrl.Name = "tabCtrl";
            this.tabCtrl.SelectedIndex = 0;
            this.tabCtrl.Size = new System.Drawing.Size(891, 275);
            this.tabCtrl.TabIndex = 700;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.RoyalBlue;
            this.tabPage1.Controls.Add(this.optSendOthers);
            this.tabPage1.Controls.Add(this.optCashOut);
            this.tabPage1.Controls.Add(this.optCashIn);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(883, 240);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "G-Cash via Mobile";
            // 
            // optSendOthers
            // 
            this.optSendOthers.AutoSize = true;
            this.optSendOthers.Location = new System.Drawing.Point(251, 13);
            this.optSendOthers.Name = "optSendOthers";
            this.optSendOthers.Size = new System.Drawing.Size(334, 23);
            this.optSendOthers.TabIndex = 8;
            this.optSendOthers.Text = "Send Money to Others / Cash-In to Others";
            this.optSendOthers.UseVisualStyleBackColor = true;
            this.optSendOthers.CheckedChanged += new System.EventHandler(this.optSendOthers_CheckedChanged);
            // 
            // optCashOut
            // 
            this.optCashOut.AutoSize = true;
            this.optCashOut.Location = new System.Drawing.Point(130, 13);
            this.optCashOut.Name = "optCashOut";
            this.optCashOut.Size = new System.Drawing.Size(97, 23);
            this.optCashOut.TabIndex = 7;
            this.optCashOut.Text = "Cash-Out";
            this.optCashOut.UseVisualStyleBackColor = true;
            this.optCashOut.CheckedChanged += new System.EventHandler(this.optCashOut_CheckedChanged);
            // 
            // optCashIn
            // 
            this.optCashIn.AutoSize = true;
            this.optCashIn.Checked = true;
            this.optCashIn.Location = new System.Drawing.Point(13, 13);
            this.optCashIn.Name = "optCashIn";
            this.optCashIn.Size = new System.Drawing.Size(84, 23);
            this.optCashIn.TabIndex = 6;
            this.optCashIn.TabStop = true;
            this.optCashIn.Text = "Cash-In";
            this.optCashIn.UseVisualStyleBackColor = true;
            this.optCashIn.CheckedChanged += new System.EventHandler(this.optCashIn_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtRebate1);
            this.panel1.Controls.Add(this.btnProcessGCash);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtSvcFee1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtAmount1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtRefNum1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtGCashMobNum);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(858, 178);
            this.panel1.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 145);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 19);
            this.label11.TabIndex = 17;
            this.label11.Text = "Commission";
            // 
            // txtRebate1
            // 
            this.txtRebate1.Location = new System.Drawing.Point(165, 142);
            this.txtRebate1.Name = "txtRebate1";
            this.txtRebate1.ReadOnly = true;
            this.txtRebate1.Size = new System.Drawing.Size(240, 26);
            this.txtRebate1.TabIndex = 13;
            this.txtRebate1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRebate1_KeyDown);
            // 
            // btnProcessGCash
            // 
            this.btnProcessGCash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessGCash.Location = new System.Drawing.Point(764, 136);
            this.btnProcessGCash.Name = "btnProcessGCash";
            this.btnProcessGCash.Size = new System.Drawing.Size(90, 37);
            this.btnProcessGCash.TabIndex = 14;
            this.btnProcessGCash.Text = "Process";
            this.btnProcessGCash.UseVisualStyleBackColor = true;
            this.btnProcessGCash.Click += new System.EventHandler(this.btnProcessGCash_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "Service Fee";
            // 
            // txtSvcFee1
            // 
            this.txtSvcFee1.Location = new System.Drawing.Point(165, 110);
            this.txtSvcFee1.Name = "txtSvcFee1";
            this.txtSvcFee1.ReadOnly = true;
            this.txtSvcFee1.Size = new System.Drawing.Size(240, 26);
            this.txtSvcFee1.TabIndex = 12;
            this.txtSvcFee1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Amount";
            // 
            // txtAmount1
            // 
            this.txtAmount1.Location = new System.Drawing.Point(165, 78);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(240, 26);
            this.txtAmount1.TabIndex = 11;
            this.txtAmount1.TextChanged += new System.EventHandler(this.txtAmount1_TextChanged);
            this.txtAmount1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Reference Number";
            // 
            // txtRefNum1
            // 
            this.txtRefNum1.Location = new System.Drawing.Point(165, 46);
            this.txtRefNum1.Name = "txtRefNum1";
            this.txtRefNum1.Size = new System.Drawing.Size(372, 26);
            this.txtRefNum1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mobile Number";
            // 
            // txtGCashMobNum
            // 
            this.txtGCashMobNum.Location = new System.Drawing.Point(165, 14);
            this.txtGCashMobNum.Name = "txtGCashMobNum";
            this.txtGCashMobNum.Size = new System.Drawing.Size(372, 26);
            this.txtGCashMobNum.TabIndex = 9;
            this.txtGCashMobNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGCashMobNum_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage2.Controls.Add(this.optRecDom);
            this.tabPage2.Controls.Add(this.optRecInt);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(883, 240);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "G-Cash Remit (RECEIVE)";
            // 
            // optRecDom
            // 
            this.optRecDom.AutoSize = true;
            this.optRecDom.Location = new System.Drawing.Point(321, 13);
            this.optRecDom.Name = "optRecDom";
            this.optRecDom.Size = new System.Drawing.Size(257, 23);
            this.optRecDom.TabIndex = 11;
            this.optRecDom.Text = "Receive Domestic Cash Pick-up";
            this.optRecDom.UseVisualStyleBackColor = true;
            // 
            // optRecInt
            // 
            this.optRecInt.AutoSize = true;
            this.optRecInt.Checked = true;
            this.optRecInt.Location = new System.Drawing.Point(13, 13);
            this.optRecInt.Name = "optRecInt";
            this.optRecInt.Size = new System.Drawing.Size(282, 23);
            this.optRecInt.TabIndex = 10;
            this.optRecInt.TabStop = true;
            this.optRecInt.Text = "Receive International Cash Pick-up";
            this.optRecInt.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtRebate2);
            this.panel2.Controls.Add(this.btnProcessRemit);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtSvcFee2);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.txtAmount2);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtRefNum2);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.txtCountry);
            this.panel2.Location = new System.Drawing.Point(12, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(858, 178);
            this.panel2.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "Commission";
            // 
            // txtRebate2
            // 
            this.txtRebate2.Location = new System.Drawing.Point(165, 142);
            this.txtRebate2.Name = "txtRebate2";
            this.txtRebate2.ReadOnly = true;
            this.txtRebate2.Size = new System.Drawing.Size(240, 26);
            this.txtRebate2.TabIndex = 12;
            this.txtRebate2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRebate2_KeyDown);
            // 
            // btnProcessRemit
            // 
            this.btnProcessRemit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessRemit.Location = new System.Drawing.Point(764, 136);
            this.btnProcessRemit.Name = "btnProcessRemit";
            this.btnProcessRemit.Size = new System.Drawing.Size(90, 37);
            this.btnProcessRemit.TabIndex = 13;
            this.btnProcessRemit.Text = "Process";
            this.btnProcessRemit.UseVisualStyleBackColor = true;
            this.btnProcessRemit.Click += new System.EventHandler(this.btnProcessGCash_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 19);
            this.label12.TabIndex = 10;
            this.label12.Text = "Service Fee";
            // 
            // txtSvcFee2
            // 
            this.txtSvcFee2.Location = new System.Drawing.Point(165, 110);
            this.txtSvcFee2.Name = "txtSvcFee2";
            this.txtSvcFee2.ReadOnly = true;
            this.txtSvcFee2.Size = new System.Drawing.Size(240, 26);
            this.txtSvcFee2.TabIndex = 11;
            this.txtSvcFee2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 19);
            this.label13.TabIndex = 8;
            this.label13.Text = "Amount";
            // 
            // txtAmount2
            // 
            this.txtAmount2.Location = new System.Drawing.Point(165, 78);
            this.txtAmount2.Name = "txtAmount2";
            this.txtAmount2.Size = new System.Drawing.Size(240, 26);
            this.txtAmount2.TabIndex = 10;
            this.txtAmount2.TextChanged += new System.EventHandler(this.txtAmount2_TextChanged);
            this.txtAmount2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 19);
            this.label14.TabIndex = 6;
            this.label14.Text = "Reference Number";
            // 
            // txtRefNum2
            // 
            this.txtRefNum2.Location = new System.Drawing.Point(165, 46);
            this.txtRefNum2.Name = "txtRefNum2";
            this.txtRefNum2.Size = new System.Drawing.Size(372, 26);
            this.txtRefNum2.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 19);
            this.label15.TabIndex = 4;
            this.label15.Text = "Country";
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(165, 14);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(372, 26);
            this.txtCountry.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tabPage3.Controls.Add(this.optCancelP2P);
            this.tabPage3.Controls.Add(this.optSendP2P);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(883, 240);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "G-Cash Remit (SEND/CANCEL)";
            // 
            // optCancelP2P
            // 
            this.optCancelP2P.AutoSize = true;
            this.optCancelP2P.Location = new System.Drawing.Point(96, 13);
            this.optCancelP2P.Name = "optCancelP2P";
            this.optCancelP2P.Size = new System.Drawing.Size(78, 23);
            this.optCancelP2P.TabIndex = 11;
            this.optCancelP2P.Text = "Cancel";
            this.optCancelP2P.UseVisualStyleBackColor = true;
            this.optCancelP2P.CheckedChanged += new System.EventHandler(this.optCancelP2P_CheckedChanged);
            // 
            // optSendP2P
            // 
            this.optSendP2P.AutoSize = true;
            this.optSendP2P.Checked = true;
            this.optSendP2P.Location = new System.Drawing.Point(13, 13);
            this.optSendP2P.Name = "optSendP2P";
            this.optSendP2P.Size = new System.Drawing.Size(64, 23);
            this.optSendP2P.TabIndex = 10;
            this.optSendP2P.TabStop = true;
            this.optSendP2P.Text = "Send";
            this.optSendP2P.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.txtRebate3);
            this.panel3.Controls.Add(this.btnProcessSend);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtSvcFee3);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtAmount3);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.txtReceiverMobile);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.txtSenderMobile);
            this.panel3.Location = new System.Drawing.Point(12, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(858, 178);
            this.panel3.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 19);
            this.label9.TabIndex = 15;
            this.label9.Text = "Commission";
            // 
            // txtRebate3
            // 
            this.txtRebate3.Location = new System.Drawing.Point(165, 143);
            this.txtRebate3.Name = "txtRebate3";
            this.txtRebate3.ReadOnly = true;
            this.txtRebate3.Size = new System.Drawing.Size(240, 26);
            this.txtRebate3.TabIndex = 15;
            this.txtRebate3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRebate3_KeyDown);
            // 
            // btnProcessSend
            // 
            this.btnProcessSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessSend.Location = new System.Drawing.Point(764, 136);
            this.btnProcessSend.Name = "btnProcessSend";
            this.btnProcessSend.Size = new System.Drawing.Size(90, 37);
            this.btnProcessSend.TabIndex = 16;
            this.btnProcessSend.Text = "Process";
            this.btnProcessSend.UseVisualStyleBackColor = true;
            this.btnProcessSend.Click += new System.EventHandler(this.btnProcessGCash_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(13, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 19);
            this.label16.TabIndex = 10;
            this.label16.Text = "Service Fee";
            // 
            // txtSvcFee3
            // 
            this.txtSvcFee3.Location = new System.Drawing.Point(165, 110);
            this.txtSvcFee3.Name = "txtSvcFee3";
            this.txtSvcFee3.ReadOnly = true;
            this.txtSvcFee3.Size = new System.Drawing.Size(240, 26);
            this.txtSvcFee3.TabIndex = 14;
            this.txtSvcFee3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 81);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 19);
            this.label17.TabIndex = 8;
            this.label17.Text = "Amount";
            // 
            // txtAmount3
            // 
            this.txtAmount3.Location = new System.Drawing.Point(165, 78);
            this.txtAmount3.Name = "txtAmount3";
            this.txtAmount3.Size = new System.Drawing.Size(240, 26);
            this.txtAmount3.TabIndex = 13;
            this.txtAmount3.TextChanged += new System.EventHandler(this.txtAmount3_TextChanged);
            this.txtAmount3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount2_KeyDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 49);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 19);
            this.label18.TabIndex = 6;
            this.label18.Text = "Receiver\'s Mobile";
            // 
            // txtReceiverMobile
            // 
            this.txtReceiverMobile.Location = new System.Drawing.Point(165, 46);
            this.txtReceiverMobile.Name = "txtReceiverMobile";
            this.txtReceiverMobile.Size = new System.Drawing.Size(372, 26);
            this.txtReceiverMobile.TabIndex = 12;
            this.txtReceiverMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGCashMobNum_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(126, 19);
            this.label19.TabIndex = 4;
            this.label19.Text = "Sender\'s Mobile";
            // 
            // txtSenderMobile
            // 
            this.txtSenderMobile.Location = new System.Drawing.Point(165, 14);
            this.txtSenderMobile.Name = "txtSenderMobile";
            this.txtSenderMobile.Size = new System.Drawing.Size(372, 26);
            this.txtSenderMobile.TabIndex = 11;
            this.txtSenderMobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGCashMobNum_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Contact Number";
            // 
            // txtSenderNum
            // 
            this.txtSenderNum.Location = new System.Drawing.Point(175, 61);
            this.txtSenderNum.Name = "txtSenderNum";
            this.txtSenderNum.Size = new System.Drawing.Size(329, 26);
            this.txtSenderNum.TabIndex = 2;
            this.txtSenderNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGCashMobNum_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Customer/Sender";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Location = new System.Drawing.Point(175, 7);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(329, 26);
            this.txtSenderName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Beneficiary/Recipient";
            // 
            // txtRecipientName
            // 
            this.txtRecipientName.Location = new System.Drawing.Point(175, 93);
            this.txtRecipientName.Name = "txtRecipientName";
            this.txtRecipientName.Size = new System.Drawing.Size(329, 26);
            this.txtRecipientName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Contact Number";
            // 
            // txtRecipientNum
            // 
            this.txtRecipientNum.Location = new System.Drawing.Point(175, 139);
            this.txtRecipientNum.Name = "txtRecipientNum";
            this.txtRecipientNum.Size = new System.Drawing.Size(329, 26);
            this.txtRecipientNum.TabIndex = 4;
            this.txtRecipientNum.TextChanged += new System.EventHandler(this.txtRecipientNum_TextChanged);
            this.txtRecipientNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGCashMobNum_KeyDown);
            // 
            // btnClearSend
            // 
            this.btnClearSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClearSend.Location = new System.Drawing.Point(12, 474);
            this.btnClearSend.Name = "btnClearSend";
            this.btnClearSend.Size = new System.Drawing.Size(137, 37);
            this.btnClearSend.TabIndex = 702;
            this.btnClearSend.Text = "Clear";
            this.btnClearSend.UseVisualStyleBackColor = true;
            this.btnClearSend.Click += new System.EventHandler(this.btnClearSend_Click);
            // 
            // lblAvailableBal
            // 
            this.lblAvailableBal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableBal.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableBal.Location = new System.Drawing.Point(555, 155);
            this.lblAvailableBal.Name = "lblAvailableBal";
            this.lblAvailableBal.Size = new System.Drawing.Size(343, 26);
            this.lblAvailableBal.TabIndex = 15;
            this.lblAvailableBal.Text = "Available Balance";
            this.lblAvailableBal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(172, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(223, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "First Name       Last Name      Middle Name";
            // 
            // ctrlLoadAccount
            // 
            this.ctrlLoadAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlLoadAccount.BackColor = System.Drawing.Color.Blue;
            this.ctrlLoadAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLoadAccount.Description = "G-Cash";
            this.ctrlLoadAccount.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLoadAccount.LoadId = 0;
            this.ctrlLoadAccount.LoadType = AlreySolutions.Class.Load.LoadAccountType.GCash;
            this.ctrlLoadAccount.Location = new System.Drawing.Point(555, 7);
            this.ctrlLoadAccount.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLoadAccount.Name = "ctrlLoadAccount";
            this.ctrlLoadAccount.Picture = null;
            this.ctrlLoadAccount.Size = new System.Drawing.Size(343, 145);
            this.ctrlLoadAccount.TabIndex = 701;
            this.ctrlLoadAccount.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Rockwell", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(172, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(223, 13);
            this.label21.TabIndex = 30;
            this.label21.Text = "First Name       Last Name      Middle Name";
            // 
            // frmSCashTrans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 525);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblAvailableBal);
            this.Controls.Add(this.btnClearSend);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRecipientNum);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRecipientName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSenderNum);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSenderName);
            this.Controls.Add(this.ctrlLoadAccount);
            this.Controls.Add(this.tabCtrl);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSCashTrans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "E-Cash Transaction";
            this.Load += new System.EventHandler(this.frmECashTrans_Load);
            this.tabCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlLoadAccount ctrlLoadAccount;
        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton optSendOthers;
        private System.Windows.Forms.RadioButton optCashOut;
        private System.Windows.Forms.RadioButton optCashIn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSvcFee1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRefNum1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGCashMobNum;
        private System.Windows.Forms.RadioButton optRecDom;
        private System.Windows.Forms.RadioButton optRecInt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSvcFee2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAmount2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRefNum2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtCountry;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RadioButton optCancelP2P;
        private System.Windows.Forms.RadioButton optSendP2P;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSvcFee3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAmount3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtReceiverMobile;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSenderMobile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenderNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRecipientName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRecipientNum;
        private System.Windows.Forms.Button btnProcessGCash;
        private System.Windows.Forms.Button btnProcessRemit;
        private System.Windows.Forms.Button btnClearSend;
        private System.Windows.Forms.Button btnProcessSend;
        private System.Windows.Forms.Label lblAvailableBal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRebate3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRebate2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRebate1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
    }
}