using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor.TypeDogovorsManagement
{
    public partial class frmCreateModDogovorType : Form
    {
        #region Свойства
        private PartnersListDataContext PLDC;
        private PrtDogTypes PrtDogType;

        private enum enDogovorType
        {
            Агентский,
            Доп_соглашение,
            Другой
        }

        public class ATItem
        {
            public string Name;
            public int ID;

            public ATItem(PrtType value)
            {
                Name = value.PT_Name;
                ID = value.PT_Id;
            }

            public override string ToString()
            {
                return Name;
            }
        }
        #endregion

        #region Конструктор
        public frmCreateModDogovorType(PartnersListDataContext pldc)
        {
            PLDC = pldc;
            InitializeComponent();

            foreach (var item in (PrtDogTypes.enAgencyType[])Enum.GetValues(typeof(PrtDogTypes.enAgencyType)))
            {
                if (item != PrtDogTypes.enAgencyType.Все)
                    edtGroupe.Items.Add(item);
            }

            foreach (var item in (enDogovorType[])Enum.GetValues(typeof(enDogovorType)))
            {
                edtType.Items.Add(item);
            }

            edtActiveType1.Items.Add("нет");
            edtActiveType2.Items.Add("нет");
            edtActiveType3.Items.Add("нет");

            foreach (var item in pldc.PrtTypes.OrderBy(x => x.PT_Id).Select(x => new ATItem(x)))
            {
                edtActiveType1.Items.Add(item);
                edtActiveType2.Items.Add(item);
                edtActiveType3.Items.Add(item);
            }

            edtAccess.Items.AddRange(new string[] { "LTP_AC_Dog_Agency", "LTP_AC_Dog_FIT", "LTP_AC_Dog_AviaZD", "LTP_AC_Dog_Cruize" });
        }

        public frmCreateModDogovorType(PartnersListDataContext pldc, PrtDogTypes pdt)
            : this(pldc)
        {
            PrtDogType = pdt;
            edtName.Text = PrtDogType.PDT_Name;
            edtNumberKey.Text = PrtDogType.LTP_DogType.LDT_Key;
            edtType.SelectedItem = (PrtDogType.LTP_DogType.LDT_IsRoot
                ? enDogovorType.Агентский
                : PrtDogType.LTP_DogType.LDT_IsChield
                    ? enDogovorType.Доп_соглашение
                    : enDogovorType.Другой);

            edtActiveType1.SelectedIndex = 0;
            edtActiveType2.SelectedIndex = 0;
            edtActiveType3.SelectedIndex = 0;

            if (PrtDogType.LTP_DogType.LDT_ActivePrtType1.HasValue)
            {
                foreach (var item in edtActiveType1.Items)
                {
                    if (item is ATItem && ((ATItem)item).ID == PrtDogType.LTP_DogType.LDT_ActivePrtType1.Value)
                    {
                        edtActiveType1.SelectedItem = item;
                        break;
                    }
                }
            }
            if (PrtDogType.LTP_DogType.LDT_ActivePrtType2.HasValue)
            {
                foreach (var item in edtActiveType2.Items)
                {
                    if (item is ATItem && ((ATItem)item).ID == PrtDogType.LTP_DogType.LDT_ActivePrtType2.Value)
                    {
                        edtActiveType2.SelectedItem = item;
                        break;
                    }
                }
            }
            if (PrtDogType.LTP_DogType.LDT_ActivePrtType3.HasValue)
            {
                foreach (var item in edtActiveType3.Items)
                {
                    if (item is ATItem && ((ATItem)item).ID == PrtDogType.LTP_DogType.LDT_ActivePrtType3.Value)
                    {
                        edtActiveType3.SelectedItem = item;
                        break;
                    }
                }
            }

            edtBlocked.Checked = PrtDogType.LTP_DogType.LDT_IsDisable;
            edtGroupe.SelectedItem = (PrtDogTypes.enAgencyType)PrtDogType.LTP_DogType.LDT_GroupID;
            edtAccess.SelectedItem = PrtDogType.LTP_DogType.LDT_Permission;
            if (ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() != "sa" &&
                ltp_v2.Framework.SqlConnection.ConnectionUserName.ToLower() != "sysadm")
            {
                edtAccess.Enabled = false;
                edtNumberKey.Enabled = false;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (PLDC.PrtDogTypes.Count(x =>
                x.PDT_ID != PrtDogType.PDT_ID &&
                x.PDT_Name.ToLower() == PrtDogType.PDT_Name.ToLower().Trim()) > 0)
            {
                MessageBox.Show("Есть договора с таким-же названием, сохранение отменено");
                return;
            }

            if (PLDC.LTP_DogTypes.Count(x=>
                x.LDT_PDTID != PrtDogType.PDT_ID &&
                x.LDT_Key.ToLower() == edtNumberKey.Text.ToLower().Trim()) > 0)
            {
                MessageBox.Show("Есть договора с таким-же кодом номера, сохранение отменено");
                return;
            }
            if (edtName.Text.Trim() == "")
            {
                MessageBox.Show("Заполните название");
                return;
            }
            if (edtNumberKey.Text.Trim() == "")
            {
                MessageBox.Show("Заполните ключ номер");
                return;
            }
            if (edtType.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип");
                return;
            }
            if (edtActiveType1.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите 1-ый тип партнера при активации");
                return;
            }
            if (edtActiveType2.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите 2-ой тип партнера при активации");
                return;
            }
            if (edtActiveType3.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите 3-ий тип партнера при активации");
                return;
            }
            if (edtGroupe.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите группу договора");
                return;
            }
            if (edtAccess.SelectedIndex < 0)
            {
                MessageBox.Show("Выберите право доступа");
                return;
            }

            LTP_DogType ltpDogType;

            if (PrtDogType == null)
            {
                PrtDogType = new PrtDogTypes();
                PLDC.PrtDogTypes.InsertOnSubmit(PrtDogType);
                ltpDogType = new LTP_DogType();
                PrtDogType.LTP_DogType = ltpDogType;
            }
            
            PrtDogType.PDT_Name = PrtDogType.PDT_NameLat = edtName.Text.Trim();
            PrtDogType.PDT_NDS = null;
            PrtDogType.PDT_Type = 0;
            PrtDogType.PDT_SimpleTax = null;
            PrtDogType.PDT_CourseDay = 0;
            PrtDogType.PDT_CourseType = 0;
            PrtDogType.PDT_Percent = null;

            ltpDogType = PrtDogType.LTP_DogType;

            ltpDogType.LDT_Key = edtNumberKey.Text.Trim();
            ltpDogType.LDT_DefUseMonth = 12;
            ltpDogType.LDT_IsRoot = ((enDogovorType)edtType.SelectedItem) == enDogovorType.Агентский;
            ltpDogType.LDT_IsChield = ((enDogovorType)edtType.SelectedItem) == enDogovorType.Доп_соглашение;
            ltpDogType.LDT_ActivePrtType1 = (edtActiveType1.SelectedIndex == 0 ? null : (int?)((ATItem)edtActiveType1.SelectedItem).ID);
            ltpDogType.LDT_ActivePrtType2 = (edtActiveType2.SelectedIndex == 0 ? null : (int?)((ATItem)edtActiveType2.SelectedItem).ID);
            ltpDogType.LDT_ActivePrtType3 = (edtActiveType3.SelectedIndex == 0 ? null : (int?)((ATItem)edtActiveType3.SelectedItem).ID);
            ltpDogType.LDT_IsDisable = edtBlocked.Checked;
            ltpDogType.LDT_GroupID = (int)((PrtDogTypes.enAgencyType)edtGroupe.SelectedItem);
            ltpDogType.LDT_Permission = edtAccess.Text;
            PLDC.SubmitChanges();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
