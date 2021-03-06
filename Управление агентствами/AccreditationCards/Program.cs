﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace AccreditationCards
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
            bool ViewFullData = (Args.Length > 2);
            string server = (Args.Length > 2 && Args[2].Contains("ip:")) ? Args[2].Replace("ip:", "") : "";
            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);
            if (screen.Show() == DialogResult.OK)
            {
                frmMain mainForm = new frmMain(ViewFullData);

                mainForm.Text = mainForm.Text

                    + " ver." + mainForm.GetType().Assembly.GetName().Version.ToString()
                    + " db:" + SqlConnection.ConnectionDBName;

                Application.Run(mainForm);
            }
        }
    }
}
