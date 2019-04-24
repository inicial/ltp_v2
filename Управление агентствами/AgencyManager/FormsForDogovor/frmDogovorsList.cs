using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Controls;
using System.Diagnostics;
using ltp_v2.Framework;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmDogovorsList : Form
    {
        #region Свойства
        private tbl_Partners CurrentUsePIM;
        private PartnersListDataContext CurrentUsePLDC;

        /// <summary>
        /// Первый выбранный договор в DataGridView, 
        /// ипользуется как привязка при создание договора
        /// </summary>
        public LTP_PrtDog SelectedDogovorItem
        {
            get
            {
                if (CombineDogovorsDGV.SelectedRows == null || CombineDogovorsDGV.SelectedRows.Count == 0)
                    return null;
                if (CombineDogovorsDGV.SelectedRows.Count > 1)
                    return null;
                return (LTP_PrtDog)CombineDogovorsDGV.SelectedRows[0].DataBoundItem;
            }
        }

        /// <summary>
        /// Список выбранных договоров в DataGridView
        /// используется для отправки договоров по почте
        /// </summary>
        public List<LTP_PrtDog> SelectedDogovorItems
        {
            get
            {
                if (CombineDogovorsDGV.SelectedRows == null || CombineDogovorsDGV.SelectedRows.Count == 0)
                    return null;
                List<LTP_PrtDog> result = new List<LTP_PrtDog>();
                foreach (DataGridViewRow dgvrItem in CombineDogovorsDGV.SelectedRows)
                {
                    LTP_PrtDog dciSelected = (LTP_PrtDog)dgvrItem.DataBoundItem;
                    result.Add(dciSelected);
                }
                return result;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Обновление списка договоров
        /// </summary>
        public void RefreshDataGrid()
        {
            CombineDogovorsDGV.AutoGenerateColumns = false;
            CombineDogovorsDGV.Columns.Clear();

            if (CombineDogovorsDGV.DataSource != null)
            {
                ((List<LTP_PrtDog>)CombineDogovorsDGV.DataSource).Clear();
            }

            CombineDogovorsDGV.DataSource = CurrentUsePIM.LTP_PrtDogs
                .OrderByDescending(x => x.LTPD_DogNum)
                .ThenByDescending(x => x.LTPD_DateEnd)
                .ThenBy(x => x.LTPD_DogovorTypeID).ToList();

            CombineDogovorsDGV.Columns.AddColumns("IsActive", "Активирован", typeof(Boolean));
            CombineDogovorsDGV.Columns.AddColumns("NumberWithInfo", "Номер");
            CombineDogovorsDGV.Columns.AddColumns("DogovorTypeName", "Тип договора");
            CombineDogovorsDGV.Columns.AddColumns("LTPD_DateStart", "Дата начала действия", "dd.MM.yyyy");
            CombineDogovorsDGV.Columns.AddColumns("LTPD_DateEnd", "Дата завершения действия", "dd.MM.yyyy");
            CombineDogovorsDGV_DataBindingComplete(CombineDogovorsDGV, null);
        }
        #endregion

        #region Конструктор
        public frmDogovorsList(PartnersListDataContext currentUsePLDC, tbl_Partners currentUsePIM)
        {
            InitializeComponent();
            this.CurrentUsePLDC = currentUsePLDC;
            this.CurrentUsePIM = currentUsePIM;
            this.Shown += new EventHandler(frmDogovorsList_Shown);

            this.Text = "Список договоров для : " + currentUsePIM.ToString();
        }
        #endregion

        #region Обработка событий
        private void frmDogovorsList_Shown(object sender, EventArgs e)
        {
            this.RefreshDataGrid();
            if (ParentForm == null)
            {
                tsBtnCreateDogovor.Visible = false;
                tsBtnEdit.Visible = false;
                tsBtnDelete.Visible = false;
                tsBtnClose.Visible = false;
                tsBtnCheckDogovor.Visible = false;
                CombineDogovorsDGV.MultiSelect = true;
                tsLblSelect.Text = "Для выделения договоров на отправку используйте Ctrl или Shift";
            }
        }

        private void frmDogovorsList_ParentChanged(object sender, EventArgs e)
        {
            if (ParentForm == null)
            {
                return;
            }

            if (ParentForm.GetType() == typeof(frmCreateDogovor))
            {
                tsBtnCreateDogovor.Visible = false;
                tsBtnEdit.Visible = false;
                tsBtnSelect.Visible = false;
                tsLblSelect.Visible = false;
            }
            if (ParentForm.GetType() == typeof(FormsForPartners.frmEditPartner))
            {
                tsBtnSelect.Visible = false;
                tsLblSelect.Visible = false;
            }
            if (ParentForm.GetType() == typeof(FormsForPartners.frmSendMail))
            {
                tsBtnCreateDogovor.Visible = false;
                tsBtnEdit.Visible = false;
                tsBtnDelete.Visible = false;
                tsBtnClose.Visible = false;
                tsBtnCheckDogovor.Visible = false;
                CombineDogovorsDGV.MultiSelect = true;
                tsLblSelect.Text = "Для выделения договоров на отправку используйте Ctrl или Shift";
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            if (SelectedDogovorItem == null)
            {
                MessageBox.Show("Выберите договор для закрытия");
                return;
            }

            // Проверка договора на привязку к АКА
            using (AccreditationCards.ltsDataContext akaDC = new AccreditationCards.ltsDataContext(SqlConnection.ConnectionData))
            {
                if (akaDC.LTP_AccreditationCards.Any(x => x.LTPA_LTPDKey == SelectedDogovorItem.LTPD_Key))
                {
                    MessageBox.Show("Вы не можете закрыть договор, так как к нему привязана Аккредитационная карта");
                    return;
                }
            }

            var result = new ltp_v2.Controls.DialogFroms.lwDateTimeDialog()
            {
                MaxValue = SelectedDogovorItem.LTPD_DateStart.Date.AddYears(1),
                MinValue = SelectedDogovorItem.LTPD_DateStart.Date,
                CurrentValue = ltp_v2.Framework.SqlConnection.ServerDateTime.Date
            }.Show("Дата закрытия договора");

            if (result.HasValue)
            {
                foreach (var ltpPrtDog in CurrentUsePLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == SelectedDogovorItem.LTPD_DogNum))
                {
                    ltpPrtDog.LTPD_DateEnd = result.Value;
                    if (ltpPrtDog.PrtDogs != null)
                        ltpPrtDog.PrtDogs.PD_DateEnd = result.Value;
                }
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedDogovorItem == null)
                return;

            // Проверка на то что он неактивный в противном случае выход
            if (SelectedDogovorItem.IsActive)
            {
                MessageBox.Show("Вы не можете удалить активированный договор");
                return;
            }

            using(AccreditationCards.ltsDataContext ltsAKA = new AccreditationCards.ltsDataContext(SqlConnection.ConnectionData))
            {
                if (ltsAKA.LTP_AccreditationCards.Any(x => x.LTPA_LTPDKey == SelectedDogovorItem.LTPD_Key))
                {
                    MessageBox.Show("Договор привязан к аккредитационной карте агента, удаление не возможно");
                    return;
                }
            }

            // Проверка на то что он базовый
            if (SelectedDogovorItem.PrtDogTypes.LTP_DogType.LDT_IsRoot)
            {
                // Проверка на активированные подчиненные договора
                if (SelectedDogovorItem.Dogovors_Dop.Where(x => x.IsActive).Count() > 0)
                {
                    MessageBox.Show("Есть активированные доп.соглашения для этого договора, удаление невозможно");
                    return;
                }

                // Проверка на наличие подчиненных договоров
                if (SelectedDogovorItem.Dogovors_Dop.Count() > 0)
                {
                    if (MessageBox.Show("Есть доп.соглашения для этого договора, удалить вместе с ними?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;

                    foreach (LTP_PrtDog DRItem in SelectedDogovorItem.Dogovors_Dop)
                    {
                        CurrentUsePLDC.LTP_PrtDogs.DeleteOnSubmit(DRItem);
                        foreach (LTP_Journal journalItem in DRItem.LTP_Journals)
                        {
                            CurrentUsePLDC.LTP_Journals.DeleteOnSubmit(journalItem);
                        }
                    }
                }

                foreach (LTP_TempAccreditationCard tacItem in SelectedDogovorItem.LTP_TempAccreditationCards)
                {
                    tacItem.LTPA_LTPDKey = null;
                }
            }

            foreach (LTP_Journal journalItem in SelectedDogovorItem.LTP_Journals)
            {
                CurrentUsePLDC.LTP_Journals.DeleteOnSubmit(journalItem);
            }

            CurrentUsePLDC.LTP_PrtDogs.DeleteOnSubmit(SelectedDogovorItem);
            CombineDogovorsDGV_DataBindingComplete(null, new DataGridViewBindingCompleteEventArgs(ListChangedType.ItemChanged));
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (SelectedDogovorItem == null)
            {
                MessageBox.Show("Выберите документ для печати");
                return;
            }

            var currentUsedDogovor = SelectedDogovorItem;
            var anyDogovors = CurrentUsePLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == currentUsedDogovor.LTPD_DogNum);
            if (anyDogovors.Count() > 1)
            {
                IQueryable<LTP_PrtDog> fs = anyDogovors
                    .Where(x => x.tbl_Partners.PrtTypesToPartners.Any(xptp => xptp.PTP_PTId == 1027));

                if (fs.Count() > 0)
                    currentUsedDogovor = fs.First();
            }

            PrintDogovor PD = new PrintDogovor(currentUsedDogovor);
            if (PD.ResultSaveFile != null)
            {
                Process.Start(PD.ResultSaveFile);
            }
        }

        private void CombineDogovorsDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedDogovorItem == null)
            {
                tsBtnClose.Enabled = false;
                tsBtnDelete.Enabled = false;
                tsBtnPrint.Enabled = false;
                tsBtnEdit.Enabled = false;
                return;
            }

            tsBtnClose.Enabled = true;
            tsBtnDelete.Enabled = true;
            tsBtnPrint.Enabled = true;
            tsBtnEdit.Enabled = true;

            if (SelectedDogovorItem.IsActive)
                tsBtnDelete.Enabled = false;
            else
                tsBtnClose.Enabled = false;

            if (CurrentUsePLDC.GetChangeSet().Deletes.IndexOf(SelectedDogovorItem) >= 0)
            {
                tsBtnDelete.Enabled = false;
                tsBtnClose.Enabled = false;
                tsBtnPrint.Enabled = false;
                tsBtnEdit.Enabled = false;
            }
        }

        private void CombineDogovorsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (CombineDogovorsDGV.Rows.Count == 0)
                return;
            if (CombineDogovorsDGV.SelectedRows.Count == 0)
                CombineDogovorsDGV.Rows[0].Selected = true;
            CombineDogovorsDGV_RowEnter(sender, new DataGridViewCellEventArgs(0, CombineDogovorsDGV.Rows.IndexOf(CombineDogovorsDGV.SelectedRows[0])));

            foreach (DataGridViewRow dgvr in CombineDogovorsDGV.Rows)
            {
                Label useLblLegend = lblLegendNotActive;

                LTP_PrtDog dgvrTypedDR = (LTP_PrtDog)dgvr.DataBoundItem;
                if (CurrentUsePLDC.GetChangeSet().Deletes.IndexOf(dgvrTypedDR) >= 0)
                {
                    useLblLegend = lblLegendDelete;
                }
                else if (CurrentUsePLDC.GetChangeSet().Inserts.IndexOf(dgvrTypedDR) >= 0
                    || CurrentUsePLDC.GetChangeSet().Updates.IndexOf(dgvrTypedDR) >= 0
                    || CurrentUsePLDC.GetChangeSet().Inserts.IndexOf(dgvrTypedDR.PrtDogs) >= 0
                    || CurrentUsePLDC.GetChangeSet().Updates.IndexOf(dgvrTypedDR.PrtDogs) >= 0)
                {
                    useLblLegend = lblLegendNew;
                }
                else if (dgvrTypedDR.IsActiveState == DogovorActiveState.TmpActive)
                {
                    useLblLegend = lblLegendTempActive;
                }
                else if (dgvrTypedDR.IsActive)
                {
                    useLblLegend = lblLegendActive;
                }

                dgvr.DefaultCellStyle.ForeColor = useLblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = useLblLegend.BackColor;
                dgvr.DefaultCellStyle.Font = useLblLegend.Font;
                if (useLblLegend.ForeColor.ToArgb() == CombineDogovorsDGV.DefaultCellStyle.ForeColor.ToArgb())
                    dgvr.DefaultCellStyle.SelectionForeColor = CombineDogovorsDGV.DefaultCellStyle.SelectionForeColor;
                else
                    dgvr.DefaultCellStyle.SelectionForeColor = useLblLegend.ForeColor;
            }
        }

        private void tsBtnCreateDogovor_Click(object sender, EventArgs e)
        {
            new frmCreateDogovor(CurrentUsePLDC, this.CurrentUsePIM).ShowDialog();
            this.RefreshDataGrid();
        }

        private void tsBtnSelect_Click(object sender, EventArgs e)
        {
            CombineDogovorsDGV.ClearSelection();
            foreach (DataGridViewRow dgvrItem in CombineDogovorsDGV.Rows)
            {
                LTP_PrtDog CurrentDCI = ((LTP_PrtDog)dgvrItem.DataBoundItem);
                if (!CurrentDCI.IsActive)
                    dgvrItem.Selected = true;
            }
        }

        private void tsBtnCheckDogovor_Click(object sender, EventArgs e)
        {
            if (SelectedDogovorItem == null)
            {
                MessageBox.Show("Выберите документ для того что бы его переподвесить на другие по ИНН");
                return;
            }
            CurrentUsePLDC.GenerateCopyDogovorsByINN(SelectedDogovorItem);
            MessageBox.Show("Договора переподвешены на агентства с таким-же ИНН, необходимо сохранить");
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (SelectedDogovorItem == null)
            {
                MessageBox.Show("Выберите документ для изменения");
                return;
            }

            new frmDogovorCommentEditor(SelectedDogovorItem).ShowDialog();
        }

        private void frmDogovorsList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CombineDogovorsDGV.DataSource != null)
            {
                ((List<LTP_PrtDog>)CombineDogovorsDGV.DataSource).Clear();
            }
        }
        #endregion
    }
}