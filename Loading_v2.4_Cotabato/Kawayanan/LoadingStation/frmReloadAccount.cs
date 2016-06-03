using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class.Load;
using AlreySolutions.Class;

namespace AlreySolutions.LoadingStation
{
    public partial class frmReloadAccount : Form
    {
        clsLoadAccount m_loadAct = null;
        clsUsers m_user = null;
        public frmReloadAccount(clsLoadAccount loadact, clsUsers user)
        {
            InitializeComponent();
            m_loadAct = loadact;
            m_user = user;
            txtDesc.Text = m_loadAct.Description;
            txtCurBal.Text = m_loadAct.CurrentBalance.ToString("0.00"); 
            txtAvailBal.Text = m_loadAct.AvailableBalance.ToString("0.00");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Account Description:{0}\nReload Amount:{1:0.00}\nRemarks:{2}\n\nAre you sure this is correct?", txtDesc.Text, txtAmount.Text, txtRemarks.Text), "Reload Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                clsReloadHistory reload = new clsReloadHistory();
                reload.Amount = Convert.ToDouble(txtAmount.Text);
                reload.Load_Id = m_loadAct.LoadId;
                reload.RefNum = string.Format("RELOAD{0:yyyyMMddHHssmm}", DateTime.Now);
                reload.Timestamp = DateTime.Now;
                reload.UserId = m_user.UserId;
                reload.Remarks = txtRemarks.Text;
                reload.TransactionAmount = 0;
                
                reload.RemainingBalance = dbConnect.GetRemainingLoadBalance(m_loadAct.LoadId) + reload.Amount;
                if (reload.Save())
                {
                    m_loadAct.CurrentBalance = reload.RemainingBalance;
                    m_loadAct.AvailableBalance = reload.RemainingBalance;
                  
                    if (m_loadAct.Save())
                    {
                        reload.PrintReceipt(m_loadAct);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account Balance was not updated!", "Reload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Reload Failed!", "Reload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void frmReloadAccount_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));

        }
    }
}
