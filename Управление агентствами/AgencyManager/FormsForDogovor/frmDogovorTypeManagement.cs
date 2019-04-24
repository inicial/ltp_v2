using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmDogovorTypeManagement : Form
    {
        #region Переменные
        private enum enViewState
        {
            Только_активные = 1,
            Все = 0
        }

        private enum enTypeDogovor
        {
            Агентские = 1,
            Доп_соглашения = 2,
            Другие_договора = 3,
            Все = 0
        }

        private PartnersListDataContext PLDC;
        #endregion

        #region Объекты
        public class dgvItem
        {
            public int ID { get; private set; }
            public string NumberKey { get; private set; }
            public string Name { get; private set; }
            public bool IsDisable { get; private set; }
            public int CountUsedDogovor { get; private set; }
            public PrtDogTypes PrtDogType;
            public dgvItem(PrtDogTypes value)
            {
                PrtDogType = value;
                ID = value.PDT_ID;
                Name = value.PDT_Name;
                IsDisable = value.LTP_DogType.LDT_IsDisable;
                CountUsedDogovor = Math.Max(value.LTP_PrtDogs.Count(), value.PrtDogss.Count());
                NumberKey = value.LTP_DogType.LDT_Key;
            }
        }
        #endregion

        #region Конструктор
        public frmDogovorTypeManagement()
        {
            PLDC = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            InitializeComponent();

            tsFltViewState.Items.Clear();
            foreach (var item in (enViewState[])Enum.GetValues(typeof(enViewState)))
            {
                tsFltViewState.Items.Add(item);
            }
            tsFltViewState.SelectedItem = enViewState.Только_активные;

            tsFltTypeDogovor.Items.Clear();
            foreach (var item in (enTypeDogovor[])Enum.GetValues(typeof(enTypeDogovor)))
            {
                tsFltTypeDogovor.Items.Add(item);
            }
            tsFltTypeDogovor.SelectedItem = enTypeDogovor.Агентские;

            tsFltAgencyType.Items.Clear();
            foreach (var item in (PrtDogTypes.enAgencyType[])Enum.GetValues(typeof(PrtDogTypes.enAgencyType)))
            {
                tsFltAgencyType.Items.Add(item);
            }
            tsFltAgencyType.SelectedItem = PrtDogTypes.enAgencyType.Все;
        }
        #endregion

        #region Обработка событий
        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            var res = PLDC.LTP_DogTypes.Select(x => x.PrtDogTypes);
            enViewState viewStates = (tsFltViewState.SelectedItem != null ? (enViewState)tsFltAgencyType.SelectedItem : enViewState.Все);
            enTypeDogovor typeDogovor  = (tsFltTypeDogovor.SelectedItem != null ? (enTypeDogovor)tsFltTypeDogovor.SelectedItem : enTypeDogovor.Все);
            PrtDogTypes.enAgencyType agencyType = (tsFltAgencyType.SelectedItem != null ? (PrtDogTypes.enAgencyType)tsFltAgencyType.SelectedItem : PrtDogTypes.enAgencyType.Все);

            switch (viewStates)
            {
                case enViewState.Только_активные:
                    res = res.Where(x => !x.LTP_DogType.LDT_IsDisable);
                    break;
            }

            switch (typeDogovor)
            {
                case enTypeDogovor.Агентские:
                    res = res.Where(x => x.LTP_DogType.LDT_IsRoot);
                    break;
                case enTypeDogovor.Доп_соглашения:
                    res = res.Where(x => x.LTP_DogType.LDT_IsChield);
                    break;
                case enTypeDogovor.Другие_договора:
                    res = res.Where(x => !x.LTP_DogType.LDT_IsRoot && !x.LTP_DogType.LDT_IsChield);
                    break;
            }

            if (agencyType != PrtDogTypes.enAgencyType.Все)
                res = res.Where(x=>x.LTP_DogType.LDT_GroupID ==(int)agencyType);

            DogovorTypesDGV.DataSource = res.OrderBy(x => x.PDT_Name).Select(x => new dgvItem(x));
            DogovorTypesDGV.Columns["ID"].Visible = false;
            DogovorTypesDGV.Columns["Name"].HeaderText = "Название";
            DogovorTypesDGV.Columns["IsDisable"].HeaderText = "Блокирован";
            DogovorTypesDGV.Columns["NumberKey"].HeaderText = "Ключ типа в номере";
            DogovorTypesDGV.Columns["CountUsedDogovor"].HeaderText = "Кол-во договоров";
        }
        #endregion

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (DogovorTypesDGV.SelectedRows.Count > 0)
            {
                new TypeDogovorsManagement.frmCreateModDogovorType(PLDC, ((dgvItem)DogovorTypesDGV.SelectedRows[0].DataBoundItem).PrtDogType).ShowDialog();
            }
        }

        private void tsBtnAdd_Click(object sender, EventArgs e)
        {
            new TypeDogovorsManagement.frmCreateModDogovorType(PLDC).ShowDialog();
        }
    }
}
