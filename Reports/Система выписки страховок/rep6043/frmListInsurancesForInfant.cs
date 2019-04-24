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
    public partial class frmListInsurancesForInfant : Form
    {
        #region Вспомогательные классы
        public class helperClass
        {
            public DateTime CreateDate { get; private set; }
            public DateTime DateStart { get; private set; }
            public DateTime DateEnd { get; private set; }
            public String Number { get; private set; }
            public String Insured { get; private set; }
            public INS_INSURANCE INS_INSURANCE { get; private set; }

            public helperClass(INS_INSURANCE value)
            {
                INS_INSURANCE = value;
                CreateDate = value.IN_DATE;
                DateStart = value.IN_DATESTART.Date;
                DateEnd = value.IN_DATEEND.Date;
                Number = value.IN_NUMBER;
                Insured = value.IN_INSURED;
            }

            public override string ToString()
            {
                return " №" + Number + " / " + Insured + " / с" + DateStart.ToString("dd.MM.yyyy") + " по" + DateEnd.ToString("dd.MM.yyyy");
            }
        }
        #endregion

        #region Свойства
        public sqlDataContext SqlDС;
        private int TUKey;
        #endregion

        public frmListInsurancesForInfant(int tuKey, int day, int days)
        {
            this.TUKey = tuKey;
            InitializeComponent();
            SqlDС = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            var currTurist = SqlDС.tbl_Turists.First(x => x.TU_KEY == tuKey);
            lblInfo.Text = "Список доступных страховок для туриста" + currTurist.ToString();

            var q = SqlDС.INS_INSURANCEs
                        .Where(x =>
                            x.IN_UseDGCode == SqlDС.tbl_Turists.First(xTU => xTU.TU_KEY == tuKey).TU_DGCOD
                            && !x.IN_ANNULDATE.HasValue
                            && x.IN_ParentINKey == 0)
                        .Select(x => new { x, tbl_Dogovor = SqlDС.tbl_Dogovors.Where(xDG => xDG.DG_CODE == x.IN_UseDGCode).First() })
                        .Where(x =>
                            (x.x.IN_DATESTART - x.tbl_Dogovor.DG_TURDATE).TotalDays + 1 == day
                            && (x.x.IN_DATEEND - x.x.IN_DATESTART).TotalDays + 1 == days)
                       .Select(x => new helperClass(x.x));

            listBox1.DataSource = q.ToArray();
        }

        private void tsBtnCreateInsurances_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            helperClass hc = (helperClass)listBox1.SelectedItem;
            if (hc.CreateDate.Date.Month != ltp_v2.Framework.SqlConnection.ServerDateTime.Month)
            {
                MessageBox.Show(ErrorMessages.ErrCreateNotCurrentMonth, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (hc.DateStart.Date < ltp_v2.Framework.SqlConnection.ServerDateTime.Date)
            {
                MessageBox.Show(ErrorMessages.ErrOutDayBeforeCreate(hc.Number, (int)(hc.DateStart.Date - ltp_v2.Framework.SqlConnection.ServerDateTime.Date).TotalDays), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var currentTurist = SqlDС.tbl_Turists.First(x => x.TU_KEY == TUKey);

            // Если в текущем полисе имеется страхование от невыезда то выносим его в новый полис
            if (hc.INS_INSURANCE.INS_CONDITIONs.Any(x => x.INS_RISK.RS_CODE == 'D'))
            {
                INS_INSURANCE newInsur = new INS_INSURANCE();
                newInsur.InsurancesParent = hc.INS_INSURANCE;
                foreach (var condNotTrip in hc.INS_INSURANCE.INS_CONDITIONs.Where(x => x.INS_RISK.RS_CODE == 'D').ToArray())
                {
                    condNotTrip.INS_INSURANCE = newInsur;
                }
                foreach (var itemTurist in hc.INS_INSURANCE.INS_PERSONs.Where(x => !newInsur.INS_PERSONs.Any(xNIP => xNIP.IP_TUKEY == x.IP_TUKEY)))
                {
                    newInsur.INS_PERSONs.Add(new INS_PERSON()
                    {
                        tbl_Turist = itemTurist.tbl_Turist
                    });
                }
                foreach (var itemTerretory in hc.INS_INSURANCE.INS_TERRITORies)
                {
                    newInsur.INS_TERRITORies.Add(new INS_TERRITORy()
                    {
                        INS_COUNTRIES_ING = itemTerretory.INS_COUNTRIES_ING
                    });
                }
                newInsur.RecalculatePremiumTotal();
                hc.INS_INSURANCE.RecalculatePremiumTotal();
            }

            hc.INS_INSURANCE.INS_PERSONs.Add(new INS_PERSON() { tbl_Turist = currentTurist });
            SqlDС.SubmitChanges();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}