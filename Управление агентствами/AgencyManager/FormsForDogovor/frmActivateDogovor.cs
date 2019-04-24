using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ltp_v2.Controls.Forms;
using AgencyManager.ObjectModel;
using ltp_v2.Framework;

namespace AgencyManager.FormsForDogovor
{
    public partial class frmActivateDogovor : Form
    {
        #region Вспомогательные структуры данных
        private class DogovorListItem
        {           
            /// <summary>
            /// Возможные статусы !! ВНИМЕНИЕ !! Эти статусы прописанны в тригер - LTP_PrtDog.LTP_PrtDog_History
            /// </summary>
            public static string[] ArrayStatusNormalActive = new string[] { "Принят", "1 Экземпляр", "Отказ" };
            public static string[] ArrayStatusFaxActive = new string[] { "E-Mail", "Факс" };

            private string _Comment = "";
            private int _PrtGroupID;
            private int _CountActivateDays;
            private string _NewActiveType;

            public LTP_PrtDog PrtDog;

            [DisplayName("Статус активации")]
            public string NewActiveType
            {
                get { return _NewActiveType; }
                set
                {
                    _NewActiveType = value;
                }
            }
            [DisplayName("Номер договора")]
            public string Number
            {
                get { return PrtDog.LTPD_DogNum; }
            }
            [DisplayName("Группа партнера")]
            public int PrtGroupID
            {
                get
                {
                    return _PrtGroupID;
                }
                set
                {
                    _PrtGroupID = value;
                }
            }
            [DisplayName("Текущий статус")]
            public string ActiveType
            {
                get
                {
                    return PrtDog.LTPD_PDKey != null ?
                        PrtDog.LTPD_TempActive
                            ? "до " + PrtDog.LTPD_DateStart.AddDays(PrtDog.LTPD_TempActiveCountDayUse).ToString("dd.MM.yyyy")
                            : "оригинал"
                        : "не актив";
                }
            }
            [DisplayName("Подписан")]
            public bool IsSigning
            {
                get { return PrtDog.LTPD_Signing.HasValue; }
            }
            [DisplayName("Название партнера")]
            public string ParnerName
            {
                get { return PrtDog.tbl_Partners.PR_NAME + " (" + PrtDog.tbl_Partners.PR_CITY + ")"; }
            }
            [DisplayName("Кол-во дней временной активации")]
            public int CountActivateDays
            {
                get
                {
                    return _CountActivateDays;
                }
                set
                {
                    _CountActivateDays = value;
                }
            }
            [DisplayName("Наличие коментария")]
            public bool PresentComment
            {
                get { return Comment != ""; }
            }

            public string Comment
            {
                get { return _Comment; }
                set
                {
                    _Comment = value;
                }
            }

            public int GetTotalDaysUseAfterCreate()
            {
                return (int)DateTime.Now.Subtract(PrtDog.LTPD_DateStart).TotalDays + (int)CountActivateDays;
            }

            public DogovorListItem(LTP_PrtDog value, bool IsTemporyActivate)
            {
                this.PrtDog = value;
                CountActivateDays = 7;
                _PrtGroupID = this.PrtDog.tbl_Partners.PR_PGKEY;
                _Comment = this.PrtDog.LTPD_Comment;
                if (System.Text.RegularExpressions.Regex.IsMatch(_Comment, @"/[А-Яа-я0-1 ]*/"))
                {
                    _NewActiveType = System.Text.RegularExpressions.Regex.Match(_Comment, @"/[А-Яа-я0-1 ]*/").Value.Replace("/", "");
                    if (IsTemporyActivate && !ArrayStatusFaxActive.Any(x => x == _NewActiveType))
                        _NewActiveType = ArrayStatusFaxActive[0];
                    else if (!IsTemporyActivate && !ArrayStatusNormalActive.Any(x => x == _NewActiveType))
                        _NewActiveType = ArrayStatusNormalActive[0];
                }
                else
                    _NewActiveType = (IsTemporyActivate
                        ? ArrayStatusFaxActive[0]
                        : ArrayStatusNormalActive[0]);
            }
        }
        #endregion

