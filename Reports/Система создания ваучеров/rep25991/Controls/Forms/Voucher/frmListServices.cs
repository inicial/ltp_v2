using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rep25991.ExtendedMethods;
using rep25991.Controls.Forms.Configuration;
using ltp_v2.Controls.Forms;

namespace rep25991.Controls.Forms.Voucher
{
    public partial class frmListServices : Form
    {
        public enum ErrorTypes : int
        {
            /// <summary>
            /// На ваучере есть измененная услуга
            /// </summary>
            ErrorLostService = 2,
            /// <summary>
            /// На ваучере есть измененный турист
            /// </summary>
            ErrorLostPerson = 4,
            /// <summary>
            /// На услуге ваучера не полное кол-во туристов
            /// </summary>
            ErrorPersonNotUse = 8,
            /// <summary>
            /// Все услуги невходящие в пакет тура
            /// </summary>
            IndividualService = 16,
            /// <summary>
            /// Шаблонная услуга - отсутствие ваучера
            /// </summary>
            ShablonService = 32,
            /// <summary>
            /// Не нуждается в создание ваучера
            /// </summary>
            NotNeedCreate = 64,
            /// <summary>
            /// Ваучер распечатан
            /// </summary>
            VoucherPrinted = 128,
            /// <summary>
            /// Наличие ваучера на услуге
            /// </summary>
            VoucherNoPrint = 256,
            /// <summary>
            /// Ваучер создан
            /// </summary>
            PresentVoucher = 512,
            /// <summary>
            /// Нет ваучера
            /// </summary>
            NoVoucher = 1024,
            /// <summary>
            /// Блокирует создание по шаблонам
            /// </summary>
            IsBlockCreateVouchers = ErrorLostService | ErrorLostPerson | ErrorPersonNotUse | IndividualService,
            /// <summary>
            /// Является глобальной ошибкой, Измененная услга, Ваучер не на полное кол-во человек
            /// </summary>
            IsGlobalError = ErrorLostService | ErrorLostPerson | ErrorPersonNotUse
        }

        #region Вспомогательные классы
        public class HelperResultOut
        {
            #region Свойства
            public ErrorTypes ErrorStatus;
            public int? DLKEy;
            public int DGKey;
            private LT_V_Voucher currentVoucher
            {
                set
                {
                    if (value != null)
                    {
                        this.CreateDate = value.V_CRDate.Date.ToString("dd.MM.yyyy");
                        this.VoucherNum = value.V_Number;
                        this.VId = value.V_Id;
                        if (value.V_PrintDate.HasValue)
                            this.PrintDate = value.V_PrintDate.Value.Date.ToString("dd.MM.yyyy");
                        if (value.V_PrintByWeb)
                            this.PrintDate += "из WEB";
                    }
                }
            }
            public int? VId;

            [DisplayName("Название услуги")]
            [ReadOnly(true)]
            public string Name { get; set; }
            [DisplayName("№ Ваучера")]
            [ReadOnly(true)]
            [DefaultWidth(150)]
            public string VoucherNum { get; set; }
            [DisplayName("Дата создания")]
            [ReadOnly(true)]
            [DefaultWidth(100)]
            public string CreateDate { get; set; }
            [DisplayName("Дата печати")]
            [ReadOnly(true)]
            [DefaultWidth(100)]
            public string PrintDate { get; set; }
            [DisplayName("Статус")]
            [ReadOnly(true)]
            public string Status { get; set; }
            #endregion

