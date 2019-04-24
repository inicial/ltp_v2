using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using rep25991.ExtendedMethods.AutoWrappingText;

namespace rep25991.Report
{
    public partial class ReportGenerator : Form
    {
        #region Свойства
        private LT_V_Voucher[] valuesPrint;
        private sqlDataContext SqlDC;
        private bool IsConsult;
        private bool UseOnlyHotel;
        #endregion

        private HelperReport CreateHeader(LT_V_Voucher value)
        {
            HelperReport hr = new HelperReport();
            hr.CountryName = value.V_CountryName;
            string parnertString = value.V_PartnerName + "\r\n" + value.V_PartnerContact;
            if (PartnerAW.WordwrapToArray(value.V_PartnerName).Length > 1)
                parnertString = value.V_PartnerName + ": " + value.V_PartnerContact;
            string[] ArrayPartner = PartnerAW.WordwrapToArray(parnertString).RemoveBlankLines();

            hr.PartnerLine1 = ArrayPartner.Length > 0 ? ArrayPartner[0] : "";
            hr.PartnerLine2 = ArrayPartner.Length > 1 ? ArrayPartner[1] : "";
            hr.PartnerLine3 = ArrayPartner.Length > 2 ? ArrayPartner[2] : "";

            hr.Logotip = value.tbl_Partner.LT_V_MappingPartner.VMP_Image.ToArray();

            hr.PersonsCount = value.LT_V_Persons.Count();
            hr.ContactPerson = value.V_ContactPerson;
            hr.TravelDates = value.V_DateBeg.ConvertToMyFormat(value.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat)
                + " - " + value.V_DateEnd.ConvertToMyFormat(value.tbl_Partner.LT_V_MappingPartner.VMP_DateFormat) + " " +
                (value.V_Reis.RemoveSpace());
            hr.TourName = value.V_TourName;
            hr.VoucherNum = value.V_Number;
            hr.DogovorNum = value.V_BronNumber;

            return hr;
        }

        private List<HelperReport> GetListReport(LT_V_Voucher[] value)
        {
            List<HelperReport> result = new List<HelperReport>();
            foreach (LT_V_Voucher item in value)
            {
                List<string> Persons = new List<string>();
                Persons.AddRange(PersonAW.WordwrapToArray(String.Join("\r\n", item.LT_V_Persons.Select(x => x.VT_Name).ToArray())));

                while (Persons.Count > 0)
                {
                    List<string> Services = new List<string>();
                    var fltServices = item.LT_V_Services.Where(x => x.VS_Id != -1);
                    if (UseOnlyHotel)
                        fltServices = fltServices.Where(x => x.tbl_DogovorList != null && (x.tbl_DogovorList.DL_SVKEY == 3 || x.tbl_DogovorList.DL_SVKEY == 3149));

                    Services.AddRange(ServiceAW.WordwrapToArray(string.Join("\r\n", fltServices.OrderBy(x => x.VS_PrintLine).Select(x => x.VS_Name).ToArray())));
                    while (Services.Count > 0)
                    {
                        HelperReport hr = CreateHeader(item);
                        result.Add(hr);
                        hr.PersonLine1 = (Persons.Count > 0 ? Persons[0] : "");
                        hr.PersonLine2 = (Persons.Count > 1 ? Persons[1] : "");
                        hr.PersonLine3 = (Persons.Count > 2 ? Persons[2] : "");
                        hr.PersonLine4 = (Persons.Count > 3 ? Persons[3] : "");

                        if (item.tbl_Dogovor != null 
                            && item.tbl_Dogovor.DG_PRICE - item.tbl_Dogovor.DG_PAYED > 2
                            && !SqlDC.LTV_AccessDogovors.Any(x=>x.VDG_DGCod == item.tbl_Dogovor.DG_CODE)
                            || IsConsult)
                        {
                            Services.Insert(0, "Только для консульств | Only for Consulates");
                        }

                        hr.ServiceLine1 = (Services.Count > 0 ? Services[0] : "");
                        hr.ServiceLine2 = (Services.Count > 1 ? Services[1] : "");
                        hr.ServiceLine3 = (Services.Count > 2 ? Services[2] : "");
                        hr.ServiceLine4 = (Services.Count > 3 ? Services[3] : "");
                        hr.ServiceLine5 = (Services.Count > 4 ? Services[4] : "");
                        Services.RemoveRange(0, Math.Min(Services.Count, 5));
                    }
                    Persons.RemoveRange(0, Math.Min(Persons.Count, 4));
                }
            }
            return result;
        }

        #region Конструктор
        public ReportGenerator(sqlDataContext sqlDC, LT_V_Voucher[] value, bool IsPreview, bool isConsult, bool useOnlyHotel)
        {
            this.IsConsult = isConsult;
            this.UseOnlyHotel = useOnlyHotel;
            this.SqlDC = sqlDC;
            InitializeComponent();

            valuesPrint = value;
            var reports = GetListReport(value);
            this.reportViewer1.Print += new ReportPrintEventHandler(reportViewer1_Print);
            
            if (IsPreview)
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "rep25991.Report.Voucher_preview.rdlc";
                this.reportViewer1.ShowPrintButton = (ltp_v2.Framework.SqlConnection.ConnectionUserName == "sysadm");
                this.reportViewer1.ShowProgress = true;
                tsMenu.Visible = true;
            }
            else
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "rep25991.Report.Voucher_print.rdlc";
                this.reportViewer1.ShowPrintButton = true;
                this.reportViewer1.ShowExportButton = false;
                this.reportViewer1.ShowProgress = true;
                tsMenu.Visible = false;
            }

            ReportDataSource item = new ReportDataSource();
            item.Name = "dsHelperReport";
            item.Value = reports;
            this.reportViewer1.LocalReport.DataSources.Add(item);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
        }
        #endregion

        void reportViewer1_Print(object sender, ReportPrintEventArgs e)
        {
            if (!IsConsult)
            {
                DateTime printDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                foreach (var q in valuesPrint)
                {
                    q.V_PrintDate = printDate;
                }
            }
        }

        private void ReportGenerator_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void tsBtnCreate_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}