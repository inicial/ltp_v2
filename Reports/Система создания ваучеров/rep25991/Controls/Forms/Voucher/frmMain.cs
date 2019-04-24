using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Controls.Forms;

namespace rep25991.Controls.Forms.Voucher
{
    public partial class frmMain : Form
    {
        enum ErrorTypes : int
        {
            NoVoucher = 2,
            LostService = 4,
            LostTurist = 8,
            NotUseTurist = 16,
            OnServiceIsNotAllTurist = 32,
            IsIndividual = 64,
            PresentDopService = 128,
            FullVoucherPacket = 256,
            AllVoucherIsPrinted = 512,
            NoPayed = 1024,
            StateWait = 2048,
            VoucherHaveCreate = NoVoucher | NoPayed,
            VoucherNotCanCreate = LostService | LostTurist | NotUseTurist | OnServiceIsNotAllTurist | IsIndividual | PresentDopService | FullVoucherPacket | StateWait
        }

        #region Вспомогательные классы
        private class HelperOutFltValue
        {
            public string Name;
            public int ID;

            public HelperOutFltValue(string name, int id)
            {
                this.Name = name;
                this.ID = id;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private class helperMappingTurService
        {
            public int _Index { get; set; }
            public int _SVKey { get; set; }
        }

        private class HelperResultOut
        {
            public int DGKey;
            public ErrorTypes ErrorStatus;
            public int OrderKey { get; set; }
            [DisplayName("№ Брони")]
            public string DGCode { get; set; }
            [DisplayName("Дата заезда")]
            public DateTime TurDate { get; set; }
            [DisplayName("Статус")]
            public string Status { get; set; }
            [DisplayName("Созданно ваучеров")]
            public int CountVoucher { get; set; }
            [DisplayName("Кол-во услуг")]
            public int CountServices { get; set; }
            [DisplayName("Услуг нуждающихся в ваучере")]
            public int CountServicesNeedVoucher { get; set; }

            // Установка статуса согласно услугам тура
            private void SetStatus(tbl_Dogovor value, sqlDataContext sqlDC)
            {
                ErrorStatus = ErrorTypes.NoVoucher;
                var createdVochers = value.LT_V_Vouchers.Where(x => !x.V_AnnulDate.HasValue);
                
                // Список индексированных услуг для тура
                var indexedTS = value.tbl_TurList.GetIndexedTurService().ToArray();
                var indexedSDL = value.GetIndexedStructService().ToArray();
                var indexedServ = value.GetIndexedService(true).ToArray();

                var t = sqlDC.ExecuteQuery<helperMappingTurService>(@"
SELECT VS_Index as _Index, VS_SVKey as _SvKey
FROM	LT_V_MappingTurList
INNER JOIN LT_V_MappingTurService ON VS_VTId = VT_Id
WHERE	VT_TLKey = {0}", new object[] { value.DG_TRKEY }).ToArray();

                var serviceBaseNeedVouchers =
                    (from xITS in indexedTS
                     from xMTL in t
                     where xMTL._Index == xITS.Index
                         && xMTL._SVKey == xITS.SVKey
                     select xITS.Key).ToArray();
               
                // Список услуг тура не нуждающихся в ваучере
                var serviceBaseNotNeedVoucher =
                    indexedTS.Where(x => !serviceBaseNeedVouchers.Contains(x.Key)).Distinct().ToArray();
                
                // Список услуг брони нуждающихся или с созданным ваучером
                var services =
                    from xIS in indexedServ
                    from xISS in indexedSDL
                    where xIS.DL_KEY == xISS.Key
                            && !serviceBaseNotNeedVoucher.Any(x => x.Index == xISS.Index && x.SVKey == xISS.SVKey)
                            || serviceBaseNeedVouchers.Count() == 0
                    select xIS;

                CountVoucher = createdVochers.Count();
                CountServices = indexedServ.Count();
                CountServicesNeedVoucher = services
                    .Where(x =>
                        x.LT_V_Services.Count() == 0
                        || !x.LT_V_Services.Any(xVS => !xVS.LT_V_Voucher.V_AnnulDate.HasValue))
                    .Select(x => x.DL_KEY)
                    .Distinct()
                    .Count();
                
                #region Если тур не подтвержден
                if (value.DG_SOR_CODE != 7)
                    this.ErrorStatus = ErrorTypes.StateWait;
                #endregion

                #region Если на все индексированные услуги созданы ваучеры
                if (
                    services.All(xDL =>
                    xDL.LT_V_Services.Count() > 0
                    && xDL.LT_V_Services.Any(xVS => !xVS.LT_V_Voucher.V_AnnulDate.HasValue)))
                {
                    this.ErrorStatus = ErrorTypes.FullVoucherPacket;
                    if (createdVochers.All(x => x.V_PrintDate.HasValue))
                        ErrorStatus |= ErrorTypes.AllVoucherIsPrinted;
                }
                #endregion

                #region Наличие удаленных | измененных услуг на которые создан ваучер
                if ((
                    from xV in createdVochers
                    from xVS in xV.LT_V_Services.Where(x => x.VS_DLKey > 0 && x.tbl_DogovorList != null && x.VS_Code.HasValue)
                    select xVS)
                    .Any(x =>
                        x.VS_Code != x.tbl_DogovorList.DL_CODE
                        || x.VS_Code1.HasValue && x.VS_Code1.GetValueOrDefault(0) != x.tbl_DogovorList.DL_SUBCODE1.GetValueOrDefault(0)
                        || x.VS_Code2.HasValue && x.VS_Code2.GetValueOrDefault(0) != x.tbl_DogovorList.DL_SUBCODE2.GetValueOrDefault(0)
                        || x.LT_V_Voucher.V_PRKey != x.tbl_DogovorList.DL_PARTNERKEY))
                {
                    this.ErrorStatus |= ErrorTypes.LostService;
                }
                #endregion

                #region Проверка на туриста
                //Проверка на отсутствие туриста
                if (createdVochers.Any(x => x.LT_V_Persons.Any(xVP => xVP.tbl_Turist == null)))
                {
                    this.ErrorStatus |= ErrorTypes.LostTurist;
                }
                
                // Проверка на недостоющихся туристов
                else if ((from xCV in createdVochers
                          from xVS in xCV.LT_V_Services
                          where xVS.tbl_DogovorList != null 
                                && xVS.tbl_DogovorList.DL_NMEN != xVS.tbl_DogovorList.LT_V_Services.Where(x => x.LT_V_Voucher.V_AnnulDate == null).Sum(x => x.LT_V_Voucher.LT_V_Persons.Count())
                          select xCV).Count() > 0)
                {
                    this.ErrorStatus |= ErrorTypes.NotUseTurist;
                }

                #endregion

                #region Проверка на неполное сопоставление услуг и туристов
                if (indexedServ.Any(x => x.DL_NMEN != x.TuristServices.Count()))
                {
                    this.ErrorStatus |= ErrorTypes.OnServiceIsNotAllTurist;
                }
                #endregion

                #region Проверка на оплату
                if (value.DG_PRICE - value.DG_PAYED > 2 && !sqlDC.LTV_AccessDogovors.Any(x => x.VDG_DGCod == value.DG_CODE))
                {
                    this.ErrorStatus |= ErrorTypes.NoPayed;
                }
                #endregion

                #region Отсутствие шаблоннов для тура
                if (value.tbl_TurList.LT_V_MappingTurLists.Count() == 0)
                {
                    this.ErrorStatus |= ErrorTypes.IsIndividual;
                }
                #endregion

                // Индексированные услуги пакета
                
                // услуги не относящиеся к пакету
                var serviceNotInPacket = indexedSDL.Select(x => new { x.Index, x.SVKey })
                    .Except(indexedTS.Select(x => new { x.Index, x.SVKey }));

                #region Есть услуги не относящиеся к пакету
                if (serviceNotInPacket.Count() != 0)
                {
                    #region Проверка на существование ваучера для добавленной услуги
                    var q = from xIDL in indexedSDL
                            from xDL in value.tbl_DogovorLists.Where(x => 
                                x.LT_V_Services.Count() == 0
                                || x.LT_V_Services.All(xVS => xVS.LT_V_Voucher.V_AnnulDate.HasValue))
                            where xIDL.Key == xDL.DL_KEY                                    
                            select xIDL;
                    
                    if (q.Count() > 0)
                    {
                        if (
                            (from xQ in q
                             from xSNIP in serviceNotInPacket
                             where
                                 xQ.Index == xSNIP.Index
                                 && xQ.SVKey == xSNIP.SVKey
                             select xQ).Count() > 0)
                        {
                            this.ErrorStatus |= ErrorTypes.PresentDopService;
                        }
                    }
                    #endregion
                }
                #endregion

                OrderKey = 999;
                if ((this.ErrorStatus & ErrorTypes.LostService) != 0)
                {
                    this.Status = "Есть ваучер на измененную услугу";
                    OrderKey = 0;
                }
                else if ((this.ErrorStatus & ErrorTypes.LostTurist) != 0)
                {
                    this.Status = "Есть ваучер на удаленного туриста";
                    OrderKey = 0;
                }
                else if ((this.ErrorStatus & ErrorTypes.NotUseTurist) != 0)
                {
                    this.Status = "Есть турист на которого не создан ваучер";
                    OrderKey = 0;
                }
                else if ((this.ErrorStatus & ErrorTypes.OnServiceIsNotAllTurist) != 0)
                {
                    this.Status = "К одной из услуг подвязаны не все туристы";
                    OrderKey = 0;
                }
                else if ((this.ErrorStatus & ErrorTypes.StateWait) != 0)
                {
                    this.Status = "Тур не подтвержден";
                    OrderKey = 9999;
                }
                else if ((this.ErrorStatus & ErrorTypes.AllVoucherIsPrinted) != 0)
                {
                    this.Status = "Все ваучеры распечатаны";
                    OrderKey = 1000;
                }
                else if ((this.ErrorStatus & ErrorTypes.IsIndividual) != 0)
                {
                    this.Status = "Ручное создание ваучеров";
                    OrderKey = 1;
                }
                else if ((this.ErrorStatus & ErrorTypes.PresentDopService) != 0)
                {
                    this.Status = "Доп. услуга";
                    OrderKey = 2;
                }
                else if ((this.ErrorStatus & ErrorTypes.NoPayed) != 0)
                {
                    this.Status = "Не хватает оплаты";
                    OrderKey = 3;
                }
                else if ((this.ErrorStatus & ErrorTypes.FullVoucherPacket) != 0)
                {
                    this.Status = "Полный пакет";
                    OrderKey = 999;
                }
            }

            public HelperResultOut(tbl_Dogovor value, sqlDataContext sqlDC)
            {
                this.DGCode = value.DG_CODE;
                this.TurDate = value.DG_TURDATE.Date;
                this.DGKey = value.DG_Key;
                SetStatus(value, sqlDC);
            }
        }
        #endregion

        #region Свойства
        private sqlDataContext SqlDC;
        private System.Data.SqlClient.SqlConnection sqlConnection;
        private System.Data.SqlClient.SqlTransaction sqlTransaction;
        private string StartWithDGCode;
        private bool BlockRefreshList = false;
        #endregion

        #region Методы
        private void RefreshDGV()
        {
            int currentUseCNKey = ((HelperOutFltValue)fltCountry.SelectedItem).ID;

            if (!tsBtnRefresh.Enabled || BlockRefreshList)
            {
                ResultListDGV.DataSource = null;
                return;
            }

            lwWaitScreen ws = new lwWaitScreen();
            ws.Show();
            if (SqlDC != null)
                SqlDC.Dispose();
            if (sqlConnection != null)
                sqlConnection.Dispose();
            if (sqlTransaction != null)
                sqlTransaction.Dispose();
            sqlConnection  = new System.Data.SqlClient.SqlConnection(ltp_v2.Framework.SqlConnection.ConnectionData);
            sqlConnection.Open();
            sqlTransaction = sqlConnection.BeginTransaction(IsolationLevel.ReadUncommitted);
            SqlDC = new sqlDataContext(sqlConnection);
            SqlDC.Transaction = sqlTransaction;

            var AllDogovors =
                (from xDG in SqlDC.tbl_Dogovors.Where(x => x.DG_TURDATE.Date >= new DateTime(1990, 09, 1))
                 from xDL in SqlDC.tbl_DogovorLists.Where(x => x.Service.LT_V_ServiceNotUse == null && (x.DL_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0)
                 where xDG.DG_Key == xDL.DL_DGKEY
                 select xDG).Distinct();

            var q = AllDogovors;

            if (fltBronNumber.Text.RemoveSpace() != "")
            {
                var qCN = SqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_CODE == fltBronNumber.Text);
                if (qCN != null)
                    currentUseCNKey = qCN.DG_CNKEY;
                q = q.Where(x => x.DG_CODE == fltBronNumber.Text);
            }
            else
            {
                q = q.Where(x => x.DG_TURDATE.Date == fltDate.Value.Date)
                    .Where(x => x.DG_CNKEY == currentUseCNKey);

                if (((HelperOutFltValue)fltTourName.SelectedItem).ID > 0)
                {
                    q = q.Where(x => x.tbl_TurList.TL_KEY == ((HelperOutFltValue)fltTourName.SelectedItem).ID);
                }
            }

            var listLostService =
                from xDG in AllDogovors
                    .Where(x => x.DG_CNKEY == currentUseCNKey)
                    .Where(x => x.DG_TURDATE.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
                from xV in xDG.LT_V_Vouchers.Where(x => x.V_AnnulDate == null)
                from xVS in xV.LT_V_Services.Where(x => x.VS_Code.HasValue)
                from xDL in xDG.tbl_DogovorLists
                where xVS.tbl_DogovorList == null
                      || xDL.DL_KEY == xVS.VS_DLKey
                      && (
                        xDL.DL_CODE != xVS.VS_Code
                        || xDL.DL_SUBCODE1.GetValueOrDefault(0) != xVS.VS_Code1.GetValueOrDefault(0)
                        || xDL.DL_SUBCODE2.GetValueOrDefault(0) != xVS.VS_Code2.GetValueOrDefault(0)
                      ) || xDL.DL_KEY == xVS.VS_DLKey
                      && xDL.DL_PARTNERKEY != xV.V_PRKey
                select xDG;

            var listLostPersons =
                from xDG in AllDogovors
                    .Where(x => x.DG_CNKEY == currentUseCNKey)
                    .Where(x => x.DG_TURDATE.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
                from xV in xDG.LT_V_Vouchers.Where(x => x.V_AnnulDate == null)
                from xVP in xV.LT_V_Persons
                from xTU in xDG.tbl_Turists
                where xVP.tbl_Turist == null
                select xDG;

            var listNotUsePersons =
                from xDG in AllDogovors
                    .Where(x => x.DG_CNKEY == currentUseCNKey)
                    .Where(x => x.DG_TURDATE.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
                from xV in xDG.LT_V_Vouchers.Where(x => x.V_AnnulDate == null)
                from xVS in xV.LT_V_Services
                from xDL in xDG.tbl_DogovorLists.Where(x => x.DL_KEY == xVS.VS_DLKey)
                where xDL.DL_NMEN != xV.LT_V_Persons.Count()
                select xDG;

            q = q.Union(listLostService).Union(listLostPersons).Union(listNotUsePersons);

            ResultListDGV.DataSource = q.Select(x => new HelperResultOut(x, SqlDC));
            
            ResultListDGV.Columns["OrderKey"].Visible = false;
            ResultListDGV.Sort(ResultListDGV.Columns["OrderKey"], ListSortDirection.Ascending);

            ws.Close();
        }
        #endregion

        #region Конструктор
        public frmMain(string dgCode)
        {
            StartWithDGCode = dgCode;
            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            BlockRefreshList = true;
            fltBronNumber.Text = StartWithDGCode;
            var currentDogovor = SqlDC.tbl_Dogovors
                .Select(x => new { x.DG_CODE, x.DG_TURDATE, x.DG_CNKEY, x.DG_TRKEY })
                .FirstOrDefault(x => x.DG_CODE == StartWithDGCode);
            if (currentDogovor == null)
                fltDate.Value = ltp_v2.Framework.SqlConnection.ServerDateTime.Date;
            else
            {
                fltDate.Value = currentDogovor.DG_TURDATE.Date;
                fltCountry.SelectedItem = fltCountry.Items.OfType<HelperOutFltValue>().FirstOrDefault(x => x.ID == currentDogovor.DG_CNKEY);
                if (currentDogovor.DG_TRKEY.HasValue)
                    fltTourName.SelectedItem = fltTourName.Items.OfType<HelperOutFltValue>().FirstOrDefault(x => x.ID == currentDogovor.DG_TRKEY);
            }
            BlockRefreshList = false;
            
            //tsBtnCreateAllow.Visible = SqlDC.PresentUserInRole("Voucher_AC_notPaid");
            if (!(tsBtnConfigureShablon.Visible = (ltp_v2.Framework.SqlConnection.ConnectionUserName == "sysadm")))
                tsBtnPrint.Visible = !(tsBtnPrintCons.Visible = SqlDC.PresentUserInRole("visaEditDoc"));
            RefreshDGV();
        }

        DateTime lastFltDate = DateTime.MinValue;
        private void fltDate_ValueChanged(object sender, EventArgs e)
        {
            if (lastFltDate == DateTime.MinValue)
                fltDate_Leave(sender, e);
        }

        private void fltDate_Enter(object sender, EventArgs e)
        {
            lastFltDate = fltDate.Value;
        }

        bool fltCountryDSChange = false;
        private void fltDate_Leave(object sender, EventArgs e)
        {
            if (lastFltDate.Date != fltDate.Value)
            {
                var qRes =
                from xDG in SqlDC.tbl_Dogovors
                //from xDL in xDG.tbl_DogovorLists.Where(x => (x.DL_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0 && xDL.Service.LT_V_ServiceNotUse == null)
                from xCN in SqlDC.COUNTRies.Where(x=>x.CN_KEY == xDG.DG_CNKEY)
                where   xDG.DG_TURDATE.Date == fltDate.Value.Date
                select xCN;

                var lastSelect = (HelperOutFltValue)this.fltCountry.SelectedItem;

                fltCountryDSChange = true;
                this.fltCountry.DataSource = qRes
                    .Distinct()
                    .OrderBy(x => x.CN_NAME)
                    .Select(x => new HelperOutFltValue(x.CN_NAME, x.CN_KEY));
                fltCountryDSChange = false;

                if (lastSelect != null)
                    this.fltCountry.SelectedItem = this.fltCountry.Items.OfType<HelperOutFltValue>().FirstOrDefault(x => x.ID == lastSelect.ID);
                else if (this.fltCountry.Items.Count == 0)
                    this.fltCountry.SelectedIndex = 0;
            }
        }

        private void fltCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltCountryDSChange)
                return;

            fltTourName.Enabled = tsBtnRefresh.Enabled = true;
            if (fltCountry.SelectedIndex < 0 && fltCountry.Items.Count > 0)
            {
                fltCountry.SelectedIndex = 0;
                return;
            }

            if (fltCountry.SelectedIndex < 0)
            {
                fltTourName.Enabled = tsBtnRefresh.Enabled = false;
                fltTourName.DataSource = null;
                return;
            }

            var qRes = (from xTL in SqlDC.tbl_TurLists.Where(x => x.TL_CNKEY == ((HelperOutFltValue)fltCountry.SelectedItem).ID)
                        from xDG in SqlDC.tbl_Dogovors.Where(x => x.DG_TURDATE.Date == fltDate.Value.Date)
                        //from xDL in xDG.tbl_DogovorLists.Where(x => (x.DL_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0 && x.Service.LT_V_ServiceNotUse == null)
                        where xDG.DG_TRKEY == xTL.TL_KEY
                        select xTL
                 ).Distinct()
                .OrderBy(x => x.TL_NAME)
                .Select(x => new HelperOutFltValue(x.TL_NAME, x.TL_KEY))
                .ToList();
            qRes.Insert(0, new HelperOutFltValue("все", -1));
            fltTourName.DataSource = qRes;
        }

        private void fltTourName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltBronNumber.Text == "")
                RefreshDGV();  
        }

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                Label lblLegend = legNoVoucher;
                HelperResultOut itemHRO = (HelperResultOut)dgvr.DataBoundItem;
                if ((itemHRO.ErrorStatus & (ErrorTypes.LostTurist | ErrorTypes.OnServiceIsNotAllTurist | ErrorTypes.NotUseTurist)) != 0)
                    lblLegend = legErrorService;
                else if ((itemHRO.ErrorStatus & ErrorTypes.LostService) != 0)
                    lblLegend = legErrorService;
                else if ((itemHRO.ErrorStatus & ErrorTypes.StateWait) != 0)
                    lblLegend = legStateWait;
                else if ((itemHRO.ErrorStatus & ErrorTypes.NoPayed) != 0)
                    lblLegend = legNotPayed;
                else if ((itemHRO.ErrorStatus & ErrorTypes.AllVoucherIsPrinted) != 0)
                    lblLegend = legPrintedVoucher;
                else if ((itemHRO.ErrorStatus & ErrorTypes.FullVoucherPacket) != 0)
                    lblLegend = legPresentVoucher;
                else if ((itemHRO.ErrorStatus & (ErrorTypes.PresentDopService | ErrorTypes.IsIndividual)) != 0)
                    lblLegend = legPresentIndividual;
                

                dgvr.DefaultCellStyle.Font = lblLegend.Font;
                dgvr.DefaultCellStyle.ForeColor = lblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = lblLegend.BackColor;
            }
        }

