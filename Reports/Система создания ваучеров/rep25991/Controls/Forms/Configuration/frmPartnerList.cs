using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ltp_v2.Controls.Forms;
using rep25991.Controls.Forms;
using rep25991.ExtendedMethods;

namespace rep25991.Controls.Forms.Configuration
{
    public partial class frmPartnerList : Form
    {
        #region Вспомогательные класс
        public class helperOutClass
        {
            public int PRKey;
            [DisplayName("Название партнера в Мастер-тур")]
            public string NameInMaster { get; set; }
            [DisplayName("Название для ваучера")]
            public string MappingName { get; set; }
            [DisplayName("Адрес для ваучера")]
            public string MappingAddress { get; set; }
            [DisplayName("Логотип для ваучера")]
            public Image MappingLogo { get; set; }

            public helperOutClass(tbl_Partner value)
            {
                this.PRKey = value.PR_KEY;
                this.NameInMaster = value.PR_NAME;
                if (value.LT_V_MappingPartner != null)
                {
                    if (value.LT_V_MappingPartner.VMP_Image != null && value.LT_V_MappingPartner.VMP_Image.Length > 0)
                    {
                        this.MappingLogo = LogoCreater.CreateLogo(value.LT_V_MappingPartner.VMP_Image.ToArray(), new Size(253 / 2, 102 / 2), "");
                    }
                }
            }
        }
        #endregion

        #region Свойства
        private sqlDataContext SqlDC;
        private int CNKey;
        private IEnumerable<helperOutClass> _ArrayPartners;
        private IEnumerable<helperOutClass> ArrayPartners
        {
            get
            {
                if (_ArrayPartners == null)
                {
                    lwWaitScreen ws = new lwWaitScreen();
                    ws.Show();
                    var usedPartnersKey = SqlDC.tbl_DogovorLists
                        .Where(x => x.DL_CNKEY == CNKey
                                    && x.Service.LT_V_ServiceNotUse == null
                                    && (x.DL_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0)
                        .Select(x => x.DL_PARTNERKEY)
                        .Union(
                            SqlDC.TurServices
                                .Where(x => x.TS_CNKEY == CNKey
                                            && x.Service.LT_V_ServiceNotUse == null
                                            && (x.TS_ATTRIBUTE.GetValueOrDefault(0) & 64) == 0)
                                .Select(x => x.TS_PARTNERKEY))
                        .Where(x => x.HasValue)
                        .Select(x => x.Value)
                        .Distinct();

                    _ArrayPartners = from xUP in usedPartnersKey
                                     from xPR in SqlDC.tbl_Partners.Where(x => x.PR_KEY == xUP)
                                     select new helperOutClass(xPR);
                    ws.Close();
                }
                return _ArrayPartners;
            }
        }
        #endregion       

        private void ReloadPartner()
        {
            if (fltPartnerName.Text.RemoveSpace() == "")
            {
                ResultListDGV.DataSource = ArrayPartners;
            }
            else
            {
                lwWaitScreen ws = new lwWaitScreen();
                ws.Show();
                ResultListDGV.DataSource = ArrayPartners.Where(x => x.NameInMaster.ToLower().Contains(fltPartnerName.Text.ToLower())).ToArray();
                ws.Close();
            }
        }

        public frmPartnerList(int cnKey)
        {
            this.CNKey = cnKey;
            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);        
            InitializeComponent();

            this.Text = "Список доступных партнеров по стране: " + SqlDC.tbl_Countries.First(x => x.CN_KEY == cnKey).CN_NAME;
        }

        private void frmPartnerList_Load(object sender, EventArgs e)
        {
            ReloadPartner();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ReloadPartner();
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            var xSR = (helperOutClass)ResultListDGV.SelectedRows[0].DataBoundItem;

            if (new frmConfigPartner(SqlDC.tbl_Partners.FirstOrDefault(x => x.PR_KEY == xSR.PRKey), true).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SqlDC.SubmitChanges();
                _ArrayPartners = null;
            }
            ReloadPartner();
        }
    }
}
