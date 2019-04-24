using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rep25991.Controls.Forms.Voucher;
using rep25991.ExtendedMethods;
using ltp_v2.Controls.Forms;
namespace rep25991
{
    public partial class frmExtended : Form
    {
        #region Вспомогательные классы
        public class HelperResultOut : frmListServices.HelperResultOut
        {
            public HelperResultOut(tbl_DogovorList x)
                : base(x)
            {
                Checked = true;
            }

            public HelperResultOut(LT_V_Service x)
                : base(x)
            {
            }

            private bool _CheckPreview = false;

            [DisplayName("Предпросмотр")]
            [ReadOnly(false)]
            [DefaultWidth(55)]
            public bool Preview
            {
                get { return _CheckPreview; }
                set
                {
                    _CheckPreview = (Checked && value);
                }
            }

            private bool _CheckCreate = false;
            [DisplayName("Создавать")]
            [ReadOnly(false)]
            [DefaultWidth(55)]
            public bool Checked
            {
                get
                {
                    return _CheckCreate;
                }
                set
                {
                    _CheckCreate = value;
                    if ((this.ErrorStatus & frmListServices.ErrorTypes.NotNeedCreate) != 0)
                        _CheckCreate = false;
                    else if ((this.ErrorStatus & frmListServices.ErrorTypes.ShablonService) != 0)
                        _CheckCreate = true;
                    else if ((this.ErrorStatus & frmListServices.ErrorTypes.IsGlobalError) != 0
                            && (this.ErrorStatus & frmListServices.ErrorTypes.NoVoucher) == 0)
                        _CheckCreate = true;
                    else if ((this.ErrorStatus & frmListServices.ErrorTypes.PresentVoucher) != 0)
                        _CheckCreate = false;

                    if (!Checked)
                        Preview = false;
                }
            }
        }
        #endregion

        #region Свойства
        private sqlDataContext sqlDC;
        private int DGKey;
        private string DGCode;
        private tbl_Dogovor CurrentDogovor;
        public bool ViewCheckBox = true;
        #endregion

        #region Методы
        private void InitializeDataSource(string dgCode)
        {
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            CurrentDogovor = sqlDC.tbl_Dogovors.First(x => x.DG_CODE == dgCode);
            DGKey = CurrentDogovor.DG_Key;
            var indexedDL = CurrentDogovor.GetIndexedService(false);
            var resultArray = indexedDL.Select(x => new HelperResultOut(x)).ToList();

            var lostVoucher =
                from xV in CurrentDogovor.LT_V_Vouchers.Where(x => !x.V_AnnulDate.HasValue)
                from xVS in xV.LT_V_Services
                where xVS.tbl_DogovorList == null
                select new HelperResultOut(xVS);
            resultArray.InsertRange(0, lostVoucher.Distinct().ToArray());
            ResultListDGV.DatasourceType = typeof(HelperResultOut);
            ResultListDGV.DataSource = resultArray;
        }

