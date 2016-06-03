using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Xls;
using System.IO;
using AlreySolutions.Class.Load;

namespace AlreySolutions.Class
{
    public class clsExportToExcel
    {
        public clsExportToExcel()
        {
            Spire.License.LicenseProvider.SetLicenseKey("nRwBAHxpDJUeZM90WuhnYPrNjAv82SM9h2Z1wTCtFDZe/tUXxbHnXcHRWpYlYlirk3qcfwXV9yWtGQi0Cskt6OJAixfPN6lYXcvCjh/dof9wH0cckwUs8LEtcqSj6+fmJjUDffDWjYcf0ad+4E/x6RHAeeFw9uxM2Zr6euqwP6n8DLyq6NtCcSxouLGvKi1Nr710458W4Qfnmb3P7uP1XoC9KC2V1rgTRB4kQetum8nnXJw3KyXijElCEwNTR4OoZfnXOgESU0aEuHe4xlncHOVdPcAPfujameTsGHnzO42G5u/zxr5kIZNVWDmrzC8Hdj/477Y0jU/ub8uKVxS5kPeBoFWYSR3SBHCg8NGPOAhk9sG6cnzhQfPAsdVcUku8vBmtpGiIB5hzokQiplIBeul0ZSN3pabw7OCVy63eoEx4wLBahQqybLcNOWJsbvX/CEmyPbZOpQ1PWyx4VqPrtQjp9ECaV6NzRYUdxi5DFzF/SygSVR6x7Ke5qec9q2XM5Aec7ku2UhlNlupuN/EL7eO25eXdIPm/YYkptwmZujW4ZQWwOFDaBCtM1cOhBn6CVAC1LlOSfDN/7bngEHTi4BgONdnJ8hZUchhFhp3+WZ8MHxwjiiHjPOOR5GEFYLelWo8VgMAL/8+uAE4TxD0hd12T6pV8RMjLpgD1hO815Vb+Fv0syBD/wO6Zr97zaf9yIXZcNIVmnv9LPVre8NOmJBnyiGU+Bm9JTW7olowokprsG3V55PB4dszJ0oAv8byZXvui+pOr4sh4WyuzrnwZAqBSMQV19RcOYTU5yUdxR2NAVwVLa+oSeuXkeehMLEg35f5ybrFqci3Bj6YCWB1CKIXooM8KxR5mxBzCa9tqqo4suQ1wUspnUoXlQR2eXX0AWAcBut6DMiwYka2a1yjm0MLfWf7mZ6joT/OwQKV9JoB51SexRowcbUa4lP1oDo3UNFtSjF45SSGh6v06hOBbjvG6YPahK5Trs3nssdIeD1TKuSf1okYiFiknLKv7XIpS7f31XZEv8IqUJg3Vm700hBqJP1ii6LOpwO4XFKW067j9mb0gmW5qhz1QCWuXt6/RBnR7ZNRh6DGJVCRhZSnu3riZotbZ6fZhcMJByBsloljGPUbyhRNzFcAUq8IwcROpJlX8IMAzhh2bESfkBVNrVxXSBalpehQRykA4dIrj8djdwZEyNu7BCft7W+shwCdD8H49ZzDxBXVYgo3qlJbEINmStZmzW21/j7cCSOUNqkdCix6LhJdTpT21isI8sJiUEPd6KL5X27wIgZ/uNgJRGeSUY1/zdaXmJt3+83lsREmGOZmeDf+1mtiUJ7M2yhSaAZVN4BAxgVGRYAoGBmyDFp+ueqpAun013siorxMg4b/fDqCC3WbkYQ==");
        }

