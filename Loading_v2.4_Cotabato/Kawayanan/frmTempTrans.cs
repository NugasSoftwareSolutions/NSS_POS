using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;

namespace AlreySolutions
{
    public partial class frmTempTrans : Form
    {
        public Receipt SelectedTempOR = null;
        public string SelectedValue = "";
        public clsUsers m_user = null;
        public frmTempTrans(clsUsers user)
        {
            InitializeComponent();
            m_user = user;
        }

        private void lstDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstTemp.SelectedIndex >= 0)
                {
                    SelectedTempOR = tmpReceipt[lstTemp.SelectedIndex];
                    SelectedValue = lstTemp.SelectedItem.ToString();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                SelectedTempOR = null;
                SelectedValue = "";
                this.Close();
            }
        }
        List<Receipt> tmpReceipt = null;
        private void frmDiscount_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            LoadTempReceipt();
        }

        private void LoadTempReceipt()
        {
            lstTemp.Items.Clear();
            tmpReceipt= Receipt.GetTempReceiptInfo();
            if (tmpReceipt != null)
            {
                foreach (Receipt r in tmpReceipt)
                {
                    lstTemp.Items.Add(string.Format("{0}:{1}", r.CashierName, r.TotalDiscountedAmount));
                }
            }
            lstTemp.Focus();
            if(lstTemp.Items.Count>0)
            lstTemp.SelectedIndex = 0;
            
        }

        private void lstDiscount_DoubleClick( object sender, EventArgs e )
        {
            SelectItem();
        }

        private void SelectItem()
        {
            if (lstTemp.SelectedIndex >= 0)
            {
                SelectedTempOR = tmpReceipt[lstTemp.SelectedIndex];
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void lstDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTemp.SelectedIndex == -1) return;
            if (GetApproval(UserAccess.Manager))
            {
                SelectedTempOR = tmpReceipt[lstTemp.SelectedIndex];
                SelectedTempOR.DeleteTempReceipt();
                LoadTempReceipt();
                SelectedTempOR = null;
            }
        }

        private bool GetApproval(UserAccess accesslevel = UserAccess.Cashier)
        {
            if (m_user.LoginType <= (int)accesslevel)
            {
                return true;
            }
            else
            {
                frmApproval login = new frmApproval((int)accesslevel);
                if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    clsUsers iuser = login.m_User;
                    if (iuser.LoginType <= (int)accesslevel) return true;
                }
            }

            return false;
        }
        private enum UserAccess
        {
            Admin = 1,
            Manager = 2,
            Supervisor = 3,
            Cashier = 4
        }

        private void btnChange_Click( object sender, EventArgs e )
        {
            if (lstTemp.SelectedIndex >= 0)
            {
                SelectedTempOR = tmpReceipt[lstTemp.SelectedIndex];
                if (SelectedTempOR != null)
                {
                    string tmpTable = SelectedTempOR.CashierName;
                    frmInput input = new frmInput();
                    input.withDecimal = true;
                    input.IsNumericOnly = false;
                    input.Title = "Customer Reference";
                    input.Value = tmpTable;
                    if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        tmpReceipt[lstTemp.SelectedIndex].CashierName = input.Value;
                        tmpReceipt[lstTemp.SelectedIndex].SaveTemp(input.Value);
                        LoadTempReceipt();
                    }
                }
            }
        }

        private void btnChange_KeyDown( object sender, KeyEventArgs e )
        {
            if (e.KeyCode == Keys.Escape)
            {
                SelectedTempOR = null;
                SelectedValue = "";
                this.Close();
            }
        }
    }
}