        #region Свойства
        private List<DogovorListItem> outList;
        private bool IsTemporyActivate = false;
        private static string messageDogNum = "Введите № договора";
        private PartnersListDataContext PLDC;
        #endregion

        #region Конструктор
        public frmActivateDogovor(bool isTemporyActivate)
        {
            InitializeComponent();
            this.Text = "Активация договора" + (isTemporyActivate ? " по копии" : " по оригиналу");

            this.PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);

            this.DialogResult = DialogResult.Cancel;

            edtDogovorNum.Text = messageDogNum;

            outList = new List<DogovorListItem>();

            this.IsTemporyActivate = isTemporyActivate;
        }
        #endregion

        #region Методы
        private void DeleteDogovorFromList(DogovorListItem[] delitedDLIArray)
        {
            DogovorListItem[] newArray = new DogovorListItem[outList.Count];
            outList.CopyTo(newArray);
            var newList = newArray.ToList();
            foreach (DataGridViewRow dgvr in DogovorsDGV.SelectedRows)
            {
                var searchingItem = newList.Where(x => x.Number == ((DogovorListItem)dgvr.DataBoundItem).Number);
                while (searchingItem.Count() > 0)
                {
                    newList.Remove(searchingItem.First());
                }
            }
            outList.Clear();
            newArray = new DogovorListItem[newList.Count];
            newList.CopyTo(newArray);
            outList = newArray.ToList();
            newArray = null;
            newList.Clear();
            newList = null;
            SetDataSource(outList);
        }

        private void SetDataSource(object source)
        {
            tsBtnActivate.Enabled = false;

            if (outList.Count > 0)
                tsBtnActivate.Enabled = true;

            DogovorsDGV.DataSource = null;
            DogovorsDGV.DataSource = outList;
        }

