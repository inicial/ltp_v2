using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmJournalCirculationDogovors : Form
    {
        #region Вспомогательные классы
        public class jrnDGV
        {
            public int PRKey;
            public int LTPDKey;

            [DisplayName("Номер договора")]
            public string DogovorNumber { get; set; }

            [DisplayName("Агентство")]
            public string AgencyName { get; set; }

            [DisplayName("Обработка запроса|Дата")]
            public DateTime FirstSendDate { get; set; }
            [DisplayName("Обработка запроса|Менеджер")]
            public string FirstSendWho { get; set; }

            [DisplayName("Копия по факсу|Дата получения")]
            public DateTime? FaxDate { get; set; }
            [DisplayName("Копия по факсу|Статус действительности")]
            public string FaxState { get; set; }
            [DisplayName("Копия по факсу|Менеджер")]
            public string FaxWho { get; set; }

            [DisplayName("Прием договора|Дата приема")]
            public DateTime? DogGetDate { get; set; }
            [DisplayName("Прием договора|Статус")]
            public string DogGetState { get; set; }
            [DisplayName("Прием договора|Менеджер")]
            public string DogGetWho { get; set; }

            [DisplayName("Прием договора в обработку|Дата обработки")]
            public DateTime? DogDate { get; set; }
            [DisplayName("Прием договора в обработку|Статус")]
            public string DogState { get; set; }
            [DisplayName("Прием договора в обработку|Менеджер")]
            public string DogWho { get; set; }

            [DisplayName("Подписание|Дата обработки")]
            public DateTime? SigDate { get; set; }
            [DisplayName("Подписание|Менеджер")]
            public string SigWho { get; set; }

            [DisplayName("№ Конверта")]
            public string PackNum { get; set; }
            [DisplayName("Опись договоров|Дата создания")]
            public DateTime? PackDate { get; set; }
            [DisplayName("Опись договоров|Менеджер")]
            public string PackWho { get; set; }

            [DisplayName("Передача курьерскому отделу|Дата")]
            public DateTime? CurierDate { get; set; }
            [DisplayName("Передача курьерскому отделу|Статус")]
            public string CurierState { get; set; }
            [DisplayName("Передача курьерскому отделу|Менеджер")]
            public string CurierWho { get; set; }

            [DisplayName("Отправка по почте|Дата")]
            public DateTime? MailDate { get; set; }
            [DisplayName("Отправка по почте|Статус")]
            public string MailState { get; set; }
            [DisplayName("Отправка по почте|Менеджер")]
            public string MailWho { get; set; }

            public jrnDGV(IEnumerable<LTP_Journal> journalItems)
            {
                LTPDKey = journalItems.First().LTP_PrtDog.LTPD_Key;
                PRKey = journalItems.First().LTP_PrtDog.LTPD_PRKey;

                DogovorNumber = journalItems.First().LTP_PrtDog.LTPD_DogNum;
                if (journalItems.First().LTP_PrtDog.tbl_Partners == null)
                    AgencyName = "!!!!!";
                else
                    AgencyName = journalItems.First().LTP_PrtDog.tbl_Partners.PR_NAME;

                var firstSends = journalItems.Where(x => x.LDJ_LRJId == 16);
                var firstSend = firstSends.Where(x => x.LDJ_Id == firstSends.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (firstSend != null)
                {
                    FirstSendDate = firstSend.LDJ_MsgDate;
                    FirstSendWho = firstSend.LDJ_Who;
                }

                var faxs = journalItems.Where(x => x.LDJ_LRJId == 11);
                var fax = faxs.Where(x => x.LDJ_Id == faxs.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (fax != null)
                {
                    FaxState = fax.LDJ_Comment;
                    FaxDate = fax.LDJ_MsgDate;
                    FaxWho = fax.LDJ_Who;
                }

                var dogsGet = journalItems.Where(x => x.LDJ_LRJId == 18);
                var dogGet = dogsGet.Where(x => x.LDJ_Id == dogsGet.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (dogGet != null)
                {
                    DogGetState = dogGet.LDJ_Comment;
                    DogGetDate = dogGet.LDJ_MsgDate;
                    DogGetWho = dogGet.LDJ_Who;
                }


                var dogs = journalItems.Where(x => x.LDJ_LRJId == 12);
                var dog = dogs.Where(x => x.LDJ_Id == dogs.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (dog != null)
                {
                    DogState = dog.LDJ_Comment;
                    DogDate = dog.LDJ_MsgDate;
                    DogWho = dog.LDJ_Who;
                }

                var sigs = journalItems.Where(x => x.LDJ_LRJId == 13);
                var sig = sigs.Where(x => x.LDJ_Id == sigs.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (sig != null)
                {
                    SigDate = sig.LDJ_MsgDate;
                    SigWho = sig.LDJ_Who;
                }

                var packs = journalItems.Where(x => x.LDJ_LRJId == 14);
                var pack = packs.OrderByDescending(x => x.LDJ_Id).FirstOrDefault();
                if (pack != null)
                {
                    PackNum = pack.LDJ_Comment;
                    PackDate = pack.LDJ_MsgDate;
                    PackWho = pack.LDJ_Who;
                }

                var curiers = journalItems.Where(x => x.LDJ_LRJId == 15);
                var curier = curiers.OrderByDescending(x => x.LDJ_Id).FirstOrDefault();
                if (curier != null)
                {
                    CurierState = curier.LDJ_Comment;
                    CurierDate = curier.LDJ_MsgDate;
                    CurierWho = curier.LDJ_Who;
                }

                var mails = journalItems.Where(x=>x.LDJ_LRJId == 17);
                var mail = mails.Where(x => x.LDJ_Id == mails.Max(x2 => x2.LDJ_Id)).FirstOrDefault();
                if (mail != null)
                {
                    MailDate = mail.LDJ_MsgDate;
                    MailState = mail.LDJ_Comment;
                    MailWho = mail.LDJ_Who;
                }
            }
        }

        public class jrnDGVDetail
        {
            [DisplayName("Номер договора")]
            public string DogovorNumber { get; set; }

            [DisplayName("Агентство")]
            public string AgencyName { get; set; }
            
            [DisplayName("Дата операции")]
            public DateTime DateOperation {get;set;}

            [DisplayName("ФИО Менеджера")]
            public string ManagerFio {get;set;}

            [DisplayName("Тип операции")]
            public string TypeOperation {get;set;}

            [DisplayName("Статус")]
            public string StatusOperation {get;set;}

            public jrnDGVDetail(LTP_Journal journalItem)
            {
                DogovorNumber = journalItem.LTP_PrtDog.LTPD_DogNum;
                AgencyName = journalItem.LTP_PrtDog.tbl_Partners.ToString();
                DateOperation = journalItem.LDJ_MsgDate;
                ManagerFio = journalItem.LDJ_Who;
                TypeOperation = journalItem.LTP_JournalRouteType.LRJ_Name;
                StatusOperation = journalItem.LDJ_Comment;
            }
        }
        #endregion

        #region Свойства
        private AgencyManager.ObjectModel.PartnersListDataContext pldc;
        private tbl_Partners _fltPartner;
        private tbl_Partners fltPartner
        {
            get { return _fltPartner; }
            set
            {
                if (value == null)
                    edtFltPartner.Text = "";
                else
                    edtFltPartner.Text = value.ToString();
                _fltPartner = value;
                LockNotUsedElements();
            }
        }
        #endregion

        #region Конструктор
        public frmJournalCirculationDogovors()
        {
            InitializeComponent();

            edtFltDateBeg.Value = DateTime.Now.Date.AddDays(-7);
            edtFltDateEnd.Value = DateTime.Now.Date;
            pldc = new AgencyManager.ObjectModel.PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            SyncCourier();
        }
        #endregion

        #region Методы
        private void LockNotUsedElements()
        {
            edtFltDateBeg.Enabled =
                edtFltDateEnd.Enabled =
                edtFltFirstSend.Enabled =
                edtFltFax.Enabled =
                edtFltDog.Enabled =
                edtFltSig.Enabled =
                edtFltPack.Enabled =
                edtFltSend.Enabled =
                edtFltEndInWeek.Enabled = (edtFltDogNumber.Text.Trim() == "" && fltPartner == null);
        }

        private void SyncCourier()
        {
            var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
            lwWaitScreen.Show();

            Courier_Sync.sync cSync = new Courier_Sync.sync();
            if (cSync.CheckConnection())
            {
                var itemsSendingToPost = pldc.LTP_Journals.Where(x => x.LDJ_LRJId == 17);
                DateTime lastGetting = new DateTime(2011,01,01,0,0,0);
                if (itemsSendingToPost.Count() > 0)
                    lastGetting = itemsSendingToPost.Max(x => x.LDJ_MsgDate);

                var sending = cSync.GetSendingPacket(lastGetting);
                if (sending != null)
                {
                    foreach (var item in sending)
                    {
                        foreach (var dogInPack in pldc.LTP_PrtDogPacks.Where(x => x.LTPP_Number == item.PacketNumber).Select(x => x.LTP_PrtDog))
                        {
                            foreach (var dogovor in pldc.LTP_PrtDogs.Where(x => x.LTPD_DogNum == dogInPack.LTPD_DogNum))
                            {
                                if (!pldc.LTP_Journals.Any(x => x.LDJ_LTPDKey == dogovor.LTPD_Key && x.LDJ_LRJId == 17))
                                {
                                    LTP_Journal newJournalItem = new LTP_Journal()
                                    {
                                        LDJ_Comment = item.State,
                                        LDJ_Who = item.Kurier.Trim(),
                                        LDJ_LRJId = 17,
                                        LDJ_LTPDKey = dogovor.LTPD_Key,
                                        LDJ_PRKey = dogovor.LTPD_PRKey
                                    };
                                    pldc.LTP_Journals.InsertOnSubmit(newJournalItem);
                                }
                            }
                        }
                    }
                    pldc.SubmitChanges();
                }
            }

            lwWaitScreen.Close();
        }
        #endregion

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
            lwWaitScreen.Show();

            if (pldc != null)
                pldc.Dispose();
            pldc = new AgencyManager.ObjectModel.PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var outData = (IQueryable<LTP_Journal>)pldc.LTP_Journals.Where(x => x.LTP_PrtDog != null);
            
            if (fltPartner != null)
            {
                outData = outData.Where(x => x.LDJ_PRKey == fltPartner.PR_KEY);
            }

            var qlx = outData
                .GroupBy(x => x.LDJ_LTPDKey)
                .Select(x => new
                {
                    Journal = x,
                    p11 = x.Any(x11 => x11.LDJ_LRJId == 11),
                    p12 = x.Any(x12 => x12.LDJ_LRJId == 12),
                    p13 = x.Any(x13 => x13.LDJ_LRJId == 13),
                    p14 = x.Any(x14 => x14.LDJ_LRJId == 14),
                    p15 = x.Any(x15 => x15.LDJ_LRJId == 15),
                    p16 = x.Any(x16 => x16.LDJ_LRJId == 16)
                });

            if (edtFltDogNumber.Text.Trim() == "" && fltPartner == null)
            {
                if (edtFltFirstSend.Checked)
                    qlx = qlx.Where(x => x.p16 && !x.p11 && !x.p12);
                if (edtFltFax.Checked)
                    qlx = qlx.Where(x => x.p11 && !x.p12);
                if (edtFltDog.Checked)
                    qlx = qlx.Where(x => x.p12);

                if (edtFltSig.Checked)
                    qlx = qlx.Where(x => x.p13);
                if (edtFltPack.Checked)
                    qlx = qlx.Where(x => x.p14);
                if (edtFltSend.Checked)
                    qlx = qlx.Where(x => x.p15);
            }
            var ext = qlx.Select(x => new { Journal = x.Journal, minDate = x.Journal.Max(x2 => x2.LDJ_MsgDate), DogNum = x.Journal.First().LTP_PrtDog.LTPD_DogNum });
            if (edtFltDogNumber.Text.Trim() == "" && !edtFltEndInWeek.Checked && fltPartner == null)
            {
                ext = ext.Where(x =>
                    x.minDate.Date >= edtFltDateBeg.Value.Date
                    && x.minDate.Date <= edtFltDateEnd.Value.Date);
            }
            if (edtFltEndInWeek.Checked)
            {
                ext = ext.Where(x =>
                    x.Journal.Any(xJ =>
                        !xJ.LTP_PrtDog.LTPD_TempActive && (xJ.LTP_PrtDog.LTPD_DateEnd - DateTime.Now).TotalDays > 0 && (xJ.LTP_PrtDog.LTPD_DateEnd - DateTime.Now).TotalDays < 7
                        || xJ.LTP_PrtDog.LTPD_TempActive && (xJ.LTP_PrtDog.LTPD_DateStart.AddDays(xJ.LTP_PrtDog.LTPD_TempActiveCountDayUse) - DateTime.Now).TotalDays > 0 && (xJ.LTP_PrtDog.LTPD_DateStart.AddDays(xJ.LTP_PrtDog.LTPD_TempActiveCountDayUse) - DateTime.Now).TotalDays < 7
                        ));
            }

            if (edtFltDogNumber.Text.Trim() != "")
            {
                ext = ext.Where(x => x.Journal.Any(xJ => xJ.LTP_PrtDog.LTPD_DogNum == edtFltDogNumber.Text));
            }

            var result = ext//.OrderBy(x => x.minDate)
                .Distinct()
                .OrderBy(x => x.DogNum)
                .Select(x => new jrnDGV(x.Journal.AsEnumerable()));

            lblCountRows.Text = result.Count().ToString();
            JournalDogovorsDGV.DataSource = result;

            lwWaitScreen.Close();
        }

        private void JournalDogovorsDGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (JournalDogovorsDGV.DataSource != null)
            {
                if (JournalDogovorsDGV.Rows.Count > 0 && JournalDogovorsDGV.Rows[0].DataBoundItem.GetType() == typeof(jrnDGV))
                {
                    JournalDogovorsDGV.Columns["AgencyName"].DefaultCellStyle.ForeColor = Color.Blue;
                    JournalDogovorsDGV.Columns["DogovorNumber"].DefaultCellStyle.ForeColor = Color.Blue;
                }
            }
        }

        private void JournalDogovorsDGV_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            jrnDGV selectedJRN;
            if (e.RowIndex >= 0)
            {
                if (JournalDogovorsDGV.Rows[e.RowIndex].DataBoundItem.GetType() == typeof(jrnDGV))
                {
                    selectedJRN = (jrnDGV)JournalDogovorsDGV.Rows[e.RowIndex].DataBoundItem;

                    if (JournalDogovorsDGV.Columns[e.ColumnIndex].Name == "AgencyName")
                    {
                        var currentPR = pldc.tbl_Partners.Where(x => x.PR_KEY == selectedJRN.PRKey).FirstOrDefault();
                        if (currentPR != null)
                        {
                            var frmDialog = new FormsForDogovor.frmDogovorsList(pldc, currentPR);
                            frmDialog.ShowDialog();
                            frmDialog.Dispose();
                            frmDialog = null;
                        }
                    }
                    else if (JournalDogovorsDGV.Columns[e.ColumnIndex].Name == "DogovorNumber")
                    {
                        JournalDogovorsDGV.DataSource = pldc
                            .LTP_Journals
                            .Where(x => x.LDJ_LTPDKey == selectedJRN.LTPDKey)
                            .OrderBy(x => x.LDJ_MsgDate)
                            .Select(x => new jrnDGVDetail(x));
                    }
                }
            }
        }

        private void JournalDogovorsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in JournalDogovorsDGV.Rows)
            {
                if (dgvr.DataBoundItem is jrnDGV)
                {
                    jrnDGV jrnItem = (jrnDGV)dgvr.DataBoundItem;
                    if (!jrnItem.DogDate.HasValue && jrnItem.FaxDate.HasValue && (jrnItem.FaxDate.Value.Date - DateTime.Now.Date).TotalDays <= 7)
                    {
                        dgvr.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void edtFltEndInWeek_CheckedChanged(object sender, EventArgs e)
        {
            edtFltDateBeg.Enabled = edtFltDateEnd.Enabled = !edtFltEndInWeek.Checked;
        }

        private void JournalDogovorsDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.JournalDogovorsDGV.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.JournalDogovorsDGV.Rows[index].HeaderCell.Value = indexStr;
        }

        private void btnSearchFltPartner_Click(object sender, EventArgs e)
        {
            var searchForm = new frmMasterPartners(0);
            if (searchForm.ShowDialog() == DialogResult.OK)
                fltPartner = searchForm.SelectedPartnerInMaster;
            else
                fltPartner = null;
        }

        private void edtFltDogNumber_TextChanged(object sender, EventArgs e)
        {
            LockNotUsedElements();
        }
    }
}