        private void ResultListDGV_SelectionChanged(object sender, EventArgs e)
        {
            tsBtnOpen.Enabled = ResultListDGV.SelectedRows.Count == 1;
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDGV();
        }

        private void tsBtnConfigureShablon_Click(object sender, EventArgs e)
        {
            new Controls.Forms.Configuration.frmConfigureShablons().ShowDialog();
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            var selectedRows = ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem);

            sqlDataContext sqlCreation = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            List<LT_V_Voucher> result = null;
            var selDGKeys = selectedRows.Where(x => (x.ErrorStatus & ErrorTypes.VoucherNotCanCreate) == 0).Select(x => x.DGKey).ToArray();
            if (selDGKeys.Count() > 0)
            {
                result = ExtendedMethods.CreateVouchersTemplateForTour.Create(
                    sqlCreation,
                    selDGKeys);
                sqlCreation.Dispose();
            }

            if (result == null)
                MessageBox.Show("Создание ваучеров отменено");
            else
            {
                var SkipCountBron = selectedRows.Select(x => x.DGKey).Count() - result.Select(x => x.V_DGKey).Distinct().Count();
                MessageBox.Show(
                    "Созданно - " + result.Count()
                    + "ваучеров по " + result.Select(x => x.V_DGKey).Distinct().Count() + " броням"
                    + (SkipCountBron > 0 ? "\n пропущено " + SkipCountBron + " броней" : ""));
                RefreshDGV();
            }
        }

