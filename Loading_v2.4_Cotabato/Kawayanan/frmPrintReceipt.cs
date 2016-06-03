using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AlreySolutions
{
    public partial class frmPrintReceipt : Form
    {

        public frmPrintReceipt(string inputstring)
        {
            InitializeComponent();
            picReceipt.Image = Convert_Text_to_Image(inputstring,"Times New Roman", 12);
        }

        private void frmPrintReceipt_Load( object sender, EventArgs e )
        {

        }

        public static Bitmap Convert_Text_to_Image( string txt, string fontname, int fontsize )
        {
            //creating bitmap image
            Bitmap bmp = new Bitmap(1, 1);

            //FromImage method creates a new Graphics from the specified Image.
            Graphics graphics = Graphics.FromImage(bmp);
            // Create the Font object for the image text drawing.
            Font font = new Font(fontname, fontsize, FontStyle.Regular);
            // Instantiating object of Bitmap image again with the correct size for the text and font.
            SizeF stringSize = graphics.MeasureString(txt, font);
            bmp = new Bitmap(bmp, (int)stringSize.Width+20, (int)stringSize.Height+50);
            graphics = Graphics.FromImage(bmp);

            /* It can also be a way
           bmp = new Bitmap(bmp, new Size((int)graphics.MeasureString(txt, font).Width, (int)graphics.MeasureString(txt, font).Height));*/

            //Draw Specified text with specified format 
            graphics.DrawString(txt, font, Brushes.Black, 10, 10);
            font.Dispose();
            graphics.Flush();
            graphics.Dispose();
            return bmp;     //return Bitmap Image 
        }

        private void picReceipt_SizeChanged( object sender, EventArgs e )
        {
            this.Size = picReceipt.Size;
        }

        private void picReceipt_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