        private void ActivateDogovors()
        {
            if (outList.Count == 0)
            {
                MessageBox.Show("Нет договоров для активации");
                return;
            }

            // Выборка доп соглашений из списка
            var dopDogs = outList.Where(x => x.PrtDog.PrtDogTypes.LTP_DogType.LDT_IsChield);

            while (dopDogs.Count() > 0)
            {
                var dopDG = dopDogs.First();
                // Отсутствие основного в списке активированных
                var notPresentRootDogInActiveList = (outList.Count(x => x.PrtDog.LTPD_Key == dopDG.PrtDog.Parent_LTPD_Key.GetValueOrDefault(0)) == 0);
                var notActiveRootDog = (PLDC.LTP_PrtDogs.Count(x => x.LTPD_Key == dopDG.PrtDog.Parent_LTPD_Key.GetValueOrDefault(0) && x.LTPD_PDKey.HasValue && !x.LTPD_TempActive) == 0);
                var needDrop = false;

                if (IsTemporyActivate)
                {
                    if (MessageBox.Show("Вы не можете активировать по копии договор №" + dopDG.Number + "\r\n"
                        + "так как он является доп.соглашением, удалить?", "Ошибка выбора договоров", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show("Отмена активации договоров");
                        return;
                    }
                    else
                    {
                        needDrop = true;
                    }
                }
                else if (notPresentRootDogInActiveList && notActiveRootDog)
                {
                    if (MessageBox.Show("Вы не можете активировать договор №" + dopDG.Number + "\r\n"
                    + "1. Вы не выбрали для активации основной договор\r\n"
                    + "2. Основной договор не был ранее активирован\r\n"
                    + "3. Основной договор был активирован как копия\r\n"
                    + "Удалить этот договор из списка активации?", "Ошибка выбора договоров", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        MessageBox.Show("Отмена активации договоров");
                        return;
                    }
                    else
                    {
                        needDrop = true;
                    }
                }
                
                if (needDrop)
                {
                    DeleteDogovorFromList(new DogovorListItem[] { dopDG });
                    dopDogs = outList.Where(x => x.PrtDog.PrtDogTypes.LTP_DogType.LDT_IsChield);
                }
                else 
                {
                    break;
                }
            }

            if (outList.Count() == 0)
            {
                MessageBox.Show("Нет договоров для активации");
                return;
            }

            foreach (DogovorListItem dliItem in outList)
            {
                if (
                    dliItem.PrtDog.LTPD_DateEnd.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date // Должен быть не просрочен
                    && dliItem.PrtDog.PrtDogTypes.LTP_DogType.LDT_IsRoot) // является основным
                {
                    dliItem.PrtDog.tbl_Partners.PR_PGKEY = dliItem.PrtGroupID;
                }
                dliItem.Comment = System.Text.RegularExpressions.Regex.Replace(dliItem.Comment, @"/[А-Яа-я0-1 ]*/", "");
                dliItem.Comment = dliItem.Comment.Trim() + " /" + dliItem.NewActiveType + "/";
                if (IsTemporyActivate || dliItem.NewActiveType.ToLower() != DogovorListItem.ArrayStatusNormalActive[2].ToLower())
                {
                    if (IsTemporyActivate)
                        dliItem.PrtDog.Activate(dliItem.GetTotalDaysUseAfterCreate(), dliItem.Comment);
                    else
                        dliItem.PrtDog.Activate(0, dliItem.Comment);
                }
            }
            edtDogovorNum.Text = messageDogNum;
            outList.Clear();
            SetDataSource(outList);
            PLDC.SubmitChanges();

            MessageBox.Show("Все выбранные договора были активированы");
        }
        #endregion

        #region Обработка событий
        private void edtDogovorNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
            {
                edtDogovorNum.SelectAll();
            }
        }

        private void edtDogovorNum_TextChanged(object sender, EventArgs e)
        {
            if (edtDogovorNum.Text == messageDogNum)
                edtDogovorNum.ForeColor = Color.Gray;
            else
                edtDogovorNum.ForeColor = SystemColors.ControlText;
        }

        private void CheckKeyUpEnter()
        {
            edtDogovorNum.SelectAll();

            if (outList.Count(x => x.PrtDog.LTPD_DogNum == edtDogovorNum.Text) > 0)
                return;

            string errorMessage = "";
            var findingDogovor = PLDC.GetDogovorFromRootAgency(edtDogovorNum.Text, out errorMessage);
            if (findingDogovor == null)
            {
                MessageBox.Show(errorMessage);
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (findingDogovor.LTPD_PDKey != null && !findingDogovor.LTPD_TempActive)
            {
                MessageBox.Show("Запрошенный договор №" + edtDogovorNum.Text + " уже активирован по оригиналу");
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (findingDogovor.LTPD_DateStart.Date > DateTime.Now.Date && IsTemporyActivate)
            {
                MessageBox.Show("Данный договор не подлежит активации по факсу, так как его дата начала действия больше текущей");
                return;
            }

            DogovorListItem newDli = new DogovorListItem(findingDogovor, IsTemporyActivate);
            outList.Add(newDli);
            edtDogovorNum.Text = messageDogNum;

            SetDataSource(outList);
        }

        private void edtDogovorNum_KeyUp(object sender, KeyEventArgs e)
        {
            if (edtDogovorNum.Text.Trim() == "")
            {
                edtDogovorNum.Text = messageDogNum;
                return;
            }

            if (e.KeyCode != Keys.Enter || edtDogovorNum.Text.Length < 9 || edtDogovorNum.Text == messageDogNum)
                return;
         
            CheckKeyUpEnter();
            
            edtDogovorNum.Text = messageDogNum;
        }

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnActivate_Click(object sender, EventArgs e)
        {
            DogovorsDGV.EndEdit();
            ActivateDogovors();
        }

        private void DogovorsDGV_DataSourceChanged(object sender, EventArgs e)
        {
            if (DogovorsDGV.DataSource != null)
            {
                DogovorsDGV.Columns.Remove("PrtGroupID");
                DogovorsDGV.Columns.Remove("CountActivateDays");
                DogovorsDGV.Columns.Remove("Comment");
                DogovorsDGV.Columns.Remove("NewActiveType");

                foreach (DataGridViewColumn Col in DogovorsDGV.Columns)
                    Col.ReadOnly = true;

                #region cellTemplatePG
                DataGridViewComboBoxCell cellTemplatePG = new DataGridViewComboBoxCell();
                cellTemplatePG.DisplayStyleForCurrentCellOnly = true;
                cellTemplatePG.DisplayMember = "PG_Name";
                cellTemplatePG.ValueMember = "PG_Key";
                cellTemplatePG.DataSource = PLDC.dict_PrtGroups;
                
                DataGridViewComboBoxColumn colPG = new DataGridViewComboBoxColumn();
                colPG.HeaderCell.Style.BackColor = Color.LightBlue;
                colPG.CellTemplate = cellTemplatePG;
                colPG.DisplayIndex = 3;
                colPG.HeaderText = "Группа партнера";
                colPG.DataPropertyName = "PrtGroupID";
                colPG.ReadOnly = false;
                colPG.Name = "PrtGroupID";
                DogovorsDGV.Columns.Add(colPG);
                DogovorsDGV.Columns["PrtGroupID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                #endregion

                if (IsTemporyActivate)
                {
                    #region cellTemplateCD
                    DataGridViewComboBoxCell cellTemplateCD = new DataGridViewComboBoxCell();
                    cellTemplateCD.DisplayStyleForCurrentCellOnly = true;

                    cellTemplateCD.DataSource = new int[] { 7, 14, 21, 28 };

                    DataGridViewComboBoxColumn colCD = new DataGridViewComboBoxColumn();
                    colCD.HeaderCell.Style.BackColor = Color.LightBlue;
                    colCD.CellTemplate = cellTemplateCD;
                    colCD.DisplayIndex = 3;
                    colCD.HeaderText = "Кол-во дней временной активации";
                    colCD.DataPropertyName = "CountActivateDays";
                    colCD.ReadOnly = false;
                    colCD.Name = "CountActivateDays";
                    DogovorsDGV.Columns.Add(colCD);
                    DogovorsDGV.Columns["CountActivateDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    #endregion
                }
                //TODO: AgencyManager: Убрать else и ввести автомат для проставления fax|email
                //else
                {
                    #region cellTemplateActiveStatus
                    DataGridViewComboBoxCell cellTemplateActiveStatus = new DataGridViewComboBoxCell();
                    cellTemplateActiveStatus.DisplayStyleForCurrentCellOnly = true;
                    cellTemplateActiveStatus.DataSource = (IsTemporyActivate 
                        ? DogovorListItem.ArrayStatusFaxActive
                        : DogovorListItem.ArrayStatusNormalActive);

                    DataGridViewComboBoxColumn colAS = new DataGridViewComboBoxColumn();
                    colAS.HeaderCell.Style.BackColor = Color.LightBlue;
                    colAS.CellTemplate = cellTemplateActiveStatus;
                    colAS.DisplayIndex = 3;
                    colAS.HeaderText = "Статус";
                    colAS.DataPropertyName = "NewActiveType";
                    colAS.ReadOnly = false;
                    colAS.Name = "NewActiveType";
                    DogovorsDGV.Columns.Add(colAS);
                    DogovorsDGV.Columns["NewActiveType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                    #endregion
                }
            }
        }

        private void DogovorsDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DogovorsDGV.Columns[e.ColumnIndex] == DogovorsDGV.Columns["PrtGroupID"])
                {
                    DogovorListItem dli = (DogovorListItem)DogovorsDGV.Rows[e.RowIndex].DataBoundItem;
                    if (dli.PrtDog.PrtDogTypes.LTP_DogType.LDT_IsRoot)
                        DogovorsDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = !(dli.PrtDog.LTPD_DateEnd.Date >= ltp_v2.Framework.SqlConnection.ServerDateTime.Date);
                    else
                        DogovorsDGV.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                }
                LTP_PrtDog DIR_CurrentUse = ((DogovorListItem)DogovorsDGV.Rows[e.RowIndex].DataBoundItem).PrtDog;
                
                
                string docText = "";
                if (DIR_CurrentUse.Parent_LTPD_Key != null)
                {
                    if (DIR_CurrentUse.Dogovor_Root.IsActiveState != DogovorActiveState.Active)
                    {
                        if (DIR_CurrentUse.Dogovor_Root.IsActiveState == DogovorActiveState.NotActive)
                            docText = "<font color='red'>Для активации данного доп.соглашения \r\n необходимо активировать основной договор</font><br><br>";
                        else if (DIR_CurrentUse.Dogovor_Root.IsActiveState == DogovorActiveState.TmpActive)
                            docText = "<font color='red'>Для активации данного доп.соглашения \r\n необходимо активировать оригинальный основной договор</font><br><br>";
                    }
                }

                string errorMsg = "";
                var officesOnSuchINN = PLDC.GetTheOfficesOnSuchAnINN(DIR_CurrentUse.tbl_Partners, out errorMsg);
                if (officesOnSuchINN == null)
                {
                    docText += "<b>Суб. агентств</b><font color=#FF0000> : " + errorMsg + "</font><br>";
                }
                else
                {
                    int CountSubAgancy = officesOnSuchINN.Count();
                    docText += (CountSubAgancy > 1 ? "<b>Суб. агентств</b> : " + CountSubAgancy.ToString() + "<br>" : "") +
                        DIR_CurrentUse.GetDogovorInformationInHTML();
                }

                wbPrtInfo.DocumentText = "<html><body>" + docText + "</body></body>";
            }
        }

        private void edtComment_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (DataGridViewRow dgvr in DogovorsDGV.SelectedRows)
            {
                ((DogovorListItem)dgvr.DataBoundItem).Comment = edtComment.Text;
            }
        }

        private void DogovorsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DogovorsDGV.SelectedRows.Count == 0)
                return;
            edtComment.Text = "";

            foreach (DataGridViewRow dgvr in DogovorsDGV.SelectedRows)
            {
                if (edtComment.Text == "")
                {
                    edtComment.Text = ((DogovorListItem)dgvr.DataBoundItem).Comment;
                    edtComment.Enabled = true;
                }
                else if (edtComment.Text != ((DogovorListItem)dgvr.DataBoundItem).Comment)
                {
                    edtComment.Text = "Разные комментарии";
                    edtComment.Enabled = false;
                }
            }
        }

        private void btnClearComments_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in DogovorsDGV.SelectedRows)
            {
                ((DogovorListItem)dgvr.DataBoundItem).Comment = "";
                edtComment.Text = "";
                edtComment.Enabled = true;
            }
        }

        private void tsmiDelDogovor_Click(object sender, EventArgs e)
        {
            if (DogovorsDGV.SelectedRows.Count > 0)
            {
                List<DogovorListItem> delitedArray = new List<DogovorListItem>();
                foreach (DataGridViewRow dgvr in DogovorsDGV.SelectedRows)
                {
                    delitedArray.Add(((DogovorListItem)dgvr.DataBoundItem));
                }
                DeleteDogovorFromList(delitedArray.ToArray());
                SetDataSource(outList);
            }
        }
        #endregion

        private void DogovorsDGV_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show((Control)sender, e.Location);
            }
        }
    }
}
