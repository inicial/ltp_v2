using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using rep25991.ExtendedMethods.Convertation;
using rep25991.ExtendedMethods;
using rep25991.ExtendedMethods.AutoWrappingText;

namespace rep25991.Controls.Forms.Voucher
{
    public partial class frmCreateVoucherRiver : Form
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
        private SqlTSDataContext sqlTS;//= new SqlTSDataContext(ltp_v2.Framework.ApplicationConf.TSSqlConnection);
        public LT_V_Voucher CreatedVoucher;

        #region Методы
        private void SetPropertyToEditor(LT_V_Voucher value)
        {
            IsProgramingEditService = true;
            var addDL = SqlDC.mk_DogovorListAdds.First(x => x.tbl_dogovor_list_key == this.DLKey);
            //CreatedVoucher.V_DateBeg
            var option = SqlDC.mk_options.Where(x => x.OP_DLKEY == this.DLKey);
            int id = 0;
            mk_option op = null;
            foreach (mk_option mkOption in option)
            {
                 if (mkOption.OP_ID > id)
                 {
                     id = mkOption.OP_ID;
                     op = mkOption;
                 }
            }
            edtBronNumber.Text = op.OP_number.Trim();
            edtCabin.Text = op.OP_N_cabin;
            try
            {
                edtTypeAliment.Text = SqlDC.mk_actions_options.FirstOrDefault(x => x.actions_id == -110 && x.DL_key == this.DLKey).Text;
            }
            catch (Exception ex )
            {
                edtTypeAliment.Text = "";
               // Debug.Write(ex);
            }
            
            var ship =  sqlTS.Ships.First(x => x.code == addDL.shipcode && x.cruise_line_id == addDL.cl_id).name_ru;
            var currPartner = value.tbl_Partner;
            List<SeaPOrtAdress> portAdressList = new List<SeaPOrtAdress>();
            try
            {
                var portDeparture =
                    sqlTS.Itinerary_old_alls.OrderBy(x =>x.activityDate).ThenBy(c=>c.departure)
                         .First(x => x.package == addDL.Pacage && x.sailDate == value.V_DateBeg);
                edtPortDeparture.Text = portDeparture.locName;
                edtTimeDeparture.Text = portDeparture.departure;
                string mm = portDeparture.departure.Split(':')[1], hh = portDeparture.departure.Split(':')[0];
                hh =(int.Parse(hh)- 2).ToString();
                if (int.Parse(hh) < 0)
                {
                    hh = (24-int.Parse(hh)).ToString();
                }
                edtTimeRegistration.Text = hh + ":" + mm;
                //edtTimeRegistration.Text = portDeparture.departure
                try
                {
                    int? idGeneralPort = sqlTS.Seaports.First(x1 => x1.code == portDeparture.locCode && x1.id_crline == portDeparture.id_crline).parent;
                    var portAdressArray =
                        sqlTS.SeaPOrtAdresses.Where(x => x.PA_SPID == idGeneralPort);

                    portAdressList = new List<SeaPOrtAdress>(portAdressArray);
                    edtAdressPort.DataSource = portAdressList;
                    try
                    {
                        var portId = sqlTS.CruiseTerminals.First(x => x.pacage == addDL.Pacage.Trim() && x.saildate == value.V_DateBeg);
                        //int idAdress=0;
                        edtAdressPort.DataSource = portAdressList;
                        if (portId != null)
                        {
                            int idAdress = portId.ID_terminal;
                            edtAdressPort.Text = portAdressList.First(x => x.PA_ID == idAdress).ToString();
                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }


                }
                catch (Exception)
                {


                }
            }
            catch (Exception ex )
            {
                edtPortDeparture.Text = "";
                edtTimeDeparture.Text = "";
                edtTimeRegistration.Text = "";
                edtItinerary.Text = "";
                edtAdressPort.Text = "";
            }

            //edtTourName.Text = value.V_TourName;
            edtPartnerName.Text = value.V_PartnerName;
            edtPartnerContact.Text = value.V_PartnerContact;
            edtPartnerLogo.Image = new Bitmap(rep25991.ExtendedMethods.LogoCreater.CreateMemoryStram(currPartner.LT_V_MappingPartner.VMP_Image.ToArray()));
            edtShip.Text = ship;
            try
            {            
                string regionCode = sqlTS.CRUISEs.First(x => x.package == addDL.Pacage && x.sailDate == value.V_DateBeg).regionCode;
                string regionName = sqlTS.Regions.First(x => x.code == regionCode).name_ru;
                var dlLine = SqlDC.tbl_DogovorLists.First(x => x.DL_KEY == this.DLKey);
                edtCountryName.Text = regionName + ", " + dlLine.DL_NDAYS.ToString() + " ночей";
            }
            catch (Exception)
            {

                edtCountryName.Text = "";
            }

                //sqlTS.CRUISES_serches.First(x => x.package == addDL.Pacage && x.sailDate == value.V_DateBeg).cruiseName;
           // edtCountryName.Text = value.V_CountryName;
            edtContactInfo.Text = value.V_ContactPerson;
            //edtBronNumber.Text = value.V_BronNumber;
            edtDateBeg.Value = value.V_DateBeg;
            edtDateEnd.Value = value.V_DateEnd;

           // List<SeaPOrtAdress> portAdressList=new List<SeaPOrtAdress>();
            string itinerary = "";
            try
            {
                var ports = sqlTS.Itinerary_old_alls.OrderBy(x => x.activityDate).ThenBy(c => c.departure)
              .Where(x => x.package == addDL.Pacage && x.sailDate == value.V_DateBeg);
                foreach (Itinerary_old_all itineraryOldAll in ports)
                {
                    if (string.IsNullOrEmpty(itinerary))
                    {
                        itinerary = itineraryOldAll.locName;
                    }
                    else
                    {
                        itinerary += " | " + itineraryOldAll.locName;
                    }
                }
                edtItinerary.Text = itinerary;

            }
            catch (Exception)
            {

                edtItinerary.Text = "";
            }
     
            
            
            
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
        
        public frmCreateVoucherRiver(sqlDataContext sqlDC,SqlTSDataContext sqlTS, int dlKey, string tourName)
        {
            this.SqlDC = sqlDC;
            this.TourName = tourName;
            this.DLKey = dlKey;
            this.sqlTS = sqlTS;
          
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
            CreatedVoucher.V_TourName = edtCountryName.Text.Trim();
            CreatedVoucher.V_ContactPerson = edtContactInfo.Text.Trim();
            CreatedVoucher.V_BronNumber = edtBronNumber.Text.Trim();
            CreatedVoucher.V_PortDeparture = edtPortDeparture.Text.Trim();
            CreatedVoucher.V_TimeDeparture = edtTimeDeparture.Text.Trim().Replace('-', ':').Replace(' ', ':');
            CreatedVoucher.V_TimeRegistration = edtTimeRegistration.Text.Trim().Replace('-', ':').Replace(' ', ':');
            CreatedVoucher.V_Ship = edtShip.Text.Trim();
            CreatedVoucher.V_Cabin = edtCabin.Text.Trim();
            CreatedVoucher.V_TypeAliment = edtTypeAliment.Text.Trim();
            CreatedVoucher.V_PortAdress = edtAdressPort.Text.Trim();
            CreatedVoucher.V_Itinerary = edtItinerary.Text.Trim();
            if (CreatedVoucher.LT_V_Services.Count() == 1)
            {
                var fService = CreatedVoucher.LT_V_Services.FirstOrDefault();
                fService.Autoformat = false;
                fService.VS_Name = edtService.Text;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
