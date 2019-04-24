using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Controls;
using ltp_v2.Framework;

namespace AccreditationCards
{
    public partial class frmMain : Form
    {
        #region Структуры
        private class AccountDGStruct
        {
            public int ACId { get; set; }
            public DateTime ACCreateDate { get; set; }
            public double ACTotalPrice { get; set; }
            public double ACPayed { get; set; }
            public string ACNumber { get; set; }

            public AccountDGStruct(ltp_v2.AccountCreator.ObjectModel.LTA_Account account)
            {
                this.ACId = account.AC_ID;
                this.ACCreateDate = account.AC_CRDate;
                this.ACTotalPrice = account.AC_TotalPrice;
                this.ACPayed = account.GetPayed();
                this.ACNumber = account.AC_Number;
            }
        }
        #endregion

        #region Свойства
        ltsDataContext lts;
        private int? FilteredPRKey;
        public bool ViewFullData;
        #endregion

        #region Конструктор
        public frmMain(bool viewFullData)
        {
            ViewFullData = viewFullData;
            FilteredPRKey = null;
            InitializeComponent();
        }

        public frmMain(int prKey)
            : this(true)
        {
            this.FilteredPRKey = prKey;
            DataGridBinding();
        }
        #endregion

        #region Методы
        private void DataGridBinding()
        {
            lts = new ltsDataContext(SqlConnection.ConnectionData);
            IQueryable<LTP_AccreditationCard> q = lts.LTP_AccreditationCards;
            if (tsFltNumberZakaz.Text.Trim() != "")
            {
                q = q.Where(x => x.LTPA_NumberZakaz == tsFltNumberZakaz.Text.Trim());
            }
            else if (tsFltYear.SelectedIndex >= 0)
            {
                q = q.Where(x => x.LTPA_CRDate.Year == (int)tsFltYear.Items[tsFltYear.SelectedIndex]);
            }
            if (FilteredPRKey.HasValue)
            {
                q = lts.LTP_AccreditationCards.Where(x => x.LTPA_PRKey == FilteredPRKey);
            }

            PartnersDGV.DataSource = q;
            statLblCountItems.Text = "Итого записей на экране: " + q.Count().ToString();
        }
        #endregion

        private void AccountsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AccountsDGV.AutoGenerateColumns = false;
            AccountsDGV.Columns.Clear();
            AccountsDGV.Columns.AddColumns("ACCreateDate", "Дата создания счета", "dd.MM.yyyy");
            AccountsDGV.Columns.AddColumns("ACNumber", "№ счета");
            AccountsDGV.Columns.AddColumns("ACTotalPrice", "Стоимость итого");
            AccountsDGV.Columns.AddColumns("ACPayed", "Оплата по счету");
        }

