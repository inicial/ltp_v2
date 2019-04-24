using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace rep259920
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
            string dgCod = (Args.Length > 2 && Args[2].IndexOf("!DGCODE=") == 0) ? Args[2].Replace("!DGCODE=", "") : "";
            bool isRestricted = Args.Length > 3 && Args[3].ToLower().IndexOf("restricted") == 0;

            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);

            if (screen.Show() == DialogResult.OK)
            {
                Form mainForm;
                if (isRestricted)
                {
                    mainForm = new frmMainPriemVidacha(dgCod);
                }
                else
                {
                    mainForm = new frmMain(dgCod);//dgCod != "" ? dgCod : ltp_v2.Framework.MasterValue.DGCodeFromASKData);
                }

                var ver = mainForm.GetType().Assembly.GetName().Version;

                mainForm.Text = mainForm.Text
                    + " ver." + ver.Minor.ToString()
                    + "." + ver.Build.ToString()
                    + "." + ver.Revision.ToString()
                    + " от " + ver.Major.ToString()
                    + " db:" + SqlConnection.ConnectionDBName
                    + " sql: " + SqlConnection.ConnectionDBServer;
                Application.Run(mainForm);
            }
        }
    }
}
