using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kawayanan
{
    public partial class OrdersDisplay : Form
    {

        public string Serving
        {
            get { return lblNow.Text; }
            set
            {
                lblNow.Text = value;
            }
        }
        public string Next
        {
            get { return lblNext.Text; }
            set
            {
                lblNext.Text = value;
            }
        }
        public OrdersDisplay()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lblNow.ForeColor == Color.White)
                lblNow.ForeColor = Color.Red;

            else
                lblNow.ForeColor = Color.White;
        }
        int adCtr = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            string[] strfile = System.IO.Directory.GetFiles("ads");
            
            int count = System.IO.Directory.GetFiles("ads").Length;

            if (adCtr > strfile.Length - 1) adCtr = 0;
            string fname = "ads\\" + System.IO.Path.GetFileName(strfile[adCtr]);
            picAd.Image = Image.FromFile(fname);
            adCtr++;
        }

        private void OrdersDisplay_Load(object sender, EventArgs e)
        {
            //axMediaPlayer.URL = @"C:\Users\Public\Videos\Sample Videos\wildlife.wmv";
        }

        public void NowServing(int ctr)
        {
            axMediaPlayer.Width = this.Width * 2;
            axMediaPlayer.Height = this.Height * 2;
            axMediaPlayer.Top = this.Width / -3;
            axMediaPlayer.Left = this.Left / -3;
            axMediaPlayer.URL = string.Format("vid\\T{0}.mp4", ctr);
            axMediaPlayer.settings.playCount = 1;
        }

        public void ThankYou()
        {

            axMediaPlayer.URL = string.Format("vid\\TY.mp4");
            axMediaPlayer.Width = this.Width * 2;
            axMediaPlayer.Height = this.Height * 2;
            axMediaPlayer.Top = this.Width / -3;
            axMediaPlayer.Left = this.Height / -3;
            axMediaPlayer.stretchToFit = true;
            //axMediaPlayer.fullScreen = true;
        }

        public void Greetings()
        {
            try
            {
                axMediaPlayer.Width = this.Width * 2;
                axMediaPlayer.Height = this.Height * 2;
                axMediaPlayer.Top = this.Width / -3;
                axMediaPlayer.Left = this.Left / -3;
                axMediaPlayer.fullScreen = true;
            }
            catch { }
            if (DateTime.Now.Hour < 12)
            {
                axMediaPlayer.URL = string.Format("vid\\AM.mp4");
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                axMediaPlayer.URL = string.Format("vid\\NN.mp4");
            }
            else
            {
                axMediaPlayer.URL = string.Format("vid\\PM.mp4");
            }
        }

        private void axMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            axMediaPlayer.uiMode = "none";
            if (e.newState == 9 || e.newState==3)
            {
                axMediaPlayer.settings.volume = 100;
                axMediaPlayer.Top = 0;
                axMediaPlayer.Left = 0;
                axMediaPlayer.Width = this.Width;
                axMediaPlayer.Height = this.Height;
                axMediaPlayer.Visible = true;
            }
            else
            {
                axMediaPlayer.Visible = false;
            } 
        }
    }
}
