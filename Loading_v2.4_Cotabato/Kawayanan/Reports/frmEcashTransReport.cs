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

namespace AlreySolutions.Reports
{
    public partial class frmEcashTransReport : Form
    {
        List<clsUsers> lstUsers = new List<clsUsers>();
        List<clsLoadAccount> m_lstAccountInfo = new List<clsLoadAccount>();

        public frmEcashTransReport()
        {
            InitializeComponent();
        }

        private void frmEcashTransReport_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboCashier.Items.Add("All");

            lstUsers = clsUsers.GetUsers();
            foreach (clsUsers str in lstUsers)
            {
                cboCashier.Items.Add(str.UserName);
            }
            cboCashier.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void dtPickStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
        }

        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cashier = cboCashier.SelectedItem.ToString();            
            clsUsers SelectedUser = lstUsers.Find(x => x.UserName == cboCashier.Text);
            int userid = SelectedUser != null ? SelectedUser.UserId : 0;

            if (cashier == "All") cashier = "";
            SearchReloadHistory(dtPickStart.Value, dtPickEnd.Value, userid, txtCustomer.Text.Trim());

        }

        private void SearchReloadHistory(DateTime startdate, DateTime enddate, int cashier, string customer)
        {
            dbConnect con = new dbConnect();
            List<clsGCashTransaction> lstLoadHistory = clsGCashTransaction.GetGcashTransactionReport(startdate, enddate, cashier,customer);
            dgvTrans.Rows.Clear();
            if (lstLoadHistory.Count > 0)
            {
                foreach(clsGCashTransaction hist in lstLoadHistory)
                {
                    AddItemToGrid(hist);
                }
            }

        }
        private void AddItemToGrid(clsGCashTransaction hist)
        {
            int rowidx = dgvTrans.Rows.Add();
            dgvTrans.Rows[rowidx].Cells[0].Value = hist.TransDate;
            dgvTrans.Rows[rowidx].Cells[1].Value = hist.AccountName;
            dgvTrans.Rows[rowidx].Cells[2].Value = hist.RefNum;
            dgvTrans.Rows[rowidx].Cells[3].Value = hist.SenderName;
            dgvTrans.Rows[rowidx].Cells[4].Value = hist.SenderContact;
            dgvTrans.Rows[rowidx].Cells[5].Value = clsGCashTransaction.GetTransType(hist.TransactionType);
            dgvTrans.Rows[rowidx].Cells[6].Value = hist.TransAmount;
            dgvTrans.Rows[rowidx].Cells[7].Value = hist.SvcFeeAmount;
            dgvTrans.Rows[rowidx].Cells[8].Value = hist.RecipientName;

            double transamt = GetTransAmount(hist.TransactionType,hist.TransAmount, hist.SvcFeeAmount);
            if (transamt < 0) dgvTrans.Rows[rowidx].Cells[9].Value = string.Format("({0})",Decimal.Negate(Decimal.Parse(transamt.ToString())));
            else dgvTrans.Rows[rowidx].Cells[9].Value = string.Format("{0}", transamt);

            dgvTrans.Rows[rowidx].Cells[10].Value = hist.UserName;
        }
        private double GetTransAmount(GCashTransType type, double amount, double svcfee)
        {
            double ret = 0;
            switch (type)
            {
                case GCashTransType.CashIn:
                    ret = (amount + svcfee);
                    break;
                case GCashTransType.SendToOthers:
                    ret = (amount + svcfee);                    
                    break;
                case GCashTransType.CashOut:
                    ret = -(amount - svcfee);                    
                    break;
                case GCashTransType.IntCashPickUp:
                    ret = -(amount - svcfee);                    
                    break;
                case GCashTransType.DomCashPickup:
                    ret = -(amount - svcfee);                    
                    break;
                case GCashTransType.RemitSend:
                    ret = (amount + svcfee);                    
                    break;
                case GCashTransType.RemitCancel:
                    ret = -(amount - svcfee);                    
                    break;
            }
            return ret;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvTrans.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to export.", "Export To Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsExportToExcel export = new clsExportToExcel();
            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.Filter = "Excel File (*.xls)|*.xls";
            savedlg.InitialDirectory = Application.StartupPath;
            if (savedlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string columns = "";
                foreach (DataGridViewColumn col in dgvTrans.Columns)
                {
                    columns += col.HeaderText + (col != dgvTrans.Columns[dgvTrans.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvTrans.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvTrans.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvTrans.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void frmEcashTransReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