        private List<LT_V_Voucher> CreateVouchers()
        {
            List<LT_V_Voucher> listCreatedVoucher = new List<LT_V_Voucher>();
            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;

            #region Создание индивидуальных услуг
            string tourName = "";

            foreach (var inividualItem in ds.Where(x => x.Checked && (x.ErrorStatus & frmListServices.ErrorTypes.IndividualService) != 0))
            {
                // Получение название тура
                var qTurName = sqlDC.LT_V_MappingTurLists.FirstOrDefault(x => x.VT_TLKey == CurrentDogovor.DG_TRKEY);
                if (tourName == "")
                {
                    if (qTurName != null)
                        tourName = qTurName.VT_Name;
                    else
                    {
                        frmGetTourName fGetTourName = new frmGetTourName(sqlDC, CurrentDogovor.DG_TRKEY.GetValueOrDefault(0));
                        fGetTourName.ShowDialog();
                        tourName = fGetTourName.TourName;
                    }
                }

                //Получение выбранной услуги
                var currentService = sqlDC.tbl_DogovorLists.FirstOrDefault(x => x.DL_KEY == inividualItem.DLKEy.Value);
                // Получение возможных шаблонов по типу услуги
                IOrderedQueryable<LT_V_ShablonService> baseFormatServices = sqlDC.LT_V_ShablonServices.Where(x =>
                    x.LT_V_ShablonFormatService.SHFS_SVKey == sqlDC.tbl_DogovorLists.FirstOrDefault(xDL => xDL.DL_KEY == inividualItem.DLKEy.Value).DL_SVKEY)
                    .OrderByDescending(x => x.SHS_UseCommentToBron);
                LT_V_Voucher newVoucher = null;
                // Если нет возможных шаблонов то открываем редактирование
                if (baseFormatServices.Count() == 0)
                {
                    frmCreateVoucher fcv = new frmCreateVoucher(sqlDC, inividualItem.DLKEy.Value, tourName);
                    fcv.ShowDialog();
                    newVoucher = fcv.CreatedVoucher;
                }
                else if (baseFormatServices.Count() > 1)
                {
                    // попытка получения формата вывода для этой страны
                    IOrderedQueryable<LT_V_ShablonService> anyVariantServiceFormat =
                        (from xSF in baseFormatServices
                         from xSTG in sqlDC.LT_V_ShablonTourGroups.Where(x => x.SHTR_SHId == xSF.LT_V_Shablon.SH_Id)
                         where xSTG.LT_V_ShablonTourNames.SHTN_CNKey == sqlDC.tbl_DogovorLists.FirstOrDefault(xDL => xDL.DL_KEY == inividualItem.DLKEy.Value).DL_CNKEY
                         select xSF).OrderByDescending(x => x.SHS_UseCommentToBron);

                    if (anyVariantServiceFormat.Count() > 0)
                        baseFormatServices = anyVariantServiceFormat;


                    newVoucher = sqlDC.CreateVoucher(
                        currentService.DL_PARTNERKEY,
                        currentService.DL_CNKEY,
                        currentService.DL_DGKEY.Value);
                    newVoucher.SetPersonToVoucher(sqlDC, currentService.TuristServices.Select(x => x.tbl_Turist).ToArray());
                    newVoucher.SetServiceToVoucher(sqlDC, new HelperVoucherCreated.helperVoucherService[] { 
                                    new HelperVoucherCreated.helperVoucherService(currentService, baseFormatServices.First())
                                });
                    newVoucher.V_TourName = tourName;
                }

                if (newVoucher != null)
                    listCreatedVoucher.Add(newVoucher);
            }
            #endregion

            #region Создание шаблонных ваучеров
            LT_V_Voucher[] createdVouchers = CreateVouchersTemplateForTour.Create(sqlDC, DGKey);
            listCreatedVoucher.AddRange(createdVouchers);
            #endregion

            return listCreatedVoucher;
        }

        /// <summary>
        /// Обновление или пересоздание данных, без создания новых
        /// </summary>
        /// <returns>истина в случае успеха</returns>
        public bool ReChangeData()
        {
            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;
            List<int> tmpDLKeys = new List<int>();

            #region Ануляция потерянных записей
            //var listSelectedDLKeys = ds.Where(x => x.Checked && x.DLKEy.HasValue).Select(x => x.DLKEy.Value);
            foreach (var itemForAnnuled in ds.Where(x => x.VId.HasValue && (x.ErrorStatus & frmListServices.ErrorTypes.IsGlobalError) != 0))
            {
                var AnnuledVoucher = this.sqlDC.LT_V_Vouchers.FirstOrDefault(x => x.V_Id == itemForAnnuled.VId);
                AnnuledVoucher.V_AnnulDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                tmpDLKeys.AddRange(AnnuledVoucher.LT_V_Services.Select(x => x.VS_DLKey).ToArray());
            }
            this.sqlDC.SubmitChanges();
            #endregion

            InitializeDataSource(CurrentDogovor.DG_CODE);

            // При условие что после аннуляции были найдены новые услуги за исключение аннулированных, то отменяем пересоздание.
            var itemsNoVoucher = ((List<HelperResultOut>)ResultListDGV.DataSource).Where(x => (x.ErrorStatus & frmListServices.ErrorTypes.NoVoucher) != 0);
            if (CheckError() != "" || itemsNoVoucher.Any(x => x.DLKEy.HasValue && !tmpDLKeys.Contains(x.DLKEy.Value)))
            {
                MessageBox.Show("Необходимо обратиться к бронировщику для создания ваучеров по данному туру");
                return false;
            }
            foreach (var item in itemsNoVoucher.Where(x => x.DLKEy.HasValue))
            {
                item.Checked = true;
            }
            
            CreateVouchers();
            sqlDC.SubmitChanges();
            return true;
        }

