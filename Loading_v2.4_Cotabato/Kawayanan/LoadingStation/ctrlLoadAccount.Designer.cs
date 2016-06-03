namespace AlreySolutions.LoadingStation
{
    partial class ctrlLoadAccount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDescription = new System.Windows.Forms.Label();
            this.imgPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgPic)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(2, 153);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(155, 34);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Smart E-Load";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // imgPic
            // 
            this.imgPic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imgPic.BackColor = System.Drawing.Color.White;
            this.imgPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgPic.Image = global::AlreySolutions.Properties.Resources.autoloadmax;
            this.imgPic.Location = new System.Drawing.Point(0, 0);
            this.imgPic.Margin = new System.Windows.Forms.Padding(4);
            this.imgPic.Name = "imgPic";
            this.imgPic.Size = new System.Drawing.Size(154, 152);
            this.imgPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgPic.TabIndex = 0;
            this.imgPic.TabStop = false;
            this.imgPic.Click += new System.EventHandler(this.imgPic_Click);
            // 
            // ctrlLoadAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.imgPic);
            this.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlLoadAccount";
            this.Size = new System.Drawing.Size(156, 188);
            this.Load += new System.EventHandler(this.ctrlLoadAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgPic;
        private System.Windows.Forms.Label lblDescription;
    }
}