        public bool SaveToExcel( string filename, string columns, List<string> values, string DateAsOf = "Export" )
        {
            Workbook xlsBook = new Workbook();
            Worksheet xlsSheet;
            int iRow =0;
            
            ClearSheets(xlsBook, DateAsOf);
            xlsSheet = xlsBook.Worksheets[DateAsOf];
            AddHeader(columns.Split("\t".ToCharArray()), xlsSheet, iRow, true);
            frmProgress progress = new frmProgress(values.Count);
            progress.Caption = "Export in progress";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();
            int ctr = 0;
            foreach (string strdata in values)
            {
                AddToExcel(strdata, xlsSheet, ref iRow);
                progress.Val = ++ctr;
                
            }
            progress.Close();
            xlsBook.Worksheets.Add(xlsSheet);
            xlsBook.SaveToFile(filename);
            System.Windows.Forms.MessageBox.Show("Export Completed!", "Export", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return File.Exists(filename);
        }

      
        public bool SaveToExcelWithSummary(string filename,string columns, List<string> values, string summarycolumns, string summaryvalues)
        {
            Workbook xlsBook = new Workbook();
            Worksheet xlsSheet;
            int iRow = 0;
            ClearSheets(xlsBook, "Export");
            xlsSheet = xlsBook.Worksheets["Export"];

            AddHeader(summarycolumns.Split("\t".ToCharArray()), xlsSheet, iRow, false);
            AddToExcel(summaryvalues, xlsSheet, ref iRow);

            iRow+=3;

            AddHeader(columns.Split("\t".ToCharArray()), xlsSheet, iRow, false);
            frmProgress progress = new frmProgress(values.Count);
            progress.Caption = "Export in progress";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();
            int ctr = 0;
            foreach (string strdata in values)
            {
                if (strdata.Contains("HEADER1"))
                {
                    string tmp = strdata.Replace("HEADER1", "");
                    iRow++;
                    AddHeader(tmp.Split("\t".ToCharArray()), xlsSheet, iRow, false);
                } 
                else if (strdata.Contains("HEADER2"))
                {
                    string tmp = strdata.Replace("HEADER2", "");
                    iRow++;
                    AddHeader(tmp.Split("\t".ToCharArray()), xlsSheet, iRow, true);
                }
                else
                {
                    AddToExcel(strdata, xlsSheet, ref iRow);
                }
                progress.Val = ++ctr;
                
            }
            progress.Close();
            xlsBook.Worksheets.Add(xlsSheet);
            xlsBook.SaveToFile(filename);
            System.Windows.Forms.MessageBox.Show("Export Completed!", "Export", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return File.Exists(filename);
        }

        public bool SaveStatementToExcel(string filename, string account, double TotPurchases, double TotPayment, double Balance, List<clsAccountStatement> lstStatement )
        {
            Workbook xlsBook = new Workbook();
            Worksheet xlsSheet;
            int iRow = 0;
            xlsBook.LoadTemplateFromFile("template\\accountstatement.xls");
            xlsSheet = xlsBook.Worksheets["Statement"];
            xlsSheet.Range[2, 3].Text = account;
            xlsSheet.Range[3, 3].Text = TotPurchases.ToString("0.00");
            xlsSheet.Range[4, 3].Text = TotPayment.ToString("0.00");
            xlsSheet.Range[5, 3].Text = Balance.ToString("0.00");
            xlsSheet.Range[2, 6].Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            iRow = 7;
            frmProgress progress = new frmProgress(lstStatement.Count);
            progress.Caption = "Export in progress";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();
            int ctr = 0;
            foreach (clsAccountStatement acc in lstStatement)
            {
                AddToExcel(acc.ToString(), xlsSheet, ref iRow);
                progress.Val = ++ctr;
                
            }
            progress.Close();
            xlsBook.Worksheets.Add(xlsSheet);
            xlsBook.SaveToFile(filename);
            System.Windows.Forms.MessageBox.Show("Export Completed!", "Export", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return File.Exists(filename);
        }

        private static void AddHeader(string[] arrDataHead, Worksheet xlsSheet,int iRow, bool isMain)
        {
            for (int iCol = 0; iCol < arrDataHead.Length; iCol++)
            {
                xlsSheet.Range[iRow + 1, iCol + 1].Text = arrDataHead[iCol];
                xlsSheet.Columns[iCol].ColumnWidth = 20;
                xlsSheet.Columns[iCol].RowHeight = 20;
                xlsSheet.Range[iRow + 1, iCol + 1].Style.HorizontalAlignment = HorizontalAlignType.Center;
                if (arrDataHead[iCol].Trim() != "")
                {
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Font.IsBold = true;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.FillPattern = ExcelPatternType.Solid;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Color = isMain ? System.Drawing.Color.LightPink : System.Drawing.Color.LightBlue;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeLeft].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeRight].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeTop].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeBottom].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                }
            }
        }