            #region Методы
            private void SetStatus(LT_V_Service value)
            {
                ErrorStatus = ErrorTypes.PresentVoucher;
                if (value.LT_V_Voucher.V_PrintDate.HasValue)
                {
                    ErrorStatus |= ErrorTypes.VoucherPrinted;
                }
                else
                {
                    ErrorStatus |= ErrorTypes.VoucherNoPrint;
                }

                // Если есть потерянные туристы
                if (value.LT_V_Voucher.LT_V_Persons.Any(x => x.tbl_Turist == null))
                {
                    Status = "Ваучер на удаленного туриста";
                    ErrorStatus |= ErrorTypes.ErrorLostPerson;
                    return;
                }

                if ((from xVS in value.LT_V_Voucher.LT_V_Services
                     where  xVS.tbl_DogovorList != null 
                            //&& xVS.tbl_DogovorList.DL_NMEN != value.LT_V_Voucher.LT_V_Persons.Count()
                            && xVS.tbl_DogovorList.DL_NMEN != xVS.tbl_DogovorList.LT_V_Services.Where(x => x.LT_V_Voucher.V_AnnulDate == null).Sum(x => x.LT_V_Voucher.LT_V_Persons.Count())
                    select xVS).Count() > 0)
                {
                    this.ErrorStatus |= ErrorTypes.ErrorPersonNotUse;
                    Status = "На ваучере не хватает туриста";
                    return;
                }

                // Если удаленная услуга
                if (value.VS_DLKey > 0 && value.tbl_DogovorList == null)
                {
                    Status = "Измененная услуга";
                    ErrorStatus |= ErrorTypes.ErrorLostService;
                    return;
                }

                // Если измененная услуга
                if (value.tbl_DogovorList != null
                    && value.VS_Code.HasValue
                    && (value.VS_Code.HasValue && value.VS_Code != value.tbl_DogovorList.DL_CODE
                    || value.VS_Code1.HasValue && value.VS_Code1.GetValueOrDefault(0) != value.tbl_DogovorList.DL_SUBCODE1.GetValueOrDefault(0)
                    || value.VS_Code2.HasValue && value.VS_Code2.GetValueOrDefault(0) != value.tbl_DogovorList.DL_SUBCODE2.GetValueOrDefault(0)
                    || value.LT_V_Voucher.V_PRKey != value.tbl_DogovorList.DL_PARTNERKEY))
                {
                    Status = "Измененная услуга";
                    ErrorStatus |= ErrorTypes.ErrorLostService;
                    return;
                }
            }

