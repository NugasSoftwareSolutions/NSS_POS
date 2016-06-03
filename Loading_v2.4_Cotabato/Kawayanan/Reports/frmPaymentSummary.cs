using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlreySolutions.Class;

namespace AlreySolutions.Reports
{
    public partial class frmPaymentSummary : Form
    {
        List<clsPaymentInfo> m_ListProdItems = null;

        public frmPaymentSummary()
        {
            InitializeComponent();
            dtPickStart.Value = DateTime.Now;
            dtPickEnd.Value = DateTime.Now.AddDays(1);
        }

        private void SearchPayments()
        {
            m_ListProdItems = new List<clsPaymentInfo>();
            dgvPayments.Rows.Clear();
            List<clsPaymentInfo> lstInventory = clsPaymentInfo.GetPaymentsInfoFromDate(dtPickStart.Value, dtPickEnd.Value,"");
            double total = 0;
            foreach (clsPaymentInfo fi in lstInventory)
            {
                total += fi.AmountPaid;
                AddItemToGrid(fi);
                m_ListProdItems.Add(fi);
            }
            lblTotalAmount.Text = string.Format("Total: P {0:0.00}", Math.Round( total,2));
        }
        private void AddItemToGrid( clsPaymentInfo fitem )
        {

            int rowidx = dgvPayments.Rows.Add();
            dgvPayments.Rows[rowidx].Cells[0].Value = fitem.Timestamp;
            dgvPayments.Rows[rowidx].Cells[1].Value = fitem.AccountName;
            dgvPayments.Rows[rowidx].Cells[2].Value = fitem.AmountPaid;
            dgvPayments.Rows[rowidx].Cells[3].Value = fitem.Remarks;
            dgvPayments.Rows[rowidx].Cells[4].Value = fitem.UserName;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPayments.Rows.Count == 0)
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
                foreach (DataGridViewColumn col in dgvPayments.Columns)
                {
                    columns += col.HeaderText + (col != dgvPayments.Columns[dgvPayments.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvPayments.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvPayments.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvPayments.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPayments();
        }


        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInventory_FormClosing( object sender, FormClosingEventArgs e )
        {

        }


    }
}
