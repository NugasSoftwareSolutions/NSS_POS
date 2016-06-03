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
    public partial class frmServiceFee : Form
    {
        clsLoadAccount m_LoadAccount = null;
        clsServiceFee SELECTED_FEE = null;
        public frmServiceFee(clsLoadAccount act)
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
            ReloadFees();
        }

        private void ReloadFees()
        {
            m_LoadAccount.LstServiceFees = clsServiceFee.GetServiceFees(m_LoadAccount.LoadId);
            dgvSvcFees.Rows.Clear();
            if (m_LoadAccount.LoadType == LoadAccountType.ELoad)
            {
                dgvSvcFees.Columns[6].Visible = true;
                label8.Visible = true;
                txtRemarks.Visible = true;
            }
            foreach (clsServiceFee act in m_LoadAccount.LstServiceFees)
            {
                AddItemToGrid(act);
            }
        }
        private void AddItemToGrid(clsServiceFee act)
        {
            int rowidx = dgvSvcFees.Rows.Add();

            dgvSvcFees.Rows[rowidx].Cells[0].Value = act.ServiceFeeID;
            dgvSvcFees.Rows[rowidx].Cells[1].Value = act.AmountFrom;
            dgvSvcFees.Rows[rowidx].Cells[2].Value = act.AmountTo;
            dgvSvcFees.Rows[rowidx].Cells[3].Value = act.EcashFee;
            dgvSvcFees.Rows[rowidx].Cells[4].Value = act.P2PFee;
            dgvSvcFees.Rows[rowidx].Cells[5].Value = act.Rebate;
            dgvSvcFees.Rows[rowidx].Cells[6].Value = act.Remarks;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
            ReloadFees();
        }
        private void ClearFields()
        {
            txtAmtFrom.Text = "0";
            txtAmtTo.Text = "0";
            txtEcashFee.Text = "0";
            txtP2P.Text = "0";
            txtRebatePercentage.Text = "0";
            dgvSvcFees.ClearSelection();
            SELECTED_FEE = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                clsServiceFee fee = SELECTED_FEE;
                if (fee == null) fee = new clsServiceFee();
                fee.Load_id = m_LoadAccount.LoadId;
                fee.AmountFrom = double.Parse(txtAmtFrom.Text);
                fee.AmountTo = double.Parse(txtAmtTo.Text);
                fee.EcashFee = double.Parse(txtEcashFee.Text);
                fee.P2PFee = double.Parse(txtP2P.Text);
                fee.Rebate = double.Parse(txtRebatePercentage.Text);
                fee.Remarks = txtRemarks.Text;

                if (fee.Save())
                {
                    MessageBox.Show("Service Fee Successfully Saved!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    ReloadFees();
                }
                else MessageBox.Show("Service Fee Not Saved!", "Save Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateFields()
        {
            bool ret = false;
            if (txtAmtFrom.Text != "" && !string.IsNullOrEmpty(txtAmtTo.Text) && !string.IsNullOrEmpty(txtEcashFee.Text) && !string.IsNullOrEmpty(txtP2P.Text) && !string.IsNullOrEmpty(txtRebatePercentage.Text))
            {
                if (double.Parse(txtAmtFrom.Text) > double.Parse(txtAmtTo.Text))
                {
                    MessageBox.Show("'Amount To' Must be Greater than Amount From.");
                    return false;
                }
                ret = true;
            }
            else MessageBox.Show("Please Fill Necessary Fields");
            return ret;
        }

        private clsServiceFee GetSelItem()
        {
            if (dgvSvcFees.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvSvcFees.SelectedRows[0].Cells[0].Value);
                if (id > 0)
                {
                    clsServiceFee ret = m_LoadAccount.LstServiceFees.Find(x => x.ServiceFeeID == id);
                    return ret;
                }
            }
            return null;
        }

        private void UpdateFields(clsServiceFee act)
        {
            if (act != null)
            {
                txtAmtFrom.Text = act.AmountFrom.ToString();
                txtAmtTo.Text = act.AmountTo.ToString();
                txtEcashFee.Text = act.EcashFee.ToString();
                txtP2P.Text = act.P2PFee.ToString();
                txtRebatePercentage.Text = act.Rebate.ToString();
                if (m_LoadAccount.LoadType == LoadAccountType.ELoad)
                {
                    txtRemarks.Text = act.Remarks;
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SELECTED_FEE != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this service fee", "Delete service fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    SELECTED_FEE.Delete();
                    ReloadFees();
                }
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void dgvSvcFees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SELECTED_FEE = GetSelItem();
            UpdateFields(SELECTED_FEE);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Filter = "Excel File (*.xls)|*.xls";
            opendlg.InitialDirectory = Application.StartupPath;
            if (opendlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clsExportToExcel import = new clsExportToExcel();
                if (import.UploadServiceFees(opendlg.FileName, m_LoadAccount.LoadId))
                {
                    ReloadFees();
                }
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvSvcFees.Rows.Count == 0)
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
                foreach (DataGridViewColumn col in dgvSvcFees.Columns)
                {
                    columns += col.HeaderText + (col != dgvSvcFees.Columns[dgvSvcFees.Columns.Count - 1] ? "\t" : "");
                }
                List<string> lstValues = new List<string>();
                foreach (DataGridViewRow row in dgvSvcFees.Rows)
                {
                    string val = "";
                    for (int ctr = 0; ctr < dgvSvcFees.Columns.Count; ctr++)
                    {
                        val += row.Cells[ctr].Value.ToString() + (ctr != dgvSvcFees.Columns.Count - 1 ? "\t" : "");
                    }
                    lstValues.Add(val);
                }
                export.SaveToExcel(savedlg.FileName, columns, lstValues);
            }
        }

        private void txtRebatePercentage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSave.Focus();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtP2P_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtRebatePercentage.Focus();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtEcashFee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtP2P.Focus();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtAmtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtAmtFrom.Focus();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || (e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtAmtTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtEcashFee.Focus();
            }
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 || e.KeyCode == Keys.Back
                || ( e.KeyCode == Keys.OemPeriod) || (e.KeyCode == Keys.Decimal) || e.KeyCode == Keys.Delete
                || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {

            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }

    }
}
