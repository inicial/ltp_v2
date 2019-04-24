using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmDogovorShablonManagement : Form
    {
        #region Свойства
        PartnersListDataContext PLDC;
        #endregion

        #region Конструктор
        public frmDogovorShablonManagement()
        {
            InitializeComponent();
            PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            edtDogovorType.DataSource = PLDC.PrtDogTypes.SetPermissionFilter().OrderBy(x => x.PDT_Name);
            edtDogovorType.ValueMember = "PDT_ID";
            edtDogovorType.DisplayMember = "PDT_Name";
            edtDogovorType.SelectedIndex = 0;
        }
        #endregion


        private void edtDogovorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tsBtnEdit.Enabled = tsBtnAdd.Enabled = edtDogovorType.SelectedItem != null;
            if (edtDogovorType.SelectedItem != null)
            {
                PrtDogTypes SelectedDT = (PrtDogTypes)edtDogovorType.SelectedItem;
                tsBtnEdit.Enabled = SelectedDT.LTP_DogType != null;
                if (SelectedDT.LTP_DogType != null)

                    listBox1.DataSource = SelectedDT.LTP_DogType.PrtDogTypesSources
                        .Where(
                            x => x.LPDS_Source != null
                        ).OrderByDescending(x => x.LPDS_InsertDate).ToList();
                else
                    listBox1.DataSource = null;
            }
            else
            {
                listBox1.DataSource = null;
            }
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            string pathToShablon = "";
            PrtDogTypesSource dts = (PrtDogTypesSource)listBox1.SelectedItem;
            var typeDog = (dts != null ? dts.LPDS_Id : 0);
            pathToShablon = ltp_v2.Framework.MasterValue.PathToOutDoc + "shb-" + typeDog + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";

            if (typeDog == 0 || typeDog != 0 && MessageBox.Show("Создать договор на основе выбранного?", "Новый договор", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                var sw = new System.IO.StreamWriter(pathToShablon);
                sw.WriteLine();
                sw.Close();
                sw.Dispose();
            }
            else
            {
                System.IO.File.WriteAllBytes(pathToShablon, dts.LPDS_Source.ToArray());
            }



            if (new TypeDogovorsManagement.frmModifyShablon(pathToShablon).ShowDialog() == DialogResult.OK)
            {
                PrtDogTypes SelectedDT = (PrtDogTypes)edtDogovorType.SelectedItem;
                byte[] Source = System.IO.File.ReadAllBytes(pathToShablon);

                dts = new PrtDogTypesSource();
                dts.LTP_DogType = SelectedDT.LTP_DogType;
                dts.LPDS_Source = Source;
                dts.LPDS_InsertDate = DateTime.Now.Date;
                PLDC.SubmitChanges();
            }

            /*
            byte[] Source = LoadDocument();
            if (Source == null)
                return;

            PrtDogTypes SelectedDT = (PrtDogTypes)edtDogovorType.SelectedItem;
            PrtDogTypesSource dts = new PrtDogTypesSource();
            dts.LTP_DogType = SelectedDT.LTP_DogType;
            dts.LPDS_Source = Source;
            dts.LPDS_InsertDate = DateTime.Now.Date;
            PLDC.SubmitChanges();
            edtDogovorType_SelectedIndexChanged(null, null);
            */
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            PrtDogTypesSource dts = (PrtDogTypesSource)listBox1.SelectedItem;
            if (Math.Abs((DateTime.Now - dts.LPDS_InsertDate).TotalDays) >= 2 &&
                ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() != "sysadm")
            {
                MessageBox.Show("Вы не можете изменить шаблон, созданный 2 или более дня назад");
                return;
            }
            string pathToShablon = ltp_v2.Framework.MasterValue.PathToOutDoc + "shb-" + dts.LPDS_Id + DateTime.Now.ToString("yyyyMMddHHmmss") + ".doc";
            System.IO.File.WriteAllBytes(pathToShablon, dts.LPDS_Source.ToArray());

            if (new TypeDogovorsManagement.frmModifyShablon(pathToShablon).ShowDialog() == DialogResult.OK)
            {
                byte[] Source = System.IO.File.ReadAllBytes(pathToShablon);
                dts.LPDS_Source = Source;
                PLDC.SubmitChanges();

            }
        }
    }
}
