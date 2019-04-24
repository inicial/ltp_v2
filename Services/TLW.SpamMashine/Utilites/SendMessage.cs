using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Mail;

namespace TLW.SpamMashine.Utilites
{
    public class SendMessage
    {
        public static int Start()
        {
            SendMessage SM = new SendMessage();
            return SM.start();
        }
        private int start()
        {
            smSQLDataContext dc = new smSQLDataContext(global::TLW.SpamMashine.Properties.Settings.Default.dbConnectionString);
            int Result = 0;
            foreach (var lssRow in dc.GetNotSend().Where(x => x.LSS_MailFrom != "i@i.ru" && x.LSS_MailTo != "K@K.ru"))
            {
                Result++;
                string[] RecipientMails = lssRow.LSS_MailTo.Replace(" ", ";").Replace(":", ";").Split(';');
                foreach (string RecipientMail in RecipientMails)
                {
                    try
                    {
                        MailMessage message = new MailMessage(lssRow.LSS_MailFrom, RecipientMail);
                        message.Subject = global::TLW.SpamMashine.Properties.Settings.Default.SubjectBeg + lssRow.LSS_Subject;
                        message.Body = lssRow.LSS_Body
                            .Replace("%headInt%", global::TLW.SpamMashine.Properties.Settings.Default.HeadToInternal)
                            .Replace("%head%", global::TLW.SpamMashine.Properties.Settings.Default.HeadToExternal)
                            .Replace("%bottomInt%", global::TLW.SpamMashine.Properties.Settings.Default.BottomToInternal)
                            .Replace("%bottom%", global::TLW.SpamMashine.Properties.Settings.Default.BottomToExternal);
                        message.IsBodyHtml = true;

                        foreach (var ssAttach in lssRow.LTS_SpamServerAttaches)
                        {
                            System.IO.MemoryStream fs = new System.IO.MemoryStream(ssAttach.LTSA_Source.ToArray());
                            message.Attachments.Add(new Attachment(fs, "doc" + message.Attachments.Count.ToString() + "." + ssAttach.LTSA_Extension));
                        }

                        string[] smtp2Address = global::TLW.SpamMashine.Properties.Settings.Default.SMTP_Server2_UsedForAddress.Split(';');
                        if (smtp2Address.Count(x => lssRow.LSS_MailFrom.ToLower().Contains(x.ToLower())) > 0)
                        {
                            new SmtpClient(global::TLW.SpamMashine.Properties.Settings.Default.SMTP_Server2).Send(message);
                        }
                        else
                        {
                            new SmtpClient(global::TLW.SpamMashine.Properties.Settings.Default.SMTP_Server).Send(message);
                        }
                        
                    }
                    catch (Exception exception)
                    {
                        dc.Insert(new LTS_SpamServer
                        {
                            LSS_MailFrom = global::TLW.SpamMashine.Properties.Settings.Default.ErrorMailFrom,
                            LSS_MailTo = global::TLW.SpamMashine.Properties.Settings.Default.ErrorMailIfMailAddressError,
                            LSS_Subject = "Ошибка обработки при отправке письма возможно не верный E-Mail",
                            LSS_Body = string.Concat(new object[] { "ID = ", lssRow.LSS_ID, "\r\nMailFrom = ", lssRow.LSS_MailFrom, "\r\nMailTo = ", lssRow.LSS_MailTo, "\r\n", exception.Message.ToString() }),
                            LSS_DTEndPeriod = Utilites.Consts.ServerDateTime,
                            LSS_ServiceSend = "ERR_SPAMUS_SEND",
                            LSS_PRKey = -1
                        });
                    }
                    dc.UpdateSend(lssRow);
                }
            }
            return Result;
        }
    }
}
