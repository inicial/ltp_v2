using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rep25991.ExtendedMethods.Convertation;
using rep25991.ExtendedMethods;
using rep25991.ExtendedMethods.AutoWrappingText;

namespace rep25991.Controls.Forms.Voucher
{
    public partial class frmCreateVoucher : Form
    {
        #region Вспомогательные классы
        public class helperOutTurist
        {
            public int Id;
            public string Name;

            public helperOutTurist(tbl_Turist turist, string formatOut, string dateFormat)
            {
                this.Id = turist.TU_ID.Value;
                this.Name = Tourist.Convert(new Tourist.TouristDataValue(turist, turist.tbl_Dogovor.IsRussianVariant()), formatOut, dateFormat);
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
        #endregion

        private bool IsProgramingEditService;
        private sqlDataContext SqlDC;
        private string TourName;
        private int DLKey;

        public LT_V_Voucher CreatedVoucher;

        #region Методы
        private void SetPropertyToEditor(LT_V_Voucher value)
        {
            IsProgramingEditService = true;
            
            var currPartner = value.tbl_Partner;
            edtTourName.Text = value.V_TourName;
            edtPartnerName.Text = value.V_PartnerName;
            edtPartnerContact.Text = value.V_PartnerContact;
            edtPartnerLogo.Image = new Bitmap(rep25991.ExtendedMethods.LogoCreater.CreateMemoryStram(currPartner.LT_V_MappingPartner.VMP_Image.ToArray()));

            edtCountryName.Text = value.V_CountryName;
            edtContactInfo.Text = value.V_ContactPerson;
            edtBronNumber.Text = value.V_BronNumber;
            edtDateBeg.Value = value.V_DateBeg;
            edtDateEnd.Value = value.V_DateEnd;

            foreach (var person in value.LT_V_Persons)
            {
                lbTurist.Items.Add(person);
            }

            edtService.Text = value.LT_V_Services.FirstOrDefault().VS_Name;
            
            IsProgramingEditService = false;
        }

        private void GetPropertyFromEditor(LT_V_Voucher value)
        {
            IsProgramingEditService = true;

            var currPartner = value.tbl_Partner;
            //Enable - false: value.V_TourName = edtTourName.Text;
            //Enable - false: value.V_PartnerName = edtPartnerName.Text;
            //Enable - false: value.V_PartnerContact = edtPartnerContact.Text;
            //Enable - false: edtPartnerLogo.Image = new Bitmap(rep25991.ExtendedMethods.LogoCreater.CreateMemoryStram(currPartner.LT_V_MappingPartner.VMP_Image.ToArray()));

            value.V_CountryName = edtCountryName.Text;
            value.V_ContactPerson = edtContactInfo.Text;
            value.V_BronNumber = edtBronNumber.Text;
            value.V_DateBeg = edtDateBeg.Value.Date;
            value.V_DateEnd = edtDateEnd.Value.Date;
            edtService.Enabled = (CreatedVoucher.LT_V_Services.Count() == 1);
                
            value.LT_V_Services.FirstOrDefault().VS_Name = edtService.Text;

            IsProgramingEditService = false;
        }
        #endregion

        public frmCreateVoucher(sqlDataContext sqlDC, int dlKey, string tourName)
        {
            this.SqlDC = sqlDC;
            this.TourName = tourName;
            this.DLKey = dlKey;
            InitializeComponent();
        }

        private void frmCreateVoucher_Load(object sender, EventArgs e)
        {
            var currentDogovorService = SqlDC.tbl_DogovorLists.FirstOrDefault(x=>x.DL_KEY == DLKey);

            CreatedVoucher = HelperVoucherCreated.CreateVoucher(SqlDC, currentDogovorService.DL_PARTNERKEY, currentDogovorService.DL_CNKEY, currentDogovorService.tbl_Dogovor.DG_Key);
            CreatedVoucher.V_TourName = TourName;

            CreatedVoucher.SetPersonToVoucher(SqlDC, currentDogovorService.TuristServices.Select(x=>x.tbl_Turist).ToArray());
            HelperVoucherCreated.helperVoucherService hvs = new HelperVoucherCreated.helperVoucherService(currentDogovorService, null);
            CreatedVoucher.SetServiceToVoucher(SqlDC, new HelperVoucherCreated.helperVoucherService[] { hvs });

            SetPropertyToEditor(CreatedVoucher);
        }

        private void edtService_TextChanged(object sender, EventArgs e)
        {
            if (!IsProgramingEditService)
            {
                tsBtnCreate.Enabled = false;
                tsBtnSplit.Enabled = true;
            }
        }

        private void tsBtnSplit_Click(object sender, EventArgs e)
        {
            edtService.Text = string.Join("\r\n", ServiceAW.WordwrapToArray(edtService.Text));

            tsBtnCreate.Enabled = true;
            tsBtnSplit.Enabled = false;
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            CreatedVoucher.V_CountryName = edtCountryName.Text.Trim();
            CreatedVoucher.V_ContactPerson = edtContactInfo.Text.Trim();
            CreatedVoucher.V_BronNumber = edtBronNumber.Text.Trim();
            if (CreatedVoucher.LT_V_Services.Count() == 1)
            {
                var fService = CreatedVoucher.LT_V_Services.FirstOrDefault();
                fService.Autoformat = false;
                fService.VS_Name = edtService.Text;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
