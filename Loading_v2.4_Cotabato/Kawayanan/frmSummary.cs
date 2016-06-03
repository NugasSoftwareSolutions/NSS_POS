using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Kawayanan.Class;

namespace Kawayanan
{
    public partial class frmSummary : Form
    {
        Dictionary<string, clsProductItem> dicProdSold = new Dictionary<string,clsProductItem>();
        Dictionary<string,clsTransactionItem> dicInventoryItems = new Dictionary<string,clsTransactionItem>();

        List<Receipt> m_receipts = new List<Receipt>();
        public Receipt m_SelectedReceipt = null;
        public int AccessLevel = -1;
        public frmSummary()
        {
            InitializeComponent();
        }

        private void frmSummary_Load(object sender, EventArgs e)
        {
            dtPick.Value = DateTime.Now;
            if (AccessLevel != 1)
            {
                lblTotalIncome.Visible = false;
                lblTotalSales.Visible = false;
                txtIncome.Visible = false;
                txtSales.Visible = false;
                btnPrint.Visible = false;
                btnShowIncome.Visible = false;
                chkAcceptPayment.Visible = false;
                txtName.Visible = false;
                lblName.Visible = false;
            }
            //UpdateDictionary();
            //UpdateList(String.Format("Select * from Receipt WHERE TransDate like '%{0}%' Order by ID desc", dtPick.Value.ToShortDateString()));
            
        }

        private List<clsTransactionItem> lstInventoryItems = new List<clsTransactionItem>();
        //private void UpdateDictionary()
        //{
        //    try
        //    {
        //        dbConnect connect = new dbConnect();
        //        lstInventoryItems.Clear();
        //        lstInventory.Items.Clear();
        //        dicInventoryItems = connect.GetORSalesInfo(Convert.ToDateTime(dtPick.Text), Convert.ToDateTime(dtPick.Text).AddDays(1));
        //        //connect.ExecuteQuery(string.Format("Select * from InventoryHistory where [Date]=#{0}# Order by Inventory_ID",Convert.ToDateTime(dtPick.Text)), lstInventoryItems);
        //        dicInventoryItems.Clear();
        //        foreach (clsTransactionItem fi in lstInventoryItems)
        //        {
        //            if(fi.Quantity>0)
        //                lstInventory.Items.Add(string.Format("{0}: {1} = {2}", fi.ProductCode, fi.Description, fi.Quantity));
        //            //fi.Quantity = 0;
        //            dicInventoryItems.Add(fi.ProductCode, fi);
        //        }
        //        connect.Close();
        //    }
        //    catch { }
        //}

        //private void UpdateList(string sql)
        //{
        //    try
        //    {
        //        btnShowBal.Text = "Show Balance";

        //        dbConnect connect = new dbConnect();
        //        List<Receipt> lstReceipt = new List<Receipt>();
        //        Dictionary<string, int> dicSales = new Dictionary<string, int>();
        //        connect.ExecuteQuery(sql, lstReceipt);
        //        lstReceipts.Items.Clear();
        //        lstProductsSold.Items.Clear();
        //        m_receipts.Clear();
        //        m_receipts.AddRange(lstReceipt);

