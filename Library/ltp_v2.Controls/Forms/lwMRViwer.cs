using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ltp_v2.Controls.Forms
{
    public class lwMRViwer : Microsoft.Reporting.WinForms.ReportViewer
    {
        #region Свойства
        private ToolStripButton tsb;
        private string mailAddress = "";
        private string mailSubject = "";
        private string mailMessage = "";

        public bool ShowSendButton
        {
            get { return tsb.Visible; }
            set { tsb.Visible = value; }
        }

        public string MailAddress
        {
            get { return mailAddress; }
            set
            {
                mailAddress = value;
                ShowSendButton = (MailAddress.Trim() != "" && this.MailSubject != "");
            }
        }

        public string MailSubject
        {
            get { return mailSubject; }
            set
            {
                mailSubject = value;
                ShowSendButton = (MailAddress.Trim() != "" && this.MailSubject != "");
            }
        }

        public string MailMessage
        {
            get { return mailMessage; }
            set { mailMessage = value; }
        }
        #endregion

        public lwMRViwer()
        {
            tsb = new ToolStripButton();
            tsb.Text = "Send To Email";
            tsb.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsb.Image = global::ltp_v2.Controls.Properties.Resources.EMail;
            tsb.Click += new EventHandler(tsb_Click);
            tsb.Visible = false;

            //"Microsoft.Reporting.WinForms.RVSplitContainer"
            var tStrip = (System.Windows.Forms.ToolStrip)this.Controls[0].Controls[0].Controls[2].Controls[1].Controls[0];
            tStrip.Items.Add(tsb);
        }

        public void tsb_Click(object sender, EventArgs e)
        {
            string MimeType = "";
            string Encoding = "";
            string FileNameExtension = "";
            string[] Striam;
            Microsoft.Reporting.WinForms.Warning[] Warnings;

            try
            {
                String AttachmentPath = ltp_v2.Framework.MasterValue.PathToOutDoc + @"\Accont - " + DateTime.Now.ToString("HHmmss") + ".pdf";
                byte[] bytes = this.LocalReport.Render("PDF", null, out MimeType, out Encoding, out FileNameExtension, out Striam, out Warnings);
                System.IO.FileStream stream = new System.IO.FileStream(AttachmentPath, System.IO.FileMode.Create);
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();

                IMAP_EML.Client client = new IMAP_EML.Client();
                client.mailMsg.IsHTMLBody = true;
                client.mailMsg.AddRecipients(MailAddress);
                client.mailMsg.Subject = global::ltp_v2.Framework.ApplicationConf.CompanyName + " " + MailSubject;
                client.mailMsg.Body = @"<html>
<p><center>" + global::ltp_v2.Framework.ApplicationConf.Logo + "</center></p>" + MailMessage;
                client.mailMsg.AddAttachment(AttachmentPath);
                client.Execute();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
        }
    }
}
