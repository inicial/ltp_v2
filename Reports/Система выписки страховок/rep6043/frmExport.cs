using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Framework;
using ltp_v2.Controls;

namespace rep6043
{
    public partial class frmExport : Form
    {
        public frmExport()
        {
            InitializeComponent();
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1);
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                dateTimePicker2.Value = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                dateTimePicker1.Value = dateTimePicker2.Value;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            MessageBox.Show("По завершению откроется Excel, а так же появится сообщение о завершние экспорта, нажмите ОК для продолжения");
            sqlDataContext sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            
            //Полный список созданных за перриод
            List<String> FilesPath = new List<string>();
            System.IO.StreamWriter SW = null;
            
            string LastRate = "";
            DateTime LastDate = DateTime.MinValue;

            var query = sqlDC.ExecuteQuery<ExtendedSql.helperExportQuery>(ExtendedSql.ExportQuery1.query, dateTimePicker1.Value.Date, dateTimePicker2.Value.Date);

            foreach (var IHItem in query
                .OrderBy(X => X.IN_PREMIUMTOTALRATE)
                .ThenBy(X => X.IN_NUMBER))
            {
                if (LastRate != IHItem.IN_PREMIUMTOTALRATE || SW == null)
                {
                    LastRate = IHItem.IN_PREMIUMTOTALRATE;
                    String FilePath = MasterValue.PathToOutDoc
                        + DateTime.Now.ToString("dd.MM.yyyy")
                        + "R6043_"
                        + LastRate + ".csv";
                    FilesPath.Add(FilePath);
                    if (SW != null)
                    {
                        SW.Close();
                        SW.Dispose();
                    }
                    SW = new System.IO.StreamWriter(FilePath, false);
                }

                SW.WriteLine(IHItem.IN_NUMBER
                    + ";" + IHItem.IN_DATE.ToString("dd.MM.yyyy")
                    + ";" + IHItem.IN_INSURED
                    + ";" + IHItem.countPersons
                    + ";" + IHItem.IN_DATESTART.ToString("dd.MM.yyyy")
                    + ";" + IHItem.IN_DATEEND.ToString("dd.MM.yyyy")
                    + ";" + IHItem.IN_PREMIUMTOTAL
                    + ";" + IHItem.RC_COURSE * IHItem.IN_PREMIUMTOTAL
                    + ";" + IHItem.RC_COURSE * IHItem.IN_PREMIUMTOTAL * (decimal)0.01
                    + ";" + (IHItem.IN_ANNULDATE.HasValue ? IHItem.IN_ANNULDATE.Value.ToString("dd.MM.yyyy") : "")
                    + ";" + IHItem.IN_PREMIUMTOTALRATE);
            }
            SW.Close();
            SW.Dispose();
            
            String FilePathFull = MasterValue.PathToOutDoc
                                    + DateTime.Now.ToString("dd.MM.yyyy")
                                    + "R6043_"
                                    + "Full" + ".csv";

            FilesPath.Add(FilePathFull);

            SW = new System.IO.StreamWriter(FilePathFull, false);
            
