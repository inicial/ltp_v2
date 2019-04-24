using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace Rep22341
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
            string server = (Args.Length > 2 && Args[2].Contains("ip:")) ? Args[2].Replace("ip:", "") : "";
            
            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);
            if (screen.Show() == DialogResult.OK)
            {
                using (sqlDataContext dc = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                {
                    bool permissionOk = dc.ExecuteQuery<bool>(@"SELECT cast(case when PERMISSIONS(OBJECT_ID('LTA_AviaOutTurist'))&8 = 8 then 1 else 0 end as bit) as UserIsRoot").First();
                    if (!permissionOk)
                    {
                        MessageBox.Show("У Вас нет прав для просмотра данного отчета, обратитесь в тех. отдел");
                        return;
                    }
                }

                frmMain mainForm = new frmMain();

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