            private void SetStatus(tbl_DogovorList value)
            {
                #region Проверка при наличие ваучера
                var currentServiceInVoucher = value.LT_V_Services.FirstOrDefault(x => !x.LT_V_Voucher.V_AnnulDate.HasValue);
                if (currentServiceInVoucher != null)
                {
                    SetStatus(currentServiceInVoucher);
                    return;
                }
                #endregion

                #region Проверки при отсутствие ваучера на услугу

                #region Если на DLNMen > Count(TurServices)
                if (value.DL_NMEN != value.TuristServices.Count())
                {
                    Status = "Привяжите туристов";
                    ErrorStatus = ErrorTypes.ErrorLostPerson | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion

                #region Услуга принудительно должна быть пропущена
                if (value.LT_V_ServicesSkip != null)
                {
                    Status = "Отказ от ваучера";
                    ErrorStatus = ErrorTypes.NotNeedCreate | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion

                #region Нет шаблонов для тура
                if (value.tbl_Dogovor.tbl_TurList.LT_V_MappingTurLists.Count() == 0)
                {
                    Status = "Нет шаблонов для тура";
                    ErrorStatus = ErrorTypes.IndividualService | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion

                var indexedCurrentDL = value.tbl_Dogovor.GetIndexedStructService().First(x => x.Key == value.DL_KEY);
                var indexedTS = value.tbl_Dogovor.tbl_TurList.GetIndexedTurService();

                #region Если услуга не принадлежит пакету
                if (!indexedTS.Any(xITS => xITS.Index == indexedCurrentDL.Index && xITS.SVKey == indexedCurrentDL.SVKey))
                {
                    Status = "Доп услуга";
                    ErrorStatus = ErrorTypes.IndividualService | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion

                #region Если услуга принадлежит пакету, и не принадлежит ни одному из шаблонов по туру
                var serviceInShablon = value.tbl_Dogovor.tbl_TurList.LT_V_MappingTurLists
                    .Any(x =>
                        x.LT_V_MappingTurServices
                        .Any(xMTS =>
                            xMTS.VS_Index == indexedCurrentDL.Index
                            && xMTS.VS_SVKey == indexedCurrentDL.SVKey));

                if (indexedTS.Any(x => x.SVKey == indexedCurrentDL.SVKey && x.Index == indexedCurrentDL.Index) && !serviceInShablon)
                {
                    Status = "Услуга, не нуждается в ваучере, по вопросам обращаться к бронировщику";
                    ErrorStatus = ErrorTypes.NotNeedCreate | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion

                #region Если услуга принадлежит шаблону
                if (serviceInShablon)
                {
                    Status = "Пакетное создание";
                    ErrorStatus = ErrorTypes.ShablonService | ErrorTypes.NoVoucher;
                    return;
                }
                #endregion
                #endregion
            }
            #endregion

            #region Конструктор
            public HelperResultOut(int dgKey)
            {
                this.Status = "";
                this.ErrorStatus = ErrorTypes.NoVoucher;
                this.DGKey = dgKey;
            }

            public HelperResultOut(tbl_DogovorList value)
                : this(value.DL_DGKEY.Value)
            {
                this.DLKEy = value.DL_KEY;
                this.Name = value.DL_NAME;
                this.currentVoucher = value.tbl_Dogovor.LT_V_Vouchers
                    .Where(x => !x.V_AnnulDate.HasValue)
                    .Where(x => x.LT_V_Services.Any(xVS => xVS.VS_DLKey > 0 && xVS.tbl_DogovorList != null && xVS.tbl_DogovorList.DL_KEY == value.DL_KEY)).FirstOrDefault();
                SetStatus(value);
            }

            public HelperResultOut(LT_V_Service value)
                : this(value.LT_V_Voucher.V_DGKey)
            {
                this.DLKEy = null;
                this.Name = value.VS_Name;
                this.currentVoucher = value.LT_V_Voucher;

                SetStatus(value);
            }
            #endregion
        }
        #endregion

        #region Свойства
        private int DGKey;
        private sqlDataContext sqlDC;
        #endregion

        #region Методы
        private void RefrestDGV()
        {
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var currentDogovor = sqlDC.tbl_Dogovors.First(x => x.DG_Key == DGKey);
            var indexedDL = currentDogovor.GetIndexedService(false);
            var resultArray = indexedDL.Select(x => new HelperResultOut(x)).ToList();

            var lostVoucher =
                from xV in currentDogovor.LT_V_Vouchers.Where(x => !x.V_AnnulDate.HasValue)
                from xVS in xV.LT_V_Services
                where xVS.tbl_DogovorList == null
                select new HelperResultOut(xVS);
            resultArray.InsertRange(0, lostVoucher.Distinct().ToArray());
            ResultListDGV.DataSource = resultArray;
        }

        private bool PresentGloabalError()
        {
            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;
            var serviceGlobalError = ds.FirstOrDefault(x => (x.ErrorStatus & ErrorTypes.IsGlobalError) != 0);
            if (serviceGlobalError != null)
            {
                MessageBox.Show("Сначала необходимо поправить\n" + serviceGlobalError.Name + "\n по причине\n" + serviceGlobalError.Status);
                return true;
            }
            return false;
        }
        #endregion

        #region Конструктор
        public frmListServices(int dgKey)
        {
            this.DGKey = dgKey;
            InitializeComponent();
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            this.Text += sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_Key == dgKey).DG_CODE;
            if (ltp_v2.Framework.SqlConnection.ConnectionUserName != "sysadm")
            {
                tsBtnPrint.Visible = !sqlDC.PresentUserInRole("visaEditDoc");
            }
        }
        #endregion

        private void frmListServices_Load(object sender, EventArgs e)
        {
            RefrestDGV();
        }

        private void ResultListDGV_SelectionChanged(object sender, EventArgs e)
        {
            tsBtnCreate.Enabled
                = tsBtnSkipCreatedVoucher.Enabled
                = tsBtnDelete.Enabled
                = tsBtnPrint.Enabled
                = tsBtnSecondPrintAllow.Enabled
                = false;

            var selectedHRO = ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem);
            var Voucher_AC_SecondPrint = sqlDC.PresentUserInRole("Voucher_AC_SecondPrint");

            tsBtnCreate.Enabled = tsBtnSkipCreatedVoucher.Enabled = (selectedHRO.All(x => (x.ErrorStatus & ErrorTypes.NoVoucher) != 0));
            tsBtnSecondPrintAllow.Enabled = (selectedHRO.All(x => (x.ErrorStatus & ErrorTypes.VoucherPrinted) != 0)) && Voucher_AC_SecondPrint;
            tsBtnDelete.Enabled = (selectedHRO.All(x => (x.ErrorStatus & ErrorTypes.PresentVoucher) != 0)) && Voucher_AC_SecondPrint;
            tsBtnPrint.Enabled = (selectedHRO.All(x => (x.ErrorStatus & ErrorTypes.VoucherNoPrint) != 0));
        }

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                Label lblLegend = legNoVoucher;
                HelperResultOut itemHRO = (HelperResultOut)dgvr.DataBoundItem;
                if ((itemHRO.ErrorStatus & ErrorTypes.IsGlobalError) != 0)
                    lblLegend = legErrorService;
                else if ((itemHRO.ErrorStatus & ErrorTypes.NotNeedCreate) != 0)
                    lblLegend = legServiceNotNeedCreate;
                else if ((itemHRO.ErrorStatus & ErrorTypes.IndividualService) != 0)
                    lblLegend = legIndividualService;
                else if ((itemHRO.ErrorStatus & ErrorTypes.VoucherPrinted) != 0)
                    lblLegend = legPrintedVoucher;
                else if ((itemHRO.ErrorStatus & ErrorTypes.VoucherNoPrint) != 0)
                    lblLegend = legPresentVoucher;

                dgvr.DefaultCellStyle.Font = lblLegend.Font;
                dgvr.DefaultCellStyle.ForeColor = lblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = lblLegend.BackColor;
            }
        }

