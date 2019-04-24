using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmCreateDogovor : Form
    {
        #region Свойства
        PartnersListDataContext CurrentUsePLDC;
        frmDogovorsList formDogovorsList;
        tbl_Partners CurrentUsePIM;
        bool IsCreateAndExit;
        #endregion

        #region Методы
        private void GetStartDogovorDate()
        {
            PrtDogTypes dtMyItem = ((PrtDogTypes)cblDogovorType.SelectedItem);

            MinimumDate MD = new MinimumDate();
            MD.GetMinimumDate(CurrentUsePIM.PR_KEY, dtMyItem.PDT_ID);

            /// Получение дат заездов не закрытых договорами
            DateTime newBegDate = (dtMyItem.LTP_DogType.LDT_IsRoot ? MD.NewDate.Value : MD.LastDogovor.Value.AddDays(1));
            DateTime newEndDate = newBegDate.AddMonths(dtMyItem.LTP_DogType.LDT_DefUseMonth);
            edtDateBeg.Value = newBegDate;
            edtDateEnd.Value = newEndDate;
            tsBtnCreate.Enabled = true;
            
            edtDateBeg.Enabled = edtDateEnd.Enabled = !dtMyItem.LTP_DogType.LDT_IsChield;
        }
        
        /// <summary>
        /// Создание дополнительного договора
        /// </summary>
        private LTP_PrtDog CreateDopDogovor(PrtDogTypes NeedDogovotType)
        {
            if (formDogovorsList.SelectedDogovorItem == null)
            {
                MessageBox.Show("Выберите договор к которому будет привязан текущий");
                return null;
            }

            if (formDogovorsList.SelectedDogovorItem.PrtDogTypes == null)
            {
                MessageBox.Show("Выбран договор у которого не удалось распознать тип");
                return null;
            }

            if (!formDogovorsList.SelectedDogovorItem.PrtDogTypes.LTP_DogType.LDT_IsRoot)
            {
                MessageBox.Show("Выберите основной договор");
                return null;
            }

            if (CurrentUsePLDC.GetChangeSet().Deletes.IndexOf(formDogovorsList.SelectedDogovorItem) >= 0)
            {
                MessageBox.Show("Выбранный основной договор помечен на удаление");
                return null;
            }

            if (CurrentUsePLDC.LTP_PrtDogs.Any(x =>
                x.LTPD_DogNum == formDogovorsList.SelectedDogovorItem.LTPD_DogNum
                && formDogovorsList.SelectedDogovorItem.tbl_Partners.PR_INN != null
                && formDogovorsList.SelectedDogovorItem.tbl_Partners.PR_INN.Length > 7
                && x.tbl_Partners.PR_INN != formDogovorsList.SelectedDogovorItem.tbl_Partners.PR_INN
                && x.tbl_Partners.PR_KEY != formDogovorsList.SelectedDogovorItem.tbl_Partners.PR_KEY))
            {
                MessageBox.Show("Вы не можете использовать договор №" + formDogovorsList.SelectedDogovorItem.LTPD_DogNum + " как основной" +
                    "\r\nтак как он может являться ошибочным, потому как № принядлежит нескольким агентствам с разным ИНН");
                MessageBox.Show("Создание договора отменено");
                return null;
            }

            //string NewNumber = formDogovorsList.SelectedDogovorItem.LTPD_DogNum + "-" + NeedDogovotType.LTP_DogType.LDT_Key;
            LTP_PrtDog NewDR = new LTP_PrtDog();
            NewDR.PrtDogTypes = NeedDogovotType;
            //NewDR.LTPD_DogNumKey. = formDogovorsList.SelectedDogovorItem.LTPD_DogNumKey;
            //NewDR.LTPD_DogNum = NewNumber;
            NewDR.LTPD_DateStart = formDogovorsList.SelectedDogovorItem.LTPD_DateStart;
            NewDR.LTPD_DateEnd = formDogovorsList.SelectedDogovorItem.LTPD_DateEnd;
            NewDR.Dogovor_Root = formDogovorsList.SelectedDogovorItem;
            return NewDR;
        }

        private LTP_PrtDog CreateBaseDogovor(PrtDogTypes NeedDogovotType)
        {
            if (CurrentUsePIM.LTP_PrtDogs.Where(x =>
                (
                    x.LTPD_DateStart <= edtDateBeg.Value
                    && x.LTPD_DateEnd >= edtDateBeg.Value
                    || x.LTPD_DateStart <= edtDateEnd.Value
                    && x.LTPD_DateEnd >= edtDateEnd.Value
                    || x.LTPD_DateStart >= edtDateBeg.Value
                    && x.LTPD_DateEnd <= edtDateEnd.Value
                ) && (
                    NeedDogovotType.LTP_DogType.LDT_IsRoot == true
                    && x.PrtDogTypes.LTP_DogType.LDT_IsRoot == NeedDogovotType.LTP_DogType.LDT_IsRoot
                    || NeedDogovotType.LTP_DogType.LDT_IsRoot == false
                    && x.PrtDogTypes.LTP_DogType.LDT_PDTID == NeedDogovotType.LTP_DogType.LDT_PDTID)
                ).Count() > 0)
            {
                MessageBox.Show("Дата желаемого договора пересекается с таким-же типом договора\r\nсмените дату");
                return null;
            }

            LTP_PrtDog NewDR = new LTP_PrtDog();
            NewDR.PrtDogTypes = NeedDogovotType;
            NewDR.LTPD_DateStart = edtDateBeg.Value;
            NewDR.LTPD_DateEnd = edtDateEnd.Value;
            return NewDR;
        }
        #endregion

        #region Конструктор
        public frmCreateDogovor(PartnersListDataContext curentUsePLDC, tbl_Partners pim)
        {
            InitializeComponent();

            IsCreateAndExit = false;
            this.CurrentUsePLDC = curentUsePLDC;
            this.CurrentUsePIM = pim;
            formDogovorsList = new frmDogovorsList(CurrentUsePLDC, CurrentUsePIM);
            formDogovorsList.TopLevel = false;
            formDogovorsList.Dock = DockStyle.Fill;
            formDogovorsList.FormBorderStyle = FormBorderStyle.None;
            groupBox1.Controls.Add(formDogovorsList);
            formDogovorsList.Show();

            this.Text = "Создание договоров для: " + CurrentUsePIM.PR_NAME + " [" + CurrentUsePIM.PR_COD + "]";

            edtDateBeg.Value = DateTime.Now;
            edtDateEnd.Value = DateTime.Now;

            cblDogovorType.DataSource = CurrentUsePLDC
                .PrtDogTypes
                .SetPermissionFilter()
                .OrderByDescending(x => x.LTP_DogType.LDT_IsRoot)
                .ThenBy(x => x.LTP_DogType.LDT_Key)
                .ToArray();
            cblDogovorType.ValueMember = "PDT_ID";
            cblDogovorType.DisplayMember = "DisplayText";
        }

        public frmCreateDogovor(PartnersListDataContext currentUsePLDC, tbl_Partners pim, PrtDogTypes DogovorType)
            : this(currentUsePLDC, pim)
        {
            cblDogovorType.SelectedValue = DogovorType.PDT_ID;
            IsCreateAndExit = true;
            this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Обработка событий
        private void edtDateBeg_ValueChanged(object sender, EventArgs e)
        {
            if (edtDateBeg.Value > edtDateEnd.Value)
                edtDateEnd.Value = edtDateBeg.Value;
            tsBtnCreate.Enabled = (edtDateEnd.Value.Date != edtDateBeg.Value.Date);
        }

        private void edtDateEnd_ValueChanged(object sender, EventArgs e)
        {
            if (edtDateBeg.Value > edtDateEnd.Value)
                edtDateBeg.Value = edtDateEnd.Value;
            tsBtnCreate.Enabled = (edtDateEnd.Value.Date != edtDateBeg.Value.Date);
        }

        private void cblDogovorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cblDogovorType.SelectedIndex < 0)
            {
                tsBtnCreate.Enabled = false;
                return;
            }

            GetStartDogovorDate();
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            if (cblDogovorType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип договора который вы хотите создать");
                MessageBox.Show("Создание договора отменено");
                return;
            }

            string errorMsg = "";
            var officesOnSuchINN = CurrentUsePLDC.GetTheOfficesOnSuchAnINN(CurrentUsePIM, out errorMsg);
            if (officesOnSuchINN == null)
            {
                MessageBox.Show(errorMsg);
                MessageBox.Show("Создание договора отменено");
                return;
            }

            int CountSubAgancy = officesOnSuchINN.Count();
            if (CountSubAgancy > 1)
            {
                if (MessageBox.Show("Внимание есть Агентства с подобным ИНН в кол-ве " + (CountSubAgancy - 1).ToString() + " вы хотите создать на всех?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    MessageBox.Show("Создание договора отменено");
                    return;
                }
            }

            PrtDogTypes NeedDogovotType = ((PrtDogTypes)cblDogovorType.SelectedItem);
            
            LTP_PrtDog newDogovor = null;
            if ((newDogovor = (NeedDogovotType.LTP_DogType.LDT_IsChield
                    ? CreateDopDogovor(NeedDogovotType)
                    : CreateBaseDogovor(NeedDogovotType))) != null)
            {
                CurrentUsePIM.LTP_PrtDogs.Add(newDogovor);
            }
            else
            {
                return;
            }

            if (NeedDogovotType.PDT_ID == 1)
            {
                MinimumDate MD = new MinimumDate();
                MD.GetMinimumDate(CurrentUsePIM.PR_KEY, NeedDogovotType.PDT_ID);
                if (MD.NewDate.Value.AddMonths(NeedDogovotType.LTP_DogType.LDT_DefUseMonth) < DateTime.Now)
                {
                    MessageBox.Show("Есть незакрытые брони\r\nСоздайте договора прошлых периодов\r\nтем самым закроете продажи договорами", "Создание договора", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formDogovorsList.RefreshDataGrid();
                    GetStartDogovorDate();
                }
            }
            if (IsCreateAndExit)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            formDogovorsList.RefreshDataGrid();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCreateDogovor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formDogovorsList != null)
                formDogovorsList.Close();
        }
        #endregion
    }
}
