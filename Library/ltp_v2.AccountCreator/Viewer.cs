using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

using ltp_v2.AccountCreator.ObjectModel;

namespace ltp_v2.AccountCreator
{
    public partial class Viewer : Form
    {
        #region Свойства
        private AccountDataContext AccountDC;
        private LTA_Account Account;
        #endregion

        #region События
        public event EventHandler BtnSaveClick;
        #endregion

        #region Инициализация
        public Viewer(AccountDataContext accountDC, LTA_Account account)
        {
            this.AccountDC = accountDC;
            this.Account = account;
            this.Account.ReCalculateTotalPrice();
            
            InitializeComponent();
            ReloadReportViewer();

            if (account.AC_TotalPrice == 0)
                tsBtnSave.Enabled = false;       
            
        }

        public Viewer(AccountDataContext accountDC, LTA_Account account, string EMail, string Subject, string BodyMessage)
            : this(accountDC, account)
        {
            this.reportViewer.MailAddress = EMail;
            this.reportViewer.MailSubject = Subject;
            this.reportViewer.MailMessage = BodyMessage;
        }
        #endregion

        #region Методы
        private void ReloadReportViewer()
        {
            tsBtnSave.Enabled = !(reportViewer.ShowToolBar = !(tsBtnSave.Enabled = Account.AC_ID == 0));
            this.reportViewer.RefreshReport();

            bsAccount.DataSource = this.Account;
            ReportDataSource rdsAccount = new ReportDataSource();
            rdsAccount.Name = "Account";
            rdsAccount.Value = bsAccount;

            BindingSource bsBuyer = new BindingSource();
            bsBuyer.DataSource = this.Account.Buyer;
            ReportDataSource rdsBuyer = new ReportDataSource();
            rdsBuyer.Name = "Buyer";
            rdsBuyer.Value = bsBuyer;

            BindingSource bsSupplier = new BindingSource();
            bsSupplier.DataSource = this.Account.Supplier;
            ReportDataSource rdsSupplier = new ReportDataSource();
            rdsSupplier.Name = "Supplier";
            rdsSupplier.Value = bsSupplier;
            var dictPrtAccounts = this.Account.Supplier.dict_PrtAccounts.Where(x => x.PA_Key == this.Account.Supplier.dict_PrtAccounts.Max(x2 => x2.PA_Key));
            if (dictPrtAccounts.Count() == 0)
            {
                MessageBox.Show("Невозможно найти банковские данные");
                return;
            }

            BindingSource bsPrtAccount = new BindingSource();
            bsPrtAccount.DataSource = dictPrtAccounts.First();
            ReportDataSource rdsSupplierAccount = new ReportDataSource();
            rdsSupplierAccount.Name = "SupplierAccount";
            rdsSupplierAccount.Value = bsPrtAccount;

            BindingSource bsSupplierBank = new BindingSource();
            bsSupplierBank.DataSource = dictPrtAccounts.First().dict_PrtBank;
            ReportDataSource rdsSupplierBank = new ReportDataSource();
            rdsSupplierBank.Name = "SupplierBank";
            rdsSupplierBank.Value = bsSupplierBank;

            BindingSource bsAccountServices = new BindingSource();
            bsAccountServices.DataSource = this.Account.LTA_AccountServices;
            ReportDataSource rdsAccountServices = new ReportDataSource();
            rdsAccountServices.Name = "AccountServices";
            rdsAccountServices.Value = bsAccountServices;

            this.reportViewer.Reset();
            this.reportViewer.LocalReport.DataSources.Add(rdsAccount);
            
            this.reportViewer.LocalReport.DataSources.Add(rdsAccountServices);
            this.reportViewer.LocalReport.DataSources.Add(rdsBuyer);
            this.reportViewer.LocalReport.DataSources.Add(rdsSupplier);
            this.reportViewer.LocalReport.DataSources.Add(rdsSupplierAccount);
            this.reportViewer.LocalReport.DataSources.Add(rdsSupplierBank);

            int ATID = this.Account.LTA_AccountType.AT_ID;
            string PathFile = ltp_v2.Framework.MasterValue.PathToShablon + "\\AccountT" + ATID.ToString() + ".rdlc";
            if (!new System.IO.FileInfo(PathFile).Exists)
                PathFile = ltp_v2.Framework.MasterValue.PathToShablon + "\\AccountT1.rdlc";

            this.reportViewer.LocalReport.ReportPath = PathFile;
            this.reportViewer.RefreshReport();
            this.reportViewer.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer.ZoomMode = ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();
        }
        #endregion

        #region События
        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            if (Account.AC_ID == 0)
            {
                AccountDC.LTA_Accounts.InsertOnSubmit(Account);
                AccountDC.SubmitChanges();
                int ACID = Account.AC_ID;
                this.Hide();

                if (BtnSaveClick != null)
                    BtnSaveClick(this, null);

                AccountCreator AC = new AccountCreator();
                if (this.reportViewer.MailAddress != "")
                    AC.ViewAccount(ACID, this.reportViewer.MailAddress, this.reportViewer.MailSubject, this.reportViewer.MailMessage);
                else
                    AC.ViewAccount(ACID);
                
                this.Close();
            }
        }
        #endregion

        private void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            tsBtnSave.Enabled = !(reportViewer.ShowToolBar = !(tsBtnSave.Enabled = Account.AC_ID == 0));
        }

        private void reportViewer_ReportError(object sender, ReportErrorEventArgs e)
        {
            //MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            tsBtnSave.Enabled = false;
        }
    }
}