        //        double totalincome=0;
        //        double totalsales = 0;
        //        dicProdSold.Clear();
        //        foreach (Receipt r in lstReceipt)
        //        {
        //            if (r.TotalAmount > 0)
        //            {
        //                lstReceipts.Items.Add("[" + r.TransDate.ToShortDateString() + " " + r.TransDate.ToShortTimeString() + "]" + " TableNum:" + r.TableNum + " OR:" + r.ReceiptID.ToString("00000") + " Customer:" + r.CustomerName + " Amount Due: " + r.TotalAmount + " Balance: " + (r.TotalAmount - (r.TotalAmount <= r.CashTendered ? r.TotalAmount : r.CashTendered)).ToString());
        //                totalincome += (r.TotalAmount <= r.CashTendered ? r.TotalAmount : r.CashTendered);
        //                totalsales += r.TotalAmount;
        //                foreach (KeyValuePair<string, clsProductItem> fi in r.PurchasedItems)
        //                {
        //                    clsProductItem fitem = new clsProductItem();
        //                    fitem.Amount = fi.Value.Amount;
        //                    fitem.BarCode = fi.Value.BarCode;
        //                    fitem.Description = fi.Value.Description;
        //                    fitem.Qty = fi.Value.Qty;
        //                    fitem.UserID = fi.Value.UserID;
        //                    clsProductItem tmp = new clsProductItem();
        //                    connect.ExecuteQuery("Select * from Food WHERE ID = '" + fitem.BarCode + "'", tmp);
        //                    if(tmp!=null)
        //                        fitem.ProductCode = tmp.ProductCode;
        //                    if (fitem.Qty > 0)
        //                    {
        //                        if (dicProdSold.ContainsKey(fi.Key) == false)
        //                        {
        //                            dicProdSold.Add(fi.Key, fitem);
        //                        }
        //                        else
        //                        {
        //                            dicProdSold[fi.Key].Qty += fitem.Qty;
        //                        }
        //                    }
        //                    if (fitem.ProductCode != null)
        //                    {
        //                        List<string> codes = fitem.ProductCode.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        //                        if (codes.Count > 0)
        //                        {
        //                            foreach (string str in codes)
        //                            {
        //                                if (dicSales.ContainsKey(str) == false) dicSales.Add(str, 0);
        //                                if (dicInventoryItems.ContainsKey(str))
        //                                {
        //                                    dicInventoryItems[str].Quantity -= fi.Value.Qty;
        //                                    dicSales[str] += fi.Value.Qty;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        lstSales.Items.Clear();
        //        lstTotal.Items.Clear();
        //        foreach (KeyValuePair<string, clsTransactionItem> i in dicInventoryItems)
        //        {
        //            lstSales.Items.Add(string.Format("{0}: {1} = {2}", i.Value.ProductCode, i.Value.Description, i.Value.Quantity));
        //            if(dicSales.ContainsKey(i.Key))
        //                lstTotal.Items.Add(string.Format("{0}: {1} = {2}", i.Value.ProductCode, i.Value.Description, dicSales[i.Key]));
        //        }
                
        //        foreach (KeyValuePair<string, clsProductItem> fi in dicProdSold)
        //        {
        //            lstProductsSold.Items.Add(fi.Value.ToString());
        //        }
        //        lstProductsSold.Sorted = true;
        //        lstSales.Sorted = true;
        //        lstInventory.Sorted = true;
        //        lstTotal.Sorted = true;
        //        txtIncome.Text = totalincome.ToString();
        //        txtSales.Text = totalsales.ToString();
        //        connect.Close();
        //    }
        //    catch { }
        //}

        //private void ShowBalanceList()
        //{
        //    try
        //    {
        //        btnShowBal.Text = "Show Balance";

        //        dbConnect connect = new dbConnect();
        //        List<Receipt> lstReceipt = new List<Receipt>();
        //        connect.ExecuteQuery(String.Format("Select * from Receipt WHERE TransDate like '%{0}%' Order by ID desc", dtPick.Value.Year), lstReceipt);
        //        lstReceipts.Items.Clear();
        //        lstProductsSold.Items.Clear();
        //        m_receipts.Clear();
        //        m_receipts.AddRange(lstReceipt);

        //        double totalincome = 0;
        //        double totalsales = 0;
        //        dicProdSold.Clear();
        //        foreach (Receipt r in lstReceipt)
        //        {
        //            if (r.TotalAmount > 0 && (r.TotalAmount - (r.TotalAmount <= r.CashTendered ? r.TotalAmount : r.CashTendered))>0)
        //            {
        //                lstReceipts.Items.Add("[" + r.TransDate.ToShortDateString() + " " + r.TransDate.ToShortTimeString() + "] \tOR:" + r.ReceiptID.ToString("00000") + "\tCustomer:" + r.CustomerName + "\tTableNum:" + r.TableNum + "\tAmount Due: " + r.TotalAmount + "\t\tBalance: " + (r.TotalAmount - (r.TotalAmount <= r.CashTendered ? r.TotalAmount : r.CashTendered)).ToString());
        //                totalincome += (r.TotalAmount <= r.CashTendered ? r.TotalAmount : r.CashTendered);
        //                totalsales += r.TotalAmount;
        //                foreach (KeyValuePair<string, clsProductItem> fi in r.PurchasedItems)
        //                {
        //                    clsProductItem fitem = new clsProductItem();
        //                    fitem.Amount = fi.Value.Amount;
        //                    fitem.BarCode = fi.Value.BarCode;
        //                    fitem.Description = fi.Value.Description;
        //                    fitem.Qty = fi.Value.Qty;
        //                    fitem.UserID = fi.Value.UserID;

