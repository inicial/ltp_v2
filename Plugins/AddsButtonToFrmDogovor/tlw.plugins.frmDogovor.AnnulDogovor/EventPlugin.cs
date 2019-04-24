using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Megatec.Framework.Plugins;
using Megatec.TDInterop;
using System.Windows.Forms;
using System.Diagnostics;

namespace tlw.plugins.frmDogovor.AnnulDogovor
{
    [Plugin("Аннуляция брони", Forms = new string[] { "frmDogovor" })]
    public class EventPlugin
    {
        [PluginMethod("Аннуляция брони_")]
        public void StartReport()
        {
            string NumberDogovor = String.Empty, login = String.Empty, pwd = String.Empty;

            var windowsPath = System.Environment.GetEnvironmentVariable("windir");
            string masterPath = "";
            if (windowsPath.Trim() != "")
            {
                IniFile iniFile = new IniFile(windowsPath + "\\win.ini");
                masterPath = iniFile.IniReadValue("Master", "path");
            }

            string curPath = masterPath + @"\Report\rep259921.exe";
            ExecutionContext context = new ExecutionContext();
            context.SetContext();
            object obj2 = context.Execute("AskStringX(hWndForm, ASK_Dogovor)");
            if (obj2.ToString() != string.Empty)
            {
                NumberDogovor = obj2.ToString();
            }
            else
            {
                MessageBox.Show("Невозможно определить № Брони");
            }

            string CurConnection = Megatec.MasterTour.BusinessRules.DataAccess.conn_str;
            string[] vals = CurConnection.Split(';');
            foreach (string cur in vals)
            {
                if (cur.ToUpper().StartsWith("USER ID"))
                    login = cur.Split('=')[1];
                if (cur.ToUpper().StartsWith("PASSWORD"))
                    pwd = cur.Split('=')[1];
            }
            if (login == String.Empty || pwd == String.Empty)
            {
                MessageBox.Show("Невозможно передать данные соединения!");
            }

            try
            {
                var psi = new ProcessStartInfo();
                psi.Arguments = login + " " + pwd + " !DGCODE=" + NumberDogovor;
                psi.FileName = curPath;
                psi.WorkingDirectory = new System.IO.FileInfo(curPath).Directory.FullName;
                Process.Start(psi);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "\r\n" + curPath + " !DGCODE=" + NumberDogovor);
            }
        }
    }
}