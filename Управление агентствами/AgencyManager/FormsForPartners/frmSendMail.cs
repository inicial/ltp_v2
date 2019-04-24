using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using AgencyManager.FormsForDogovor;
using AgencyManager.FormsForAccess;
using ltp_v2.Framework;

namespace AgencyManager.FormsForPartners
{
    public partial class frmSendMail : Form
    {
        #region Свойства
        private PartnersListDataContext PLDC;
        private tbl_Partners PIM;
        private frmDogovorsList formDogovorsList;
        #endregion

        #region Конструктор
        public frmSendMail(int PartnerKey)
        {
            InitializeComponent();

            this.PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            this.PIM = PLDC.tbl_Partners.Where(x=>x.PR_KEY == PartnerKey).First();

            edt_FullName.Text = this.PIM.PR_FULLNAME;
            edt_INN.Text = this.PIM.PR_INN;
            edt_Name.Text = this.PIM.PR_NAME;
            edt_Phones.Text = this.PIM.PR_PHONES;
            edt_Email.Text = this.PIM.PR_EMAIL;
            if (edt_Email.Text.Trim() == "")
                tsBtnSend.Enabled = false;

            formDogovorsList = new frmDogovorsList(PLDC, PIM);
            formDogovorsList.SetFormForInsertToControl();
            this.gbDogovors.Controls.Add(formDogovorsList);
            formDogovorsList.Show();

            frmLantaOnLine formLantaOnLine = new frmLantaOnLine(PLDC, PIM);
            formLantaOnLine.SetFormForInsertToControl();
            tabOnLine.Controls.Add(formLantaOnLine);
            formLantaOnLine.Show();

            frmAviaOnLine formAviaOnLine = new frmAviaOnLine(PLDC, PIM);
            formAviaOnLine.SetFormForInsertToControl();
            this.tabAvia.Controls.Add(formAviaOnLine);
            formAviaOnLine.Show();

            if (PIM.DUP_USERs == null || PIM.DUP_USERs.Count() == 0)
                tsBtnSendOnLine.Enabled = false;
            if (PIM.LTP_AviaAccounts == null || PIM.LTP_AviaAccounts.Count() == 0)
                tsBtnSendAvia.Enabled = false;
            if ((PIM.PrtDogss == null || PIM.PrtDogss.Count() == 0)
                && (PIM.LTP_PrtDogs == null || PIM.LTP_PrtDogs.Count() == 0))
                tsBtnSendDogovors.Enabled  =false;
        }
        #endregion

