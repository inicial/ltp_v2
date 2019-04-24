using System;
using System.Windows.Forms;
using System.ServiceProcess;

namespace TLW.SpamMashine
{
    static class Program
    {
        [STAThread]
        static void Main(string[] Param)
        {            
            if (Param.Length == 1 && Param[0] == "config")
            {
                Application.Run(new Forms.frmConfiguration());
            }
            else
            {
                ServiceBase.Run(new Service1());
            }
        }
    }
}
