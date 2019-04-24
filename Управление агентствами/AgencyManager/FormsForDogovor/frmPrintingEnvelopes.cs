using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Controls.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;
using Microsoft.Reporting.WinForms;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmPrintingEnvelopes : Form
    {
        #region Структуы
        private class DogovorListItem
        {
            public LTP_PrtDog PrtDog;
            public string Number { get { return PrtDog.LTPD_DogNum; } }
            public bool IsActivate { get { return PrtDog.LTPD_ActiveDate.HasValue; } }
            public string ActiveType
            {
                get
                {
                    return PrtDog.LTPD_TempActive
                        ? "врем." + PrtDog.LTPD_TempActiveCountDayUse.ToString() + "дн."
                        : "оригинал";
                }
            }
            public string ParnerName { get { return PrtDog.tbl_Partners.PR_NAME + " (" + PrtDog.tbl_Partners.PR_CITY + ")"; } }
            public bool IsSigning { get { return PrtDog.LTPD_Signing.HasValue; } }

            public DogovorListItem(LTP_PrtDog value)
            {
                this.PrtDog = value;
            }
        }
        #endregion

        #region Свойства
        private string LastDogNum = "";
        private static string messageDogNum = "Введите № договора, нажмите Enter";
        private PartnersListDataContext PLDC;
        List<DogovorListItem> outList;
        #endregion

        #region Конструктор
        public frmPrintingEnvelopes()
        {
            PLDC = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();

            this.DialogResult = DialogResult.Cancel;

            groupBox1.Visible = tsBtnActivate.Visible = tsBtnClear.Visible = DogovorsDGV.Visible = true;
            rptPrinter.Visible = false;
            outList = new List<DogovorListItem>();
        }
        #endregion

        #region Обработка событий

        private void edtDogovorNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
            {
                edtDogovorNum.SelectAll();
            }
        }

        private void edtDogovorNum_TextChanged(object sender, EventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
                edtDogovorNum.ForeColor = Color.Gray;
            else
                edtDogovorNum.ForeColor = SystemColors.ControlText;
        }

        private void edtDogovorNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text.Trim() == "")
            {
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (LastDogNum != edtDogovorNum.Text)
            {
                LastDogNum = edtDogovorNum.Text;
            }

            if (e.KeyCode != Keys.Enter || edtDogovorNum.Text.Length < 9 || edtDogovorNum.Text == messageDogNum)
                return;

            edtDogovorNum.SelectAll();

            IQueryable<LTP_PrtDog> findingDRs = PLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == edtDogovorNum.Text);

            if (findingDRs.Count() == 0)
            {
                MessageBox.Show("Запрошенный договор в базе данных не найден");
                return;
            }

            if (findingDRs.Any(x => x.LTPD_PDKey == null))
            {
                MessageBox.Show("Выбранный вами договор №" + edtDogovorNum.Text + "должен быть сначала активирован");
                return;
            }

            if (findingDRs.Any(x => x.LTPD_Signing == null))
            {
                MessageBox.Show("Выбранный вами договор №" + edtDogovorNum.Text + "должен быть сначала подписан");
                return;
            }

            // попытка получения PTID = 1027 Основного офиса
            IQueryable<LTP_PrtDog> fs = findingDRs.Where(x => x.tbl_Partners.PrtTypesToPartners.Count(xptp => xptp.PTP_PTId == 1027) > 0);
            if (fs.Count() > 0)
                findingDRs = fs;

            foreach (var dog in findingDRs)
            {
                if (outList.Count() == 0 || outList.Count(x => x.PrtDog.LTPD_PRKey == dog.LTPD_PRKey) > 0)
                {
                    if (outList.Count(x => x.PrtDog.LTPD_Key == dog.LTPD_Key) == 0)
                        outList.Add(new DogovorListItem(dog));
                }
            }

            tsBtnClear.Enabled = tsBtnActivate.Enabled = true;

            DogovorsDGV.DataSource = null;
            DogovorsDGV.DataSource = outList;
            edtDogovorNum.SelectAll();
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnActivate_Click(object sender, EventArgs e)
        {
            List<rptDogovorList> rptDogovorList = new List<rptDogovorList>();
            LTP_PrtDogPack firstPrtDogPack = null;
            foreach (var dogItem in outList)
            {
                LTP_PrtDogPack newPrtDogPack = new LTP_PrtDogPack();
                if (firstPrtDogPack == null)
                    firstPrtDogPack = newPrtDogPack;
                rptDogovorList.Add(new rptDogovorList(dogItem.PrtDog));
                newPrtDogPack.LTP_PrtDog = dogItem.PrtDog;
                PLDC.LTP_PrtDogPacks.InsertOnSubmit(newPrtDogPack);
            }

            PLDC.SubmitChanges();

            DogovorsDGV.DataSource = null;
            edtDogovorNum.SelectAll();

            outList.Clear();

            if (firstPrtDogPack != null)
            {
                groupBox1.Visible = tsBtnActivate.Visible = tsBtnClear.Visible = DogovorsDGV.Visible = false;
                rptPrinter.Visible = true;

                this.rptPrinter.Reset();

                BindingSource bsRpt = new BindingSource();
                bsRpt.DataSource = new rptClassPrintingEnvelopes(firstPrtDogPack);
                ReportDataSource rdsRpt = new ReportDataSource();
                rdsRpt.Name = "rptClassPrintingEnvelopes";
                rdsRpt.Value = bsRpt;
                this.rptPrinter.LocalReport.DataSources.Add(rdsRpt);

                BindingSource bsDogovorList = new BindingSource();
                bsDogovorList.DataSource = rptDogovorList;
                ReportDataSource rdsDogovorList = new ReportDataSource();
                rdsDogovorList.Name = "rptDogovorList";
                rdsDogovorList.Value = bsDogovorList;
                this.rptPrinter.LocalReport.DataSources.Add(rdsDogovorList);

                this.rptPrinter.LocalReport.ReportEmbeddedResource = "AgencyManager.FormsForDogovor.rptPrintingEnvelopes.rdlc";
                this.rptPrinter.RefreshReport();
                this.rptPrinter.SetDisplayMode(DisplayMode.Normal);
                this.rptPrinter.ZoomMode = ZoomMode.FullPage;
                this.rptPrinter.RefreshReport();

                rptClassPrintingEnvelopes repval = new rptClassPrintingEnvelopes(firstPrtDogPack);
            }
        }

        private void frmPrintingEnvelopes_Load(object sender, EventArgs e)
        {
            this.rptPrinter.RefreshReport();
        }

        private void tsBtnClear_Click(object sender, EventArgs e)
        {
            outList.Clear();
            DogovorsDGV.DataSource = null;
            DogovorsDGV.DataSource = outList;
        }

        private void DogovorsDGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (DogovorsDGV.DataSource != null)
            {
                DogovorsDGV.Columns["Number"].HeaderText = "Номер договора";
                DogovorsDGV.Columns["Number"].Width = 100;

                DogovorsDGV.Columns["IsActivate"].HeaderText = "Активирован";
                DogovorsDGV.Columns["IsActivate"].Width = 50;

                DogovorsDGV.Columns["IsSigning"].HeaderText = "Подписан";
                DogovorsDGV.Columns["IsSigning"].Width = 50;

                DogovorsDGV.Columns["ActiveType"].HeaderText = "Тип активации";
                DogovorsDGV.Columns["ActiveType"].Width = 50;

                DogovorsDGV.Columns["ParnerName"].HeaderText = "Название партнера";
            }
        }

        void rptPrinter_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            outList.Clear();
            DogovorsDGV.DataSource = null;
            DogovorsDGV.DataSource = outList;

            groupBox1.Visible = tsBtnActivate.Visible = tsBtnClear.Visible = DogovorsDGV.Visible = true;
            rptPrinter.Visible = false;
            edtDogovorNum.Text = "";
        }
        #endregion
    }
}