        //                    if (fitem.Qty > 0)
        //                    {
        //                        if (dicProdSold.ContainsKey(fi.Key) == false)
        //                        {
        //                            dicProdSold.Add(fi.Key, fitem);
        //                        }
        //                        else
        //                        {
        //                            dicProdSold[fi.Key].Qty += fitem.Qty;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        foreach (KeyValuePair<string, clsProductItem> fi in dicProdSold)
        //        {
        //            lstProductsSold.Items.Add(fi.Value.ToString());
        //        }
        //        txtIncome.Text = totalincome.ToString();
        //        txtSales.Text = totalsales.ToString();
        //        connect.Close();
        //    }
        //    catch { }
        //}

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void dtPick_ValueChanged(object sender, EventArgs e)
        {
            //UpdateDictionary();
            //UpdateList(String.Format("Select * from Receipt WHERE TransDate like '%{0}%' Order by ID desc", dtPick.Value.ToShortDateString()));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (btnShowBal.Text == "Show Balance")
            {
                Print();
            }
            else
            {
                Print(2);
            }
        }
        public void Print(int printItem=1)
        {
            PrintDocument recordDoc;
            // Create the document and name it
            recordDoc = new PrintDocument();
            recordDoc.DocumentName = "Inventory Receipt";
            PaperSize ps = new PaperSize();
            ps.RawKind = 119;
            ps.Width = 200;
            recordDoc.DefaultPageSettings.PaperSize = ps;
            recordDoc.DefaultPageSettings.Margins.Top = 1;
            recordDoc.DefaultPageSettings.Margins.Left = 1;
            if (printItem == 1)
            {
                recordDoc.PrintPage += new PrintPageEventHandler(this.PrintReceiptPage);
                CalculatePrint();
            }
            else
            {
                recordDoc.PrintPage += new PrintPageEventHandler(this.PrintUtangPage);
                CalculateUtangPrint();
            }
            ps.Height = m_ReceiptSize;

            // Preview document
            System.Windows.Forms.PrintPreviewDialog dlgPreview = new System.Windows.Forms.PrintPreviewDialog();
            dlgPreview.Document = recordDoc;

            Profile _myProfile = new Profile();
            _myProfile.ReadXML();
            if (_myProfile.EnablePreview == true)
            {
                dlgPreview.ShowDialog();
            }
            else
            {
                recordDoc.Print();
                dlgPreview.Close();
            }
            // Dispose of document when done printing
            recordDoc.Dispose();
        }
        private int m_ReceiptSize = 200;
        private void PrintReceiptPage(object sender, PrintPageEventArgs e)
        {
            int y;
            // Print receipt
            Font myFont = new Font("Small Font", 7, FontStyle.Regular);
            y = e.MarginBounds.Y;
            try
            {
                Bitmap bmp2 = new Bitmap("logo.png");
                Rectangle rec2 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
                e.Graphics.DrawImage(bmp2, 0, 0, rec2, GraphicsUnit.Pixel);
            }
            catch { }

            List<string> strmsg = new List<string>();
            List<string> strmsg2 = new List<string>();
            Profile _myProfile = new Profile();
            _myProfile.ReadXML();
            strmsg.Add(_myProfile.Company); 
            strmsg.Add(_myProfile.Address); 
            strmsg.Add(_myProfile.TIN); 
            strmsg.Add(_myProfile.ContactNum); 
            strmsg.Add(" "); 
            strmsg.Add(" "); 
            strmsg.Add("Date:" + dtPick.Value.ToShortDateString()); 
            strmsg.Add("Sales Inventory"); 
            strmsg.Add("--------------------------------------------------------------------------------");
            double total = 0.0;
            foreach (KeyValuePair< string,clsProductItem> fi in dicProdSold)
            {
                if (fi.Value.Description.Length > 25)
                    strmsg.Add(String.Format("{0}: {1} - P{2} x {3} = {4}", fi.Value.BarCode, fi.Value.Description.Substring(0,25), fi.Value.Amount.ToString("0.00"), fi.Value.Qty, fi.Value.Total));
                else
                    strmsg.Add(fi.Value.ToString());

                total += fi.Value.Total;
            }
            strmsg.Add("--------------------------------------------------------------------------------");
            strmsg.Add("Total Sales:" + total.ToString("0.00"));
            strmsg.Add(string.Format("Total Income: {0:0.00}",  Convert.ToDouble(txtIncome.Text)));
            strmsg.Add(" ");
            strmsg.Add(" ");
            strmsg.Add("Products Left");
            strmsg.Add("--------------------------------------------------------------------------------");
            for (int ctr2 = 0; ctr2 < lstSales.Items.Count; ctr2++)
            {
                strmsg.Add(lstSales.Items[ctr2].ToString());
            }
            strmsg.Add("--------------------------------------------------------------------------------");

            int ctr = 1;
            foreach (string str in strmsg)
            {
                if (ctr < 5)
                {
                    myFont = new Font("Small Font", 5, FontStyle.Bold);
                    e.Graphics.DrawString(str, myFont, Brushes.Black, 50, y);
                }
                else
                {
                    myFont = new Font("Small Font", 5, FontStyle.Regular);
                    e.Graphics.DrawString(str, myFont, Brushes.Black, e.MarginBounds.X, y);
                }
                y += (int)e.Graphics.MeasureString(str, myFont).Height;
                ctr++;
            }

        }
        private void CalculatePrint()
        {
            System.Windows.Forms.PrintPreviewDialog dlgPreview = new System.Windows.Forms.PrintPreviewDialog();
            Graphics g = dlgPreview.CreateGraphics();

            int y;
            // Print receipt
            Font myFont = new Font("Small Font", 7, FontStyle.Regular);
            y = 0;
            try
            {
                Bitmap bmp2 = new Bitmap("logo.png");
                Rectangle rec2 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
                g.DrawImage(bmp2, 0, 0, rec2, GraphicsUnit.Pixel);
            }
            catch { }

            List<string> strmsg = new List<string>();
            List<string> strmsg2 = new List<string>();
            Profile _myProfile = new Profile();
            _myProfile.ReadXML();
            strmsg.Add(_myProfile.Company);
            strmsg.Add(_myProfile.Address);
            strmsg.Add(_myProfile.TIN);
            strmsg.Add(_myProfile.ContactNum);
            strmsg.Add(" ");
            strmsg.Add(" ");
            strmsg.Add("Date:" + dtPick.Value.ToShortDateString());
            strmsg.Add("Sales Inventory");
            strmsg.Add("--------------------------------------------------------------------------------");
            double total = 0.0;
            foreach (KeyValuePair<string, clsProductItem> fi in dicProdSold)
            {
                strmsg.Add(fi.Value.ToString());
                total += fi.Value.Total;
            }
            strmsg.Add("--------------------------------------------------------------------------------");
            strmsg.Add("Grand Total:" + total.ToString("0.00"));
            strmsg.Add(string.Format("Total Income: {0:0.00}", Convert.ToDouble(txtIncome.Text)));
            strmsg.Add(" ");
            strmsg.Add(" ");
            strmsg.Add("Products Left");
            strmsg.Add("--------------------------------------------------------------------------------");
            for (int ctr2 = 0; ctr2 < lstSales.Items.Count; ctr2++)
            {
                strmsg.Add(lstSales.Items[ctr2].ToString());
            }
            strmsg.Add("--------------------------------------------------------------------------------");


            int ctr = 1;
            foreach (string str in strmsg)
            {
                if (ctr < 5)
                {
                    myFont = new Font("Small Font", 5, FontStyle.Bold);
                    g.DrawString(str, myFont, Brushes.Black, 50, y);
                }
                else
                {
                    myFont = new Font("Small Font", 5, FontStyle.Regular);
                    g.DrawString(str, myFont, Brushes.Black, 0, y);
                }
                y += (int)g.MeasureString(str, myFont).Height;
                ctr++;
            }
            m_ReceiptSize = y + 30;
        }

