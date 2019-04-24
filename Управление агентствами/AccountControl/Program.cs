using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace AccountControl
{
    static class Program
    {
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
                new ltp_v2.AccountCreator.frmAccountControl().ShowDialog();
            }
        }
    }
}
