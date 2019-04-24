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
    public partial class frmMainPriemVidacha : Form
    {
        #region Свойства
        private rep6043.frmExtended frmRep6043;
        private rep25991.frmExtended frmRep25991;
        private String DGCode;
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

        public frmMainPriemVidacha(string dgCode)
        {
            this.DGCode = dgCode;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var tmpTblDogovor = sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_CODE == DGCode);
            lblBronNum.Text = tmpTblDogovor.DG_CODE;
            lblPricePayed.Text = tmpTblDogovor.DG_PRICE.ToString() + " / " + tmpTblDogovor.DG_PAYED.ToString();
            lblTourDate.Text = tmpTblDogovor.DG_TURDATE.ToString("dd.MM.yyyy") + " - " + tmpTblDogovor.DG_TURDATE.AddDays(tmpTblDogovor.DG_NDAY - 1).ToString("dd.MM.yyyy");
            lblPPaymentDate.Text = tmpTblDogovor.DG_PPAYMENTDATE.HasValue ? tmpTblDogovor.DG_PPAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";
            lblPaymentDate.Text = tmpTblDogovor.DG_PAYMENTDATE.HasValue ? tmpTblDogovor.DG_PAYMENTDATE.Value.ToString("dd.MM.yyyy") : "";

            lblAnyErrors.Text = "";

            if (tmpTblDogovor.DG_PPAYMENTDATE.HasValue && tmpTblDogovor.DG_TURDATE.Date < tmpTblDogovor.DG_PPAYMENTDATE.Value.Date
                || tmpTblDogovor.DG_PAYMENTDATE.HasValue && tmpTblDogovor.DG_TURDATE.Date < tmpTblDogovor.DG_PAYMENTDATE.Value.Date
                || tmpTblDogovor.DG_PPAYMENTDATE.HasValue && tmpTblDogovor.DG_PAYMENTDATE.HasValue && tmpTblDogovor.DG_PAYMENTDATE.Value.Date < tmpTblDogovor.DG_PPAYMENTDATE.Value.Date)
            {
                lblAnyErrors.Text = "Неправильно указаны даты оплаты или предоплаты";
            }
            else if (tmpTblDogovor.tbl_DogovorLists.Any(x => x.DL_CONTROL != 0 || x.DL_WAIT.GetValueOrDefault(0) == 1))
            {
                lblAnyErrors.Text = "Есть неподтвержденная услуга или находится на листе ожидания";
            }
            else if (tmpTblDogovor.DG_SOR_CODE != 7)
            {
                lblAnyErrors.Text = "Статус путевки не ОК";
            }

            frmRep6043 = new rep6043.frmExtended(DGCode, true);
            InitializeForm(frmRep6043, gpInsurances);

            frmRep25991 = new rep25991.frmExtended(DGCode, false);
            InitializeForm(frmRep25991, gpVoucher);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
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

            #region Сохранение Extended Forms
            frmRep25991.ReChangeData();

            if (!frmRep6043.Submit())
            {
                MessageBox.Show("Подтверждение и создание отменено по просьбе пользователя");
                return;
            }
            #endregion

            frmRep6043.Print();

            MessageBox.Show("Изменения подтверждены");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
