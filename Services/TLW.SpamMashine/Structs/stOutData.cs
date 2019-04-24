using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TLW.SpamMashine.Structs
{
    public class stOutData
    {
        private Dictionary<stPartner, String> ListPartners;
        private stProcess CurrentService;
        public stOutData(stProcess CurrentService)
        {
            this.CurrentService = CurrentService;
            ListPartners = new Dictionary<stPartner, string>();
        }
        public int Count
        {
            get
            {
                return ListPartners.Keys.Count;
            }
        }
        public void Add(stPartner Partner, string Body)
        {
            if (!ListPartners.ContainsKey(Partner))
                ListPartners.Add(Partner, Body);
            else
                ListPartners[Partner] += Body;
        }

        public void Save(TLW.SpamMashine.Utilites.ProcessParser PP)
        {
            foreach (stPartner Key in ListPartners.Keys)
            {
                bool FindFile = true;
                System.IO.Directory.CreateDirectory("C:/temp/" + Key.ServiceID);
                string FileName = "C:/temp/" + Key.ServiceID + "/" + Key.MailTo.ToString() + ".html";
                int Step = 0;
                while (FindFile)
                {
                    FindFile = false;
                    FileName = new System.IO.FileInfo(FileName).DirectoryName + "/" + Key.MailTo.ToString() + (Step > 0 ? "(" + Step.ToString() + ")" : "") + ".html";
                    if (new System.IO.FileInfo(FileName).Directory.GetFiles((new System.IO.FileInfo(FileName).Name)).Length > 0)
                    {
                        Step++;
                        FindFile = true;
                    }
                }
                System.IO.StreamWriter SW = new System.IO.StreamWriter(FileName);
                SW.WriteLine("TEST BY Time:" + Utilites.Consts.ServerDateTime.ToString("dd.MM.yyyy HH:mm:ss") + "<br>");
                SW.WriteLine("Perriod from: " + PP.UseBeg.Value.ToString("dd.MM.yyyy HH:mm:ss") + " to:" + PP.UseEnd.Value.ToString("dd.MM.yyyy HH:mm:ss") + "<br>");
                SW.WriteLine("MailTO:" + Key.MailTo + "<br>");
                SW.WriteLine("SericeID:" + Key.ServiceID + "<br>");
                SW.WriteLine("Subject:" + Key.Subject + "<br>");
                SW.WriteLine("-----------------------------------" + "<br>" + "<br>");
                SW.WriteLine(ListPartners[Key].ToString());
                SW.Close();
            }
        }

        public void Insert2Base(DateTime LastUseDate)
        {
            smSQLDataContext dc = new smSQLDataContext(global::TLW.SpamMashine.Properties.Settings.Default.dbConnectionString);
            foreach (stPartner Key in ListPartners.Keys)
            {
                if (Key.MailFrom.ToLower() == "i@i.ru")
                {
                    foreach (var delItem in dc.LTS_SpamServers.Where(x => x.LSS_ServiceSend == Key.ServiceID && x.LSS_MailFrom == Key.MailFrom))
                    {
                        dc.LTS_SpamServers.DeleteOnSubmit(delItem);
                    }
                }

                dc.Insert(new LTS_SpamServer
                {
                    LSS_MailFrom = Key.MailFrom,
                    LSS_MailTo = Key.MailTo,
                    LSS_Subject = Key.Subject,
                    LSS_PRKey = Key.PRKey,
                    LSS_DTEndPeriod = LastUseDate,
                    LSS_ServiceSend = Key.ServiceID,
                    LSS_Body = ListPartners[Key].ToString()
                });
            }
            dc.SubmitChanges();
        }

        public void Modify_SqlRoot_Value_By_Shablon(string Shablon)
        {
            Dictionary<stPartner, string> Result = new Dictionary<stPartner, string>();
            foreach (stPartner Key in ListPartners.Keys)
            {
                Result.Add(Key, Regex.Replace(Shablon, "%SQL#rootSql%", ListPartners[Key], RegexOptions.IgnoreCase));
            }
            ListPartners = Result;
        }
    }
}
