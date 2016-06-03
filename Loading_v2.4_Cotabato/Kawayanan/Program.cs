using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AlreySolutions.LoadingStation;
namespace AlreySolutions
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.AdminPage == false)
                Application.Run(new myPosWide());
            else
                Application.Run(new frmUtility(null, null));
        }
    }
}
