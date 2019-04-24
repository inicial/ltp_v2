using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep259920
{
    public partial class frmMain : Form
    {
        #region Свойства
        private rep6043.frmExtended frmRep6043;
        private rep25991.frmExtended frmRep25991;
        private WordReport.WordRepExternalForm frmRep99011;
        private tbl_Dogovor CurrentDG;
        #endregion

        private void InitializeForm(Form sender, ltp_v2.Controls.Forms.lwGroupContainer container)
        {
            sender.TopLevel = false;
            container.PnlContainer.Controls.Add(sender);
            if (sender.MinimumSize.Height == 0)
                sender.MinimumSize = new Size(0, 500);
            container.Height = (container.PnlContainer.Height = sender.MinimumSize.Height) + 20;
            sender.Show();
            sender.Dock = DockStyle.Fill;

            sender.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        public frmMain(string dgCod)
        {
            InitializeComponent();

            sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            CurrentDG = sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_CODE == dgCod);
            lblBronNum.Text = CurrentDG.DG_CODE;
            lblPricePayed.Text = CurrentDG.DG_PRICE.ToString() + " / " + CurrentDG.DG_PAYED.ToString();
            lblTourDate.Text = CurrentDG.DG_TURDATE.ToString("dd.MM.yyyy") + " - " + CurrentDG.DG_TURDATE.AddDays(CurrentDG.DG_NDAY - 1).ToString("dd.MM.yyyy");
            lblPPaymentDate.Text = CurrentDG.DG_PPAYMENTDATE.HasValue ? CurrentDG.DG_PPAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";
            lblPaymentDate.Text = CurrentDG.DG_PAYMENTDATE.HasValue ? CurrentDG.DG_PAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";

            lblAnyErrors.Text = "";

            if (CurrentDG.DG_PPAYMENTDATE.HasValue && CurrentDG.DG_TURDATE.Date < CurrentDG.DG_PPAYMENTDATE.Value.Date
                || CurrentDG.DG_PAYMENTDATE.HasValue && CurrentDG.DG_TURDATE.Date < CurrentDG.DG_PAYMENTDATE.Value.Date
                || CurrentDG.DG_PPAYMENTDATE.HasValue && CurrentDG.DG_PAYMENTDATE.HasValue && CurrentDG.DG_PAYMENTDATE.Value.Date < CurrentDG.DG_PPAYMENTDATE.Value.Date)
            {
                lblAnyErrors.Text = "Неправильно указаны даты оплаты или предоплаты";
            }
            else if (CurrentDG.tbl_DogovorLists.Any(x => x.DL_CONTROL != 0 || x.DL_WAIT.GetValueOrDefault(0) == 1))
            {
                lblAnyErrors.Text = "Есть неподтвержденная услуга или находится на листе ожидания";
            }
            else if (CurrentDG.DG_SOR_CODE != 7)
            {
                lblAnyErrors.Text = "Статус путевки не ОК";
            }
            
            if (lblAnyErrors.Text.Trim() != "")
            {
                gpVoucher.Visible = false;
                gpInsurances.Visible = false;
                btnSubmit.Enabled = false;
                lblAnyErrors.Visible = true;
            }
            else
            {
                lblAnyErrors.Visible = false;

                frmRep99011 = new WordReport.WordRepExternalForm(dgCod, ltp_v2.Framework.SqlConnection.ConnectionUserName, ltp_v2.Framework.SqlConnection.ConnectionPassword);
                InitializeForm(frmRep99011, gpRep99011);

                frmRep6043 = new rep6043.frmExtended(dgCod, false);
                InitializeForm(frmRep6043, gpInsurances);

                frmRep25991 = new rep25991.frmExtended(dgCod, true);
                InitializeForm(frmRep25991, gpVoucher);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            #region Проверка на ошибки перед сохранением
            if (CurrentDG.tbl_DogovorLists.Any(x => x.DL_CONTROL != 0 || x.DL_WAIT.GetValueOrDefault(0) == 1))
            {
                MessageBox.Show("Есть неподтвержденная услуга или находится на листе ожидания", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CurrentDG.DG_SOR_CODE != 7)
            {
                MessageBox.Show("Статус путевки не ОК", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msgErr = frmRep6043.CheckError();
            if (msgErr != "")
            {
                MessageBox.Show(msgErr, "Отмена: Выписка страховок Ингосстрах", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpInsurances.FullView = true;
                return;
            }

            msgErr = frmRep25991.CheckError();
            if (msgErr != "")
            {
                MessageBox.Show(msgErr, "Отмена: Выписка ваучеров", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpVoucher.FullView = true;
                return;
            }
            #endregion

            #region Сохранение Extended Forms
            if (!frmRep25991.Submit())
            {
                MessageBox.Show("Подтверждение и создание отменено по просьбе пользователя");
                return;
            }

            if (!frmRep6043.Submit())
            {
                MessageBox.Show("Подтверждение и создание отменено по просьбе пользователя");
                return;
            }

            try
            {
                frmRep99011.Submit();
            }
            catch { }
            #endregion

            sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var PaymentValue = this.CurrentDG.DG_PROCENT.GetValueOrDefault(0) == 0 ? this.CurrentDG.DG_RazmerP.GetValueOrDefault(0) : this.CurrentDG.DG_PRICE * this.CurrentDG.DG_RazmerP.Value / 100;

            History newHistory;

            #region Запись в историю о подтверждение тура
            newHistory = new History();
            newHistory.HI_MessEnabled = 1;
            newHistory.HI_TEXT = "Подтверждение тура";
            newHistory.HI_MOD = "OPT";
            newHistory.HI_DGCOD = CurrentDG.DG_CODE;
            newHistory.HI_DGKEY = CurrentDG.DG_Key;
            newHistory.HI_WHO = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
            sqlDC.Histories.InsertOnSubmit(newHistory);
            #endregion

            #region Разрешение выставления маршрутных квитанций
            var rca = sqlDC.Lanta_RouteCertificateAdmins.FirstOrDefault(x => x.RCA_DGKey == CurrentDG.DG_Key);
            if (rca == null)
            {
                rca = new Lanta_RouteCertificateAdmin()
                {
                    RCA_Admin = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_KEY,
                    RCA_AllowPrint = true,
                    RCA_DGCODE = CurrentDG.DG_CODE,
                    RCA_DGKey = CurrentDG.DG_Key,
                    RCA_LastChange = ltp_v2.Framework.SqlConnection.ServerDateTime
                };
                sqlDC.Lanta_RouteCertificateAdmins.InsertOnSubmit(rca);
            }
            else rca.RCA_AllowPrint = true;
            #endregion

            sqlDC.SubmitChanges();

            if (MessageBox.Show("Произвести корректировку дат оплат?", "Предупрежедение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                sqlDC.LANTA2011_PAYMENTS_DATES_UPDATE(CurrentDG.DG_CODE);
                sqlDC.SubmitChanges();
            }

            #region Запись в историю сообщения для агентства
            newHistory = new History();
            newHistory.HI_MessEnabled = 1;
            tbl_Dogovor _currentDG = sqlDC.tbl_Dogovors.First(x => x.DG_CODE == CurrentDG.DG_CODE);
            String PPaymentDate = _currentDG.DG_PPAYMENTDATE.HasValue ? _currentDG.DG_PPAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";
            String PaymentDate = _currentDG.DG_PAYMENTDATE.HasValue ? _currentDG.DG_PAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";

            string PaymentAdds = "";
            if (_currentDG.DG_PAYED < PaymentValue && PPaymentDate != "")
                PaymentAdds = "Напоминаем, что срок внесения предоплаты до " + PPaymentDate;
            else if (_currentDG.DG_PAYED < _currentDG.DG_PRICE - 2 && PaymentDate != "")
                PaymentAdds = "Напоминаем, что срок полной оплаты до " + PaymentDate;

            newHistory.HI_TEXT = "Уважаемые коллеги, тур подтвержден. " + PaymentAdds;
            newHistory.HI_MOD = "MTC";
            newHistory.HI_DGCOD = _currentDG.DG_CODE;
            newHistory.HI_DGKEY = _currentDG.DG_Key;
            newHistory.HI_WHO = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
            sqlDC.Histories.InsertOnSubmit(newHistory);
            #endregion

            sqlDC.SubmitChanges();

            MessageBox.Show("Бронь подтверждена");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}