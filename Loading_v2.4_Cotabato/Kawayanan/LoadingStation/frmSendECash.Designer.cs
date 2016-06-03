namespace AlreySolutions.LoadingStation
{
    partial class frmSendECash
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSender = new System.Windows.Forms.TextBox();
            this.txtSContact = new System.Windows.Forms.TextBox();
            this.txtRContact = new System.Windows.Forms.TextBox();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtTransAmount = new System.Windows.Forms.TextBox();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtServiceFee = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ctrlLoadAccount1 = new AlreySolutions.LoadingStation.ctrlLoadAccount();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sender Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contact Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Contact Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Recipient Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Account Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Transfer Amount";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 364);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Service Fee";
            // 
            // txtSender
            // 
            this.txtSender.Location = new System.Drawing.Point(166, 146);
            this.txtSender.Name = "txtSender";
            this.txtSender.Size = new System.Drawing.Size(254, 26);
            this.txtSender.TabIndex = 7;
            // 
            // txtSContact
            // 
            this.txtSContact.Location = new System.Drawing.Point(166, 178);
            this.txtSContact.Name = "txtSContact";
            this.txtSContact.Size = new System.Drawing.Size(254, 26);
            this.txtSContact.TabIndex = 8;
            // 
            // txtRContact
            // 
            this.txtRContact.Location = new System.Drawing.Point(166, 258);
            this.txtRContact.Name = "txtRContact";
            this.txtRContact.Size = new System.Drawing.Size(254, 26);
            this.txtRContact.TabIndex = 10;
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(166, 226);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(254, 26);
            this.txtRecipient.TabIndex = 9;
            // 
            // txtTransAmount
            // 
            this.txtTransAmount.Location = new System.Drawing.Point(166, 328);
            this.txtTransAmount.Name = "txtTransAmount";
            this.txtTransAmount.Size = new System.Drawing.Size(254, 26);
            this.txtTransAmount.TabIndex = 12;
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(166, 296);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(254, 26);
            this.txtAccount.TabIndex = 11;
            // 
            // txtServiceFee
            // 
            this.txtServiceFee.Location = new System.Drawing.Point(166, 361);
            this.txtServiceFee.Name = "txtServiceFee";
            this.txtServiceFee.Size = new System.Drawing.Size(254, 26);
            this.txtServiceFee.TabIndex = 13;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(166, 393);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(128, 36);
            this.btnSend.TabIndex = 15;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(300, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 36);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ctrlLoadAccount1
            // 
            this.ctrlLoadAccount1.BackColor = System.Drawing.Color.Red;
            this.ctrlLoadAccount1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrlLoadAccount1.Description = null;
            this.ctrlLoadAccount1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLoadAccount1.LoadId = 0;
            this.ctrlLoadAccount1.LoadType = AlreySolutions.Class.Load.LoadAccountType.GCash;
            this.ctrlLoadAccount1.Location = new System.Drawing.Point(0, 1);
            this.ctrlLoadAccount1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlLoadAccount1.Name = "ctrlLoadAccount1";
            this.ctrlLoadAccount1.Picture = null;
            this.ctrlLoadAccount1.Size = new System.Drawing.Size(431, 140);
            this.ctrlLoadAccount1.TabIndex = 14;
            // 
            // frmSendECash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 434);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.ctrlLoadAccount1);
            this.Controls.Add(this.txtServiceFee);
            this.Controls.Add(this.txtTransAmount);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.txtRContact);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.txtSContact);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmSendECash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Send E-Cash";
            this.Load += new System.EventHandler(this.frmSendECash_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSender;
        private System.Windows.Forms.TextBox txtSContact;
        private System.Windows.Forms.TextBox txtRContact;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.TextBox txtTransAmount;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtServiceFee;
        private ctrlLoadAccount ctrlLoadAccount1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
    }
}