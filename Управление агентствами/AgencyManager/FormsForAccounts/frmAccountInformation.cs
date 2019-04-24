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

namespace AgencyManager.FormsForAccounts
{
    public partial class frmAccountInformation : Form
    {
        #region Делегированные свойства
        public delegate void UsePrtAccount(PrtAccount sender);
        #endregion

        #region Свойства
        public PrtAccount currentPA { get; private set; }
        PartnersListDataContext PLDC;
        tbl_Partners PIM;
        #endregion

        #region Конструктор
        private frmAccountInformation(PartnersListDataContext pldc, tbl_Partners pim, PrtAccount pa)
        {
            this.PLDC = pldc;
            this.currentPA = pa;
            this.PIM = pim;

            InitializeComponent();
            tsLblInformation.Text = "";
            if (currentPA.Bank != null)
            {
                edtBank.Text = currentPA.Bank.BN_Name;
            }
            edtText.Text = currentPA.PA_Text;
            edtRS.Text = currentPA.PA_Account;
        }

        /// <summary>
        /// Использовать для создания нового счета
        /// </summary>
        public frmAccountInformation(PartnersListDataContext pldc, tbl_Partners pim)
            : this(pldc, pim, new PrtAccount())
        {
            tsBtnDelete.Visible = false;
            this.Text += pim.NameForForms;
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Использовать для редактирования счета с данными по умолчанию
        /// </summary>
        public frmAccountInformation(PartnersListDataContext pldc, tbl_Partners pim, Bank FindBank, PrtAccount NewPA)
            :this(pldc, pim)
        {
            currentPA.PA_Account = NewPA.PA_Account;
            currentPA.PA_Text = NewPA.PA_Text;
            frmBanks frmBanks = new frmBanks(PLDC, FindBank);
            if (frmBanks.ShowDialog() == DialogResult.Yes)
            {
                currentPA.Bank = frmBanks.SelectedBank;
                edtBank.Text = currentPA.Bank.BN_Name;
            }
            edtText.Text = currentPA.PA_Text;
            edtRS.Text = currentPA.PA_Account;
        }

        /// <summary>
        /// Использовать для редактирования счета
        /// </summary>
        public frmAccountInformation(PartnersListDataContext pldc, PrtAccount pa)
            : this(pldc, null, pa)
        {
            this.tsBtnSave.Visible = false;
            tsBtnClose.Visible = false;

            if (pa == null)
                throw new Exception("PrtAccount не может быть null");

            if (pldc.GetChangeSet().Inserts.IndexOf(currentPA) >= 0)
            {
                tsLblInformation.Text = "Новый несохранен";
                tsBtnDelete.Text = "Отменить добавление";
            }
        }
        #endregion

        #region Обработка событий
        private void edtBank_Click(object sender, EventArgs e)
        {
            Bank BankForFind = new Bank();
            BankForFind.BN_Name = edtBank.Text;
            if (currentPA.Bank != null)
            {
                BankForFind.BN_BIK = currentPA.Bank.BN_BIK;
                BankForFind.BN_CorAccount = currentPA.Bank.BN_CorAccount;
            }

            frmBanks frmBanks = new frmBanks(PLDC, BankForFind);
            if (frmBanks.ShowDialog() == DialogResult.Yes)
            {
                currentPA.Bank = frmBanks.SelectedBank;
                edtBank.Text = currentPA.Bank.BN_Name;
            }
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (currentPA.Bank == null || currentPA.PA_Account == null || currentPA.PA_Account.Trim() == "")
            {
                MessageBox.Show("Выберите банк, и р/с, Сохранение отменено");
                return;
            }
            PIM.PrtAccounts.Add(currentPA);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void edtRS_TextChanged(object sender, EventArgs e)
        {
            if (currentPA.PA_Account != edtRS.Text) currentPA.PA_Account = edtRS.Text;
        }

        private void edtText_TextChanged(object sender, EventArgs e)
        {
            if (currentPA.PA_Text != edtText.Text) currentPA.PA_Text = edtText.Text;
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (PLDC.GetChangeSet().Inserts.IndexOf(currentPA) >= 0)
            {
                this.Close();
            }
            else if (PLDC.GetChangeSet().Deletes.IndexOf(currentPA) >= 0)
            {
                tsLblInformation.Text = "";
                PLDC.PrtAccounts.InsertOnSubmit(currentPA);
            }
            else
            {
                tsLblInformation.Text = "Отмечен на удаление";
                PLDC.PrtAccounts.DeleteOnSubmit(currentPA);
            }
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
