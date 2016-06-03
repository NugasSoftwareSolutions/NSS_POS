using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class.Load;
using System.IO;

namespace AlreySolutions.LoadingStation
{
    public partial class frmGCashTrans : Form
    {
        clsLoadAccount m_LoadAccount = null;
        List<clsServiceFee> LstServiceFees = clsServiceFee.GetServiceFees();
        public frmGCashTrans(clsLoadAccount act)
        {
            InitializeComponent();
            txtAmount.TextChanged += new EventHandler(textBox_TextChanged);
            m_LoadAccount = act;
        }

        private void frmECashTrans_Load(object sender, EventArgs e)
        {
            ctrlLoadAccount.Description = m_LoadAccount.Description;
            ctrlLoadAccount.LoadType = m_LoadAccount.LoadType;
            ctrlLoadAccount.LoadId = m_LoadAccount.LoadId;
            //btn.Picture = 
            if (m_LoadAccount.ImgFile != null)
            {
                MemoryStream mem = new MemoryStream(m_LoadAccount.ImgFile);
                ctrlLoadAccount.Picture = Image.FromStream(mem);
                mem.Close();
            }
            else
            {
                ctrlLoadAccount.Picture = null;
            }
        }

        private void btnClaim_Click(object sender, EventArgs e)
        {
            frmClaimECash ec = new frmClaimECash(m_LoadAccount);
            ec.Left = this.Bounds.Right;
            ec.Top = this.Bounds.Top;
            ec.ShowDialog();

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            frmSendECash ec = new frmSendECash(m_LoadAccount);
            ec.Left = this.Bounds.Right;
            ec.Top = this.Bounds.Top;
            ec.ShowDialog();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            clsServiceFee fee = LstServiceFees.Find(x => x.AmountFrom >= double.Parse(txt.Text) && x.AmountTo <= double.Parse(txt.Text));
            if (fee != null)
            {
                txtServiceFee.Text = fee.EcashFee.ToString("n");
            }
        }        
    }
}