        private static void AddToExcel(string strData, Worksheet xlsSheet, ref int iRow)
        {
            try
            {
                string[] arrData;
                arrData = strData.Split("\t".ToCharArray());

                iRow++;

                for (int iCol = 0; iCol < arrData.Length; iCol++)
                {
                    try
                    {
                        if ("123456789".Contains(arrData[iCol][0]) && arrData[iCol].Length > 10)
                        {
                            xlsSheet.Range[iRow + 1, iCol + 1].Text = "'" + arrData[iCol];
                        }
                        else if ("123456789".Contains(arrData[iCol][0]) && arrData[iCol].Contains("-")==false)
                        {
                            double val = Convert.ToDouble(arrData[iCol]);
                            xlsSheet.Range[iRow + 1, iCol + 1].NumberValue = val;

                        }
						else if (arrData[iCol].StartsWith("="))
                        {
                            xlsSheet.Range[iRow + 1, iCol + 1].Formula = arrData[iCol];
                        }
                        else
                        {
                            xlsSheet.Range[iRow + 1, iCol + 1].Text = arrData[iCol];
                        }
                    }
                    catch {
                    xlsSheet.Range[iRow + 1, iCol + 1].Text = arrData[iCol];
                    }
                    
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.HorizontalAlignment = HorizontalAlignType.Left;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeLeft].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeRight].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeTop].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeBottom].Color = System.Drawing.Color.Black;
                    xlsSheet.Range[iRow + 1, iCol + 1].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
                }
            }
            catch { }
        }


        private static void ClearSheets(Workbook xlsBook,string sheetname)
        {
            try
            {
                while (xlsBook.Worksheets.Count > 1)
                {
                    xlsBook.Worksheets.Remove(0);
                }
                if (xlsBook.Worksheets.Count == 1) xlsBook.Worksheets[0].Name = sheetname;
            }
            catch (Exception ex)
            {
                
            }
        }

        public string UpdateInventory( string filename, List<clsProductItem> lstProdItems, string username )
        {
            Workbook xlsBook = new Workbook();
            Worksheet xlsSheet = null;
            if (File.Exists(filename))
                xlsBook.LoadFromFile(filename);

            Dictionary<string, clsProductItem> dicProd = new Dictionary<string, clsProductItem>();
            foreach (clsProductItem c in lstProdItems)
            {
                if (dicProd.ContainsKey(c.BarCode) == false)
                {
                    dicProd.Add(c.BarCode.Trim(), c);
                }
            }
            Dictionary<int, string> categories = dbConnect.GetCategories();
            foreach (Worksheet sheet in xlsBook.Worksheets)
            {
                xlsSheet = sheet;
                if (xlsSheet[1, 1].Value.Trim() == "Barcode" && xlsSheet[1, 2].Value.Trim() == "Description" &&
                    xlsSheet[1, 3].Value.Trim() == "Capital" && xlsSheet[1, 4].Value.Trim() == "Retail Amount" && xlsSheet[1, 5].Value.Trim() == "Wholesale Amount" &&
                     xlsSheet[1, 6].Value.Trim() == "Category" && xlsSheet[1, 7].Value.Trim() == "Total Inventory" && xlsSheet[1, 8].Value.Trim() == "Quantity Sold" &&
                    xlsSheet[1, 9].Value.Trim() == "Remaining Quantity" && xlsSheet[1, 10].Value.Trim() == "Actual Qty" && xlsSheet[1, 11].Value.Trim() == "Difference")
                {
                    int ctr = 2;

                    frmProgress progress = new frmProgress(lstProdItems.Count);
                    progress.Caption = "Update in Progress";
                    progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                    progress.Show();

                    while (xlsSheet[ctr, 1].Value != "")
                    {
                        progress.Val += 1;
                        if (dicProd.ContainsKey(xlsSheet[ctr, 1].Value.Trim()))
                        {
                            clsProductItem prod = dicProd[xlsSheet[ctr, 1].Value.Trim()];
                            try
                            {
                                double addQtyToInventory = Convert.ToDouble(xlsSheet[ctr, 10].Value) - prod.StocksRemainingQty;
                                if (prod.Description != xlsSheet[ctr, 2].Value.Trim() || prod.Capital != double.Parse(xlsSheet[ctr, 3].Value.Trim())
                                    || prod.Amount != double.Parse(xlsSheet[ctr, 4].Value.Trim()) || prod.WSAmount != double.Parse(xlsSheet[ctr, 5].NumberText)
                                    || Convert.ToDouble(xlsSheet[ctr, 10].Value) != prod.StocksRemainingQty || xlsSheet[ctr, 6].Value.Trim() != prod.Category)
                                {
                                    if (Convert.ToDouble(xlsSheet[ctr, 10].Value) - prod.StocksRemainingQty != 0)
                                    {
                                        clsInventory itemIventory = new clsInventory();
                                        itemIventory.BarCode = prod.BarCode;
                                        itemIventory.Capital = prod.Capital;
                                        itemIventory.Quantity = addQtyToInventory;
                                        itemIventory.DateAdded = DateTime.Now;
                                        itemIventory.Remarks = string.Format("{0}: TotInv={1} + {2}", username, prod.StocksRemainingQty, addQtyToInventory);
                                        itemIventory.Save();

                                        prod.Description = xlsSheet[ctr, 2].Value.Trim();
                                        prod.Capital = double.Parse(xlsSheet[ctr, 3].Value.Trim());
                                        prod.Amount = double.Parse(xlsSheet[ctr, 4].Value.Trim());
                                        prod.WSAmount = double.Parse(xlsSheet[ctr, 5].NumberText);
                                        prod.TotalInventoryQty += addQtyToInventory;
                                        if (categories.ContainsValue(xlsSheet[ctr, 6].Value.Trim()) == false)
                                        {
                                            dbConnect.AddCategory(xlsSheet[ctr, 6].Value.Trim());
                                            categories = dbConnect.GetCategories();
                                        } 
                                        
                                        if (categories != null && categories.ContainsValue(xlsSheet[ctr, 6].Value.Trim()))
                                        {
                                            foreach (KeyValuePair<int, string> str in categories)
                                            {
                                                if (str.Value == xlsSheet[ctr, 6].Value.Trim())
                                                {
                                                    prod.CategoryId = str.Key;
                                                    break;
                                                }
                                            }

                                        } 

                                        prod.Save();
                                    }

                                    
                                }

                            }
                            catch { }

                        }
                        else
                        {
                            clsProductItem proditem = new clsProductItem();
                            proditem.BarCode = xlsSheet[ctr, 1].Value.Trim().ToUpper();
                            proditem.Description = xlsSheet[ctr, 2].Value.Trim();
                            proditem.Amount = double.Parse(xlsSheet[ctr, 4].Value.Trim());
                            proditem.WSAmount = double.Parse(xlsSheet[ctr, 5].Value.Trim());
                            proditem.WSMinimum = 0;
                            proditem.Capital = double.Parse(xlsSheet[ctr, 3].Value.Trim());
                            proditem.Imagepath = "";
                            proditem.Unit = "pc";
                            proditem.InStorage = 0;
                            proditem.CriticalLevel = 5;
                            proditem.QtySold = 0;

                            clsInventory itemIventory = new clsInventory();
                            itemIventory.BarCode = proditem.BarCode;
                            itemIventory.Capital = proditem.Capital;
                            itemIventory.DateAdded = DateTime.Now;
                            itemIventory.Quantity = Convert.ToDouble(xlsSheet[ctr, 10].Value);
                            itemIventory.Remarks = string.Format("{0}: TotInv={1} + {2}", username, 0, itemIventory.Quantity);
                            itemIventory.Save();
                            proditem.TotalInventoryQty = itemIventory.Quantity;
                            if (categories.ContainsValue(xlsSheet[ctr, 6].Value.Trim()) == false)
                            {
                                dbConnect.AddCategory(xlsSheet[ctr, 6].Value.Trim());
                                categories = dbConnect.GetCategories();
                            } 
                            if (categories != null && categories.ContainsValue(xlsSheet[ctr, 6].Value.Trim()))
                            {
                                foreach (KeyValuePair<int, string> str in categories)
                                {
                                    if (str.Value == xlsSheet[ctr, 6].Value.Trim())
                                    {
                                        proditem.CategoryId = str.Key;
                                        break;
                                    }
                                }
                            }
                            proditem.Save();
                        }
                        ctr++;
                    }
                    progress.Close();
                }

                break;
            }
            
            return "";
        }

        public string UpdateInventoryFromTemp(List<clsProductItem> lstProdItems, string username )
        {

            Receipt m_receipt = new Receipt();
            frmTempTrans tmp = new frmTempTrans(clsUsers.GetUser(username));
            if (tmp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (tmp.SelectedTempOR != null)
                {
                    m_receipt = tmp.SelectedTempOR;
                }
            }

            Dictionary<string, clsProductItem> dicProd = new Dictionary<string, clsProductItem>();
            foreach (clsProductItem c in lstProdItems)
            {
                if (dicProd.ContainsKey(c.BarCode) == false)
                {
                    dicProd.Add(c.BarCode.Trim(), c);
                }
            }
            frmProgress progress = new frmProgress(lstProdItems.Count);
            progress.Caption = "Update in Progress";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();

            foreach(KeyValuePair<string,clsPurchasedItem> p in m_receipt.PurchasedItems)
            {
                progress.Val++;
                if (dicProd.ContainsKey(p.Key))
                {
                    clsProductItem prod = dicProd[p.Key];
                    if(prod.StocksRemainingQty != p.Value.Qty)
                    {
                        double addQtyToInventory = p.Value.Qty - prod.StocksRemainingQty;

                        clsInventory itemIventory = new clsInventory();
                        itemIventory.BarCode = prod.BarCode;
                        itemIventory.Capital = prod.Capital;
                        itemIventory.Quantity = addQtyToInventory;
                        itemIventory.DateAdded = DateTime.Now;
                        itemIventory.Remarks = string.Format("{0}: TotInv={1} + {2}", username, prod.StocksRemainingQty, addQtyToInventory);
                        itemIventory.Save();

                        prod.TotalInventoryQty += addQtyToInventory;
                        prod.Save();

                    }
                }
                progress.Close();
                m_receipt.DeleteTempReceipt();
            }
            return "";
        }
        public bool UploadServiceFees(string filename, int LoadId)
        {
            try
            {
                bool ret = false;
                Workbook xlsBook = new Workbook();
                Worksheet xlsSheet = null;
                if (File.Exists(filename)) xlsBook.LoadFromFile(filename);

                xlsSheet = xlsBook.Worksheets[0];
                int RowCount = xlsSheet.Rows.Count();
                string str = xlsSheet[1, 1].Value.ToString().Trim();
                for (int i = 3; i <= RowCount; i++)
                {
                    clsServiceFee fee = new clsServiceFee()
                    {
                        ServiceFeeID = xlsSheet[i, 1].Value.ToString().Trim() != "" ? int.Parse(xlsSheet[i, 1].Value.ToString().Trim()) : 0,
                        Load_id = LoadId,
                        AmountFrom = xlsSheet[i, 2].Value.ToString().Trim() != "" ? double.Parse(xlsSheet[i, 2].Value.ToString().Trim()) : 0,
                        AmountTo = xlsSheet[i, 3].Value.ToString().Trim() != "" ? double.Parse(xlsSheet[i, 3].Value.ToString().Trim()) : 0,
                        EcashFee = xlsSheet[i, 4].Value.ToString().Trim() != "" ? double.Parse(xlsSheet[i, 4].Value.ToString().Trim()) : 0,
                        P2PFee = xlsSheet[i, 5].Value.ToString().Trim() != "" ? double.Parse(xlsSheet[i, 5].Value.ToString().Trim()) : 0,
                        Rebate = xlsSheet[i, 6].Value.ToString().Trim() != "" ? double.Parse(xlsSheet[i, 6].Value.ToString().Trim()) : 0,
                        Remarks = xlsSheet[i, 7].Value.ToString().Trim()
                    };
                    ret = fee.Save();
                }
                return ret;
            }
            catch { }

            return false;
        }

        public bool SaveToExcelServiceFee(string filename, string columns, List<string> values, string DateAsOf = "Export")
        {
            Workbook xlsBook = new Workbook();
            Worksheet xlsSheet;
            int iRow = 0;

            ClearSheets(xlsBook, DateAsOf);
            xlsSheet = xlsBook.Worksheets[DateAsOf];
            AddHeader(columns.Split("\t".ToCharArray()), xlsSheet, iRow, true);
            frmProgress progress = new frmProgress(values.Count);
            progress.Caption = "Export in progress";
            progress.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            progress.Show();
            int ctr = 0;
            foreach (string strdata in values)
            {
                AddToExcel(strdata, xlsSheet, ref iRow);
                progress.Val = ++ctr;

            }
            progress.Close();
            xlsBook.Worksheets.Add(xlsSheet);
            xlsBook.SaveToFile(filename);
            System.Windows.Forms.MessageBox.Show("Export Completed!", "Export", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

            return File.Exists(filename);
        }



        public bool UploadSubD(string filename, int loadid)
        {
            try
            {
                bool ret = false;
                Workbook xlsBook = new Workbook();
                Worksheet xlsSheet = null;
                if (File.Exists(filename)) xlsBook.LoadFromFile(filename);

                xlsSheet = xlsBook.Worksheets[0];
                int RowCount = xlsSheet.Rows.Count();

                for (int i = 2; i <= RowCount; i++)
                {
                    clsSubDAccount subd = null;
                    try
                    {
                        subd = new clsSubDAccount()
                        {
                            Id_subdAccounts = 0,
                            LoadId = loadid,
                            Name = xlsSheet[i, 1].Value.ToString().Trim(),
                            MobileNum = xlsSheet[i, 2].Value.ToString().Trim(),
                            Balance = (string.IsNullOrEmpty(xlsSheet[i, 3].Value.ToString()) ? 0 : Convert.ToDouble(xlsSheet[i, 3].Value.ToString()))
                        };
                    }
                    catch
                    {
                        subd = new clsSubDAccount()
                        {
                            Id_subdAccounts = 0,
                            LoadId = loadid,
                            Name = xlsSheet[i, 1].Value.ToString().Trim(),
                            MobileNum = xlsSheet[i, 2].Value.ToString().Trim(),
                            Balance = 0
                        };
                    }
                    ret = subd.Save();
                }
                return ret;
            }
            catch { }

            return false;
        }
    }
}
