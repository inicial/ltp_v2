using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Rep22341
{
    public partial class frmPrint : Form
    {
        #region Вспоммогательные классы
        private class helperPrtObjectItem
        {
            public ExportVariants.VariantsEXType VarEXType = ExportVariants.VariantsEXType.None;
            public Type ObjectType;
            public string Name = "";

            public helperPrtObjectItem(Type value)
            {
               this.ObjectType = value;
               var q = value.GetCustomAttributes(typeof(DisplayNameAttribute), false);
               if (q.Count() > 0)
                   this.Name = ((System.ComponentModel.DisplayNameAttribute)(q[0])).DisplayName;

               var defaultValues = value.GetCustomAttributes(typeof(DefaultValueAttribute), false);
               if (defaultValues.Count() > 0)
               {
                   foreach (var defItemValue in defaultValues)
                   {
                       VarEXType |= (ExportVariants.VariantsEXType)((System.ComponentModel.DefaultValueAttribute)defItemValue).Value;
                   }
               }
            }

            public override string ToString()
            {
                return this.Name;
            }
        }
        #endregion

        private enum PayedType
        {
            Полная_оплата = 0,
            Частичная_оплата = 1,
            Неоплачено = 2,
            Все = 3
        }
        
        #region Свойства
        private sqlDataContext sqlDC;
        private DateTime TurDate;
        private int[] CharterKeys;
        private int[] AirServiceKeys;
        #endregion

        #region Конструктор
        public frmPrint(sqlDataContext sqlDC, DateTime turDate, int[] charterKeys, int[] airServiceKeys)
        {
            this.sqlDC = sqlDC;
            this.TurDate = turDate;
            this.CharterKeys = charterKeys;
            this.AirServiceKeys = airServiceKeys;

            InitializeComponent();
        }
        #endregion

        private void frmPrint_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string nameSpace = "Rep22341.ExportVariants";
            cbExportType.Items.Clear();
            var q = assembly.GetTypes()
                .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.OrdinalIgnoreCase))
                .Where(x => x.BaseType == typeof(ExportVariants.IprtClass))
                .Select(x => new helperPrtObjectItem(x))
                .OrderBy(x => x.ToString())
                .ToArray();

            foreach (var item in q)
            {
                cbExportType.Items.Add(item);
            }

            cbFilterPaidBilets.Items.Clear();
            foreach (var item in (PayedType[])Enum.GetValues(typeof(PayedType)))
            {
                cbFilterPaidBilets.Items.Add(item);
            }
            cbFilterPaidBilets.SelectedItem = PayedType.Все;

            cbFltHotelStateOK.Checked = false;
            cbFltNotUsedPersons.Checked = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbExportType.SelectedItem == null)
                return;
            var resTurist = (IQueryable<tbl_Turist>)sqlDC.tbl_Turists;

            #region Фильтрация по оплате
            if ((PayedType)cbFilterPaidBilets.SelectedItem != PayedType.Все)
            {
                var payedType = (PayedType)cbFilterPaidBilets.SelectedItem;
                resTurist = resTurist.Where(x =>
                    payedType == PayedType.Полная_оплата && x.tbl_Dogovor.DG_PAYED >= x.tbl_Dogovor.DG_PRICE ||
                    payedType == PayedType.Частичная_оплата && x.tbl_Dogovor.DG_PRICE > x.tbl_Dogovor.DG_PAYED && x.tbl_Dogovor.DG_PAYED > x.tbl_Dogovor.DG_PRICE * 0.5m ||
                    payedType == PayedType.Неоплачено && x.tbl_Dogovor.DG_PAYED <= x.tbl_Dogovor.DG_PRICE * 0.5m);
            }
            #endregion

            #region Фильтрация по подверженному отелю
            if (cbFltHotelStateOK.Checked)
            {
                resTurist = resTurist.Where(x =>
                    x.tbl_Dogovor.tbl_DogovorLists.Count(xDL =>
                        xDL.DL_SVKEY == 3 &&
                        xDL.DL_CONTROL != 0) > 0);
            }
            #endregion

            #region Фильтрация по экспортированным
            if (cbFltNotUsedPersons.Checked)
            {
                resTurist = resTurist.Where(x => !sqlDC.LTA_AviaOutTurists.Any(xQ => xQ.LTA_TUKey == x.TU_KEY));
            }
            #endregion

            #region Фильтрация по рейсу и классу
            var result = from xTU in resTurist
                         from xTD in sqlDC.TuristServices
                         from xDL in sqlDC.tbl_DogovorLists
                         where xTD.TU_TUKEY == xTU.TU_KEY &&
                                xTD.TU_DLKEY == xDL.DL_KEY &&
                                xDL.DL_SVKEY == 1 &&
                                xDL.DL_SUBCODE1.HasValue &&
                                xDL.DL_TURDATE.GetValueOrDefault(xDL.tbl_Dogovor.DG_TURDATE).Date.AddDays(xDL.DL_DAY.GetValueOrDefault(0) - 1) == TurDate.Date &&
                                CharterKeys.Contains(xDL.DL_CODE) &&
                                AirServiceKeys.Contains(xDL.DL_SUBCODE1.Value)
                         group xDL by new { xTU = xTU, DLKey = xDL.DL_KEY } into gr
                         select new ExportItem() { Turist = gr.Key.xTU, RootDLKey = gr.Key.DLKey, DogovorList = gr.Key.xTU.tbl_Dogovor.tbl_DogovorLists };
            
            if (!ExportToExcel(result))
                return;

            #endregion

            if (MessageBox.Show("Отметить туристов, как выписанные?", "Экспорт", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (var q in result)
                {
                    if (sqlDC.LTA_AviaOutTurists.Count(x => x.LTA_TUKey == q.Turist.TU_KEY) == 0)
                    {
                        LTA_AviaOutTurist aot = new LTA_AviaOutTurist();
                        aot.LTA_TUKey = q.Turist.TU_KEY;
                        aot.LTA_DLCode = q.FirstReis.DL_CODE;
                        aot.LTA_DLCode1 = q.FirstReis.DL_SUBCODE1;
                        aot.LTA_InsDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                        sqlDC.LTA_AviaOutTurists.InsertOnSubmit(aot);
                        
                        if (q.BackReis != null)
                        {
                            aot = new LTA_AviaOutTurist();
                            aot.LTA_TUKey = q.Turist.TU_KEY;
                            aot.LTA_DLCode = q.BackReis.DL_CODE;
                            aot.LTA_DLCode1 = q.BackReis.DL_SUBCODE1;
                            aot.LTA_InsDate = ltp_v2.Framework.SqlConnection.ServerDateTime;
                            sqlDC.LTA_AviaOutTurists.InsertOnSubmit(aot);
                        }
                    }
                }
            }
            sqlDC.SubmitChanges();
        }


        private bool ExportToExcel(IQueryable<ExportItem> exportItems)
        {
            if (exportItems.Count() == 0)
            {
                MessageBox.Show("Уважаемый(ая) " + ltp_v2.Framework.SqlConnection.ConnectionUserInformation.US_FNAME + " в выбранных вами параметрах, нет экспортируемых данных");
                return false;
            }

            var selItem = (helperPrtObjectItem)cbExportType.SelectedItem;

            ExportVariants.IprtClass ex = (ExportVariants.IprtClass)Activator.CreateInstance(selItem.ObjectType);
            if ((selItem.VarEXType & ExportVariants.VariantsEXType.SplitPartner) != 0)
                ex.Start(exportItems, cbSplitPartner.Checked);
            else
                ex.Start(exportItems);

            return true;
        }

        private void cbExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = (helperPrtObjectItem)cbExportType.SelectedItem;
            cbSplitPartner.Enabled = ((selItem.VarEXType & ExportVariants.VariantsEXType.SplitPartner) != 0);
        }
    }
}