using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;
using System.Windows;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmSendToCourier : Form
    {
        private static string messageDogNum = "Введите № договора";
        private PartnersListDataContext PLDC;

        public class PacketListItem
        {
            [DisplayName("№ Пакета")]
            public int PacketNumber {get;set;}
        }

        List<PacketListItem> outList = new List<PacketListItem>();

        public frmSendToCourier()
        {
            InitializeComponent();
            PLDC = new AgencyManager.ObjectModel.PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
        }

        #region Методы
        private void SetDataSource(object source)
        {
            tsBtnActivate.Enabled = false;

            if (outList.Count > 0)
                tsBtnActivate.Enabled = true;

            DogovorsDGV.DataSource = null;
            DogovorsDGV.DataSource = outList;
        }
        #endregion

        #region Обработка событий
        private void edtDogovorNum_TextChanged(object sender, EventArgs e)
        {
            if (edtPacketNum.Text == messageDogNum)
                edtPacketNum.ForeColor = Color.Gray;
            else
                edtPacketNum.ForeColor = SystemColors.ControlText;
        }

        private void edtDogovorNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (edtPacketNum.Text == messageDogNum)
            {
                edtPacketNum.SelectAll();
            }
        }

        private void edtDogovorNum_KeyUp(object sender, KeyEventArgs e)
        {
            int fltPkgNum = 0;
            if (!int.TryParse(edtPacketNum.Text, out fltPkgNum))
                return;

            if (edtPacketNum.Text.Trim() == "")
            {
                edtPacketNum.Text = messageDogNum;
                return;
            }

            if (e.KeyCode != Keys.Enter || edtPacketNum.Text.Length < 4 || edtPacketNum.Text == messageDogNum)
                return;

            edtPacketNum.SelectAll();

            var findingPkgsNumber = PLDC.LTP_PrtDogPacks.Where(x => x.LTPP_Number == fltPkgNum).Select(x=>x.LTPP_Number).Distinct();

            if (outList.Count(x => x.PacketNumber == fltPkgNum) > 0)
                return;

            if (findingPkgsNumber.Count() == 0)
            {
                MessageBox.Show("Запрошенный пакет №" + edtPacketNum.Text + " в базе данных не найден");
                edtPacketNum.Text = messageDogNum;
                return;
            }
            Courier_Sync.sync sync = new Courier_Sync.sync();
            if (!sync.CheckConnection())
            {
                MessageBox.Show("Нет подключения к базе данных, ошибка получения данных");
                return;
            }
            if (sync.CheckPacketSend(fltPkgNum.ToString())) 
            {
                MessageBox.Show("Запрошенный пакет №" + edtPacketNum.Text + " уже передан");
                edtPacketNum.Text = messageDogNum;
                return;
            }

            foreach (var dog in findingPkgsNumber)
            {
                if (!outList.Any(x => x.PacketNumber == dog))
                {
                    PacketListItem newDli = new PacketListItem() { PacketNumber = dog};
                    outList.Add(newDli);
                    edtPacketNum.Text = messageDogNum;
                }
            }

            SetDataSource(outList);
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void tsBtnActivate_Click(object sender, EventArgs e)
        {
            ltp_v2.Controls.Forms.lwWaitScreen lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
            lwWaitScreen.Show();
           
            Courier_Sync.sync sync = new Courier_Sync.sync();
            var userInfo = ltp_v2.Framework.SqlConnection.ConnectionUserInformation;
            if (!sync.CheckConnection())
            {
                MessageBox.Show("Нет подключения к базе данных, ошибка передачи данных");
                return;
            }
            int ClientID = sync.CheckClients(userInfo.US_NAME + " " + userInfo.US_FNAME + " " + userInfo.US_SNAME);
            if (ClientID == 0)
            {
                MessageBox.Show("Ошибка получения данных о пользователе");
                return;
            }

            var address = sync.CreateNewAddressByZakaz(ClientID);
            foreach (var q in outList)
            {
                sync.InsertItemsToAddress(address, q.PacketNumber.ToString());
                foreach (var prtDog in PLDC.LTP_PrtDogPacks.Where(x => x.LTPP_Number == q.PacketNumber).Select(x=>x.LTP_PrtDog))
                {
                    foreach (var unicalPrtDog in PLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == prtDog.LTPD_DogNum))
                    {
                        LTP_Journal journal = new LTP_Journal();
                        journal.LDJ_Comment = "";
                        journal.LDJ_LRJId = 15;
                        journal.LDJ_LTPDKey = unicalPrtDog.LTPD_Key;
                        journal.LDJ_PRKey = unicalPrtDog.LTPD_PRKey;
                        journal.LDJ_Comment = "Пакет № " + q.PacketNumber.ToString();
                        PLDC.LTP_Journals.InsertOnSubmit(journal);
                    }
                }
            }
            PLDC.SubmitChanges();
            outList.Clear();
            SetDataSource(outList);
            lwWaitScreen.Close();
        }
        #endregion
    }
}
