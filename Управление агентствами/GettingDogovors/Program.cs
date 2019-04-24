using System;
using System.Windows.Forms;
using ltp_v2.Framework;
using AgencyManager.FormsForDogovor;

namespace GettingDogovors
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            new Master32.Program().ExtendedStart();
            string user = (Args.Length > 0) ? Args[0] : "";
            string pass = (Args.Length > 1) ? Args[1] : "";
            string server = (Args.Length > 2 && Args[2].Contains("ip:")) ? Args[2].Replace("ip:", "") : "";
            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);
            if (screen.Show() == DialogResult.OK)
            {
                Application.EnableVisualStyles();
                Application.Run(new frmGettingDogovor());
            }
        }
    }
}
