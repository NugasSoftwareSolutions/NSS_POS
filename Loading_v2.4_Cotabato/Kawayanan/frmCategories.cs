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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            clsThemes.ApplyTheme(this,new clsThemes.ThemeSettings(Properties.Settings.Default.Theme));
            UpdateGrid();
        }
        Dictionary<int,string> lstCategories=null;
        private void UpdateGrid()
        {
            lstCategories = dbConnect.GetCategories();
            dgvCategories.Rows.Clear();
            foreach (KeyValuePair<int,string> category in lstCategories)
            {
                AddItemToGrid(category.Key,category.Value);
            }
        }

        private void AddItemToGrid(int id, string category)
        {
            int rowidx = dgvCategories.Rows.Add();

            dgvCategories.Rows[rowidx].Cells[0].Value = id;
            dgvCategories.Rows[rowidx].Cells[1].Value = category;
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCategories.SelectedRows[0].Cells[0].Value.ToString());
                if (id>0)
                {
                    if (dbConnect.DeleteCategory(id))
                        UpdateGrid();
                    else
                        MessageBox.Show("Failed to delete category", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            frmInput input = new frmInput();
            input.Title = "Category";
            input.Caption = "Add Category";
            input.Value = "";
            if (input.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (input.Value.Trim() != "")
                {
                    if (dbConnect.AddCategory(input.Value.Trim()))
                    {
                        UpdateGrid();
                    }
                }
            }

        }

        private void frmCategories_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