        /// <summary>
        /// Создание всех данных
        /// </summary>
        /// <returns>истина в случае успеха</returns>
        public bool Submit()
        {
            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;

            // Ключи услуг нуждающихся в обновление
            var dlKeysPreview = ds.Where(x => x.Preview && x.Checked && x.DLKEy.HasValue).Select(x=>x.DLKEy.Value);
            // кэш выбранных усгуг для переопределения
            var cacheSelectedDLKeys = ds.Where(x => x.Checked && x.DLKEy.HasValue).Select(x => x.DLKEy.Value);

            #region Ануляция потерянных записей
            foreach (var itemForAnnuled in ds.Where(x => x.VId.HasValue && (x.ErrorStatus & frmListServices.ErrorTypes.IsGlobalError) != 0))
            {
                var AnnuledVoucher = this.sqlDC.LT_V_Vouchers.FirstOrDefault(x => x.V_Id == itemForAnnuled.VId);
                AnnuledVoucher.V_AnnulDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
            }
            this.sqlDC.SubmitChanges();
            #endregion
            InitializeDataSource(CurrentDogovor.DG_CODE);
            
            #region Переотметка выбранных броней
            foreach (var tmpDL in (List<HelperResultOut>)ResultListDGV.DataSource)
            {
                tmpDL.Checked = cacheSelectedDLKeys.Any(x => x == tmpDL.DLKEy);
            }
            #endregion            
            
            #region Блокировка невыбранных услуг
            foreach (var itemForLock in ds.Where(x => !x.Checked && (x.ErrorStatus & frmListServices.ErrorTypes.NotNeedCreate) != 0))
            {
                if (!this.sqlDC.LT_V_ServicesSkips.Any(x => x.LSS_DLKey == itemForLock.DLKEy.Value))
                {
                    this.sqlDC.LT_V_ServicesSkips.InsertOnSubmit(new LT_V_ServicesSkip() { LSS_DLKey = itemForLock.DLKEy.Value });
                }
            }
            #endregion

            List<LT_V_Voucher> listCreatedVoucher = CreateVouchers();

            var result = false;
            var previewList = listCreatedVoucher.Where(x=>x.LT_V_Services.Any(xVS=>dlKeysPreview.Any(xDLP => xDLP == xVS.VS_DLKey)));
            if (dlKeysPreview.Count() == 0 || dlKeysPreview.Count() > 0 && new Report.ReportGenerator(sqlDC, previewList.ToArray(), true, false, false).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                sqlDC.SubmitChanges();
                result = true;
            }
            InitializeDataSource(CurrentDogovor.DG_CODE);
            return result;
        }

        public string CheckError()
        {
            var ds = (List<HelperResultOut>)ResultListDGV.DataSource;
            var serviceGlobalError = ds.FirstOrDefault(x => 
                (x.ErrorStatus & frmListServices.ErrorTypes.IsGlobalError) != 0
                && (x.ErrorStatus & frmListServices.ErrorTypes.NoVoucher) != 0);
            if (serviceGlobalError != null)
            {
                return "Сначала необходимо поправить\n" + serviceGlobalError.Name + "\n по причине\n" + serviceGlobalError.Status;
            }
            return "";
        }

        /// <summary>
        /// Аннуляция всех данных по путевке
        /// </summary>
        public void Annul()
        {
            sqlDataContext sqlAnnuled = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            foreach (var hro in (List<HelperResultOut>)ResultListDGV.DataSource)
            {
                if ((hro.ErrorStatus & frmListServices.ErrorTypes.PresentVoucher) != 0)
                {
                    var voucher = sqlAnnuled.LT_V_Vouchers.First(x => x.V_Id == hro.VId.Value);
                    voucher.V_AnnulDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                }
            }
            sqlAnnuled.SubmitChanges();
        }
        #endregion

        #region Конструктор
        public frmExtended(string dgCode, bool viewCheckBox)
        {
            this.DGCode = dgCode;
            this.ViewCheckBox = viewCheckBox;
            InitializeComponent();
        }
        #endregion

        private void frmExtended_Load(object sender, EventArgs e)
        {
            InitializeDataSource(DGCode);
        }

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                Label lblLegend = legNoVoucher;
                HelperResultOut itemHRO = (HelperResultOut)dgvr.DataBoundItem;
                if ((itemHRO.ErrorStatus & frmListServices.ErrorTypes.IsGlobalError) != 0)
                    lblLegend = legErrorService;
                else if ((itemHRO.ErrorStatus & frmListServices.ErrorTypes.NotNeedCreate) != 0)
                    lblLegend = legServiceNotNeedCreate;
                else if ((itemHRO.ErrorStatus & frmListServices.ErrorTypes.IndividualService) != 0)
                    lblLegend = legIndividualService;
                else if ((itemHRO.ErrorStatus & frmListServices.ErrorTypes.VoucherPrinted) != 0)
                    lblLegend = legPrintedVoucher;
                else if ((itemHRO.ErrorStatus & frmListServices.ErrorTypes.VoucherNoPrint) != 0)
                    lblLegend = legPresentVoucher;

                dgvr.DefaultCellStyle.Font = lblLegend.Font;
                dgvr.DefaultCellStyle.ForeColor = lblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = lblLegend.BackColor;
            }
        }

        private void ResultListDGV_DataSourceChanged(object sender, EventArgs e)
        {
            ResultListDGV.Columns["CreateDate"].Visible = false;
            ResultListDGV.Columns["PrintDate"].Visible = false;
            ResultListDGV.Columns["Checked"].Visible = ResultListDGV.Columns["Preview"].Visible = ViewCheckBox;
        }

        private void ResultListDGV_MouseUp(object sender, MouseEventArgs e)
        {
            ResultListDGV.EndEdit();
        }
    }
}