        private void tsBtnOpen_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count == 1)
            {
                var q = (HelperResultOut)ResultListDGV.SelectedRows[0].DataBoundItem;
                new frmListServices(q.DGKey).ShowDialog();
            }
            RefreshDGV();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Будут обработанны только те брони у которых созданы ваучеры на все услуги и небыли ранее распечатаны, вы хотите отменить печать?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Создание ваучеров отменено");
                return;
            }

            var selectedRows = ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem);
            var voucherNeedPrint =
                from xSR in selectedRows.Where(x =>
                   (x.ErrorStatus & ErrorTypes.FullVoucherPacket) != 0
                   && (x.ErrorStatus & ErrorTypes.AllVoucherIsPrinted) == 0)
                from xV in SqlDC.LT_V_Vouchers.Where(x=> x.V_DGKey == xSR.DGKey)
                where   !xV.V_AnnulDate.HasValue
                        && !xV.V_PrintDate.HasValue
                select xV;

            if (voucherNeedPrint.Count() == 0)
            {
                MessageBox.Show("Создание ваучеров отменено из-за отсутствия нераспечатанных ваучеров");
            }
            else
            {
                new Report.ReportGenerator(SqlDC, voucherNeedPrint.ToArray(), false, false, false).ShowDialog();
                SqlDC.SubmitChanges();
                RefreshDGV();
            }
        }

        private void tsBtnPrintCons_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Будут обработанны только те брони у которых созданы ваучеры на отель\n вы хотите прервать?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Создание ваучеров отменено");
                return;
            }

            var selectedRows = ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem);

            var voucherNeedPrint =
                from xSR in selectedRows
                from xV in SqlDC.LT_V_Vouchers.Where(x => x.V_DGKey == xSR.DGKey)
                from xVS in SqlDC.LT_V_Services.Where(x => x.VS_VId == xV.V_Id)
                from xDL in SqlDC.tbl_DogovorLists.Where(x => x.DL_DGKEY == xSR.DGKey && (x.DL_SVKEY == 3 || x.DL_SVKEY == 3149))
                where xDL.DL_KEY == xVS.VS_DLKey
                        && !xV.V_AnnulDate.HasValue
                select xV;

            if (voucherNeedPrint.Count() == 0)
            {
                MessageBox.Show("Создание ваучеров отменено из-за отсутствия ваучеров на отель");
            }
            else
            {
                new Report.ReportGenerator(SqlDC, voucherNeedPrint.ToArray(), false, true, true).ShowDialog();
                SqlDC.SubmitChanges();
                RefreshDGV();
            }
        }

        private void tsBtnView_Click(object sender, EventArgs e)
        {
            var selectedRows = ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem);
            var voucherViewer =
                from xSR in selectedRows
                from xV in SqlDC.LT_V_Vouchers.Where(x => x.V_DGKey == xSR.DGKey)
                where !xV.V_AnnulDate.HasValue
                select xV;

            if (voucherViewer.Count() == 0)
            {
                MessageBox.Show("Предпросмотр ваучеров отменен, из-за отсутствия нераспечатанных ваучеров");
            }
            else
            {
                new Report.ReportGenerator(SqlDC, voucherViewer.ToArray(), true, false, false).ShowDialog();
                RefreshDGV();
            }
        }
    }
}