        private void PrintUtangPage(object sender, PrintPageEventArgs e)
        {
            int y;
            // Print receipt
            Font myFont = new Font("Small Font", 7, FontStyle.Regular);
            y = e.MarginBounds.Y;
            try
            {
                Bitmap bmp2 = new Bitmap("logo.png");
                Rectangle rec2 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
                e.Graphics.DrawImage(bmp2, 0, 0, rec2, GraphicsUnit.Pixel);
            }
            catch { }

            List<string> strmsg = new List<string>();
            List<string> strmsg2 = new List<string>();
            Profile _myProfile = new Profile();
            _myProfile.ReadXML();
            strmsg.Add(_myProfile.Company);
            strmsg.Add(_myProfile.Address);
            strmsg.Add(_myProfile.TIN);
            strmsg.Add(_myProfile.ContactNum);
            strmsg.Add(" ");
            strmsg.Add(" ");
            strmsg.Add("Date:" + dtPick.Value.ToString());
            strmsg.Add("Item(s) Purchased");
            strmsg.Add("--------------------------------------------------------------------------------");
            double total = 0.0;
            foreach (Receipt r in m_receipts)
            {
                strmsg.Add(string.Format("{0}:Name={1} Balance={2}", r.TransDate, r.CustomerName, (r.TotalAmount - r.CashTendered < 0 ? 0 : r.TotalAmount - r.CashTendered)));
                foreach (KeyValuePair<string, clsPurchasedItem> fi in r.PurchasedItems)
                {
                    strmsg.Add(string.Format("\t{0}:{1}x{2}={3}", fi.Value.Description, fi.Value.Qty, fi.Value.Amount, fi.Value.Qty * fi.Value.Amount));
                }

                total += (r.TotalAmount-r.CashTendered<0?0:r.TotalAmount-r.CashTendered);
            }

            strmsg.Add("--------------------------------------------------------------------------------");
            strmsg.Add("Total Balance:" + total.ToString("0.00"));

            int ctr = 1;
            foreach (string str in strmsg)
            {
                if (ctr < 5)
                {
                    myFont = new Font("Small Font", 5, FontStyle.Bold);
                    e.Graphics.DrawString(str, myFont, Brushes.Black, 50, y);
                }
                else
                {
                    myFont = new Font("Small Font", 5, FontStyle.Regular);
                    e.Graphics.DrawString(str, myFont, Brushes.Black, e.MarginBounds.X, y);
                }
                y += (int)e.Graphics.MeasureString(str, myFont).Height;
                ctr++;
            }

        }
        private void CalculateUtangPrint()
        {
            System.Windows.Forms.PrintPreviewDialog dlgPreview = new System.Windows.Forms.PrintPreviewDialog();
            Graphics g = dlgPreview.CreateGraphics();

            int y;
            // Print receipt
            Font myFont = new Font("Small Font", 7, FontStyle.Regular);
            y = 0;
            try
            {
                Bitmap bmp2 = new Bitmap("logo.png");
                Rectangle rec2 = new Rectangle(0, 0, bmp2.Width, bmp2.Height);
                g.DrawImage(bmp2, 0, 0, rec2, GraphicsUnit.Pixel);
            }
            catch { }

            List<string> strmsg = new List<string>();
            List<string> strmsg2 = new List<string>();
            Profile _myProfile = new Profile();
            _myProfile.ReadXML();
            strmsg.Add(_myProfile.Company);
            strmsg.Add(_myProfile.Address);
            strmsg.Add(_myProfile.TIN);
            strmsg.Add(_myProfile.ContactNum);
            strmsg.Add(" ");
            strmsg.Add(" ");
            strmsg.Add("Date:" + dtPick.Value.ToString());
            strmsg.Add("Item(s) Purchased");
            strmsg.Add("--------------------------------------------------------------------------------");
            double total = 0.0;
            foreach (Receipt r in m_receipts)
            {
                strmsg.Add(string.Format("{0}:Name={1} Balance={2}", r.TransDate, r.CustomerName, (r.TotalAmount - r.CashTendered < 0 ? 0 : r.TotalAmount - r.CashTendered)));
                foreach (KeyValuePair<string, clsProductItem> fi in r.PurchasedItems)
                {
                    strmsg.Add(string.Format("\t{0}:{1}x{2}={3}", fi.Value.Description, fi.Value.Qty, fi.Value.Amount, fi.Value.Qty * fi.Value.Amount));
                }
                total += (r.TotalAmount - r.CashTendered < 0 ? 0 : r.TotalAmount - r.CashTendered);
            }

            strmsg.Add("--------------------------------------------------------------------------------");
            strmsg.Add("Total Balance:" + total.ToString("0.00"));
            strmsg.Add("--------------------------------------------------------------------------------");


            int ctr = 1;
            foreach (string str in strmsg)
            {
                if (ctr < 5)
                {
                    myFont = new Font("Small Font", 5, FontStyle.Bold);
                    g.DrawString(str, myFont, Brushes.Black, 50, y);
                }
                else
                {
                    myFont = new Font("Small Font", 5, FontStyle.Regular);
                    g.DrawString(str, myFont, Brushes.Black, 0, y);
                }
                y += (int)g.MeasureString(str, myFont).Height;
                ctr++;
            }
            m_ReceiptSize = y + 30;
        }