            foreach (INS_INSURANCE IHItem in sqlDC.INS_INSURANCEs
                .Where(X =>
                    X.IN_DATE.Date >= dateTimePicker1.Value.Date
                    && X.IN_DATE.Date <= dateTimePicker2.Value.Date)
                .OrderBy(X => X.IN_PREMIUMTOTALRATE)
                .OrderBy(X => X.IN_NUMBER))
            {
                foreach (INS_PERSON IPItem in IHItem.INS_PERSONs)
                {
                    string TerretoriesName = string.Join(",", IHItem.INS_TERRITORies.Select(x=>x.INS_COUNTRIES_ING.CI_NAME).Distinct().ToArray());

                    string RS_AddsToName = "";
                    string RiskCodes = "";
                    string A_Summ = "";
                    string A_Premium = "";
                    string A_Remark = "";

                    string B_Summ = "";
                    string B_Premium = "";

                    string D_Summ = "";
                    string D_Premium = "";
                    double D_Franchise = 0;

                    foreach (INS_CONDITION ICItem in IHItem.INS_CONDITIONs)
                    {
                        RS_AddsToName += (String.IsNullOrEmpty(ICItem.INS_RISK.RS_AddsToName)
                            ? "" : ICItem.INS_RISK.RS_AddsToName);

                        RiskCodes += ICItem.INS_RISK.RS_CODE.ToString();

                        if (ICItem.INS_RISK.RS_CODE != 'D')
                        {
                            List<int?> NotPartInUsedTerretory = IHItem.INS_TERRITORies.ToList().
                                NotPartInList<INS_TERRITORy, INS_TARIFF, int?>(
                                "IT_CIKEY", ICItem.INS_RISK.INS_TARIFFs.ToList(), "TR_CIKEY");

                            var dateUse = ICItem.INS_INSURANCE.IN_DATESTART.Date;
                            bool NeedRecalcOfDay = ICItem.INS_RISK.RS_CalcOfDay;
                            if (ICItem.INS_RISK.RS_CODE == 'A')
                            {
                                A_Remark = ICItem.INS_RISK.RS_AddsToName;
                                A_Summ = ICItem.CO_INSUREDSUM.ToString();
                                A_Premium = ((decimal)ICItem.CO_PREMIUMSUM * (decimal)ICItem.CO_COEF * (decimal)IPItem.Coef(dateUse) * (NeedRecalcOfDay ? (decimal)IHItem.IN_DURATION : 1)).ToString();
                            }
                            else if (ICItem.INS_RISK.RS_CODE == 'B')
                            {
                                B_Summ = ICItem.CO_INSUREDSUM.ToString();
                                B_Premium = ((decimal)ICItem.CO_PREMIUMSUM * (decimal)ICItem.CO_COEF * (decimal)IPItem.Coef(dateUse) * (NeedRecalcOfDay ? (decimal)IHItem.IN_DURATION : 1)).ToString();
                            }
                        }
                        else if (ICItem.INS_RISK.RS_CODE == 'D')
                        {
                            D_Summ = ICItem.CO_INSUREDSUM.ToString();
                            D_Premium = ((ICItem.CO_PREMIUMSUM / 100) * ICItem.CO_INSUREDSUM).ToString();
                            D_Franchise = ICItem.CO_FRANCHISE;
                        }
                    }

                    //TODO: rep6043 : Убранно так как вешает выгрузку
                    //if (!IHItem.IN_IsExport)
                    //    IHItem.IN_IsExport = true;

                    SW.WriteLine(
                        IHItem.IN_NUMBER // A
                        + ";" + IHItem.IN_DATE.ToString("dd.MM.yyyy") // B
                        + ";" + RiskCodes // C
                        + ";" + IPItem.IP_NAME + " " + IPItem.IP_FNAME //D
                        + ";" + IPItem.IP_BIRTHDAY.ToString("dd.MM.yyyy") //E
                        + ";" + (IPItem.tbl_Turist != null ? IPItem.tbl_Turist.TU_RealSex == 1 ? "F" : "M" : "") //F
                        + ";" + TerretoriesName //G
                        + ";" + IHItem.IN_DATESTART.ToString("dd.MM.yyyy") //H
                        + ";" + IHItem.IN_DATEEND.ToString("dd.MM.yyyy") //I
                        + ";" + IHItem.IN_DURATION //J
                        + ";" + A_Summ //K
                        + ";" + A_Premium //L
                        + ";" + "" //M
                        + ";" + B_Summ //N
                        + ";" + B_Premium //O
                        + ";" + "" //P
                        + ";" + "" //Q
                        + ";" + D_Summ //R
                        + ";" + D_Premium //S
                        + ";" + "" //T
                        + ";" + "" //U
                        + ";" + "" //V
                        + ";" + A_Remark //W
                        + ";" + (IHItem.IN_ANNULDATE == null ? "V" : "A") //X
                        + ";" + IHItem.IN_PREMIUMTOTALRATE //Y
                        + ";" + (D_Franchise == 15 ? 1 : 2).ToString() //Z
                        );
                }
            }
            SW.Close();
            SW.Dispose();

            foreach (string tmpFileName in FilesPath)
            {
                System.Diagnostics.Process.Start(tmpFileName);
            }

            MessageBox.Show("Экспорт завершен");

            sqlDC.SubmitChanges();
        }
    }
}
