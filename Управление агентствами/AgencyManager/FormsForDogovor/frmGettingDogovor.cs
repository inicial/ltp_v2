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
    public partial class frmGettingDogovor : Form
    {
        #region Вспомогательные классы
        private class helperDogList
        {
            public LTP_PrtDog[] CurrentDogs;

            [DisplayName("№ Договора")]
            public string DogovorNumber { get; set; }

            [DisplayName("Тип получения")]
            public string TypeGetDogovor { get; set; }

            [DisplayName("Партнер")]
            public string Partner { get; set; }
        }
        #endregion

        #region Свойства
        private ObjectModel.PartnersListDataContext prtLDC;
        private List<helperDogList> helperDL = new List<helperDogList>();
        #endregion 

        public frmGettingDogovor()
        {
            InitializeComponent();
            prtLDC = new ObjectModel.PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            edtGetType.SelectedIndex = 0;
        }

        private void edtFindingDogovor_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var fDogovors = prtLDC.LTP_PrtDogs.Where(x => x.LTPD_DogNum == edtFindingDogovor.Text);
                if (fDogovors.Count() > 0)
                {
                    var rootDogovor = fDogovors.FirstOrDefault(x => x.tbl_Partners.PrtTypesToPartners.Count(xptp => xptp.PTP_PTId == 1027) > 0);
                    if (rootDogovor == null)
                        rootDogovor = fDogovors.FirstOrDefault();

                    if (!helperDL.Any(x => x.DogovorNumber == rootDogovor.LTPD_DogNum))
                    {
                        helperDL.Add(new helperDogList()
                        {
                            CurrentDogs = fDogovors.ToArray(),
                            DogovorNumber = rootDogovor.LTPD_DogNum,
                            TypeGetDogovor = edtGetType.Text + ", кол-во экз: " + edtCountCopy.Value.ToString(),
                            Partner = rootDogovor.tbl_Partners.PR_FULLNAME
                        });
                    }
                    ResultListDGV.DataSource = null;
                    ResultListDGV.DataSource = helperDL;
                }
                edtFindingDogovor.SelectAll();
            }
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            foreach (var itemHDL in helperDL)
            {
                foreach (var itemDog in itemHDL.CurrentDogs)
                {
                    LTP_Journal newJournal = new LTP_Journal()
                    {
                        LDJ_Comment = itemHDL.TypeGetDogovor,
                        LDJ_LRJId = 18,
                        LDJ_LTPDKey = itemDog.LTPD_Key,
                        LDJ_PRKey = itemDog.LTPD_PRKey
                    };
                    prtLDC.LTP_Journals.InsertOnSubmit(newJournal);
                }
            }
            prtLDC.SubmitChanges();
            
            helperDL.Clear();
            ResultListDGV.DataSource = null;
            ResultListDGV.DataSource = helperDL;

            MessageBox.Show("Договора добавлены");
        }

        private void tsBtnDelDog_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow itemSelRow in ResultListDGV.SelectedRows)
            {
                var hdl = (helperDogList)itemSelRow.DataBoundItem;
                helperDL.Remove(hdl);
            }

            ResultListDGV.DataSource = null;
            ResultListDGV.DataSource = helperDL;
            MessageBox.Show("Договора удалены");
        }
    }
}
