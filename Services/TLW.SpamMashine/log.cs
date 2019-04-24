using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TLW.SpamMashine
{
    public class log
    {
        public static void WriteToLog(string Message)
        {
            string CurrentDir = new System.IO.FileInfo(System.Windows.Forms.Application.ExecutablePath).Directory.FullName;
            if (new System.IO.FileInfo(CurrentDir + "\\Service_work.log").Exists && new System.IO.FileInfo(CurrentDir + "\\Service_work.log").Length >= 200 * 1024 * 1024)
            {
                System.IO.File.Delete(CurrentDir + "\\Service_work.log");
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(CurrentDir + "\\Service_work.log", true))
            {
                sw.WriteLine(Utilites.Consts.ServerDateTime.ToString() + "\t" + Message);
            }
        }

        public static void WriteToError(string ErrorMessage)
        {
            string CurrentDir = new System.IO.FileInfo(System.Windows.Forms.Application.ExecutablePath).Directory.FullName;
            if (new System.IO.FileInfo(CurrentDir + "\\Service_err.log").Exists && new System.IO.FileInfo(CurrentDir + "\\Service_err.log").Length >= 200 * 1024 * 1024)
            {
                System.IO.File.Delete(CurrentDir + "\\Service_err.log");
            }

            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(CurrentDir + "\\Service_err.log", true))
            {
                sw.WriteLine(Utilites.Consts.ServerDateTime.ToString() + "\t" + ErrorMessage);
            }
        }
    }
}
