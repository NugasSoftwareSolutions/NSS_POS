using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AlreySolutions.Class.Load;

namespace AlreySolutions.LoadingStation
{
    public partial class frmSendECash : Form
    {
        clsLoadAccount m_LoadAccount = null;
        public frmSendECash(clsLoadAccount account)
        {
            InitializeComponent();
            m_LoadAccount = account;
            ctrlLoadAccount1.Description = m_LoadAccount.Description;
            ctrlLoadAccount1.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount1.LoadId = m_LoadAccount.LoadId;
            //btn.Picture = 
            if (m_LoadAccount.ImgFile != null)
            {
                MemoryStream mem = new MemoryStream(m_LoadAccount.ImgFile);
                ctrlLoadAccount1.Picture = Image.FromStream(mem);
                mem.Close();
            }
            else
            {
                ctrlLoadAccount1.Picture = null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void frmSendECash_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
