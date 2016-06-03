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
    public partial class frmExpenseReport : Form
    {
        double TotalExpenses = 0.0;
        clsUsers m_user = null;
        public frmExpenseReport(clsUsers user)
        {
            InitializeComponent();
            m_user = user;

        }
        List<clsExpenses> lstExpenses = new List<clsExpenses>();
        private void SearchExpenses(DateTime startdate, DateTime enddate,string cashier)
        {
                      
            TotalExpenses = 0.0;
            lstExpenses = clsExpenses.GetExpenses(startdate, enddate,cashier);

            dgvExpenses.Rows.Clear();
            AddItemToGrid(lstExpenses);
            foreach (clsExpenses r in lstExpenses)
            {
                TotalExpenses += r.Amount;
            }
            lblTotalSales.Text = string.Format("Expenses: P {0:0.00}", TotalExpenses);

        }

        private void AddItemToGrid(List<clsExpenses> exp)
        {
            foreach (clsExpenses fitem in exp)
            {
                int rowidx = dgvExpenses.Rows.Add();
                dgvExpenses.Rows[rowidx].Cells[0].Value = fitem.Expense_id;
                dgvExpenses.Rows[rowidx].Cells[1].Value = fitem.Timestamp;
                dgvExpenses.Rows[rowidx].Cells[2].Value = fitem.Description;
                dgvExpenses.Rows[rowidx].Cells[3].Value = fitem.Amount;
                dgvExpenses.Rows[rowidx].Cells[4].Value = fitem.UserName;
            }
        }


        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickStart.Value >= dtPickEnd.Value) dtPickEnd.Value = dtPickStart.Value.AddDays(1);
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string cashier = cboCashier.SelectedItem.ToString();
            if(cashier=="All") cashier="";
            SearchExpenses(dtPickStart.Value, dtPickEnd.Value,cashier);
        }

        private void dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtPickEnd.Value <= dtPickStart.Value) dtPickStart.Value = dtPickEnd.Value.AddDays(-1);
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            cboCashier.Items.Add("All");
            List<string> lstUsers = clsUsers.GetUserList();
            foreach (string str in lstUsers)
            {
                cboCashier.Items.Add(str);
            }
            cboCashier.SelectedIndex = 0;
            dtPickEnd.Value = dtPickStart.Value.AddDays(1);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.Rows.Count == 0)
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
                string columns="";
                foreach(DataGridViewColumn col in dgvExpenses.Columns)
                {
                    columns += col.HeaderText + (col!=dgvExpenses.Columns[dgvExpenses.Columns.Count-1]?"\t":"");
                }
                List<string> lstValues = new List<string>();
                frmProgress progress = new frmProgress(dgvExpenses.Rows.Count);
                progress.Caption = "Loading Data";
                progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                progress.Show();
                int ctr2 = 0;

                foreach(DataGridViewRow row in dgvExpenses.Rows)
                {
                    string val="";
                    for(int ctr=0;ctr<dgvExpenses.Columns.Count;ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr!=dgvExpenses.Columns.Count-1?"\t":"");
                    }
                    lstValues.Add(val);
                    progress.Val = ++ctr2;
                    
                }
                progress.Close();
                export.SaveToExcelWithSummary(savedlg.FileName, columns, lstValues, "Total Expenses", string.Format("{0}", TotalExpenses));
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteExp_Click(object sender, EventArgs e)
        {
            if (dgvExpenses.SelectedRows!=null && dgvExpenses.SelectedRows.Count == 1)
            {
                foreach (clsExpenses exp in lstExpenses)
                {
                    if (dgvExpenses.SelectedRows[0].Cells[0].Value.ToString().Trim() == exp.Expense_id.ToString().Trim())
                    {
                        clsExpenses.Delete(exp.Expense_id);
                        btnSearch.PerformClick();
                        return;
                    }
                }
            }
        }

        private void dgvExpenses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExpenses.SelectedRows != null && dgvExpenses.SelectedRows.Count == 1)
            {
                clsExpenses exp = new clsExpenses();
                exp.Expense_id = Convert.ToInt32(dgvExpenses.SelectedRows[0].Cells[0].Value);
                exp.UserId = m_user.UserId;
                exp.UserName = m_user.UserName;
                exp.Amount = Convert.ToDouble(dgvExpenses.SelectedRows[0].Cells[3].Value);
                exp.Description = dgvExpenses.SelectedRows[0].Cells[2].Value.ToString();
                exp.Timestamp = Convert.ToDateTime(dgvExpenses.SelectedRows[0].Cells[1].Value.ToString());


                frmInput InputExpense = new frmInput();
                InputExpense.Title = "Expense Description";
                InputExpense.Caption = "Description";
                InputExpense.IsNumericOnly = false;
                InputExpense.Value = exp.Description;
                if (InputExpense.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (InputExpense.Value != "")
                    {
                        exp.Description = InputExpense.Value;

                        InputExpense.Title = "Expense Amount";
                        InputExpense.Caption = "Amount";
                        InputExpense.IsNumericOnly = true;
                        InputExpense.Value = exp.Amount.ToString();
                        if (InputExpense.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            if (InputExpense.Value != "")
                            {
                                exp.Amount = Convert.ToDouble(InputExpense.Value);
                                exp.Save();
                                btnSearch.PerformClick();
                            }
                        }
                    }
                }
            }
        }

        private void frmExpenseReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
