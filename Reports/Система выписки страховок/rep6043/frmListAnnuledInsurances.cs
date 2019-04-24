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
    public partial class frmListAnnuledInsurances : Form
    {
        #region Вспомогательные классы
        private class HelperResultOut
        {
            public int INKey;
            [DisplayName("Полис этого тура")]
            public bool IsFirstOut { get; set; }
            [DisplayName("№ Полиса")]
            public string Number { get; private set; }
            [DisplayName("Дата создания полиса")]
            public DateTime CreateDate { get; private set; }
            [DisplayName("ФИО Застрахованного")]
            public string InsuredFIO { get; private set; }

            public HelperResultOut(INS_INSURANCE value)
            {
                this.INKey = value.IN_KEY;
                this.Number = value.IN_NUMBER;
                this.CreateDate = value.IN_DATE;
                this.InsuredFIO = value.IN_INSURED;
            }
        }
        #endregion

        private sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
        private string DGCode;
        private int DLDay;
        private int DLNDays;
        private int TUKey;

        private void ReloadFilteredList()
        {
            var result =
                // списркв всех аннулированных стаховок "сирот" за перриуд
                from xINS in sqlDC.INS_INSURANCEs
                    .Where(x =>
                        x.IN_DATE.Date >= edtFtlCreateDateFrom.Value.Date
                        && x.IN_DATE.Date <= edtFtlCreateDateTo.Value.Date
                        && x.IN_ParentINKey == 0
                        && x.InsurancesChield.Count() == 0
                        && x.IN_ANNULDATE.HasValue)
                // Список услуг страхования в МТ для туриста на укказанный день
                from xDL6 in sqlDC.tbl_DogovorLists
                    .Where(x =>
                        x.DL_DGCOD == DGCode
                        && x.DL_SVKEY == 6
                        && x.DL_DAY == DLDay
                        && x.TuristServices.Any(xTU => xTU.TU_TUKEY == TUKey))
                // Выборка услуг которые имеют связь и ингосстрахом
                from xRF in sqlDC.INS_SL_REFs
                    .Where(x =>
                        x.INS_RISK.RS_CODE == 'A'
                        && x.SLR_SLKEY == xDL6.DL_CODE
                        && x.SLR_SUBCODE1 == xDL6.DL_SUBCODE1
                        && x.SLR_SUBCODE2 == xDL6.DL_SUBCODE2)
                // Выборка стран из справочника ингосстраха
                from xCR in sqlDC.INS_COUNTRY_REFs
                    .Where(x => sqlDC.tbl_DogovorLists.Any(xCN =>
                            (xCN.DL_SVKEY == 3 || xCN.DL_SVKEY == 8 || xCN.DL_SVKEY == 4 || xCN.DL_SVKEY == 7 || xCN.DL_SVKEY == 9)
                            && xCN.TuristServices.Any(xTU => xTU.TU_TUKEY == TUKey)
                            && x.CR_CNKEY == x.CR_CNKEY)
                        || x.CR_CNKEY == xDL6.tbl_Dogovor.DG_CNKEY
                        || x.CR_CNKEY == xDL6.tbl_Dogovor.DG_CNKEY)
                from xTR in sqlDC.INS_TARIFFs
                    .Where(x =>
                        !x.TR_CIKey.HasValue && x.TR_RATE == xDL6.tbl_Dogovor.DG_RATE
                        || x.TR_CIKey.HasValue && x.TR_CIKey.Value == xCR.CR_CIKEY)
                where xINS.IN_NUMBER.IndexOf(xTR.TR_NumCode) == 0
                select new HelperResultOut(xINS) { IsFirstOut = xINS.IN_UseDGCode == DGCode };

            ResultListDGV.DataSource = result.OrderBy(x => x.IsFirstOut).Distinct();
        }

        public frmListAnnuledInsurances(string dgCode, int dlDay, int tuKey, int dlNDays)
        {
            InitializeComponent();
            this.TUKey = tuKey;
            this.DLDay = dlDay;
            this.DGCode = dgCode;
            this.DLNDays = dlNDays;

            var dogovor = sqlDC.tbl_Dogovors.Where(x => x.DG_CODE == dgCode).First();
            var turist = dogovor.tbl_Turists.Where(x => x.TU_KEY == tuKey).First();
            var insurancesAnull = sqlDC.INS_INSURANCEs.Where(x => x.IN_UseDGCode == dgCode && x.IN_ANNULDATE.HasValue);
            edtRTB.Text =
                dogovor.DG_CODE + "\r\n"
                + "* Дата брони: " + dogovor.DG_CRDATE.ToString("dd.MM.yyyy") + "\r\n"
                + "* Дата заезда: " + dogovor.DG_TURDATE.ToString("dd.MM.yyyy") + "\r\n"
                + "* Наличие анулированных страховых полисов в этом месяце для этого тура: " + (insurancesAnull.Count() > 0 ? "ДА" : "НЕТ") + "\r\n"
                + "* Фамилия страхующегося: " + turist.TU_NAMELAT.Trim().ToUpper() + " " + turist.TU_FNAMELAT.Trim().ToUpper();
            DateTime sqlDate = ltp_v2.Framework.SqlConnection.ServerDateTime.Date;
            if (dogovor.DG_TURDATE.Date.Month == sqlDate.Month && dogovor.DG_TURDATE.Date.Year == sqlDate.Year)
            {
                var minDate = dogovor.DG_CRDATE.Date;
                if (minDate.Month != sqlDate.Month || minDate.Year != sqlDate.Year)
                    minDate = new DateTime(sqlDate.Date.Year, sqlDate.Date.Month, 1);

                edtFtlCreateDateFrom.Value = minDate.Date;
                edtFtlCreateDateTo.Value = dogovor.DG_TURDATE.Date;
            }

            ReloadFilteredList();
        }

        private void edtFtlCreateDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (edtFtlCreateDateFrom.Value.Date > edtFtlCreateDateTo.Value.Date)
            {
                edtFtlCreateDateTo.Value = edtFtlCreateDateFrom.Value;
            }
            ReloadFilteredList();
        }

        private void edtFtlCreateDateTo_ValueChanged(object sender, EventArgs e)
        {
            if (edtFtlCreateDateFrom.Value.Date > edtFtlCreateDateTo.Value.Date)
            {
                edtFtlCreateDateFrom.Value = edtFtlCreateDateTo.Value;
            }
            ReloadFilteredList();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (ResultListDGV.SelectedRows.Count == 0)
                return;
            HelperResultOut item = (HelperResultOut)ResultListDGV.SelectedRows[0].DataBoundItem;
            DialogResult = new frmCreateInsurances(item.INKey, DGCode, DLDay, DLNDays, TUKey).ShowDialog();
        }
    }
}
