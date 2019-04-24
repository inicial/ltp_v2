namespace AgencyManager.ObjectModel
{
    using System;
    using System.Linq;
    using System.Data.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.Linq.Mapping;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;

    using AgencyManager.FormsForAccess;

    using ltp_v2.Framework;
    using ltp_v2.Controls;

    partial class LTP_JournalRouteType
    {
        public override string ToString()
        {
            return this.LRJ_Name;
        }
    }

    partial class dict_PrtGroup
    {
        public override string ToString()
        {
            return this.PG_Name;
        }
    }

    partial class LTS_SpamServer
    {
        partial void OnCreated()
        {
            this._LSS_DTEndPeriod = DateTime.Now;
            this._LSS_ServiceSend = "AgencyManager";

            if (SqlConnection.ConnectionUserInformation.AccessForAgency != null
                && !String.IsNullOrEmpty(SqlConnection.ConnectionUserInformation.AccessForAgency.LTP_AC_BackMail))
            {
                this._LSS_MailFrom = SqlConnection.ConnectionUserInformation.US_NAME + " " +
                    SqlConnection.ConnectionUserInformation.US_FNAME + "<" +
                    SqlConnection.ConnectionUserInformation.AccessForAgency.LTP_AC_BackMail + ">";
            }
            else
            {
                this._LSS_MailFrom = "info@lantatur.ru";
            }
        }
    }

    partial class PartnersListDataContext
    {
        /// <summary>
        /// Полчучение договора основного агентства у которого имеется тип 1027 или он единственный.
        /// </summary>
        public LTP_PrtDog GetDogovorFromRootAgency(string DogovorNum, out string ErrorMessage)
        {
            ErrorMessage = "";
            var findingDRs = this.LTP_PrtDogs.Where(x => x.LTPD_DogNum == DogovorNum);
            if (findingDRs.Count() == 0)
            {
                ErrorMessage = "Запрашиваемый договор №" + DogovorNum + " не найден";
                return null;
            }
            LTP_PrtDog findingDogovor;
            if (findingDRs.Count() == 1)
                findingDogovor = findingDRs.First();
            else
                findingDogovor = findingDRs.FirstOrDefault(x => x.tbl_Partners.PrtTypesToPartners.Any(xPTP => xPTP.PTP_PTId == 1027));
            if (findingDogovor == null)
            {
                ErrorMessage = "По договору №" + DogovorNum + " ненайдено основное агентство";
                return null;
            }
            return findingDogovor;
        }

        /// <summary>
        /// Получение списка партнеров с таким-же ИНН
        /// </summary>
        /// <param name="Partner">Партнер для сравнения</param>
        /// <returns>null - если имеется группа партнеров с одинаковым ИНН, но нет PT_ID = 1027</returns>
        public IQueryable<tbl_Partners> GetTheOfficesOnSuchAnINN(tbl_Partners value, out string errorMsg)
        {
            errorMsg = "";
            var partners = this.tbl_Partners.Where(x =>
                    x.PR_INN == value.PR_INN
                    && x.PR_INN != null
                    && x.PR_INN.Trim().Length > 7);

            if (partners.Count() > 1)
            {
                var checkPresentRoot = partners.Where(x => x.PrtTypesToPartners.Count(xptp => xptp.PTP_PTId == 1027) > 0);
                if (checkPresentRoot.Count() == 0)
                {
                    errorMsg = "Есть группа агентств с одинаковым ИНН,\r\n но нет указания на основной офис по признаку";
                    return null;
                }

                if (checkPresentRoot.Count() > 1)
                {
                    string PRCode = "";
                    foreach (var prtRoot in checkPresentRoot)
                    {
                        PRCode += "," + prtRoot.PR_COD;
                    }
                    errorMsg = "Есть группа агентств с одинаковым ИНН,\r\n и есть указание на основной офис по признаку, у "
                        + checkPresentRoot.Count() + " агентств с кодом" + PRCode + " необходимо, что бы был у одного";
                    return null;
                }
            }
            return partners;
        }

        /// <summary>
        /// Получение основного офиса для партнера
        /// </summary>
        public IQueryable<tbl_Partners> GetTheMainOfficePartner(tbl_Partners value, out string errorMsg)
        {
            var checkPresentRoot = GetTheOfficesOnSuchAnINN(value, out errorMsg)
                .Where(x => x.PrtTypesToPartners.Count(xptp => xptp.PTP_PTId == 1027) > 0);
            return checkPresentRoot;
        }
        /// <summary>
        /// Обновление ключей для создаваемых записей
        /// </summary>
        private void UpdateNewKeys()
        {
            foreach (object tmpItem in this.GetChangeSet().Inserts)
            {
                if (tmpItem.GetType() == typeof(Bank))
                {
                    int? NewKey = 0;
                    this.GetNKey("Banks", ref NewKey);
                    ((Bank)tmpItem).BN_Key = NewKey.Value;
                }
                else if (tmpItem.GetType() == typeof(tbl_Partners))
                {
                    int? NewKey = 0;
                    this.GetNKey("PARTNERS", ref NewKey);
                    ((tbl_Partners)tmpItem).PR_KEY = NewKey.Value;
                }
                else if (tmpItem.GetType() == typeof(PrtAccount))
                {
                    int? NewKey = 0;
                    this.GetNKey("PrtAccounts", ref NewKey);
                    ((PrtAccount)tmpItem).PA_Key = NewKey.Value;
                }
                else if (tmpItem.GetType() == typeof(DUP_USER))
                {
                    int? NewKey = 0;
                    this.GetNKey("DUP_User", ref NewKey);
                    ((DUP_USER)tmpItem).US_KEY = NewKey.Value;
                }
                else if (tmpItem.GetType() == typeof(PrtDogs))
                {
                    int? NewKey = 0;
                    this.GetNKey("PrtDogs", ref NewKey);
                    ((PrtDogs)tmpItem).PD_Key = NewKey.Value;
                    ((PrtDogs)tmpItem).PD_Abonent = this.tbl_Partners.First(x => x.PR_Filial == 1).PR_KEY;
                }
                else if (tmpItem.GetType() == typeof(LTP_PrtDog))
                {
                    if (((LTP_PrtDog)tmpItem).LTPD_DogNumKey == null)
                        GenerateDogovorNumber((LTP_PrtDog)tmpItem);
                }
            }
        }

        /// <summary>
        /// Генерация номера договора
        /// </summary>
        private void GenerateDogovorNumber(LTP_PrtDog DRUsed)
        {
            if (DRUsed.Parent_LTPD_Key == null)
            {
                // Обработка для основного договора
                //  Получение максимального номера этого типа
                int? NewNumberKey = this.LTP_PrtDogs.Where(x =>
                        x.PrtDogTypes.PDT_ID == DRUsed.PrtDogTypes.PDT_ID
                        && x.LTPD_DateStart >= new DateTime(DRUsed.LTPD_DateStart.Year, 1, 1, 0, 0, 0)
                        && x.LTPD_DateStart <= new DateTime(DRUsed.LTPD_DateStart.Year, 12, 31, 23, 59, 59)
                    ).Max(x => x.LTPD_DogNumKey);

                if (NewNumberKey == null)
                    NewNumberKey = 0;

                NewNumberKey += 1;

                // Выравнивание длинны номера
                string NewNumber = NewNumberKey.ToString();
                while (NewNumber.Length < 5)
                    NewNumber = "0" + NewNumber;

                DRUsed.LTPD_DogNum = DRUsed.LTPD_DateStart.Year.ToString().Substring(2, 2) + "-" + NewNumber + "-" + DRUsed.PrtDogTypes.LTP_DogType.LDT_Key;
                DRUsed.LTPD_DogNumKey = NewNumberKey;
            }
            else
            {
                // Обработка для доп. соглашения
                DRUsed.LTPD_DogNum = DRUsed.Dogovor_Root.LTPD_DogNum + "-" + DRUsed.PrtDogTypes.LTP_DogType.LDT_Key;
                DRUsed.LTPD_DogNumKey = DRUsed.Dogovor_Root.LTPD_DogNumKey;
            }
        }

        /// <summary>
        /// Копирование данных договора и занесением его в PIMForCopyDogovor
        /// </summary>
        /// <param name="PIMForCopyDogovor">Партнер для которого копирутеся договор</param>
        /// <param name="FromDogovor">Договор с которого будут взяты данные</param>
        /// <returns>Копия договора, если у PIMForCopyDogovor имеется договор с таким же номерок как FromDogovor то вернет его</returns>
        private LTP_PrtDog CreateCopyOrGetDogovor(tbl_Partners toPartner, LTP_PrtDog fromDogovor)
        {
            // Проверка на существование подобного договора у текущего партнера
            var CopyToDogovor = toPartner.LTP_PrtDogs.Where(x => x.LTPD_DogNum == fromDogovor.LTPD_DogNum);

            LTP_PrtDog result;
            if (CopyToDogovor.Count() == 0)
            {
                // Перенос данных договора в результат
                result = new LTP_PrtDog();
                result.LTPD_DogNum = fromDogovor.LTPD_DogNum;
                result.LTPD_DogNumKey = fromDogovor.LTPD_DogNumKey;
                result.LTPD_DateStart = fromDogovor.LTPD_DateStart;
                result.LTPD_DateEnd = fromDogovor.LTPD_DateEnd;
                result.LTPD_CreateDate = fromDogovor.LTPD_CreateDate;
                result.PrtDogTypes = fromDogovor.PrtDogTypes;

                // Получение или cоздание основного договора если fromDogovor является доп соглашением
                if (fromDogovor.Parent_LTPD_Key != null || fromDogovor.Dogovor_Root != null)
                {
                    result.Dogovor_Root = CreateCopyOrGetDogovor(toPartner, fromDogovor.Dogovor_Root);
                }

                // Занесение копии в БД.
                toPartner.LTP_PrtDogs.Add(result);
            }
            else
            {
                result = CopyToDogovor.First();
            }

            result.LTPD_Comment = fromDogovor.LTPD_Comment;

            // Активация договора если с которого коппируют активирован
            if (fromDogovor.LTPD_PDKey.HasValue
                && (
                    result.LTPD_TempActive != fromDogovor.LTPD_TempActive
                    || result.LTPD_TempActiveCountDayUse != fromDogovor.LTPD_TempActiveCountDayUse
                    || !result.LTPD_PDKey.HasValue
                ))
            {
                result.Activate(fromDogovor.LTPD_TempActiveCountDayUse, fromDogovor.LTPD_Comment);
            }

            // Подписание договора если с которого коппируют подписан
            if (fromDogovor.LTPD_Signing.HasValue && !result.LTPD_Signing.HasValue)
            {
                result.Signing(fromDogovor.LTPD_Comment);
            }

            return result;
        }

        /// <summary>
        /// Создание копиии договора для агенств с подобным ИНН
        /// </summary>
        /// <param name="FromDogovor">Договор с которого будут браться данные</param>
        public void GenerateCopyDogovorsByINN(LTP_PrtDog FromDogovor)
        {
            //Проход по списку партнеров с подобным ИНН
            string empty;
            foreach (tbl_Partners pimByINN in this.GetTheOfficesOnSuchAnINN(FromDogovor.tbl_Partners, out empty))
            {
                CreateCopyOrGetDogovor(pimByINN, FromDogovor);
            }
        }

        public override void SubmitChanges(ConflictMode failureMode)
        {
            PartnersListDataContext newConnection = new PartnersListDataContext(SqlConnection.ConnectionData);

            List<object> InsertList = new List<object>();
            InsertList.AddRange(this.GetChangeSet().Inserts.ToArray());

            List<object> DeleteList = new List<object>();
            DeleteList.AddRange(this.GetChangeSet().Deletes.ToArray());

            List<object> UpdateList = new List<object>();
            UpdateList.AddRange(this.GetChangeSet().Updates.ToArray());

            foreach (var item in InsertList.Where(x => x.GetType() == typeof(LCC_MetroStation)).Select(x=>(LCC_MetroStation)x))
            {
                this.LCC_MetroStations.DeleteOnSubmit(item);
            }
            
            #region Генерация номера пакета
            if (InsertList.Any(x => x.GetType() == typeof(LTP_PrtDogPack)))
            {
                int newPKGNumber = (newConnection.LTP_PrtDogPacks.Count() > 0 ? newConnection.LTP_PrtDogPacks.Select(x => x.LTPP_Number).Max() : 1000);
                foreach (var item in InsertList.Where(x => x.GetType() == typeof(LTP_PrtDogPack)).Select(x => (LTP_PrtDogPack)x))
                {
                    item.LTPP_Number = newPKGNumber + 1;
                }
            }
            #endregion

            #region Пересчет типов у партнера
            List<tbl_Partners> listNeedUpdateTypes = new List<tbl_Partners>(); // Список партнеров нуждающихся в пересчете типов
            // Для событий Deleted, Inserted
            foreach (var item in InsertList.Where(x=>x.GetType() == typeof(PrtTypesToPartner)).Union(DeleteList.Where(x => x.GetType() == typeof(PrtTypesToPartner))).Select(x=>(PrtTypesToPartner)x))
            {
                #region Сбор партнеров нуждающихся в пересчете типов
                tbl_Partners currentParnter = item.tbl_Partners;
                if (currentParnter == null)
                {
                    var lastPTP = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData).PrtTypesToPartners.Where(x => x.PTP_Id == item.PTP_Id).FirstOrDefault();
                    if (lastPTP != null)
                        currentParnter = this.tbl_Partners.Where(x => x.PR_KEY == lastPTP.PTP_PRKey).FirstOrDefault();
                }
                if (currentParnter != null && listNeedUpdateTypes.IndexOf(currentParnter) < 0)
                    listNeedUpdateTypes.Add(currentParnter);
                #endregion
            }
            
            foreach (tbl_Partners tmpItemPartner in listNeedUpdateTypes)
            {
                double pow = 0;
                foreach (var ptId in (tmpItemPartner.PrtTypesToPartners.Where(x => x.PTP_PTId < 20).Select(x => x.PTP_PTId)))
                {
                    pow += Math.Pow(2d, ptId - 1d);
                }
                tmpItemPartner.PR_TYPE = (long)pow;
            }
            listNeedUpdateTypes.Clear();
            listNeedUpdateTypes = null;
            #endregion
            
            UpdateNewKeys();
            base.SubmitChanges(failureMode);

            #region Обработка договоров
            // Добавление договора партнеру с таким-же инн если у него - его не существует
            // Для событий Updated, Inserted
            foreach (var item in UpdateList.Where(x => x.GetType() == typeof(LTP_PrtDog)).Union(InsertList.Where(x => x.GetType() == typeof(LTP_PrtDog))).Select(x => (LTP_PrtDog)x))
            {
                GenerateCopyDogovorsByINN(item); 
            }

            //Удаление копии договора у партнеров с таким же ИНН
            foreach (var item in DeleteList.Where(x=>x.GetType() == typeof(LTP_PrtDog)).Select(x=>(LTP_PrtDog)x))
            {
                foreach (LTP_PrtDog dx in this.LTP_PrtDogs.Where(x => x.LTPD_DogNum == item.LTPD_DogNum))
                {
                    this.LTP_PrtDogs.DeleteOnSubmit(dx);
                }
            }
            #endregion

            #region Обработка LTP_AviaAccount
            foreach (var item in InsertList.Where(x => x.GetType() == typeof(LTP_AviaAccount)).Select(x=>(LTP_AviaAccount)x))
            {
                #region Запуск бота заполнения регистрации на сайте Lanta-Avia
                using (bot bot = new bot(
                    item.tbl_Partners.PR_FULLNAME
                    , item.tbl_Partners.PR_EMAIL
                    , item.tbl_Partners.PR_INN
                    , item.LTPA_User))
                {
                    if (bot.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        this.LTP_AviaAccounts.DeleteOnSubmit(item);
                        System.Windows.Forms.MessageBox.Show("Неудалось создать логин: " + item.LTPA_User);
                    }
                }
                #endregion
            }
            #endregion

            UpdateNewKeys();
            base.SubmitChanges(failureMode);

            #region Сброс объектов в сборщик мусора
            DeleteList.Clear();
            DeleteList = null;

            InsertList.Clear();
            InsertList = null;

            UpdateList.Clear();
            UpdateList = null;

            newConnection.Dispose();
            newConnection = null;
            #endregion
            ltp_v2.Controls.em_Forms.ClearMemory();
        }

        public IQueryable<tbl_Partners> tbl_Partners_By_Permission
        {
            get
            {
                var xdf = this.tbl_Partners.Where(x => x.PR_COD == "47827").ToArray();
                return this.tbl_Partners.SetPermissionFilter();
            }
        }

        public IQueryable<LTP_PrtDog> LTP_PrtDogs_By_Permission
        {
            get
            {
                return this.LTP_PrtDogs.SetPermissionFilter();
            }
        }

        public IQueryable<LTP_TempPartner> LTP_TempPartners_By_Permission
        {
            get
            {
                return this.LTP_TempPartners.SetPerimssionFilter();
            }
        }
    }

    partial class LTP_PrtDogPack
    {
        partial void OnCreated()
        {
            this.LTPP_DateCreate = ltp_v2.Framework.SqlConnection.ServerDateTime;
            this.LTPP_Who = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
        }
    }

    partial class PrtDogTypes
    {
        public enum enAgencyType
        {
            ИП = 2,
            Юр_Лицо = 1,
            Все = 0
        }

        public override string ToString()
        {
            return this.PDT_Name;
        }

        public string DisplayText
        {
            get { return this.ToString(); }
        }
    }

    partial class PrtType
    {
        public override string ToString()
        {
            return this.PT_Name;
        }
    }

    partial class tbl_Country
    {
        public override string ToString()
        {
            return this.CN_NAME;
        }
    }

    partial class PrtDogTypesSource
    {
        public override string ToString()
        {
            return
                "Действителен от " +
                this.LPDS_InsertDate.ToString("dd.MM.yyyy");
        }
    }

    partial class LTP_DogType
    {
        public override string ToString()
        {
            return this.PrtDogTypes.PDT_Name;
        }
    }

    partial class PrtDogs
    {
        partial void OnCreated()
        {
            this.PD_Creator = SqlConnection.ConnectionUserInformation.US_KEY;
            this.PD_Abonent = 1;
            this.PD_WarnFinish = 0;
            this.PD_ISDEFAULT = 0;
            this.PD_Token = 0;
        }
    }

    partial class LTP_Journal
    {
        partial void OnCreated()
        {
            this.LDJ_MsgDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
            this.LDJ_Who = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
        }
    }

    partial class LTP_PrtDog
    {
        public string GetDogovorInformationInHTML()
        {
            var result = @"
<style>
    td.Header
    {
        font-weight:700;
        font-size:11pt;
        background-color:#DDD;
    }
    td.Value
    {
        font-size:11pt;
        font-color:#005;
    }
</style>

<table>";
            result += "<tr><td class='Header'>Партнер:</td><td class='Value'>"
                + this.tbl_Partners.PR_NAME + " (" +this.tbl_Partners.PR_CITY + ") " + this.tbl_Partners.PR_COD 
                + "</td></tr>";

            result += "<tr><td class='Header'><b>активные типы:</b></td><td class='Value'>";
            foreach (var prtType in this.tbl_Partners.PrtTypesToPartners)
            {
                result += prtType.PrtType.PT_Name + ", ";
            }
            result += "</td></tr>";


            result += "<tr><td class='Header'><b>Договор №</b></td><td class='Value'>" + this.LTPD_DogNum + "</td></tr>";
            result += "<tr><td class='Header'><b>Создан</b>:</td><td class='Value'>" + this.LTPD_CreateDate.ToString("dd.MM.yyyy") + "</td></tr>";
            result += "<tr><td class='Header'><b>Действителен с</b>:</td><td class='Value'>"
                    + this.LTPD_DateStart.ToString("dd.MM.yyyy") + "<b> по</b>: " + this.LTPD_DateEnd.ToString("dd.MM.yyyy") + "</td></tr>";
            result += "<tr><td class='Header'><b>Статус</b>: <font color='red'></td><td class='Value'>" + this.IsActiveState.ToNormalStr() + "</font></td></tr>";



            result += "<tr><td class='Header'><b>Подписание:</b></td><td class='Value'>" 
                + (this.LTPD_Signing.HasValue 
                    ? "от: " + this.LTPD_Signing.Value.ToString("dd.MM.yyyy") 
                    : "<font color='red'>Не подписан</font>") 
                + "</td></tr>";

            result += "<tr><td class='Header'><b>Активация</b>:</td><td class='Value'>"
                + (this.IsActiveState == DogovorActiveState.NotActive
                    ? "<font color='red'>Не активирован</font>"
                    : "от: " + this.LTPD_ActiveDate.Value.ToString("dd.MM.yyyy")
                        + (this.IsActiveState == DogovorActiveState.TmpActive
                            ? "<br><b>Действителен до</b>: "
                                + this.LTPD_DateStart.AddDays(this.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy")
                                + this.LTPD_TempActiveCountDayUse.ToString() + " дней"
                            : ""))
                + "</td></tr>";

            if (this.Parent_LTPD_Key != null)
            {
                result += "<tr><td class='Header'><b>Имеется основной договор №:</td><td class='Value'>"
                    + this.Dogovor_Root.LTPD_DogNum
                    + " <font color='red'>" + this.Dogovor_Root.IsActiveState.ToNormalStr() + "</font>"
                    + "</td></tr>";
            }
            else if (this.Dogovors_Dop.Count() != 0)
            {
                result += "<tr><td class='Header'><b>Имеются доп соглашения</b></td><td class='Value'>";
                foreach (LTP_PrtDog ddDCIItem in this.Dogovors_Dop)
                {
                    result += "  <br><b>№</b>: " 
                        + ddDCIItem.LTPD_DogNum
                        + " <font color='red'>" 
                        + ddDCIItem.IsActiveState.ToNormalStr() 
                        + "</font>";
                }
                result += "</td></tr>";
            }
            result += "</table>";
            return result;
        }

        public override string ToString()
        {
            return this.LTPD_DogNum + " " + this.IsActiveState.ToString();
        }

        partial void OnCreated()
        {
            this.LTPD_PDKey = null;
            this.LTPD_CreateDate = DateTime.Now;
            this.LTPD_Comment = "";
            this.LTPD_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }

        public bool IsActive
        {
            get { return (this.LTPD_PDKey != null); }
        }

        public DogovorActiveState IsActiveState
        {
            get
            {
                return (!IsActive ? DogovorActiveState.NotActive
                    : this.LTPD_TempActive ? DogovorActiveState.TmpActive
                    : DogovorActiveState.Active);
            }
        }

        public string NumberWithInfo
        {
            get
            {
                if (string.IsNullOrEmpty(this.LTPD_DogNum))
                    return "НОВЫЙ НЕ СОХРАНЕН";

                string AddString = "";
                if (this.Dogovors_Dop != null)
                {
                    foreach (string DogovorTypeKey in this.Dogovors_Dop.Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key))
                    {
                        AddString += DogovorTypeKey;
                    }
                }
                return this.LTPD_DogNum.Trim()
                    + (IsActiveState == DogovorActiveState.TmpActive ? " КОПИЯ" : "")
                    + (AddString != "" ? " имеет д.с.(" + AddString + ")" : "");
            }
        }

        public string DogovorTypeName
        {
            get
            {
                return (this.PrtDogTypes != null
                    ? this.PrtDogTypes.PDT_Name
                    : "");
            }
        }

        public byte[] GetActualShablon()
        {
            byte[] result = null;
            var MaxDate = this.PrtDogTypes.LTP_DogType.PrtDogTypesSources.Where(x =>
                x.LPDS_PDTId == this.PrtDogTypes.PDT_ID
                && x.LPDS_InsertDate <= this.LTPD_CreateDate).Max(x => x.LPDS_InsertDate);

            var MaxID = this.PrtDogTypes.LTP_DogType.PrtDogTypesSources.Where(x =>
                x.LPDS_InsertDate == MaxDate).Max(x => x.LPDS_Id);

            result = this.PrtDogTypes.LTP_DogType.PrtDogTypesSources.Where(x => x.LPDS_Id == MaxID).First().LPDS_Source.ToArray();

            return result;
        }

        /// <summary>
        /// Активация этого договора
        /// </summary>
        /// <param name="TempActivateDayCount">Если меньше или = 0 то активировать как основной </param>
        public void Activate(int TempActivateDayCount,  string comment)
        {
            // Если договор активен
            if (this.LTPD_PDKey.HasValue && !this.LTPD_TempActive)
                return;

            // Если договор временно активен и нужное кол-во дней менее чем уже есть
            if (this.LTPD_TempActive && this.LTPD_TempActiveCountDayUse >= TempActivateDayCount && TempActivateDayCount > 0)
                return;

            this.LTPD_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;

            // Выполнить процедуру прроставления признаков если активируемый договор имеет смысл (не просрочен)
            if (this.LTPD_DateEnd.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
            {
                #region Активаци типов у партнера в соответствие со справочником договоров
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType1);
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType2);
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType3);
                #endregion

                #region Активация ON-Line паролей
                if (this.PrtDogTypes.LTP_DogType.LDT_IsRoot)
                {
                    foreach (DUP_USER duItem in this.tbl_Partners.DUP_USERs)
                    {
                        duItem.Active = true;
                    }
                }
                #endregion
            }

            //Если выбранный договор еще не активировался то создаем новый
            if (!this.LTPD_PDKey.HasValue && this.PrtDogs == null)
            {
                this.PrtDogs = new PrtDogs();
                this.PrtDogs.PD_PRKey = this.LTPD_PRKey;
            }

            this.LTPD_ActiveDate = DateTime.Now;

            #region Вносим данные по умолчанию
            PrtDogs prtDog = this.PrtDogs;
            this.PrtDogs.PD_UpdDate = DateTime.Now;
            prtDog.PD_Creator = SqlConnection.ConnectionUserInformation.US_KEY;
            prtDog.PD_DogNumber = this.LTPD_DogNum;
            prtDog.PD_DateBeg = this.LTPD_DateStart;
            prtDog.PD_DateEnd = this.LTPD_DateEnd;
            prtDog.PrtDogTypes = this.PrtDogTypes;

            if (this.LTPD_TempActive = TempActivateDayCount > 0)
            {
                this.LTPD_TempActiveCountDayUse = TempActivateDayCount;
                prtDog.PD_DogNumber += " КОПИЯ";
                if (this.LTPD_DateEnd.Date >= DateTime.Now)
                {
                    using (PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData))
                    {
                        LTS_SpamServer ltsss = new LTS_SpamServer();
                        ltsss.LSS_MailTo = this.tbl_Partners.PR_EMAIL;
                        ltsss.LSS_PRKey = this.tbl_Partners.PR_KEY;
                        ltsss.LSS_Subject = "Автоматическая система оповещения о регистрации Договора";
                        ltsss.LSS_Body = @"%head%<br>
<p>Уважаемые коллеги.</p>
<p><b>Внимание</b> Ваш договор № <b>" + this.LTPD_DogNum + @"</b> был зарегистрирован <b>"
                                              + this.LTPD_ActiveDate.Value.ToString("dd.MM.yyyy") + @"</b>.</p>
<p>Регистрация договора в системе была произведена по копии. В связи с этим Вам необходимо до <b>"
                                              + this.LTPD_ActiveDate.Value.AddDays(this.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy")
                                              + @"</b> предоставить оригинал. В противном случае Вы будете отключены от системы и Ваш логин/пароль будет блокирован.</p>
<p><b>Просим предпринять меры для оформления договора в оригинале.</b></p>
%bottom%";
                        PLDC.LTS_SpamServers.InsertOnSubmit(ltsss);
                    }
                }
            }
            else
            {
                this.LTPD_TempActiveCountDayUse = 0;
            }
            this.LTPD_ActiveDate = DateTime.Now;
            this.LTPD_Comment = comment;
            #endregion
        }

        public void Signing(string Comment)
        {
            this.LTPD_Comment = Comment;

            if (!this.LTPD_Signing.HasValue)
            {
                this.LTPD_Signing = ltp_v2.Framework.SqlConnection.ServerDateTime;
            }
        }
    }

    partial class LTP_TempPartner
    {
        /// <summary>
        /// Список договоров необходимых для регистрации
        /// </summary>
        public string NeedDogovors
        {
            get
            {
                string result = "";
                foreach (string drlItem in this.LTP_PrtDogLinks
                    .Where(x => x.PrtDogTypes != null)
                    .OrderBy(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Distinct())
                {
                    result += (result != "" ? "," : "") + drlItem;
                }
                return result;
            }
        }
    }

    partial class tbl_Partners
    {
        #region Локальные свойства
        private IBindingList _LTP_AviaAccount_IBindingList;
        #endregion

        #region Свойства
        public IBindingList LTP_AviaAccount_IBindingList
        {
            get
            {
                if (_LTP_AviaAccount_IBindingList == null)
                    _LTP_AviaAccount_IBindingList = this.LTP_AviaAccounts.GetNewBindingList();
                return _LTP_AviaAccount_IBindingList;
            }
        }

        public String NameForForms
        {
            get
            {
                if (PR_NAME == "")
                    return "Новый";
                else
                    return this.PR_NAME + " " + PR_CITY + " [" + PR_COD + "]";
            }
        }

        public string BossName { get; private set; }
        public string BossFName { get; private set; }
        public string BossSName { get; private set; }

        /// <summary>
        /// Список договоров активных для регистрации
        /// </summary>
        public string ActiveDogovors
        {
            get
            {
                string result = "";
                foreach (string drlItem in this.LTP_PrtDogs
                    .Where(x => x.LTPD_DateStart.Date <= DateTime.Now.Date && x.LTPD_DateEnd.Date >= DateTime.Now.Date && x.IsActive)
                    .OrderBy(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Distinct())
                {
                    result += (result != "" ? "," : "") + drlItem;
                }
                return result;
            }
        }

        /// <summary>
        /// Список договоров неактивизированных договоров дата завершения которых от сегодня и выше
        /// </summary>
        public string NotActiveDogovors
        {
            get
            {
                string result = "";
                foreach (string drlItem in this.LTP_PrtDogs
                    .Where(x => x.LTPD_DateEnd.Date >= DateTime.Now.Date && !x.IsActive)
                    .OrderBy(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Distinct())
                {
                    result += (result != "" ? "," : "") + drlItem;
                }
                return result;
            }
        }

        public string ActiveTempDogovors
        {
            get
            {
                string result = "";
                foreach (string drlItem in this.LTP_PrtDogs
                    .Where(x => x.LTPD_TempActive)
                    .OrderBy(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key)
                    .Distinct())
                {
                    result += (result != "" ? "," : "") + drlItem;
                }
                return result;
            }
        }
        #endregion

        #region Методы
        private void SplitBossName()
        {
            BossName = "";
            BossFName = "";
            BossSName = "";

            if (string.IsNullOrEmpty(this.PR_BOSSNAME))
                return;

            string UseBossName = this.PR_BOSSNAME;
            UseBossName = Regex.Replace(UseBossName, @"\s{2,}|\.\s*", " ");

            string[] ComponentName = UseBossName.Trim().Split(' ');
            if (ComponentName.Length > 0)
                BossName = ComponentName[0];
            if (ComponentName.Length > 1)
                BossFName = ComponentName[1];
            if (ComponentName.Length > 2)
                for (int i = 2; i < ComponentName.Length; i++)
                    BossSName += ComponentName[2];
        }

        partial void OnCreated()
        {
            this.PR_Deleted = 0;
            this.pr_IsActive = 1;
        }

        partial void OnPR_BOSSNAMEChanged()
        {
            SplitBossName();
        }

        partial void OnLoaded()
        {
            SplitBossName();
        }

        /// <summary>
        /// Установка типа партнеру
        /// </summary>
        public void SetPartnerType(PrtType dictPrtType)
        {
            if (dictPrtType == null || this.PrtTypesToPartners.Any(x => x.PTP_PTId == dictPrtType.PT_Id))
                return;

            PrtTypesToPartner pttp = new PrtTypesToPartner();
            pttp.PrtType = dictPrtType;
            this.PrtTypesToPartners.Add(pttp);
        }
        #endregion

        public override string ToString()
        {
            return this.PR_NAME + " [" + this.PR_COD + "]";
        }
    }

    partial class LCC_Partner
    {
        #region Свойства
        public bool? UsedCallCenter_OnLoad;
        #endregion

        #region Методы
        partial void OnCreated()
        {
            this.LCP_Rait = 0;
            this.LCP_UsedCallCenter = false;
            this.LCP_CRDate = DateTime.Now;
            this.LCP_IsFreeService = false;
            this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
            this.UsedCallCenter_OnLoad = false;
        }

        partial void OnLoaded()
        {
            this.UsedCallCenter_OnLoad = this.LCP_UsedCallCenter;
        }
        #endregion

        #region Методы сменяющие LCP_LastUSKey
        partial void OnLCP_IsFreeServiceChanging(bool value)
        {
            if (this._LCP_IsFreeService != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }

        partial void OnLCP_UsedCallCenterChanging(bool value)
        {
            if (this._LCP_UsedCallCenter != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }
        
        partial void OnLCP_MSIDChanging(int value)
        {
            if (this._LCP_MSID != value)
                this.LCP_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;
        }
        #endregion
    }

    partial class DUP_USER
    {
        private Megatec_EncryptService.EncryptionService enc = new Megatec_EncryptService.EncryptionService();
        
        private string us_PASSWORD_EncryptDecrypt = null;
        public string US_PASSWORD_EncryptDecrypt
        {
            get
            {
                try
                {
                    if (String.IsNullOrEmpty(us_PASSWORD_EncryptDecrypt))
                        us_PASSWORD_EncryptDecrypt = enc.DecryptString(this.US_PASSWORD);
                    return us_PASSWORD_EncryptDecrypt;
                }
                catch
                {
                    return "Ошибка подключения к сервису дешифрации паролей";
                }
            }
            set
            {
                try
                {
                    this.US_PASSWORD = enc.EncryptString(value);
                    us_PASSWORD_EncryptDecrypt = null;
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show(@"Ошибка подключения к сервису дешифрации паролей");
                    return;
                }
            }
        }

        public bool Active
        {
            get
            {
                return this.US_AGENT == "1" && this.US_TURAGENT != null && this.US_TURAGENT.Value == 1 && this.US_REG != null && this.US_REG.Value == 1;
            }
            set
            {
                if (value)
                {
                    this.US_AGENT = "1";
                    this.US_TURAGENT = 1;
                    this.US_REG = 1;
                }
                else
                {
                    this.US_AGENT = "0";
                    this.US_TURAGENT = 0;
                    this.US_REG = 0;
                }
            }
        }
    }

    partial class LTP_PartnerAddsValue
    {
        /// <summary>
        /// Флаг изменения UnicalBossCode
        /// </summary>
        public bool CreateUnicalBossCode { get; private set; }

        partial void OnCreated()
        {
            this.PRL_StartWorkAgency = DateTime.Now;
            CreateUnicalBossCode = false;
        }

        partial void OnLoaded()
        {
            CreateUnicalBossCode = false;
        }

        partial void OnPRL_UnicalBossCodeChanging(string value)
        {
            if (this.PRL_UnicalBossCode != value)
            {
                CreateUnicalBossCode = true;
            }
        }
    }

    partial class LTP_TempUser
    {
        public override string ToString()
        {
            return this.LTU_Name + " " + this.LTU_FName + " " + this.LTU_SName
                + " " + (this.LTU_LBAMPID != null ? "*БОНУС*" : "")
                + " " + (this.LTU_IsBoss ? "[" + this.LTU_JobName + "]" : "");
        }

        public string FullName
        {
            get {
                return this.LTU_Name + " " + this.LTU_FName + " " + this.LTU_SName;
            }
        }
    }

    partial class History
    {
        partial void OnCreated()
        {
            this.HI_DATE = DateTime.Now;
            this.HI_WHO = ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FullName;
            this.HI_MessEnabled = 0;
        }

        public string HI_ModAndText
        {
            get
            {
                string result = this.HI_TEXT;

                if (this.HI_Type.ToUpper() == "PARTNERS")
                {
                    switch (HI_MOD.ToLower())
                    {
                        case "ins":
                            result = "Содание " + this.HI_TEXT;
                            break;
                        case "upd":
                            result = "Изменение " + this.HI_TEXT;
                            break;
                        case "del":
                            result = "Удаление " + this.HI_TEXT;
                            break;
                    }
                }
                return result;
            }
        }
    }

    partial class Lanta_BonusAgencyManagerInPeriod
    {
        partial void OnCreated()
        {
            this.lbamip_Date = new DateTime(3000, 1, 1);
        }
    }
}
