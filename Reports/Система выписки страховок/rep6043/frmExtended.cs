using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep6043
{
    public partial class frmExtended : Form
    {
        #region Вспомогательные классы
        private class helperItem : frmMain.helperDGVOutItem
        {
            [DisplayName("Вывести на печать")]
            [ReadOnly(false)]
            public bool PrintThis { get; set; }

            public helperItem(sqlDataContext sqlDC, int tuKey, short dlDay, short? dlNDays, int dgKey)
                : base(sqlDC, tuKey, dlDay, dlNDays, dgKey)
            {
            }

            public helperItem(sqlDataContext sqlDC, int inKey)
                : base(sqlDC, inKey)
            {
            }

        }
        #endregion

        #region Свойства
        private sqlDataContext SqlDC;
        private helperItem[] listDataSource;
        private string DGCode;
        private bool visiblePrintThis = false;
        #endregion

        #region Методы
        public void InitializeDataSource(string dgCode)
        {
            var listFilteredDogovors =
                (from xDG in SqlDC.tbl_Dogovors
                 where xDG.DG_CODE == dgCode
                 select xDG);

            var listFilteredServices = listFilteredDogovors.Select(x => x.DG_Key).Distinct();

            var listTuristAndSevice =
                (from xFS in listFilteredServices
                 from xDL in SqlDC.tbl_DogovorLists.Where(x => x.DL_SVKEY == 6 && x.DL_DGKEY == xFS)
                 join qTS in SqlDC.TuristServices on xDL.DL_KEY equals qTS.TU_DLKEY into joinTS
                 from xTS in joinTS.DefaultIfEmpty()
                 from xSR in SqlDC.INS_SL_REFs
                 where xSR.SLR_SLKEY == xDL.DL_CODE
                        && xSR.SLR_SUBCODE1 == xDL.DL_SUBCODE1
                        && xSR.SLR_SUBCODE2 == xDL.DL_SUBCODE2
                        && xSR.INS_RISK.RS_CODE == 'A'
                 select new
                 {
                     TUKey = (xTS == null ? -1 : xTS.TU_TUKEY),
                     DLDay = xDL.DL_DAY,
                     DLNDays = xDL.DL_NDAYS,
                     DGKey = xDL.DL_DGKEY,
                     RSCode = xSR.INS_RISK.RS_CODE
                 }).Distinct();

            var listNormalData = listTuristAndSevice.Select(x => new helperItem(SqlDC, x.TUKey, x.DLDay.GetValueOrDefault(1), x.DLNDays, x.DGKey.Value)).ToList();

            var lostInsurances = (
                    from xDG in listFilteredDogovors
                    from xIN in SqlDC.INS_INSURANCEs.Where(x => x.IN_ANNULDATE == null && x.IN_ParentINKey == 0)
                    where xIN.IN_UseDGCode == xDG.DG_CODE
                    select new { xDG.DG_Key, xIN.IN_KEY })
                        .ToArray()
                        .Where(x => !listNormalData.Any(xLi => xLi.DGKey == x.DG_Key && xLi.INKey == x.IN_KEY))
                        .Select(x => new helperItem(SqlDC, x.IN_KEY));

            listNormalData.AddRange(lostInsurances.ToArray());
            listDataSource = listNormalData.ToArray();
            ResultListDGV.DatasourceType = typeof(helperItem);
            ResultListDGV.DataSource = listDataSource;
        }
        #endregion

        #region Конструктор
        public frmExtended(string dgCode, bool visiblePrintChecked)
        {
            this.visiblePrintThis = visiblePrintChecked;
            this.DGCode = dgCode;
            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();
            InitializeDataSource(dgCode);
        }
        #endregion

        #region Обработка событий
        private void ResultListDGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (ResultListDGV.Columns.Count > 0)
            {
                ResultListDGV.Columns["OrderCode"].Visible = false;
                ResultListDGV.Columns["BronNumber"].Visible = false;
                if (!visiblePrintThis)
                    ResultListDGV.Columns["PrintThis"].Visible = false;
            }
        }

        private void ResultListDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ResultListDGV.Rows)
            {
                if (dgvr.DataBoundItem is helperItem)
                {
                    Label lblLegend = lblLegendNormal;
                    var itemHDGV = (helperItem)dgvr.DataBoundItem;
                    if ((itemHDGV.ErrorCode & frmMain.ErrorFlags.esNeedReCreate) != 0)
                        lblLegend = lblLegendLostService;
                    else if ((itemHDGV.ErrorCode & frmMain.ErrorFlags.esInsurancePrinted) != 0)
                        lblLegend = lblLegendPrinted;
                    else if ((((itemHDGV.ErrorCode | frmMain.ErrorFlags.esInsuranceCreate | frmMain.ErrorFlags.esInsurancePrinted)
                            ^ frmMain.ErrorFlags.esInsurancePrinted ^ frmMain.ErrorFlags.esInsuranceCreate) & frmMain.ErrorFlags.IsLockForCreate) != 0)
                        lblLegend = lblLegendAnyError;
                    else if ((itemHDGV.ErrorCode & frmMain.ErrorFlags.esCountDayBeforeStart1) != 0)
                        lblLegend = lblLegend1Days;
                    else if ((itemHDGV.ErrorCode & frmMain.ErrorFlags.esCountDayBeforeStart5) != 0)
                        lblLegend = lblLegend5Days;
                    else if ((itemHDGV.ErrorCode & frmMain.ErrorFlags.esOutOfDaysForCreate) != 0)
                        lblLegend = lblLegend0Days;

                    dgvr.DefaultCellStyle.Font = lblLegend.Font;
                    dgvr.DefaultCellStyle.ForeColor = lblLegend.ForeColor;
                    dgvr.DefaultCellStyle.BackColor = lblLegend.BackColor;
                }
            }
        }
        #endregion

        #region Методы
        public void Print()
        {
            var selectedItems = listDataSource.Where(x => x.PrintThis);

            if (selectedItems.Count() == 0)
                return;

            if (!SqlDC.IsRootManager)
            {
                #region Проверка на потерянные записи
                foreach (var hro in listDataSource)
                {
                    var errorsInsurances = listDataSource.Where(x =>
                            x.DGCode == hro.DGCode &&
                            ((((x.ErrorCode | frmMain.ErrorFlags.esInsuranceCreate | frmMain.ErrorFlags.esInsurancePrinted)
                                    ^ frmMain.ErrorFlags.esInsurancePrinted)
                                        ^ frmMain.ErrorFlags.esInsuranceCreate) & frmMain.ErrorFlags.IsLockForCreate) != 0);

                    if (errorsInsurances.Count() > 0)
                    {
                        MessageBox.Show("Есть ошибки по данной броне, вывод печати страховок невозможен");
                        return;
                    }
                }
                #endregion
            }
            List<int> inKeys = new List<int>();
            foreach (var hro in selectedItems.Where(x => x.INKey != 0))
            {
                if ((hro.ErrorCode & frmMain.ErrorFlags.esInsuranceCreate) != 0)
                    inKeys.Add(hro.INKey);
            }

            if (inKeys.Count > 0)
                new Report.ReportViewer(inKeys).ShowDialog();
        }
        /// <summary>
        /// Создание данных
        /// </summary>
        /// <returns>Истина если все хорошо</returns>
        public bool Submit()
        {
            var selectedItems = listDataSource.Where(x => x.PrintThis).ToArray();
            #region Обновление данных по туристу нуждающихся в обновление
            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                foreach (var q in listDataSource.Where(x => x.INKey != 0 && (x.ErrorCode & frmMain.ErrorFlags.esPersonValueNeedUpdate) != 0))
                {
                    var currInsurance = sqlDC.INS_INSURANCEs.FirstOrDefault(x => x.IN_KEY == q.INKey);
                    var error = currInsurance.UpdatePersonsName(sqlDC);
                    MessageBox.Show(error, "Обновление данных по туристу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                sqlDC.SubmitChanges();
            }
            #endregion

            InitializeDataSource(this.DGCode);

            #region Ануляция потерянных полисов
            using (sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                foreach (var q in listDataSource.Where(x => x.INKey != 0 && (x.ErrorCode & frmMain.ErrorFlags.esNeedReCreate) != 0))
                {
                    var currInsurance = sqlDC.INS_INSURANCEs.FirstOrDefault(x => x.IN_KEY == q.INKey);

                    if (currInsurance.INS_CONDITIONs.Any(x => x.INS_RISK.RS_CODE == 'D') && (currInsurance.IN_DATESTART.Date - DateTime.Now.Date).TotalDays < 5)
                    {
                         if (MessageBox.Show("в страховке № " + currInsurance.IN_NUMBER + " есть страхование от невыезда, после ануляции полис с невыездом создать возможно будет нельзя, \r\n Вы все равно хотите анулировать этот полиc?", "Аннуляция", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No);
                            return false;
                    }
                    string ErrorMessage = "";
                    if (!currInsurance.Anulate(true, out ErrorMessage))
                    {
                        MessageBox.Show(ErrorMessage, "Ошибка при аннуляции полиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                sqlDC.SubmitChanges();
            }
            #endregion

            InitializeDataSource(this.DGCode);

            #region Создание полисов
            foreach (var q in listDataSource.Where(x=>x.INKey == 0).OrderByDescending(x => x.PersonAge))
            {
                if (q.PersonAge < 2)
                {
                    var createdChldIns = new frmListInsurancesForInfant(q.TUKey, q.DLDay, q.DLNDays);
                    createdChldIns.ShowDialog();
                }
                else
                {
                    var frmCreateInsurances = new frmCreateInsurances(q.DGCode, q.DLDay, q.DLNDays, q.TUKey);
                }
            }
            #endregion
            if (selectedItems.Count() > 0)
            {
                InitializeDataSource(this.DGCode);
                foreach (var recheckItem in selectedItems)
                {
                    var fItem = listDataSource.FirstOrDefault(x => x.TUKey == recheckItem.TUKey
                        && x.DLDay == recheckItem.DLDay);
                    if (fItem != null)
                        fItem.PrintThis = true;
                }
            }
            return true;
        }

        /// <summary>
        /// Проверка на наличии ошибок
        /// </summary>
        /// <returns>Истина если имеются ошибки</returns>
        public string CheckError()
        {
            var q = listDataSource
                .Where(x =>
                    (x.ErrorCode & frmMain.ErrorFlags.esInsuranceCreate) == 0 &&
                    ((((x.ErrorCode | frmMain.ErrorFlags.esInsuranceCreate | frmMain.ErrorFlags.esInsurancePrinted)
                        ^ frmMain.ErrorFlags.esInsurancePrinted)
                            ^ frmMain.ErrorFlags.esInsuranceCreate) & frmMain.ErrorFlags.IsLockForCreate) != 0);
            var message = (q.FirstOrDefault() != null ? q.FirstOrDefault().ErrorMessage : "");
            return message.Trim();
        }

        /// <summary>
        /// Аннуляция всех данных по путевке
        /// </summary>
        public void Annul()
        {
            foreach (var hro in listDataSource)
            {
                if ((hro.ErrorCode & rep6043.frmMain.ErrorFlags.esInsuranceCreate) != 0)
                {
                    var currentInsurance = SqlDC.INS_INSURANCEs.FirstOrDefault(x => x.IN_KEY == hro.INKey);
                    if (currentInsurance != null)
                    {
                        string errorMessage = "";
                        if (!currentInsurance.Anulate(true, out errorMessage))
                        {
                            MessageBox.Show(errorMessage, "Ошибка при аннуляции полиса", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                SqlDC.SubmitChanges();
            }
        }
        #endregion
    }
}
