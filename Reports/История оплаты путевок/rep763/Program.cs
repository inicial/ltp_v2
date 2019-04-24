using System;
using ltp_v2.Framework;
using System.Windows.Forms;

namespace rep763
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
                frmMain mainForm = new frmMain(UsingDGCode);
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
