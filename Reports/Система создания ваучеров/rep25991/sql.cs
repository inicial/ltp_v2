namespace rep25991
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using rep25991.ExtendedMethods.Convertation;

    public delegate void AdvancedPropertyChangeEventHandler(string Table, string PropertyName);

    partial class sqlDataContext
    {
        /// <summary>
        /// Добавление списка перелетов в ваучер, должно быть уже заполенным (LT_V_Persons, tbl_Dogovor)
        /// </summary>
        public string getAviaReis(LT_V_Voucher value)
        {
            if (value.tbl_Dogovor == null)
                return "";

            var q =
                    (from xDL in value.tbl_Dogovor.tbl_DogovorLists.Where(x => x.DL_SVKEY == 1)
                     from xTS in xDL.TuristServices.Where(x => value.LT_V_Persons.Select(xVP => xVP.VT_TUKey).Contains(x.TU_TUKEY))
                     from xAS in this.AirSeasons.Where(x => x.Charter.CH_KEY == xDL.DL_CODE)
                     where
                         xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date >= xAS.AS_DATEFROM.Value.Date
                         && xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).Date <= xAS.AS_DATETO.Value.Date
                         && xAS.AS_WEEK[
                             (xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).DayOfWeek == 0
                                 ? 7
                                 : (int)xDL.tbl_Dogovor.DG_TURDATE.AddDays(xDL.DL_DAY.GetValueOrDefault(1) - 1).DayOfWeek) - 1] != '.'
                     select new
                     {
                         DLDay = xDL.DL_DAY,
                         TimeFrom = xAS.AS_TIMEFROM.Value,
                         AirLineCode = xAS.Charter.CH_AIRLINECODE,
                         Flight = xAS.Charter.CH_FLIGHT
                     }
                        ).Distinct().OrderBy(x => x.DLDay).ThenBy(x => x.TimeFrom.Hour);
            string result = "";
            foreach (var AirItem in q)
            {
                if (result != "")
                    result += "/";
                result += AirItem.AirLineCode + AirItem.Flight + "(" + AirItem.TimeFrom.ToString("HH:mm") + ")";
            }
            return result;
        }

        public bool PresentUserInRole(string Role)
        {
            var q = this.ExecuteQuery<bool>(@"
SELECT CAST(CASE WHEN Role = {0} THEN 1 ELSE 0 END AS bit) AS bollean
FROM LANTA2009_USERROLES ({1})
WHERE Role = {0}", Role, ltp_v2.Framework.SqlConnection.ConnectionUserName).ToArray();
            return q.Count() > 0 && q.First();
        }

        public IQueryable<tbl_TurList> GetTurList(int CountryKey)
        {
            return this.tbl_TurLists
                    .Where(x => x.TL_CNKEY == CountryKey)
                    .Where(x => x.TurDates.Any(xTD => xTD.TD_DATE.Date >= DateTime.Now.Date));
        }

        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            foreach (var item in this.GetChangeSet().Updates)
            {
                if (item.GetType() == typeof(tbl_DogovorList))
                {
                }
            }

            foreach (var item in this.GetChangeSet().Deletes.Where(x => x.GetType() == typeof(LT_GroupToBaseTour)).Select(x=>(LT_GroupToBaseTour)x))
            {
                this.ClearCopyMappingTurList(item.GT_ParentTLKey);
            }
            base.SubmitChanges(failureMode);

            #region Очистка справочника
            foreach (var itemSS in this.LT_V_ServicesSkips)
            {
                if (itemSS.tbl_DogovorList == null)
                    this.LT_V_ServicesSkips.DeleteOnSubmit(itemSS);
            }
            foreach (var itemSNU in this.LT_V_ServiceNotUses)
            {
                if (itemSNU.Service == null)
                    this.LT_V_ServiceNotUses.DeleteOnSubmit(itemSNU);
            }
            #endregion
            base.SubmitChanges(failureMode);
        }

        public void ClearCopyMappingTurList(int TLKey)
        {
            foreach (var delItem in this.LT_V_MappingTurLists.Where(x => x.VT_TLKey == TLKey))
            {
                this.LT_V_MappingTurLists.DeleteOnSubmit(delItem);
                foreach (var delMTS in delItem.LT_V_MappingTurServices)
                {
                    this.LT_V_MappingTurServices.DeleteOnSubmit(delMTS);
                }
            }
        }

        public void CopyMapppingTurList(int fromTLKey, int toTLKey)
        {
            ClearCopyMappingTurList(toTLKey);
            WordReport.TurTemplateLinkStat.Clear(ltp_v2.Framework.SqlConnection.ConnectionData, toTLKey);
            WordReport.TurTemplateLinkStat.Copy(ltp_v2.Framework.SqlConnection.ConnectionData, fromTLKey, toTLKey);

            foreach (var itemMTL in this.LT_V_MappingTurLists.Where(x => x.VT_TLKey == fromTLKey))
            {
                var newMTL = new LT_V_MappingTurList();
                this.LT_V_MappingTurLists.InsertOnSubmit(newMTL);
                newMTL.VT_Name = itemMTL.VT_Name;
                newMTL.VT_TLKey = toTLKey;

                foreach (var itemMTS in itemMTL.LT_V_MappingTurServices)
                {
                    newMTL.LT_V_MappingTurServices.Add(new LT_V_MappingTurService()
                    {
                        VS_Index = itemMTS.VS_Index,
                        VS_SHSId = itemMTS.VS_SHSId,
                        VS_SVKey = itemMTS.VS_SVKey
                    });
                }
            }
        }
    }

    partial class tbl_Country
    {
        public override string ToString()
        {
            return this.CN_NAME;
        }
    }

    partial class COUNTRY
    {
        public override string ToString()
        {
            return this.CN_NAME;
        }
    }

    partial class CityDictionary
    {
        public override string ToString()
        {
            return this.CT_NAME;
        }
    }

    partial class LT_V_MappingPartner
    {
        #region События
        public event AdvancedPropertyChangeEventHandler AdvancedPropertyChange;
        #endregion

        #region Свойства
        private bool PrivatePropChanged = false;
        #endregion

        #region Перехват методов
        partial void OnCreated()
        {
            this.VMP_ContactPerson = "";
            this.VMP_DateFormat = "dd.MM.yyyy";
            this.VMP_ReisOut = false;
            this.VMP_TuristFormat = "<%ФАМИЛИЯ%> <%Имя%>/<%Дата рождения для детей%>/<%возвраст для детей%>/<%№ паспорта%>";
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }

        partial void OnLoaded()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);           
            _PropertyChanged(null, new System.ComponentModel.PropertyChangedEventArgs(typeof(tbl_Partner).Name));
        }
        #endregion

        private void _PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PrivatePropChanged)
                return;

            PrivatePropChanged = true;

            if (e.PropertyName == typeof(tbl_Partner).Name && this.tbl_Partner != null)
            {
                if (this.VMP_Image == null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        System.Drawing.Bitmap bmp = ExtendedMethods.LogoCreater.CreateLogo((byte[])null, this.tbl_Partner.GetName());
                        bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        this.VMP_Image = ms.GetBuffer();
                        bmp.Dispose();
                        bmp = null;
                    }
                }                        
            }

            PrivatePropChanged = false;

            if (AdvancedPropertyChange != null)
                AdvancedPropertyChange(this.GetType().Name, e.PropertyName);
        }
    }

    partial class tbl_Partner
    {
        #region События
        public event AdvancedPropertyChangeEventHandler AdvancedPropertyChange;
        #endregion

        #region Перехват методов
        partial void OnLoaded()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);

            if (this.LT_V_MappingPartner == null)
                this.LT_V_MappingPartner = new LT_V_MappingPartner();

            if (this.LT_V_MappingPartner != null)
                this.LT_V_MappingPartner.AdvancedPropertyChange += new AdvancedPropertyChangeEventHandler(OnAdvancedPropertyChange);
        }
        #endregion

        #region Методы
        private void OnAdvancedPropertyChange(string Table, string PropertyName)
        {
            if (Table == this.GetType().Name && PropertyName == typeof(LT_V_MappingPartner).Name && this.LT_V_MappingPartner != null)
            {
                this.LT_V_MappingPartner.AdvancedPropertyChange += new AdvancedPropertyChangeEventHandler(OnAdvancedPropertyChange);
            }

            if (AdvancedPropertyChange != null)
                AdvancedPropertyChange(Table, PropertyName);
        }

        public override string ToString()
        {
            return this.PR_NAME;
        }

        public string GetName()
        {
            return string.IsNullOrEmpty(this.PR_NAMEENG) ? string.IsNullOrEmpty(this.PR_NAME) ? "" : this.PR_NAME : this.PR_NAMEENG;
        }

        public string GetAddress()
        {
            return (this.CityDictionary == null ? "" : this.CityDictionary.CT_NAMELAT != "" ? this.CityDictionary.CT_NAMELAT.Trim() : this.CityDictionary.CT_NAME.Trim())
                        + " " + (String.IsNullOrEmpty(this.PR_ADRESS) ? "" : this.PR_ADRESS)
                        + (String.IsNullOrEmpty(this.PR_PHONES) ? "" : ", tel:" + this.PR_PHONES)
                        + (String.IsNullOrEmpty(this.PR_FAX) ? "" : ", fax:" + this.PR_FAX);
        }
        #endregion

        #region Обработка событий
        private void _PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnAdvancedPropertyChange(this.GetType().Name, e.PropertyName);
        }
        #endregion
    }

    partial class tbl_DogovorList
    {
        #region События
        public event AdvancedPropertyChangeEventHandler AdvancedPropertyChange;
        #endregion

        #region Перехват методов
        partial void OnLoaded()
        {
            this.tbl_Partner.AdvancedPropertyChange += new AdvancedPropertyChangeEventHandler(OnAdvancedPropertyChange);
        }
        #endregion

        #region Методы
        private void OnAdvancedPropertyChange(string Table, string PropertyName)
        {
            if (AdvancedPropertyChange != null)
                AdvancedPropertyChange(Table, PropertyName);
        }
        #endregion
    }

    partial class LT_V_Service
    {
        #region События
        public event AdvancedPropertyChangeEventHandler AdvancedPropertyChange;
        #endregion

        #region Свойства
        private bool PrivatePropChanged = false;
        public bool Autoformat = true;
        private string _FormatOutText;
        /// <summary>
        /// Принудительный формат вывода независящий от услуги
        /// </summary>
        public string FormatOutText
        {
            get { return _FormatOutText; }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Trim() == "")
                    value = "<%дата начала услуги%> <%Назвние типа услуги%> <%Доп описание%>";
                _FormatOutText = value;
                RegenerationName();
            }
        }
        #endregion

        #region Методы
        private void OnAdvancedPropertyChange(string Table, string PropertyName)
        {
            if (Table == typeof(LT_V_MappingPartner).Name && PropertyName == "VMP_Name")
            {
                RegenerationName();
                this.LT_V_Voucher.OnAdvancedPropertyChange(this.GetType().Name, Table);
            }

            if (AdvancedPropertyChange != null)
                AdvancedPropertyChange(Table, PropertyName);
        }

        public void RegenerationName()
        {
            if (   this.LT_V_Voucher != null 
                && this.LT_V_Voucher.tbl_Partner != null 
                && this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner != null 
                && this.tbl_DogovorList != null)
            {
                PrivatePropChanged = true;

                if (!string.IsNullOrEmpty(FormatOutText) && Autoformat)
                    this.VS_Name = this.tbl_DogovorList.Convert(
                        FormatOutText, 
                        this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat, 
                        this.LT_V_Voucher.V_TourName);
                PrivatePropChanged = false;
            }
        }
        #endregion

        #region Перехват методов
        partial void OnCreated()
        {
            this.VS_PrintLine = -1;
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }

        partial void OnLoaded()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }
        #endregion

        private void _PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PrivatePropChanged)
                return;

            PrivatePropChanged = true;

            if (e.PropertyName == typeof(tbl_DogovorList).Name && this.tbl_DogovorList != null)
            {
                this.tbl_DogovorList.AdvancedPropertyChange += new AdvancedPropertyChangeEventHandler(OnAdvancedPropertyChange);
                
                this.VS_Code = tbl_DogovorList.DL_CODE;
                this.VS_Code1 = tbl_DogovorList.DL_SUBCODE1;
                this.VS_Code2 = tbl_DogovorList.DL_SUBCODE2;
            }

            if (e.PropertyName == typeof(LT_V_Voucher).Name && this.LT_V_Voucher != null)
            {
                if (this.VS_PrintLine == -1)
                    this.VS_PrintLine = this.LT_V_Voucher.LT_V_Services.Count() + 1;
            }

            OnAdvancedPropertyChange(this.GetType().Name, e.PropertyName);

            RegenerationName();
            
            PrivatePropChanged = false;
        }
    }

    partial class LT_V_Person
    {
        #region Свойства
        private bool PrivatePropChanged = false;
        #endregion

        #region Перехват методов
        partial void OnCreated()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }

        partial void OnLoaded()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }
        #endregion

        #region Методы
        public void RegenerationName()
        {
            if (this.LT_V_Voucher != null && this.LT_V_Voucher.tbl_Partner != null && this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner != null && this.tbl_Turist != null)
            {
                PrivatePropChanged = true;

                if (this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner.VMP_TuristFormat.Trim() == "")
                {
                    this.VT_Name = (
                        this.tbl_Turist.TU_NAMELAT.Trim() != "" && this.tbl_Turist.TU_FNAMELAT.Trim() != ""
                            ? this.tbl_Turist.TU_NAMELAT + " " + this.tbl_Turist.TU_FNAMELAT
                            : this.tbl_Turist.TU_NAMERUS + " " + this.tbl_Turist.TU_FNAMERUS);
                }
                else
                {
                    this.VT_Name = Tourist.Convert(
                        new Tourist.TouristDataValue(this.tbl_Turist, this.tbl_Turist.tbl_Dogovor.IsRussianVariant()),
                        this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner.VMP_TuristFormat,
                        this.LT_V_Voucher.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat);
                }

                PrivatePropChanged = false;
            }
        }

        public override string ToString()
        {
            return this.VT_Name.ToString();
        }
        #endregion

        private void _PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PrivatePropChanged)
                return;

            PrivatePropChanged = true;
            RegenerationName();
            PrivatePropChanged = false;
        }
    }

    partial class LT_V_Voucher
    {
        #region События
        public event AdvancedPropertyChangeEventHandler AdvancedPropertyChange;
        #endregion

        #region Свойства
        public bool PrivatePropChanged = false;
        public byte[] PartnerLogoBuffer;
        #endregion

        #region Перехваченные методы
        partial void OnCreated()
        {
            this._V_Number = "";
            this.V_Reis = "";
            this.V_CRDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }

        partial void OnLoaded()
        {
            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_PropertyChanged);
        }
        #endregion

        #region Методы
        private void SetInvisiblePartner()
        {
            if (this.V_CNKey == 460 || this.V_CNKey == 5 || this.V_CNKey == 17)
            {
                V_PartnerName = "Ланта-тур Вояж";
                V_PartnerContact = "Россия, Москва, Крылатские холмы 37, тел: +7(495)786-68-60";
            }
        }

        private void ChangePartner()
        {
            if (this.tbl_Partner != null)
            {
                V_PartnerName = this.tbl_Partner.GetName();
                V_PartnerContact = this.tbl_Partner.GetAddress();
                PartnerLogoBuffer = this.tbl_Partner.LT_V_MappingPartner.VMP_Image.ToArray();
                SetInvisiblePartner();
            }
        }

        public void OnAdvancedPropertyChange(string Table, string PropertyName)
        {
            if (Table == typeof(LT_V_MappingPartner).Name)
            {
                this.V_ContactPerson = this.tbl_Partner.LT_V_MappingPartner.VMP_ContactPerson;
                foreach (var q in this.LT_V_Services)
                {
                    q.RegenerationName();
                }
                foreach (var q in this.LT_V_Persons)
                {
                    q.RegenerationName();
                }
            }

            if (Table == typeof(LT_V_MappingPartner).Name || Table == typeof(tbl_Partner).Name)
            {
                ChangePartner();
            }

            if (AdvancedPropertyChange != null)
                AdvancedPropertyChange(Table, PropertyName);
        }
        #endregion

        private void _PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (PrivatePropChanged)
                return;

            PrivatePropChanged = true;

            if (e.PropertyName == typeof(tbl_Country).Name && this.tbl_Country != null)
            {
                this.V_CountryName = this.tbl_Country.CN_NAMELAT != ""
                        ? this.tbl_Country.CN_NAMELAT
                        : this.tbl_Country.CN_NAME;
                SetInvisiblePartner();
            }

            if (e.PropertyName == typeof(tbl_Dogovor).Name && this.tbl_Dogovor != null && String.IsNullOrEmpty(V_BronNumber))
            {
                V_BronNumber = this.tbl_Dogovor.DG_CODE;
            }

            if (e.PropertyName == typeof(tbl_Partner).Name && this.tbl_Partner != null)
            {
                this.tbl_Partner.AdvancedPropertyChange += new AdvancedPropertyChangeEventHandler(OnAdvancedPropertyChange);
                OnAdvancedPropertyChange(typeof(LT_V_MappingPartner).Name, "");
            }
            else
                OnAdvancedPropertyChange(this.GetType().Name, e.PropertyName);

            PrivatePropChanged = false;
        }
    }

    partial class tbl_Dogovor
    {
        public IEnumerable<tbl_DogovorList> GetIndexedService(bool HideSkipService)
        {
            var result = this.tbl_DogovorLists
                    .Where(x => x.Service.LT_V_ServiceNotUse == null)
                    .Where(x => (x.DL_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0);

            if (HideSkipService)
                result = result.Where(x => x.LT_V_ServicesSkip == null);

            return result.OrderBy(x => x.DL_DAY);
        }

        public IEnumerable<structIndexedService> GetIndexedStructService()
        {
            return this.GetIndexedService(true)
                    .Select(x => new structIndexedService(x));
        }

        public bool IsRussianVariant()
        {
            return this.DG_CNKEY == 460;
        }
    }
    
    partial class tbl_TurList
    {
        public override string ToString()
        {
            return this.TL_NAME;
        }

        public IEnumerable<TurService> GetOnlyNotHideService()
        {
            return this.TurServices
                    .Where(x => x.Service.LT_V_ServiceNotUse == null)
                    .Where(x => (x.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0);
        }

        public IEnumerable<structIndexedService> GetIndexedTurService()
        {
            return this.GetOnlyNotHideService()
                    .OrderBy(x => x.TS_DAY)
                    .Select(x => new structIndexedService(x));
        }
    }

    partial class Service
    {
        public override string ToString()
        {
            return this.SV_KEY.ToString() + " " + this.SV_NAME;
        }
    }

    partial class LT_V_ShablonService
    {
        partial void OnCreated()
        {
            this.SHS_LineOut = 0;
            this.SHS_UseCommentToBron = false;
        }
    }

    partial class LT_V_Shablon
    {
        public override string ToString()
        {
            return this.SH_Name;
        }
    }

    partial class LT_V_ShablonTourNames
    {
        public override string ToString()
        {
            return this.SHTN_Name;
        }
    }
}

