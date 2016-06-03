using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace AlreySolutions.Class
{
    public class clsThemes
    {
        public static void ApplyTheme( Form frm, ThemeSettings theme)
        {
            //theme = new ThemeSettings(Properties.Settings.Default.Theme);
            frm.BackColor = theme.MainFormColor;
            frm.ForeColor = Color.Black;// theme.MainFontColor;
            ApplyTheme(frm.Controls,theme);
        }

        public static void ApplyTheme( Control.ControlCollection cntrls ,ThemeSettings theme)
        {
            //ThemeSettings theme = new ThemeSettings(Properties.Settings.Default.Theme);

            foreach (object obj in cntrls)
            {
                if (obj is Button)
                {
                    Button btn = (Button)obj;
                    btn.BackColor = theme.btnColor;
                    btn.ForeColor = theme.btnFont;
                }
                else if (obj is Panel)
                {
                    ApplyTheme(((Panel)obj).Controls,theme);
                    Panel pan = (Panel)obj;
                    if (pan.Name.StartsWith("main"))
                    {
                        pan.BackColor = theme.PanColor;
                        pan.ForeColor = theme.MainFormColor;
                    }
                    else if(pan.Name.StartsWith("sub"))
                    {
                        pan.BackColor = theme.SubPanColor;
                        pan.ForeColor = theme.MainFormColor;
                    }
                }
                else if (obj is Label)
                {
                    Label lbl = (Label)obj;
                    if (lbl.Name.StartsWith("main"))
                    {
                        lbl.BackColor = theme.PanColor;
                        lbl.ForeColor = theme.PanFontColor;
                    }
                    if (lbl.Name.StartsWith("sub"))
                    {
                        lbl.ForeColor = theme.SubPanFontColor;
                    }
                    if (lbl.Name.StartsWith("lbl") || lbl.Name.StartsWith("label"))
                    {
                        lbl.ForeColor = theme.MainFontColor;
                    }
                    if (lbl.Name.StartsWith("txt"))
                    {
                        lbl.BackColor = theme.TextBackColor;
                        lbl.ForeColor = theme.TextFontColor;
                    }
                }
                else if (obj is CheckBox)
                {
                    CheckBox lbl = (CheckBox)obj;
                    lbl.ForeColor = theme.MainFontColor;
                }
                else if (obj is TextBox)
                {
                    TextBox txt = (TextBox)obj;
                    txt.BackColor = theme.TextBackColor;
                    txt.ForeColor = theme.TextFontColor;
                }
                else if (obj is ListBox)
                {
                    ListBox txt = (ListBox)obj;
                    txt.BackColor = theme.TextBackColor;
                    txt.ForeColor = theme.TextFontColor;
                }
            }
        }

        public class ThemeSettings
        {
            public Color btnColor { get; set; }
            public Color btnFont { get; set; }
            public Color MainFormColor { get; set; }
            public Color MainFontColor { get; set; }
            public Color PanColor { get; set; }
            public Color PanFontColor { get; set; }
            public Color SubPanColor { get; set; }
            public Color SubPanFontColor { get; set; }
            public Color TextBackColor { get; set; }
            public Color TextFontColor { get; set; }
            public ThemeSettings() 
            {

            }

            public static void ApplyThemeSettings(int theme , ThemeSettings settings)
            {
                if(theme==0)
                    Properties.Settings.Default.Theme1 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", 
                    settings.btnColor.ToArgb().ToString(),
                    settings.btnFont.ToArgb().ToString(),
                    settings.MainFormColor.ToArgb().ToString(),
                    settings.MainFontColor.ToArgb().ToString(),
                    settings.PanColor.ToArgb().ToString(),
                    settings.PanFontColor.ToArgb().ToString(),
                    settings.SubPanColor.ToArgb().ToString(),
                    settings.SubPanFontColor.ToArgb().ToString(),
                    settings.TextBackColor.ToArgb().ToString(),
                    settings.TextFontColor.ToArgb().ToString());
                else if (theme == 1)
                    Properties.Settings.Default.Theme2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", 
                    settings.btnColor.ToArgb().ToString(),
                    settings.btnFont.ToArgb().ToString(),
                    settings.MainFormColor.ToArgb().ToString(),
                    settings.MainFontColor.ToArgb().ToString(),
                    settings.PanColor.ToArgb().ToString(),
                    settings.PanFontColor.ToArgb().ToString(),
                    settings.SubPanColor.ToArgb().ToString(),
                    settings.SubPanFontColor.ToArgb().ToString(),
                    settings.TextBackColor.ToArgb().ToString(),
                    settings.TextFontColor.ToArgb().ToString());
                else if (theme == 2)
                    Properties.Settings.Default.Theme3 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", 
                    settings.btnColor.ToArgb().ToString(),
                    settings.btnFont.ToArgb().ToString(),
                    settings.MainFormColor.ToArgb().ToString(),
                    settings.MainFontColor.ToArgb().ToString(),
                    settings.PanColor.ToArgb().ToString(),
                    settings.PanFontColor.ToArgb().ToString(),
                    settings.SubPanColor.ToArgb().ToString(),
                    settings.SubPanFontColor.ToArgb().ToString(),
                    settings.TextBackColor.ToArgb().ToString(),
                    settings.TextFontColor.ToArgb().ToString());
                else if (theme == 3)
                    Properties.Settings.Default.Theme4 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    settings.btnColor.ToArgb().ToString(),
                    settings.btnFont.ToArgb().ToString(),
                    settings.MainFormColor.ToArgb().ToString(),
                    settings.MainFontColor.ToArgb().ToString(),
                    settings.PanColor.ToArgb().ToString(),
                    settings.PanFontColor.ToArgb().ToString(),
                    settings.SubPanColor.ToArgb().ToString(),
                    settings.SubPanFontColor.ToArgb().ToString(),
                    settings.TextBackColor.ToArgb().ToString(),
                    settings.TextFontColor.ToArgb().ToString());
                else if (theme == 4)
                    Properties.Settings.Default.Theme5 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                    settings.btnColor.ToArgb().ToString(),
                    settings.btnFont.ToArgb().ToString(),
                    settings.MainFormColor.ToArgb().ToString(),
                    settings.MainFontColor.ToArgb().ToString(),
                    settings.PanColor.ToArgb().ToString(),
                    settings.PanFontColor.ToArgb().ToString(),
                    settings.SubPanColor.ToArgb().ToString(),
                    settings.SubPanFontColor.ToArgb().ToString(),
                    settings.TextBackColor.ToArgb().ToString(),
                    settings.TextFontColor.ToArgb().ToString());

                Properties.Settings.Default.Save();
            }
            public ThemeSettings(int theme)
            {
                switch (theme)
                {
                    case 0:
                        if(Properties.Settings.Default.Theme1 =="")
                        {
                            btnColor = Color.FromArgb(20, 90, 20);
                            btnFont = Color.White;
                            MainFormColor = Color.FromArgb(10, 10, 10);
                            MainFontColor = Color.White;
                            PanColor = Color.DarkSlateGray;
                            PanFontColor = Color.White;
                            SubPanColor = Color.DarkSlateGray;
                            SubPanFontColor = Color.White;
                            TextBackColor = Color.Gainsboro;
                            TextFontColor = Color.Black;
                            Properties.Settings.Default.Theme1 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", btnColor.ToArgb().ToString(),
                                btnFont.ToArgb().ToString(),
                                MainFormColor.ToArgb().ToString(),
                                MainFontColor.ToArgb().ToString(),
                                PanColor.ToArgb().ToString(),
                                PanFontColor.ToArgb().ToString(),
                                SubPanColor.ToArgb().ToString(),
                                SubPanFontColor.ToArgb().ToString(),
                                TextBackColor.ToArgb().ToString(),
                                TextFontColor.ToArgb().ToString());
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            List<string> t1 = Properties.Settings.Default.Theme1.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                            btnColor = Color.FromArgb(Convert.ToInt32(t1[0]));
                            btnFont = Color.FromArgb(Convert.ToInt32(t1[1]));
                            MainFormColor = Color.FromArgb(Convert.ToInt32(t1[2]));
                            MainFontColor = Color.FromArgb(Convert.ToInt32(t1[3]));
                            PanColor = Color.FromArgb(Convert.ToInt32(t1[4]));
                            PanFontColor = Color.FromArgb(Convert.ToInt32(t1[5]));
                            SubPanColor = Color.FromArgb(Convert.ToInt32(t1[6]));
                            SubPanFontColor = Color.FromArgb(Convert.ToInt32(t1[7]));
                            TextBackColor = Color.FromArgb(Convert.ToInt32(t1[8]));
                            TextFontColor = Color.FromArgb(Convert.ToInt32(t1[9]));
                        }

                        break;
                    case 1:
                        if (Properties.Settings.Default.Theme2 == "")
                        {
                            btnColor = Color.Navy;
                            btnFont = Color.White;
                            MainFormColor = Color.RoyalBlue;
                            MainFontColor = Color.Black;
                            PanColor = Color.MidnightBlue;
                            PanFontColor = Color.White;
                            SubPanColor = Color.SteelBlue;
                            SubPanFontColor = Color.White;
                            TextBackColor = Color.White;
                            TextFontColor = Color.Black;
                            Properties.Settings.Default.Theme2 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", btnColor.ToArgb().ToString(),
                                btnFont.ToArgb().ToString(),
                                MainFormColor.ToArgb().ToString(),
                                MainFontColor.ToArgb().ToString(),
                                PanColor.ToArgb().ToString(),
                                PanFontColor.ToArgb().ToString(),
                                SubPanColor.ToArgb().ToString(),
                                SubPanFontColor.ToArgb().ToString(),
                                TextBackColor.ToArgb().ToString(),
                                TextFontColor.ToArgb().ToString());
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            List<string> t1 = Properties.Settings.Default.Theme2.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                            btnColor = Color.FromArgb(Convert.ToInt32(t1[0]));
                            btnFont = Color.FromArgb(Convert.ToInt32(t1[1]));
                            MainFormColor = Color.FromArgb(Convert.ToInt32(t1[2]));
                            MainFontColor = Color.FromArgb(Convert.ToInt32(t1[3]));
                            PanColor = Color.FromArgb(Convert.ToInt32(t1[4]));
                            PanFontColor = Color.FromArgb(Convert.ToInt32(t1[5]));
                            SubPanColor = Color.FromArgb(Convert.ToInt32(t1[6]));
                            SubPanFontColor = Color.FromArgb(Convert.ToInt32(t1[7]));
                            TextBackColor = Color.FromArgb(Convert.ToInt32(t1[8]));
                            TextFontColor = Color.FromArgb(Convert.ToInt32(t1[9]));
                        }
                        break;
                    case 2:
                        if (Properties.Settings.Default.Theme3 == "")
                        {
                            btnColor = Color.HotPink;
                            btnFont = Color.Black;
                            MainFormColor = Color.DeepPink;
                            MainFontColor = Color.Black;
                            PanColor = Color.Magenta;
                            PanFontColor = Color.White;
                            SubPanColor = Color.Pink;
                            SubPanFontColor = Color.Black;
                            TextBackColor = Color.White;
                            TextFontColor = Color.Black;
                            Properties.Settings.Default.Theme3 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", btnColor.ToArgb().ToString(),
                            btnFont.ToArgb().ToString(),
                            MainFormColor.ToArgb().ToString(),
                            MainFontColor.ToArgb().ToString(),
                            PanColor.ToArgb().ToString(),
                            PanFontColor.ToArgb().ToString(),
                            SubPanColor.ToArgb().ToString(),
                            SubPanFontColor.ToArgb().ToString(),
                            TextBackColor.ToArgb().ToString(),
                            TextFontColor.ToArgb().ToString());
                            Properties.Settings.Default.Save();

                        }
                        else
                        {
                            List<string> t1 = Properties.Settings.Default.Theme3.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                            btnColor = Color.FromArgb(Convert.ToInt32(t1[0]));
                            btnFont = Color.FromArgb(Convert.ToInt32(t1[1]));
                            MainFormColor = Color.FromArgb(Convert.ToInt32(t1[2]));
                            MainFontColor = Color.FromArgb(Convert.ToInt32(t1[3]));
                            PanColor = Color.FromArgb(Convert.ToInt32(t1[4]));
                            PanFontColor = Color.FromArgb(Convert.ToInt32(t1[5]));
                            SubPanColor = Color.FromArgb(Convert.ToInt32(t1[6]));
                            SubPanFontColor = Color.FromArgb(Convert.ToInt32(t1[7]));
                            TextBackColor = Color.FromArgb(Convert.ToInt32(t1[8]));
                            TextFontColor = Color.FromArgb(Convert.ToInt32(t1[9]));
                        }
                        break;
                    case 3:
                        if (Properties.Settings.Default.Theme4 == "")
                        {
                            btnColor = Color.FromArgb(30, 30, 30);
                            btnFont = Color.White;
                            MainFormColor = Color.White;
                            MainFontColor = Color.Black;
                            PanColor = Color.FromArgb(50, 50, 50);
                            PanFontColor = Color.White;
                            SubPanColor = Color.FromArgb(90, 90, 90);
                            SubPanFontColor = Color.White;
                            TextBackColor = Color.Black;
                            TextFontColor = Color.YellowGreen;
                            Properties.Settings.Default.Theme4 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", btnColor.ToArgb().ToString(),
                            btnFont.ToArgb().ToString(),
                            MainFormColor.ToArgb().ToString(),
                            MainFontColor.ToArgb().ToString(),
                            PanColor.ToArgb().ToString(),
                            PanFontColor.ToArgb().ToString(),
                            SubPanColor.ToArgb().ToString(),
                            SubPanFontColor.ToArgb().ToString(),
                            TextBackColor.ToArgb().ToString(),
                            TextFontColor.ToArgb().ToString());
                            Properties.Settings.Default.Save();

                        }
                        else
                        {
                            List<string> t1 = Properties.Settings.Default.Theme4.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                            btnColor = Color.FromArgb(Convert.ToInt32(t1[0]));
                            btnFont = Color.FromArgb(Convert.ToInt32(t1[1]));
                            MainFormColor = Color.FromArgb(Convert.ToInt32(t1[2]));
                            MainFontColor = Color.FromArgb(Convert.ToInt32(t1[3]));
                            PanColor = Color.FromArgb(Convert.ToInt32(t1[4]));
                            PanFontColor = Color.FromArgb(Convert.ToInt32(t1[5]));
                            SubPanColor = Color.FromArgb(Convert.ToInt32(t1[6]));
                            SubPanFontColor = Color.FromArgb(Convert.ToInt32(t1[7]));
                            TextBackColor = Color.FromArgb(Convert.ToInt32(t1[8]));
                            TextFontColor = Color.FromArgb(Convert.ToInt32(t1[9]));
                        }
                        break;
                    case 4:
                        if (Properties.Settings.Default.Theme5 == "")
                        {
                            btnColor = Color.FromArgb(0, 0, 0);
                            btnFont = Color.White;
                            MainFormColor = Color.Black;
                            MainFontColor = Color.White;
                            PanColor = Color.FromArgb(0, 0, 0);
                            PanFontColor = Color.White;
                            SubPanColor = Color.FromArgb(0, 0, 0);
                            SubPanFontColor = Color.White;
                            TextBackColor = Color.Black;
                            TextFontColor = Color.White;
                            Properties.Settings.Default.Theme5 = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}", btnColor.ToArgb().ToString(),
                                btnFont.ToArgb().ToString(),
                                MainFormColor.ToArgb().ToString(),
                                MainFontColor.ToArgb().ToString(),
                                PanColor.ToArgb().ToString(),
                                PanFontColor.ToArgb().ToString(),
                                SubPanColor.ToArgb().ToString(),
                                SubPanFontColor.ToArgb().ToString(),
                                TextBackColor.ToArgb().ToString(),
                                TextFontColor.ToArgb().ToString());
                            Properties.Settings.Default.Save();

                        }
                        else
                        {
                            List<string> t1 = Properties.Settings.Default.Theme5.Split(",".ToCharArray(), StringSplitOptions.None).ToList();
                            btnColor = Color.FromArgb(Convert.ToInt32(t1[0]));
                            btnFont = Color.FromArgb(Convert.ToInt32(t1[1]));
                            MainFormColor = Color.FromArgb(Convert.ToInt32(t1[2]));
                            MainFontColor = Color.FromArgb(Convert.ToInt32(t1[3]));
                            PanColor = Color.FromArgb(Convert.ToInt32(t1[4]));
                            PanFontColor = Color.FromArgb(Convert.ToInt32(t1[5]));
                            SubPanColor = Color.FromArgb(Convert.ToInt32(t1[6]));
                            SubPanFontColor = Color.FromArgb(Convert.ToInt32(t1[7]));
                            TextBackColor = Color.FromArgb(Convert.ToInt32(t1[8]));
                            TextFontColor = Color.FromArgb(Convert.ToInt32(t1[9]));
                        }
                        break;
                }

            }
        }
    }
}