        #region Обработка событий
        private void tsBtnSend_Click(object sender, EventArgs e)
        {
            #region Генерация договоров и сохранение списка в PathSaved
            
            History history = new History();
            history.HI_MOD = "UMS";
            history.HI_Type = "PARTNERS";
            history.HI_TypeCode = PIM.PR_KEY;
            history.HI_TEXT = "Отправка данных из AgencyManager";
            
            List<string> PathSaved = new List<string>();
            if (formDogovorsList.SelectedDogovorItems != null && tsBtnSendDogovors.Checked)
            {
                foreach (LTP_PrtDog DCI in formDogovorsList.SelectedDogovorItems)
                {
                    string PathD = PrintDogovor.Generate(DCI);
                    if (!String.IsNullOrEmpty(PathD)) 
                    {
                        PathSaved.Add(PathD);
                        HistoryDetail newHD = new HistoryDetail();
                        newHD.HD_Text = "Пересылка договора: ";
                        newHD.HD_ValueNew = DCI.LTPD_DogNum;
                        history.HistoryDetails.Add(newHD);
                    }
                }
            }
            #endregion

            // Перебор паролей LantaOnLine
            string LantaOnLinePass = "";
            if (tsBtnSendOnLine.Checked)
            {
                foreach (DUP_USER DUItem in PIM.DUP_USERs.Where(x => x.Active
                        && (x.Us_Superuser.GetValueOrDefault(false) && tsBtnSendRootLogin.Checked || !x.Us_Superuser.GetValueOrDefault(false))
                    ).OrderByDescending(x=>x.Us_Superuser))
                {
                    LantaOnLinePass +=
                        (DUItem.Us_Superuser.GetValueOrDefault(false) ? "<font Color='#FF0000'>Главный пароль<br>" : "")
                        + "<i>Контактное лицо:</i><b>" + DUItem.US_FULLNAME + "</b>"
                        + "<br><i>Логин:</i><b>" + DUItem.US_ID + "</b>"
                        + "<br><i>Пароль:</i><b>" + DUItem.US_PASSWORD_EncryptDecrypt + "</b>"
                        + (DUItem.Us_Superuser.GetValueOrDefault(false) ? "</font>" : "")
                        + "<br><br>";
                }
                if (!string.IsNullOrEmpty(LantaOnLinePass))
                {
                    HistoryDetail newHD = new HistoryDetail();
                    newHD.HD_Text = "Пересылка паролей для входа в Lanta On-Line";
                    history.HistoryDetails.Add(newHD);
                    LantaOnLinePass = "<table border=0><tr><td align=left valign=top><b><font color='#4444FF'>Данные для входа в ON-Line бронирование</font></b></td><td>" + LantaOnLinePass + "</td></tr></table><br>";
                }
            }

            // Перебор паролей Avia
            string LantaAvia = "";
            if (tsBtnSendAvia.Checked)
            {
                foreach (LTP_AviaAccount AAItem in PIM.LTP_AviaAccounts)
                {
                    LantaAvia += "<i>Логин:</i><b>" + AAItem.LTPA_User + "</b>"
                        + "<br><i>Пароль:</i><b>" + AAItem.LTPA_Pass + "</b>"
                        + "<br><br>";
                }
                if (!string.IsNullOrEmpty(LantaAvia))
                {
                    HistoryDetail newHD = new HistoryDetail();
                    newHD.HD_Text = "Пересылка паролей для входа в Lanta Avia";
                    history.HistoryDetails.Add(newHD);
                    LantaAvia = "<table border=0><tr><td align=left valign=top><b><font color='#4444FF'>Данные для входа в Lanta Avia</font></b></td><td><br>" + LantaAvia + "</td></tr></table><br>";
                }
            }

            try
            {
                if (LantaOnLinePass.Length != 0 || LantaAvia.Length != 0 || PathSaved.Count != 0)
                {
                    LTS_SpamServer spamServer = new LTS_SpamServer();
                    spamServer.LSS_MailTo = PIM.PR_EMAIL;
                    spamServer.LSS_Subject = "Регистрация на сайте";
                    spamServer.LSS_PRKey = PIM.PR_KEY;
                    spamServer.LSS_Body = @"%head%"
                        + LantaOnLinePass
                        + LantaAvia
                        + (PathSaved.Count > 0 ?
                            @"<p> Договор(а) находятся в прикрепленных к письму файлах.<br>
Для просмотра и печати необходим Adobe Acrobat Reader, программа является бесплатной,
<br>ее можно скачать в интернете с официального сайта Adobe по адресу:<br>
<a href=""http://ardownload.adobe.com/pub/adobe/reader/win/9.x/9.2/enu/AdbeRdr920_en_US.exe"">http://ardownload.adobe.com/pub/adobe/reader/win/9.x/9.2/enu/AdbeRdr920_en_US.exe</a></p>
<p><b><font color=""#FF0000"">Внимание</font> файлы договоров защищены от копирования текста, редактирования, и имеют доступ только для просмотра, сохранения копии файла и вывода на принтер.</b></p>"
                  : "")
                        + "%bottom%";


                    foreach (string AttachmentPath in PathSaved)
                    {
                        //new System.IO.FileInfo(AttachmentPath).Extension ???? .XLS или XLS - Удалить точку
                        System.IO.FileStream fs = new System.IO.FileStream(AttachmentPath, System.IO.FileMode.Open);
                        byte[] hashFile = new byte[fs.Length];
                        fs.Read(hashFile, 0, hashFile.Length);
                        fs.Close();
                        System.IO.File.Delete(AttachmentPath);

                        spamServer.LTS_SpamServerAttaches.Add(
                            new LTS_SpamServerAttach()
                            {
                                LTSA_Extension = new System.IO.FileInfo(AttachmentPath).Extension,
                                LTSA_Source = hashFile
                            });

                    }
                    PLDC.LTS_SpamServers.InsertOnSubmit(spamServer);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            PLDC.Histories.InsertOnSubmit(history);
            PLDC.SubmitChanges();
            MessageBox.Show("Письмо добавленно в очередь на отправку");
            this.Close();
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSendOnLine_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripButton CurrentTsBtn = (ToolStripButton)sender;
            if (CurrentTsBtn.Checked)
                CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.Check;
            else
                CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.UnCheck;

            if (CurrentTsBtn == tsBtnSendOnLine)
            {
                tsBtnSendRootLogin.Enabled = CurrentTsBtn.Checked;
                if (!tsBtnSendRootLogin.Enabled)
                    tsBtnSendRootLogin.Checked = false;
            }
        }

        private void frmSendMail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formDogovorsList != null)
                formDogovorsList.Close();
        }
        #endregion
    }
}
