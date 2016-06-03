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
    public partial class frmSQLQuery : Form
    {
        public frmSQLQuery()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != "")
            {
                dbConnect con = new dbConnect();
                string error="";
                int ret = con.ExecuteNonQuery(txtInput.Text,ref error);
                if (ret == -1)
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    lblResult.Text = string.Format("Result: {0} records updated", ret);
            }
        }
    }
}