        private void lstReceipts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstReceipts.SelectedIndex > -1)
            {
                if (chkAcceptPayment.Checked == false)
                {
                    m_SelectedReceipt = m_receipts[lstReceipts.SelectedIndex];
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    m_SelectedReceipt = m_receipts[lstReceipts.SelectedIndex];
                    AcceptOrder();

                }
            }
        }
        private void AcceptOrder()
        {
            if (m_SelectedReceipt != null && m_SelectedReceipt.TotalAmount > 0)
            {
                m_SelectedReceipt.CashTendered = m_SelectedReceipt.TotalAmount;
                m_SelectedReceipt.Save();
                UpdateBalance();
            }
        }

        private void lstReceipts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstReceipts.SelectedIndex > -1)
            {
                lstPurchases.Items.Clear();
                foreach (KeyValuePair<string, clsProductItem> item in m_receipts[lstReceipts.SelectedIndex].PurchasedItems)
                {
                    lstPurchases.Items.Add( item.Value.ToString());
                }
            }
        }

        private void btnShowBal_Click(object sender, EventArgs e)
        {
            if (btnShowBal.Text.Contains("Show") == true)
            {
                UpdateBalance();
            }
            else
            {
                //btnShowBal.Text = "Show Balance";
                UpdateList(String.Format("Select * from Receipt WHERE TransDate like '%{0}%' Order by ID desc", dtPick.Value.ToShortDateString()));

            }
        }

        private void UpdateBalance()
        {
            UpdateDictionary();
            if(txtName.Text!="")
                UpdateList(String.Format("Select * from Receipt WHERE CustomerName in ('{0}') and Payment=0 Order by ID desc", txtName.Text.Replace(",", "','")));
            else
                UpdateList(String.Format("Select * from Receipt WHERE Payment=0 Order by ID desc", txtName.Text));

            btnShowBal.Text = "Hide Balance";
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                UpdateBalance();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnShowIncome_Click(object sender, EventArgs e)
        {
            bool bVis = !lblTotalIncome.Visible;
            lblTotalIncome.Visible = bVis;
            lblTotalSales.Visible = bVis;
            txtIncome.Visible = bVis;
            txtSales.Visible = bVis;
        }
    }
}
