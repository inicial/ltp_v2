using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.ComponentModel;

namespace Master32
{
    public class Program
    {
        private string destinationFolder
        {
            get
            {
                var ql = System.Environment.GetEnvironmentVariable("Quick Launch");
                var result = "";
                var windowsPath = System.Environment.GetEnvironmentVariable("windir");
                if (windowsPath.Trim() != "")
                {
                    IniFile iniFile = new IniFile(windowsPath + "\\win.ini");
                    result = iniFile.IniReadValue("Master", "path");
                }

                if (result == "")
                {
                    MessageBox.Show("Нет настроек в win.ini файле, обратитесь по тел. 1500");
                }

                return result;
            }
        }

        public void ExtendedStart()
        {
            if (destinationFolder == "")
                return;

            string updateServer = "192.168.10.4";
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            var CurrentIP = localIPs.FirstOrDefault(x => System.Text.RegularExpressions.Regex.IsMatch(x.ToString(), @"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}") == true);
            if (CurrentIP != null)
            {
                if (Int32.Parse(CurrentIP.ToString().Split('.')[2]) == 60)
                {
                    updateServer = "192.168.60.1";
                }
            }

            string logFileName = @"\\" + updateServer + @"\Master\Update\UpdateLogs\" + Dns.GetHostName();
            string sourceFolder = @"\\" + updateServer + @"\master\update\master\";
            try
            {
                var frmUpdate = new frmUpdate(destinationFolder, sourceFolder, logFileName, Int32.Parse(CurrentIP.ToString().Split('.')[2]));
                frmUpdate.ShowDialog();

                StreamWriter writer = new StreamWriter(logFileName);
                writer.WriteLine();
                writer.Close();
            }
            catch (Exception err)
            {
                var errlog = new System.IO.StreamWriter(logFileName + "_errUpdate.log", false);
                errlog.WriteLine(err.Message);
                if (err.InnerException != null)
                    errlog.WriteLine(err.InnerException.Message);
                errlog.Close();
            }
        }

        public void ExtendedStart(string[] ParamStart)
        {
            if (destinationFolder == "")
                return;

            ExtendedStart();

            try
            {
                if (ParamStart != null && ParamStart.Length > 0 && ParamStart[0].Trim() != "")
                    Process.Start(destinationFolder + @"\" + ParamStart[0] + ".exe");
                else
                    Process.Start(destinationFolder + @"\ma.exe");
            }
            catch
            {
            }
        }

        [STAThread]
        private static void Main(string[] ParamStart)
        {
            new Program().ExtendedStart(ParamStart);
        }
    }
}