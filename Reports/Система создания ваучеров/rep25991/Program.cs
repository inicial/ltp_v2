using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ltp_v2.Framework;

namespace rep25991
{
    static class Program
    {
//-- -- Редактирование без внесения в настройки услуги -- --
//ТЕСТИРОВАТЬ МОНА НА RIM90912AB
//статус заявки
//Список туристов если есть путевка
//Редактирование текста без внесения в настройки
//КОНТАКТНОЕ ЛИЦО ОГРАНИЧЕТЬ 23 СИМВОЛАМИ

        [STAThread]
        static void Main(string[] Args)
        {
            string user = (Args.Length > 0) ? Args[0] : "";
            string pass = (Args.Length > 1) ? Args[1] : "";
            string dgCod = (Args.Length > 2 && Args[2].IndexOf("!DGCODE=") == 0) ? Args[2].Replace("!DGCODE=", "") : "";

            LogonScreen screen = new LogonScreen(user, pass, Application.ProductName);

            if (screen.Show() == DialogResult.OK)
            {
                sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
                Form StartForm;
                int Key = 0;
                if (user == "sysadm")
                    StartForm = new Controls.Forms.Voucher.frmMain("TTT20214A5");
                    //StartForm = new Controls.Forms.Configuration.frmMain(164056);
                else
                    if (ltp_v2.Framework.MasterValue.ASKData.Length > 0 && ltp_v2.Framework.MasterValue.ASKData[0] == "7" && int.TryParse(ltp_v2.Framework.MasterValue.ASKData[3], out Key))
                    {
                        StartForm = new Controls.Forms.Configuration.frmMain(Key);
                        if (sqlDC.PresentUserInRole("dep.trf"))
                        {
                            var cnKey = sqlDC.tbl_TurLists.FirstOrDefault(x => x.TL_KEY == Key).TL_CNKEY;
                            StartForm = new Controls.Forms.GroupTours.frmGroupTour(cnKey, Key);
                        }
                    }
                    else
                    {
                        StartForm = new Controls.Forms.Voucher.frmMain(dgCod != "" ? dgCod : ltp_v2.Framework.MasterValue.DGCodeFromASKData);
                    }

                var ver = StartForm.GetType().Assembly.GetName().Version;

                StartForm.Text = StartForm.Text
                    + " ver." + ver.Minor.ToString()
                    + "." + ver.Build.ToString()
                    + "." + ver.Revision.ToString()
                    + " от " + ver.Major.ToString()
                    + " db:" + SqlConnection.ConnectionDBName
                    + " sql: " + SqlConnection.ConnectionDBServer;

                //Application.Run(new Controls.Forms.Configuration.frmMain(129574));
                //Application.Run(new Controls.Forms.Configuration.frmConfigureShablon(15));
                Application.Run(StartForm);
            }
        }
    }
}
