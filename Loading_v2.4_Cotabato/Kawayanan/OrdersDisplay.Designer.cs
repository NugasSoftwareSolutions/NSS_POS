namespace Kawayanan
{
    partial class OrdersDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrdersDisplay));
            this.picAd = new System.Windows.Forms.PictureBox();
            this.lblNow = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.axMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.picAd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // picAd
            // 
            this.picAd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picAd.Image = ((System.Drawing.Image)(resources.GetObject("picAd.Image")));
            this.picAd.Location = new System.Drawing.Point(3, 104);
            this.picAd.Name = "picAd";
            this.picAd.Size = new System.Drawing.Size(1433, 700);
            this.picAd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAd.TabIndex = 0;
            this.picAd.TabStop = false;
            // 
            // lblNow
            // 
            this.lblNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNow.Font = new System.Drawing.Font("Broadway", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNow.ForeColor = System.Drawing.Color.Red;
            this.lblNow.Location = new System.Drawing.Point(0, 0);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(1436, 101);
            this.lblNow.TabIndex = 1;
            this.lblNow.Text = "Now Serving: Table 01";
            this.lblNow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNext
            // 
            this.lblNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNext.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.ForeColor = System.Drawing.Color.Yellow;
            this.lblNext.Location = new System.Drawing.Point(0, 807);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(1436, 67);
            this.lblNext.TabIndex = 2;
            this.lblNext.Text = "Next: Table 02";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // axMediaPlayer
            // 
            this.axMediaPlayer.Enabled = true;
            this.axMediaPlayer.Location = new System.Drawing.Point(12, 122);
            this.axMediaPlayer.Name = "axMediaPlayer";
            this.axMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMediaPlayer.OcxState")));
            this.axMediaPlayer.Size = new System.Drawing.Size(109, 44);
            this.axMediaPlayer.TabIndex = 3;
            this.axMediaPlayer.TabStop = false;
            this.axMediaPlayer.Visible = false;
            this.axMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(this.axMediaPlayer_PlayStateChange);
            // 
            // OrdersDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1436, 874);
            this.Controls.Add(this.axMediaPlayer);
            this.Controls.Add(this.picAd);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblNow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrdersDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrdersDisplay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrdersDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picAd;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private AxWMPLib.AxWindowsMediaPlayer axMediaPlayer;
    }
}