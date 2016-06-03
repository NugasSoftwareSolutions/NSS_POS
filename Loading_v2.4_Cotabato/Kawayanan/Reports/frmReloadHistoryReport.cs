﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;
using AlreySolutions.Class.Load;

namespace AlreySolutions.Reports
{
    public partial class frmReloadHistoryReport : Form
    {
        List<clsUsers> lstUsers = new List<clsUsers>();
        List<clsLoadAccount> m_lstAccountInfo = new List<clsLoadAccount>();
        public frmReloadHistoryReport()
        {
            InitializeComponent();
        }

        private void frmReloadHistoryReport_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboCashier.Items.Add("All");

            lstUsers = clsUsers.GetUsers();
            foreach (clsUsers str in lstUsers)
            {
                cboCashier.Items.Add(str.UserName);
            }
            cboLoadAcc.Items.Add("All");
            m_lstAccountInfo = clsLoadAccount.GetLoadAccounts();
            foreach (clsLoadAccount acc in m_lstAccountInfo)
            {
                cboLoadAcc.Items.Add(acc.Description);
            }
            cboCashier.SelectedIndex = 0;
            cboLoadAcc.SelectedIndex = 0;
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
            clsLoadAccount SelectedAccount = m_lstAccountInfo.Find(x=>x.Description == cboLoadAcc.Text);
            int loadid = SelectedAccount != null ? SelectedAccount.LoadId : 0;
            clsUsers SelectedUser = lstUsers.Find(x => x.UserName == cboCashier.Text);
            int userid = SelectedUser != null ? SelectedUser.UserId : 0;

            if (cashier == "All") cashier = "";
            SearchReloadHistory(dtPickStart.Value, dtPickEnd.Value, userid,loadid);
        }
        private void SearchReloadHistory(DateTime startdate, DateTime enddate, int cashier, int loadid)
        {
            dbConnect con = new dbConnect();
            List<clsReloadHistory> lstLoadHistory = clsReloadHistory.GetReLoadHistoryReport(startdate, enddate, cashier, loadid);
            dgvReload.Rows.Clear();
            if (lstLoadHistory.Count > 0)
            {
                foreach (clsReloadHistory hist in lstLoadHistory)
                {
                    AddItemToGrid(hist);
                }
            }

        }
        private void AddItemToGrid(clsReloadHistory hist)
        {
            clsLoadAccount load = clsLoadAccount.GetLoadAccount(hist.Load_Id);
            int rowidx = dgvReload.Rows.Add();
            dgvReload.Rows[rowidx].Cells[0].Value = hist.Timestamp;
            dgvReload.Rows[rowidx].Cells[1].Value = load.Description;
            dgvReload.Rows[rowidx].Cells[2].Value = hist.RefNum;
            dgvReload.Rows[rowidx].Cells[3].Value = hist.Amount;
            dgvReload.Rows[rowidx].Cells[4].Value = hist.TransactionAmount;
            dgvReload.Rows[rowidx].Cells[5].Value = hist.RemainingBalance;
            dgvReload.Rows[rowidx].Cells[6].Value = hist.Remarks;
            dgvReload.Rows[rowidx].Cells[7].Value = hist.UserName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReload.Rows.Count == 0)
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
                foreach (DataGridViewColumn col in dgvReload.Columns)
                {
                    columns += col.HeaderText + (col != dgvReload.Columns[dgvReload.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvReload.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvReload.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvReload.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void frmReloadHistoryReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }        
    }
}
