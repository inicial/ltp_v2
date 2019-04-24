using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace rep259916
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            string user = (Args.Length > 0) ? Args[0] : "";
            string pass = (Args.Length > 1) ? Args[1] : "";
            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);

            if (screen.Show() == DialogResult.OK)
            {
                string UsingDGCode = ltp_v2.Framework.MasterValue.DGCodeFromASKData;
                if ((Args.Length > 2) && (Args[2].IndexOf("!DGCODE=") >= 0))
                {
                    UsingDGCode = Args[2].Replace("!DGCODE=", "");
                }
                frmMain mainForm = new frmMain();
                mainForm.Text = mainForm.Text
                    + " ver." + mainForm.GetType().Assembly.GetName().Version.ToString()
                    + " db:" + SqlConnection.ConnectionDBName;
                Application.Run(mainForm);
            }
        }
    }
}
