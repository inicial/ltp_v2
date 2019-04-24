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
        /// ���������� �������� ��������� ��������� � �������� ������� ��� 1027 ��� �� ������������.
        /// </summary>
        public LTP_PrtDog GetDogovorFromRootAgency(string DogovorNum, out string ErrorMessage)
        {
            ErrorMessage = "";
            var findingDRs = this.LTP_PrtDogs.Where(x => x.LTPD_DogNum == DogovorNum);
            if (findingDRs.Count() == 0)
            {
                ErrorMessage = "������������� ������� �" + DogovorNum + " �� ������";
                return null;
            }
            LTP_PrtDog findingDogovor;
            if (findingDRs.Count() == 1)
                findingDogovor = findingDRs.First();
            else
                findingDogovor = findingDRs.FirstOrDefault(x => x.tbl_Partners.PrtTypesToPartners.Any(xPTP => xPTP.PTP_PTId == 1027));
            if (findingDogovor == null)
            {
                ErrorMessage = "�� �������� �" + DogovorNum + " ��������� �������� ���������";
                return null;
            }
            return findingDogovor;
        }

        /// <summary>
        /// ��������� ������ ��������� � �����-�� ���
        /// </summary>
        /// <param name="Partner">������� ��� ���������</param>
        /// <returns>null - ���� ������� ������ ��������� � ���������� ���, �� ��� PT_ID = 1027</returns>
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
                    errorMsg = "���� ������ �������� � ���������� ���,\r\n �� ��� �������� �� �������� ���� �� ��������";
                    return null;
                }

                if (checkPresentRoot.Count() > 1)
                {
                    string PRCode = "";
                    foreach (var prtRoot in checkPresentRoot)
                    {
                        PRCode += "," + prtRoot.PR_COD;
                    }
                    errorMsg = "���� ������ �������� � ���������� ���,\r\n � ���� �������� �� �������� ���� �� ��������, � "
                        + checkPresentRoot.Count() + " �������� � �����" + PRCode + " ����������, ��� �� ��� � ������";
                    return null;
                }
            }
            return partners;
        }

        /// <summary>
        /// ��������� ��������� ����� ��� ��������
        /// </summary>
        public IQueryable<tbl_Partners> GetTheMainOfficePartner(tbl_Partners value, out string errorMsg)
        {
            var checkPresentRoot = GetTheOfficesOnSuchAnINN(value, out errorMsg)
                .Where(x => x.PrtTypesToPartners.Count(xptp => xptp.PTP_PTId == 1027) > 0);
            return checkPresentRoot;
        }
        /// <summary>
        /// ���������� ������ ��� ����������� �������
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
        /// ��������� ������ ��������
        /// </summary>
        private void GenerateDogovorNumber(LTP_PrtDog DRUsed)
        {
            if (DRUsed.Parent_LTPD_Key == null)
            {
                // ��������� ��� ��������� ��������
                //  ��������� ������������� ������ ����� ����
                int? NewNumberKey = this.LTP_PrtDogs.Where(x =>
                        x.PrtDogTypes.PDT_ID == DRUsed.PrtDogTypes.PDT_ID
                        && x.LTPD_DateStart >= new DateTime(DRUsed.LTPD_DateStart.Year, 1, 1, 0, 0, 0)
                        && x.LTPD_DateStart <= new DateTime(DRUsed.LTPD_DateStart.Year, 12, 31, 23, 59, 59)
                    ).Max(x => x.LTPD_DogNumKey);

                if (NewNumberKey == null)
                    NewNumberKey = 0;

                NewNumberKey += 1;

                // ������������ ������ ������
                string NewNumber = NewNumberKey.ToString();
                while (NewNumber.Length < 5)
                    NewNumber = "0" + NewNumber;

                DRUsed.LTPD_DogNum = DRUsed.LTPD_DateStart.Year.ToString().Substring(2, 2) + "-" + NewNumber + "-" + DRUsed.PrtDogTypes.LTP_DogType.LDT_Key;
                DRUsed.LTPD_DogNumKey = NewNumberKey;
            }
            else
            {
                // ��������� ��� ���. ����������
                DRUsed.LTPD_DogNum = DRUsed.Dogovor_Root.LTPD_DogNum + "-" + DRUsed.PrtDogTypes.LTP_DogType.LDT_Key;
                DRUsed.LTPD_DogNumKey = DRUsed.Dogovor_Root.LTPD_DogNumKey;
            }
        }

        /// <summary>
        /// ����������� ������ �������� � ���������� ��� � PIMForCopyDogovor
        /// </summary>
        /// <param name="PIMForCopyDogovor">������� ��� �������� ���������� �������</param>
        /// <param name="FromDogovor">������� � �������� ����� ����� ������</param>
        /// <returns>����� ��������, ���� � PIMForCopyDogovor ������� ������� � ����� �� ������� ��� FromDogovor �� ������ ���</returns>
        private LTP_PrtDog CreateCopyOrGetDogovor(tbl_Partners toPartner, LTP_PrtDog fromDogovor)
        {
            // �������� �� ������������� ��������� �������� � �������� ��������
            var CopyToDogovor = toPartner.LTP_PrtDogs.Where(x => x.LTPD_DogNum == fromDogovor.LTPD_DogNum);

            LTP_PrtDog result;
            if (CopyToDogovor.Count() == 0)
            {
                // ������� ������ �������� � ���������
                result = new LTP_PrtDog();
                result.LTPD_DogNum = fromDogovor.LTPD_DogNum;
                result.LTPD_DogNumKey = fromDogovor.LTPD_DogNumKey;
                result.LTPD_DateStart = fromDogovor.LTPD_DateStart;
                result.LTPD_DateEnd = fromDogovor.LTPD_DateEnd;
                result.LTPD_CreateDate = fromDogovor.LTPD_CreateDate;
                result.PrtDogTypes = fromDogovor.PrtDogTypes;

                // ��������� ��� c������� ��������� �������� ���� fromDogovor �������� ��� �����������
                if (fromDogovor.Parent_LTPD_Key != null || fromDogovor.Dogovor_Root != null)
                {
                    result.Dogovor_Root = CreateCopyOrGetDogovor(toPartner, fromDogovor.Dogovor_Root);
                }

                // ��������� ����� � ��.
                toPartner.LTP_PrtDogs.Add(result);
            }
            else
            {
                result = CopyToDogovor.First();
            }

            result.LTPD_Comment = fromDogovor.LTPD_Comment;

            // ��������� �������� ���� � �������� ��������� �����������
            if (fromDogovor.LTPD_PDKey.HasValue
                && (
                    result.LTPD_TempActive != fromDogovor.LTPD_TempActive
                    || result.LTPD_TempActiveCountDayUse != fromDogovor.LTPD_TempActiveCountDayUse
                    || !result.LTPD_PDKey.HasValue
                ))
            {
                result.Activate(fromDogovor.LTPD_TempActiveCountDayUse, fromDogovor.LTPD_Comment);
            }

            // ���������� �������� ���� � �������� ��������� ��������
            if (fromDogovor.LTPD_Signing.HasValue && !result.LTPD_Signing.HasValue)
            {
                result.Signing(fromDogovor.LTPD_Comment);
            }

            return result;
        }

        /// <summary>
        /// �������� ������ �������� ��� ������� � �������� ���
        /// </summary>
        /// <param name="FromDogovor">������� � �������� ����� ������� ������</param>
        public void GenerateCopyDogovorsByINN(LTP_PrtDog FromDogovor)
        {
            //������ �� ������ ��������� � �������� ���
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
            
            #region ��������� ������ ������
            if (InsertList.Any(x => x.GetType() == typeof(LTP_PrtDogPack)))
            {
                int newPKGNumber = (newConnection.LTP_PrtDogPacks.Count() > 0 ? newConnection.LTP_PrtDogPacks.Select(x => x.LTPP_Number).Max() : 1000);
                foreach (var item in InsertList.Where(x => x.GetType() == typeof(LTP_PrtDogPack)).Select(x => (LTP_PrtDogPack)x))
                {
                    item.LTPP_Number = newPKGNumber + 1;
                }
            }
            #endregion

            #region �������� ����� � ��������
            List<tbl_Partners> listNeedUpdateTypes = new List<tbl_Partners>(); // ������ ��������� ����������� � ��������� �����
            // ��� ������� Deleted, Inserted
            foreach (var item in InsertList.Where(x=>x.GetType() == typeof(PrtTypesToPartner)).Union(DeleteList.Where(x => x.GetType() == typeof(PrtTypesToPartner))).Select(x=>(PrtTypesToPartner)x))
            {
                #region ���� ��������� ����������� � ��������� �����
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

            #region ��������� ���������
            // ���������� �������� �������� � �����-�� ��� ���� � ���� - ��� �� ����������
            // ��� ������� Updated, Inserted
            foreach (var item in UpdateList.Where(x => x.GetType() == typeof(LTP_PrtDog)).Union(InsertList.Where(x => x.GetType() == typeof(LTP_PrtDog))).Select(x => (LTP_PrtDog)x))
            {
                GenerateCopyDogovorsByINN(item); 
            }

            //�������� ����� �������� � ��������� � ����� �� ���
            foreach (var item in DeleteList.Where(x=>x.GetType() == typeof(LTP_PrtDog)).Select(x=>(LTP_PrtDog)x))
            {
                foreach (LTP_PrtDog dx in this.LTP_PrtDogs.Where(x => x.LTPD_DogNum == item.LTPD_DogNum))
                {
                    this.LTP_PrtDogs.DeleteOnSubmit(dx);
                }
            }
            #endregion

            #region ��������� LTP_AviaAccount
            foreach (var item in InsertList.Where(x => x.GetType() == typeof(LTP_AviaAccount)).Select(x=>(LTP_AviaAccount)x))
            {
                #region ������ ���� ���������� ����������� �� ����� Lanta-Avia
                using (bot bot = new bot(
                    item.tbl_Partners.PR_FULLNAME
                    , item.tbl_Partners.PR_EMAIL
                    , item.tbl_Partners.PR_INN
                    , item.LTPA_User))
                {
                    if (bot.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        this.LTP_AviaAccounts.DeleteOnSubmit(item);
                        System.Windows.Forms.MessageBox.Show("��������� ������� �����: " + item.LTPA_User);
                    }
                }
                #endregion
            }
            #endregion

            UpdateNewKeys();
            base.SubmitChanges(failureMode);

            #region ����� �������� � ������� ������
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
            �� = 2,
            ��_���� = 1,
            ��� = 0
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
                "������������ �� " +
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
            result += "<tr><td class='Header'>�������:</td><td class='Value'>"
                + this.tbl_Partners.PR_NAME + " (" +this.tbl_Partners.PR_CITY + ") " + this.tbl_Partners.PR_COD 
                + "</td></tr>";

            result += "<tr><td class='Header'><b>�������� ����:</b></td><td class='Value'>";
            foreach (var prtType in this.tbl_Partners.PrtTypesToPartners)
            {
                result += prtType.PrtType.PT_Name + ", ";
            }
            result += "</td></tr>";


            result += "<tr><td class='Header'><b>������� �</b></td><td class='Value'>" + this.LTPD_DogNum + "</td></tr>";
            result += "<tr><td class='Header'><b>������</b>:</td><td class='Value'>" + this.LTPD_CreateDate.ToString("dd.MM.yyyy") + "</td></tr>";
            result += "<tr><td class='Header'><b>������������ �</b>:</td><td class='Value'>"
                    + this.LTPD_DateStart.ToString("dd.MM.yyyy") + "<b> ��</b>: " + this.LTPD_DateEnd.ToString("dd.MM.yyyy") + "</td></tr>";
            result += "<tr><td class='Header'><b>������</b>: <font color='red'></td><td class='Value'>" + this.IsActiveState.ToNormalStr() + "</font></td></tr>";



            result += "<tr><td class='Header'><b>����������:</b></td><td class='Value'>" 
                + (this.LTPD_Signing.HasValue 
                    ? "��: " + this.LTPD_Signing.Value.ToString("dd.MM.yyyy") 
                    : "<font color='red'>�� ��������</font>") 
                + "</td></tr>";

            result += "<tr><td class='Header'><b>���������</b>:</td><td class='Value'>"
                + (this.IsActiveState == DogovorActiveState.NotActive
                    ? "<font color='red'>�� �����������</font>"
                    : "��: " + this.LTPD_ActiveDate.Value.ToString("dd.MM.yyyy")
                        + (this.IsActiveState == DogovorActiveState.TmpActive
                            ? "<br><b>������������ ��</b>: "
                                + this.LTPD_DateStart.AddDays(this.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy")
                                + this.LTPD_TempActiveCountDayUse.ToString() + " ����"
                            : ""))
                + "</td></tr>";

            if (this.Parent_LTPD_Key != null)
            {
                result += "<tr><td class='Header'><b>������� �������� ������� �:</td><td class='Value'>"
                    + this.Dogovor_Root.LTPD_DogNum
                    + " <font color='red'>" + this.Dogovor_Root.IsActiveState.ToNormalStr() + "</font>"
                    + "</td></tr>";
            }
            else if (this.Dogovors_Dop.Count() != 0)
            {
                result += "<tr><td class='Header'><b>������� ��� ����������</b></td><td class='Value'>";
                foreach (LTP_PrtDog ddDCIItem in this.Dogovors_Dop)
                {
                    result += "  <br><b>�</b>: " 
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
                    return "����� �� ��������";

                string AddString = "";
                if (this.Dogovors_Dop != null)
                {
                    foreach (string DogovorTypeKey in this.Dogovors_Dop.Select(x => x.PrtDogTypes.LTP_DogType.LDT_Key))
                    {
                        AddString += DogovorTypeKey;
                    }
                }
                return this.LTPD_DogNum.Trim()
                    + (IsActiveState == DogovorActiveState.TmpActive ? " �����" : "")
                    + (AddString != "" ? " ����� �.�.(" + AddString + ")" : "");
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
        /// ��������� ����� ��������
        /// </summary>
        /// <param name="TempActivateDayCount">���� ������ ��� = 0 �� ������������ ��� �������� </param>
        public void Activate(int TempActivateDayCount,  string comment)
        {
            // ���� ������� �������
            if (this.LTPD_PDKey.HasValue && !this.LTPD_TempActive)
                return;

            // ���� ������� �������� ������� � ������ ���-�� ���� ����� ��� ��� ����
            if (this.LTPD_TempActive && this.LTPD_TempActiveCountDayUse >= TempActivateDayCount && TempActivateDayCount > 0)
                return;

            this.LTPD_LastUSKey = SqlConnection.ConnectionUserInformation.US_KEY;

            // ��������� ��������� ������������� ��������� ���� ������������ ������� ����� ����� (�� ���������)
            if (this.LTPD_DateEnd.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
            {
                #region �������� ����� � �������� � ������������ �� ������������ ���������
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType1);
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType2);
                this.tbl_Partners.SetPartnerType(this.PrtDogTypes.LTP_DogType.PrtType3);
                #endregion

                #region ��������� ON-Line �������
                if (this.PrtDogTypes.LTP_DogType.LDT_IsRoot)
                {
                    foreach (DUP_USER duItem in this.tbl_Partners.DUP_USERs)
                    {
                        duItem.Active = true;
                    }
                }
                #endregion
            }

            //���� ��������� ������� ��� �� ������������� �� ������� �����
            if (!this.LTPD_PDKey.HasValue && this.PrtDogs == null)
            {
                this.PrtDogs = new PrtDogs();
                this.PrtDogs.PD_PRKey = this.LTPD_PRKey;
            }

            this.LTPD_ActiveDate = DateTime.Now;

            #region ������ ������ �� ���������
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
                prtDog.PD_DogNumber += " �����";
                if (this.LTPD_DateEnd.Date >= DateTime.Now)
                {
                    using (PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData))
                    {
                        LTS_SpamServer ltsss = new LTS_SpamServer();
                        ltsss.LSS_MailTo = this.tbl_Partners.PR_EMAIL;
                        ltsss.LSS_PRKey = this.tbl_Partners.PR_KEY;
                        ltsss.LSS_Subject = "�������������� ������� ���������� � ����������� ��������";
                        ltsss.LSS_Body = @"%head%<br>
<p>��������� �������.</p>
<p><b>��������</b> ��� ������� � <b>" + this.LTPD_DogNum + @"</b> ��� ��������������� <b>"
                                              + this.LTPD_ActiveDate.Value.ToString("dd.MM.yyyy") + @"</b>.</p>
<p>����������� �������� � ������� ���� ����������� �� �����. � ����� � ���� ��� ���������� �� <b>"
                                              + this.LTPD_ActiveDate.Value.AddDays(this.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy")
                                              + @"</b> ������������ ��������. � ��������� ������ �� ������ ��������� �� ������� � ��� �����/������ ����� ����������.</p>
<p><b>������ ����������� ���� ��� ���������� �������� � ���������.</b></p>
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
        /// ������ ��������� ����������� ��� �����������
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
        #region ��������� ��������
        private IBindingList _LTP_AviaAccount_IBindingList;
        #endregion

        #region ��������
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
                    return "�����";
                else
                    return this.PR_NAME + " " + PR_CITY + " [" + PR_COD + "]";
            }
        }

        public string BossName { get; private set; }
        public string BossFName { get; private set; }
        public string BossSName { get; private set; }

        /// <summary>
        /// ������ ��������� �������� ��� �����������
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
        /// ������ ��������� ������������������ ��������� ���� ���������� ������� �� ������� � ����
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

        #region ������
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
        /// ��������� ���� ��������
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
        #region ��������
        public bool? UsedCallCenter_OnLoad;
        #endregion

        #region ������
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

        #region ������ ��������� LCP_LastUSKey
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
                    return "������ ����������� � ������� ���������� �������";
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
                    System.Windows.Forms.MessageBox.Show(@"������ ����������� � ������� ���������� �������");
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
        /// ���� ��������� UnicalBossCode
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
                + " " + (this.LTU_LBAMPID != null ? "*�����*" : "")
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
                            result = "������� " + this.HI_TEXT;
                            break;
                        case "upd":
                            result = "��������� " + this.HI_TEXT;
                            break;
                        case "del":
                            result = "�������� " + this.HI_TEXT;
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