        private void PartnersDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            PartnersDGV.Columns.Clear();
            PartnersDGV.AutoGenerateColumns = false;
            PartnersDGV.Columns.AddColumns("LTPA_CRDate", "Дата заявки");
            PartnersDGV.Columns.AddColumns("Partner_UsingCard", "Название агентства");
            PartnersDGV.Columns.AddColumns("CardDateStart", "Дата начала действия АКК", "dd.MM.yyyy");
            PartnersDGV.Columns.AddColumns("CardDateEnd", "Дата завершения действия АКК", "dd.MM.yyyy");
            PartnersDGV.Columns.AddColumns("DogDateStart", "Дата начала действия Договора", "dd.MM.yyyy");
            PartnersDGV.Columns.AddColumns("DogDateEnd", "Дата завершения действия Договора", "dd.MM.yyyy");
            if (ViewFullData)
            {
                PartnersDGV.Columns.AddColumns("LTPA_PrintedDate", "Оформление|Дата", "dd.MM.yyyy");
                PartnersDGV.Columns.AddColumns("PrintedUserName", "Оформление|ФИО");
                PartnersDGV.Columns.AddColumns("LTPA_WhoTookCard", "Оформление|Куда отправить");

                PartnersDGV.Columns.AddColumns("LTPA_ActivationDate", "Выдача|Дата", "dd.MM.yyyy");
                PartnersDGV.Columns.AddColumns("ActivationUserName", "Выдача|ФИО");
                PartnersDGV.Columns.AddColumns("PartnerName_SendCardTo", "Выдача|ФИО Курьера");
            }
            else
            {
                PartnersDGV.Columns.AddColumns("PartnerName_SendCardTo", "Выдача|ФИО Курьера");
                PartnersDGV.Columns.AddColumns("LTPA_ActivationDate", "Дата выдачи карты", "dd.MM.yyyy");
            }
        }    

        private void frmMain_Load(object sender, EventArgs e)
        {
            lts = new ltsDataContext(SqlConnection.ConnectionData);
            foreach (var qYear in lts.LTP_AccreditationCards.Select(x => x.LTPA_CRDate.Year).Distinct().OrderByDescending(x => x))
            {
                tsFltYear.Items.Add(qYear);
            }
            if (tsFltYear.Items.Count > 0)
                tsFltYear.SelectedIndex = 0;

            DataGridBinding();
        }

        private void flt_Leave_Click(object sender, EventArgs e)
        {
            PartnersDGV.DataSource = null;
            DataGridBinding();
        }

        private void tsFltYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        private void tsFltNumberZakaz_TextChanged(object sender, EventArgs e)
        {
            DataGridBinding();
        }

        private void frmPrintCard_OnPrinted(object sender, EventArgs e)
        {
            var q = ((AccreditationCards.Shablon.frmViewer)sender).UsingCards;
            lts.SubmitChanges();
            //foreach (var ucItem in q)
            //{
            //    ucItem.AccountForPay.GenerateAndOpenDocuments();
            //}
            DataGridBinding();
        }

        private void PartnersDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (PartnersDGV.SelectedRows.Count == 1)
            {
                var SelectedCard = (LTP_AccreditationCard)PartnersDGV.SelectedRows[0].DataBoundItem;
                splitter1.Visible = lwContainerAccounts.Visible = true;
                var accountCreator = new ltp_v2.AccountCreator.AccountCreator();

                var accountInsert = accountCreator.GetAccount(SelectedCard.LTPA_ACId);
                var accountsDroped = accountCreator
                    .GetAccounts(SelectedCard.LTPA_PRKey, 3)
                    .Where(x =>
                        !x.AC_IsAnull.HasValue &&
                        x.AC_Param1 == SelectedCard.LTPA_CardNum)
                    .Select(x => new AccountDGStruct(x));

                List<AccountDGStruct> bindingSource = new List<AccountDGStruct>();
                bindingSource.Add(new AccountDGStruct(accountInsert));
                bindingSource.AddRange(accountsDroped);
                AccountsDGV.DataSource = bindingSource;
            }
            else
            {
                splitter1.Visible = lwContainerAccounts.Visible = false;
            }
        }

        private void lwGroupContainer1_PnlContainer_VisibleChanged(object sender, EventArgs e)
        {
            splitter1.Visible = lwContainerAccounts.Visible = (lwContainerAccounts.PnlContainer.Visible);
        }

        private void tsBtnPrintAccount_Click(object sender, EventArgs e)
        {
            if (AccountsDGV.SelectedRows.Count == 1)
            {
                var accDGStruct = (AccountDGStruct)AccountsDGV.SelectedRows[0].DataBoundItem;
                var acc = new ltp_v2.AccountCreator.AccountCreator().GetAccount(accDGStruct.ACId);
                var partner = lts.tbl_Partners.First(x => x.PR_KEY == acc.AC_PRKey);
                new ltp_v2.AccountCreator.AccountCreator()
                    .ViewAccount(
                        accDGStruct.ACId,
                        partner.PR_EMAIL,
                        "Счет на оплату Аккредитационной карты компании",
                        "см. вложеный файл");
            }
        }

        private void PartnersDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            var q = (LTP_AccreditationCard)PartnersDGV.Rows[index].DataBoundItem;
            string indexStr = (index + 1).ToString() + " " + (q.LTPA_CardType == 0 ? "осн" : "доп");
            object header = this.PartnersDGV.Rows[index].HeaderCell.Value;
            if (header == null || !header.Equals(indexStr))
                this.PartnersDGV.Rows[index].HeaderCell.Value = indexStr;
        }

        private void PartnersDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var q = ((LTP_AccreditationCard) PartnersDGV.Rows[e.RowIndex].DataBoundItem);
                bool GlobalLock = !q.LTPA_BlockDate.HasValue && !tsFltNumberZakaz.Text.IsNullOrEmptyOrSpace();
                tsBtnPrint.Enabled = GlobalLock && !q.LTPA_PrintedDate.HasValue;
                tsBtnActivate.Enabled = GlobalLock && q.LTPA_PrintedDate.HasValue && !q.LTPA_ActivationDate.HasValue;
            }
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            LTP_AccreditationCard[] result = new LTP_AccreditationCard[0];

            foreach (DataGridViewRow dgvr in PartnersDGV.SelectedRows)
            {
                var selectedCard = (LTP_AccreditationCard)dgvr.DataBoundItem;

                if (!selectedCard.LTPA_ActivationDate.HasValue) // Карта не активированна
                {
                    if (!selectedCard.LTPA_LTPDKey.HasValue) // Неимеет ID договора
                    {
                        MessageBox.Show("У выбранной карты № " + selectedCard.LTPA_CardNum
                            + "\r\nпартнер: " + selectedCard.tbl_Partner_UsingCard.PR_NAME
                            + "\r\nнет активного договора"
                            + "\r\n печать не возможна");
                        continue;
                    }
                    else if (selectedCard.LTP_PrtDog.LTPD_TempActive) // Договор временно активированный
                    {
                        MessageBox.Show("У выбранной карты № " + selectedCard.LTPA_CardNum
                            + "\r\nпартнер: " + selectedCard.tbl_Partner_UsingCard.PR_NAME
                            + "\r\nдоговор активирован по копии"
                            + "\r\n печать не возможна");
                        continue;
                    }
                    else if (!selectedCard.LTP_PrtDog.LTPD_PDKey.HasValue) // Договор не активированный
                    {
                        MessageBox.Show("У выбранной карты № " + selectedCard.LTPA_CardNum
                            + "\r\nпартнер: " + selectedCard.tbl_Partner_UsingCard.PR_NAME
                            + "\r\nдоговор не активирован"
                            + "\r\n печать не возможна");
                        continue;
                    }
                    else if (selectedCard.AccountSumm - selectedCard.AccountsPayed > 0) // Нехватает оплаты
                    {
                        MessageBox.Show("У выбранной карты № " + selectedCard.LTPA_CardNum
                            + "\r\nпартнер: " + selectedCard.tbl_Partner_UsingCard.PR_NAME
                            + "\r\nНехватает оплаты по счету в размере " + (selectedCard.AccountSumm - selectedCard.AccountsPayed).ToString() + " руб."
                            + "\r\n печать не возможна");
                        continue;
                    }

                    selectedCard.PrintCard();

                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = selectedCard;
                }
            }

            try
            {
                if (result.Length > 0)
                {
                    Shablon.frmViewer frmPrintCard = new Shablon.frmViewer(result);
                    frmPrintCard.OnPrinted += new EventHandler(frmPrintCard_OnPrinted);
                    frmPrintCard.ShowDialog();
                }
            }
            catch { }

            DataGridBinding();
        }

        private void tsBtnActivate_Click(object sender, EventArgs e)
        {
            if (PartnersDGV.SelectedRows.Count == 0)
                return;

            LTP_AccreditationCard selectedCard = (LTP_AccreditationCard)PartnersDGV.SelectedRows[0].DataBoundItem;
            new frmActivate(lts, selectedCard).ShowDialog();
        }
    }
}
