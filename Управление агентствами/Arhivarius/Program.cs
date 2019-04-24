using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace Arhivarius
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            new Master32.Program().ExtendedStart();
            string user = (Args.Length > 0) ? Args[0] : "";
            string pass = (Args.Length > 1) ? Args[1] : "";
            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);
            if (screen.Show() == DialogResult.OK)
            {
                string UsingDGCode = ltp_v2.Framework.MasterValue.DGCodeFromASKData;

                frmStart mainForm = new frmStart();

                mainForm.Text = mainForm.Text

                    + " ver." + mainForm.GetType().Assembly.GetName().Version.ToString()
                    + " db:" + SqlConnection.ConnectionDBName;

                Application.Run(mainForm);
            }
        }
    }
}