        private void tsBtnSkipCreatedVoucher_Click(object sender, EventArgs e)
        {
            if (PresentGloabalError())
                return;

            if (ResultListDGV.SelectedRows.Count == 1)
            {
                var hro = (HelperResultOut)ResultListDGV.SelectedRows[0].DataBoundItem;
                if (hro.DLKEy.HasValue && (hro.ErrorStatus & ErrorTypes.NoVoucher) == ErrorTypes.NoVoucher)
                {
                    var presentSS = this.sqlDC.LT_V_ServicesSkips.Where(x => x.LSS_DLKey == hro.DLKEy.Value);
                    if (presentSS.Count() != 0)
                    {
                        this.sqlDC.LT_V_ServicesSkips.DeleteOnSubmit(presentSS.First());
                    }
                    else
                    {
                        this.sqlDC.LT_V_ServicesSkips.InsertOnSubmit(new LT_V_ServicesSkip() { LSS_DLKey = hro.DLKEy.Value });
                    }
                    this.sqlDC.SubmitChanges();
                    RefrestDGV();
                }

            }
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            if (PresentGloabalError())
                return;

            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;
            List<LT_V_Voucher> createdVouchers = new List<LT_V_Voucher>();
            // Проверка на наличие ошибок в туре, которые могут припятствовать созданию шаблонного ваучера
            if (ds.All(x => (x.ErrorStatus & ErrorTypes.IsBlockCreateVouchers) == 0))
            {
                createdVouchers.AddRange(CreateVouchersTemplateForTour.Create(sqlDC, DGKey));
            }
            else // end if (ds.All(x => (x.ErrorStatus & ErrorTypes.ISBlockCreateBox) == 0))
            {
                if (ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Any(x => (((HelperResultOut)x.DataBoundItem).ErrorStatus & ErrorTypes.IndividualService) == 0))
                {
                    MessageBox.Show("Выберите только услуги со статусом 'ручное создание'|'доп. услуга'");
                    return;
                }
                else
                {
                    string tourName = "";
                    foreach (var selRow in ResultListDGV.SelectedRows.OfType<DataGridViewRow>().Select(x => (HelperResultOut)x.DataBoundItem))
                    {
                        var tblDogovor = sqlDC.tbl_Dogovors.FirstOrDefault(x => x.DG_Key == DGKey);
                        //Получение имени тура
                        var qTurName = sqlDC.LT_V_MappingTurLists.FirstOrDefault(x => x.VT_TLKey == tblDogovor.DG_TRKEY);
                        if (tourName == "")
                        {
                            if (qTurName != null)
                                tourName = qTurName.VT_Name;
                            else
                            {
                                frmGetTourName fGetTourName = new frmGetTourName(sqlDC, tblDogovor.DG_TRKEY.GetValueOrDefault(0));
                                fGetTourName.ShowDialog();
                                tourName = fGetTourName.TourName;
                            }
                        }

                        //Получение выбранной услуги
                        var currentService = sqlDC.tbl_DogovorLists.FirstOrDefault(x => x.DL_KEY == selRow.DLKEy.Value);
                        // Получение возможных шаблонов по типу услуги
                        var shablonServices = sqlDC.LT_V_ShablonServices.Where(x =>
                            x.LT_V_ShablonFormatService.SHFS_SVKey == sqlDC.tbl_DogovorLists.FirstOrDefault(xDL => xDL.DL_KEY == selRow.DLKEy.Value).DL_SVKEY)
                            .OrderByDescending(x => x.SHS_UseCommentToBron);

                        if (shablonServices.Count() == 0)
                        {
                            frmCreateVoucher fcv = new frmCreateVoucher(sqlDC, selRow.DLKEy.Value, tourName);
                            if (fcv.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                createdVouchers.Add(fcv.CreatedVoucher);
                        }
                        else
                        {
                            if (shablonServices.Count() > 1)
                            {
                                // попытка получения формата вывода для этой страны
                                var VariantServiceFormat =
                                    (from xSF in shablonServices
                                     from xSTG in sqlDC.LT_V_ShablonTourGroups.Where(x => x.SHTR_SHId == xSF.LT_V_Shablon.SH_Id)
                                     where xSTG.LT_V_ShablonTourNames.SHTN_CNKey == sqlDC.tbl_DogovorLists.FirstOrDefault(xDL => xDL.DL_KEY == selRow.DLKEy.Value).DL_CNKEY
                                     select xSF
                                    ).OrderByDescending(x => x.SHS_UseCommentToBron);

                                if (VariantServiceFormat.Count() > 0)
                                    shablonServices = VariantServiceFormat;
                            }

                            LT_V_Voucher newVoucher = sqlDC.CreateVoucher(
                                currentService.DL_PARTNERKEY,
                                currentService.DL_CNKEY,
                                currentService.DL_DGKEY.Value);
                            newVoucher.SetPersonToVoucher(sqlDC, currentService.TuristServices.Select(x => x.tbl_Turist).ToArray());
                            newVoucher.SetServiceToVoucher(sqlDC, new HelperVoucherCreated.helperVoucherService[] { 
                                    new HelperVoucherCreated.helperVoucherService(currentService, shablonServices.First())
                                });
                            newVoucher.V_TourName = tourName;
                            createdVouchers.Add(newVoucher);
                        }
                    }
                }
            }  // end else (ds.All(x => (x.ErrorStatus & ErrorTypes.ISBlockCreateBox) == 0))
            if (createdVouchers.Count() > 0)
            {
                if (new Report.ReportGenerator(sqlDC, createdVouchers.ToArray(), true, false, false).ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    sqlDC.SubmitChanges();
            }
            RefrestDGV();
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите анулировать ваучер(ы)", "Ануляция", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                var hro = (HelperResultOut)dgvr.DataBoundItem;
                sqlDataContext sqlAnnuled = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
                var voucher = sqlAnnuled.LT_V_Vouchers.First(x => x.V_Id == hro.VId.Value);
                voucher.V_AnnulDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                sqlAnnuled.SubmitChanges();
            }
            RefrestDGV();
        }

        private void tsBtnSecondPrintAllow_Click(object sender, EventArgs e)
        {
            if (PresentGloabalError())
                return;

            if (MessageBox.Show("Вы точно хотите разрешить повторную печать на ваучер(ы)", "Повторная печать", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;

            sqlDataContext sqlSecondPrint = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                var hro = (HelperResultOut)dgvr.DataBoundItem;
                var voucher = sqlSecondPrint.LT_V_Vouchers.First(x => x.V_Id == hro.VId.Value);
                voucher.V_PrintDate = null;
                voucher.V_PrintByWeb = false;
            }
            sqlSecondPrint.SubmitChanges();
            RefrestDGV();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (PresentGloabalError())
                return;
            sqlDataContext sqlSecondPrint = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);

            List<LT_V_Voucher> vouchersForPrint = new List<LT_V_Voucher>();
            foreach (DataGridViewRow dgvr in ResultListDGV.SelectedRows)
            {
                var hro = (HelperResultOut)dgvr.DataBoundItem;
                //Ваучер который еще не успели анулировать
                var voucher = sqlSecondPrint.LT_V_Vouchers.FirstOrDefault(x => x.V_Id == hro.VId.Value && !x.V_AnnulDate.HasValue);
                if (voucher != null)
                {
                    vouchersForPrint.Add(voucher);
                }
            }

            if (vouchersForPrint.Count > 0)
            {
                new Report.ReportGenerator(sqlSecondPrint, vouchersForPrint.ToArray(), false, false, false).ShowDialog();
                sqlSecondPrint.SubmitChanges();
            }
            vouchersForPrint.Clear();
            vouchersForPrint = null;
            RefrestDGV();
        }
    }
}