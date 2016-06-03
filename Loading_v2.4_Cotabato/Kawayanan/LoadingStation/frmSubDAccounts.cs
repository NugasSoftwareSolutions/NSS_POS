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
using System.IO;

namespace AlreySolutions.LoadingStation
{
    public partial class frmSubDAccounts : Form
    {
        clsLoadAccount m_LoadAccount = null;
        List<clsSubDAccount> m_LstSubD = new List<clsSubDAccount>();
        clsSubDAccount SelectedSubD = new clsSubDAccount();
        public frmSubDAccounts(clsLoadAccount act)
        {
            InitializeComponent();
            this.m_LoadAccount = act;
        }

        private void frmServiceFee_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this, new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
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
            ReloadSubD();
        }

        private void ReloadSubD()
        {
            m_LstSubD = clsSubDAccount.GetSubDAccounts(m_LoadAccount.LoadId, "");
            dgvSubDAccounts.Rows.Clear();
            
            foreach (clsSubDAccount act in m_LstSubD)
            {
                AddItemToGrid(act);
            }
        }
        private void AddItemToGrid(clsSubDAccount act)
        {
            int rowidx = dgvSubDAccounts.Rows.Add();

            dgvSubDAccounts.Rows[rowidx].Cells[0].Value = act.Id_subdAccounts;
            dgvSubDAccounts.Rows[rowidx].Cells[1].Value = act.Name;
            dgvSubDAccounts.Rows[rowidx].Cells[2].Value = act.MobileNum;
            dgvSubDAccounts.Rows[rowidx].Cells[3].Value = act.Discount;
            dgvSubDAccounts.Rows[rowidx].Cells[4].Value = act.Balance;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            ReloadSubD();
        }
        private void ClearFields()
        {
            txtName.Text = "";
            txtMobile.Text = "";
            txtDiscount.Text = "0";
            txtBalance.Text = "0.00";
            dgvSubDAccounts.ClearSelection();
            SelectedSubD = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                clsSubDAccount  subd = SelectedSubD;
                if (subd == null) subd = new clsSubDAccount();
                subd.LoadId = m_LoadAccount.LoadId;
                subd.Name = txtName.Text;
                subd.MobileNum = txtMobile.Text;
                subd.Discount = Convert.ToDouble(txtDiscount.Text);
                if (subd.Save())
                {
                    ClearFields();
                    ReloadSubD();
                }
                else MessageBox.Show("Service Fee Not Saved!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateFields()
        {
            bool ret = false;
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtMobile.Text))
            {
                ret = true;
            }
            else MessageBox.Show("Please Fill Necessary Fields");
            return ret;
        }

        private clsSubDAccount GetSelItem()
        {
            if (dgvSubDAccounts.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSubDAccounts.SelectedRows[0].Cells[0].Value);
                if (id > 0)
                {
                    clsSubDAccount ret = m_LstSubD.Find(x => x.Id_subdAccounts == id);
                    return ret;
                }
            }
            return null;
        }

        private void UpdateFields(clsSubDAccount act)
        {
            if (act != null)
            {
                txtName.Text = act.Name;
                txtMobile.Text = act.MobileNum;
                txtBalance.Text = act.Balance.ToString("0.00");
                txtDiscount.Text = act.Discount.ToString("0");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedSubD != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this account?", "Delete SubD Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SelectedSubD.Delete();
                    ReloadSubD();
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void dgvSvcFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedSubD = GetSelItem();
            UpdateFields(SelectedSubD);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Filter = "Excel File (*.xls)|*.xls";
            opendlg.InitialDirectory = Application.StartupPath;
            if (opendlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsExportToExcel import = new clsExportToExcel();
                if (import.UploadSubD(opendlg.FileName, m_LoadAccount.LoadId))
                {
                    ReloadSubD();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvSubDAccounts.Rows.Count == 0)
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
                foreach (DataGridViewColumn col in dgvSubDAccounts.Columns)
                {
                    columns += col.HeaderText + (col != dgvSubDAccounts.Columns[dgvSubDAccounts.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvSubDAccounts.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvSubDAccounts.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvSubDAccounts.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }
    }
}
