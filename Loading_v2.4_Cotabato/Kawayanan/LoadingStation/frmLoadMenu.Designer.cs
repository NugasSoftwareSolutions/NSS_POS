namespace AlreySolutions.LoadingStation
{
    partial class frmLoadMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadMenu));
            this.pnlLoadAccount = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLoadAccount
            // 
            this.pnlLoadAccount.AutoScroll = true;
            this.pnlLoadAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoadAccount.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLoadAccount.Location = new System.Drawing.Point(0, 0);
            this.pnlLoadAccount.Name = "pnlLoadAccount";
            this.pnlLoadAccount.Size = new System.Drawing.Size(163, 516);
            this.pnlLoadAccount.TabIndex = 0;
            this.pnlLoadAccount.Resize += new System.EventHandler(this.pnlLoadAccount_Resize);
            // 
            // frmLoadMenu
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(835, 516);
            this.Controls.Add(this.pnlLoadAccount);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmLoadMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLoadMenu_Load);
            this.ResizeEnd += new System.EventHandler(this.frmLoadMenu_ResizeEnd);
            this.Resize += new System.EventHandler(this.frmLoadMenu_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoadAccount;




    }
}