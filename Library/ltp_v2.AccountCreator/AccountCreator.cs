using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ltp_v2.Framework;
using ltp_v2.AccountCreator.ObjectModel;

namespace ltp_v2.AccountCreator
{
    public class AccountCreator
    {
        #region События
        public event EventHandler OnCreate;
        #endregion

        #region Свойства
        private ObjectModel.AccountDataContext AccountDC;
        private ObjectModel.LTA_Account useAccount;
        /// <summary>
        /// Текущий счет
        /// </summary>
        public ObjectModel.LTA_Account UseAccount
        {
            get
            {
                return useAccount;
            }
            set
            {
                useAccount = value;
            }
        }
        public object ObjectSave = null;
        #endregion

        #region Методы
        /// <summary>
        /// Получение списка счетов
        /// </summary>
        /// <param name="prKey">Ключ партнера</param>
        /// <returns>Список счетов по партнеру</returns>
        public IQueryable<LTA_Account> GetAccounts(int prKey)
        {
            return AccountDC.LTA_Accounts.Where(x => x.AC_PRKey == prKey);
        }

        /// <summary>
        /// Получение списка счетов
        /// </summary>
        /// <param name="prKey">Ключ партнера</param>
        /// <param name="TypeKey">Ключ типа счета</param>
        /// <returns>Список счетов для партнера по типу</returns>
        public IQueryable<LTA_Account> GetAccounts(int prKey, int TypeKey)
        {
            return GetAccounts(prKey).Where(x => x.AC_ATID == TypeKey);
        }

        /// <summary>
        /// Получение счета
        /// </summary>
        /// <param name="accountId">ID счета</param>
        /// <returns>Счет</returns>
        public LTA_Account GetAccount(int accountId)
        {
            var q = AccountDC.LTA_Accounts.Where(x => x.AC_ID == accountId);
            if (q.Count() == 0)
                return null;
            return q.First();
        }

        /// <summary>
        /// Получение партнера по его ключу
        /// </summary>
        /// <param name="prKey">Ключ партнера</param>
        /// <returns></returns>
        public dict_Partner GetPartnerByKey(int prKey)
        {
            var q = AccountDC.dict_Partners.Where(x => x.PR_KEY == prKey);
            if (q.Count() == 0)
                return null;
            else
                return q.First();
        }

        /// <summary>
        /// Получение банковских данных по партнеру
        /// </summary>
        /// <param name="prKey">Ключ партера</param>
        /// <returns>Банковские данные по партнеру</returns>
        public dict_PrtAccount GetAccountBankInformation(int prKey)
        {
            var q = AccountDC.dict_PrtAccounts.Where(x => x.PA_PRKey == prKey).OrderByDescending(x => x.PA_Key);
            if (q.Count() == 0)
                return null;
            else
                return q.First();
        }

        /// <summary>
        /// Получение типа счета по его ключу
        /// </summary>
        /// <param name="atKey">Ключ типа</param>
        /// <returns>Тип счета</returns>
        public LTA_AccountType GetAccountType(int atKey)
        {
            var q = AccountDC.LTA_AccountTypes.Where(x => x.AT_ID == atKey);
            if (q.Count() == 0)
                return null;
            else
                return q.First();
        }

        /// <summary>
        /// Получение услуг по умолчанию
        /// </summary>
        /// <param name="at">Тип счета</param>
        /// <returns>Список усгул по умолчанию</returns>
        public List<dict_AccountDefaultService> GetDefaultServices(LTA_AccountType at)
        {
            return AccountDC.dict_AccountDefaultServices.Where(x => x.LTA_AccountType == at).OrderBy(x => x.ADS_Name).ToList();
        }
        
        /// <summary>
        /// Сброс данных 
        /// </summary>
        public void ClearAndSetDafault()
        {
            AccountDC = new ObjectModel.AccountDataContext(SqlConnection.ConnectionData);
            UseAccount = new LTA_Account();

            #region Загрузка значений по умолчанию
            var RateList = AccountDC.dict_Rates.Where(x => x.RA_National == 1);
            if (RateList.Count() == 0)
                throw new Exception("в бд Rate нет национальной валюты");
            
            this.UseAccount.AC_BaseRate = RateList.First().RA_CODE;
            this.UseAccount.AC_Rate = RateList.First().RA_CODE;
            this.UseAccount.AC_Course = 1;
            this.UseAccount.Supplier = GetPartnerByKey(1);
            //this.UseAccount.SupplierBank = GetAccountInformation(1);
            #endregion
        }

        public void ViewAccount()
        {
            Viewer vi = new Viewer(AccountDC, UseAccount);
            vi.BtnSaveClick +=new EventHandler(vi_BtnSaveClick);
            vi.ShowDialog();
        }

        public void ViewAccount(String EMail, String Subject, String BodyMessage)
        {
            Viewer vi = new Viewer(AccountDC, UseAccount, EMail, Subject, BodyMessage);
            vi.BtnSaveClick += new EventHandler(vi_BtnSaveClick);
            vi.ShowDialog();
        }

        public void ViewAccount(int accountID, String EMail, String Subject, String BodyMessage)
        {
            var q = GetAccount(accountID);
            if (q == null)
            {
                throw new Exception("ltp1001: Счет не найден");
            }
            useAccount = q;

            Viewer vi = new Viewer(AccountDC, UseAccount, EMail, Subject, BodyMessage);
            vi.BtnSaveClick += new EventHandler(vi_BtnSaveClick);
            vi.ShowDialog();
        }

        /// <summary>
        /// Показать счет по его ID
        /// </summary>
        public void ViewAccount(int accountID)
        {
            var q = GetAccount(accountID);
            if (q == null)
            {
                throw new Exception("ltp1001: Счет не найден");
            }
            useAccount = q;
            ViewAccount();
        }
        #endregion

        #region Конструктор
        public AccountCreator(string UserId, string UserPass)
        {
            LogonScreen screen = new LogonScreen(UserId, UserPass, "AccountCreator");
            if (screen.Show() == System.Windows.Forms.DialogResult.OK)
            {
                AccountDC = new ObjectModel.AccountDataContext(SqlConnection.ConnectionData);
                this.ClearAndSetDafault();
            }
        }

        public AccountCreator()
        {
            AccountDC = new ObjectModel.AccountDataContext(SqlConnection.ConnectionData);
            this.ClearAndSetDafault();
        }
        #endregion

        #region Обработка событий
        void  vi_BtnSaveClick(object sender, EventArgs e)
        {
            if (OnCreate != null)
                OnCreate(this, null);
        }
        #endregion
    }
}
