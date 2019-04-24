using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using rep6043;
using rep25991;
using ltp_v2.Controls.Forms;

namespace rep259921
{
    public partial class frmMain : Form
    {
        //3168 - Аннуляция брони
        //10 - Штраф
        //6 - Страховка

        #region Вспомогательные свойства
        private class helperResultOut
        {
            private int SVKey;
            private bool _CheckForDelete = false;
            private bool _CheckForPenalty = false;
            /// <summary>
            /// Сервисная услуга
            /// </summary>
            [VisibleColumns(false)]
            public bool IsService
            {
                get
                {
                    return new int[] { 3168, 10 }.Contains(dlItem.DL_SVKEY);
                }
            }
            /// <summary>
            /// Услуга не может быть удалена
            /// </summary>
            [VisibleColumns(false)]
            public bool IsNotDeleted
            {
                get
                {
                    return (DLPayed > 0 || IsService);
                }
            }
            /// <summary>
            /// Услуга на которую нельзя создать штраф
            /// </summary>
            [VisibleColumns(false)]
            public bool IsNotCreatePenalty
            {
                get
                {
                    return new int[] { 6, 10, 3168 }.Contains(dlItem.DL_SVKEY);
                }
            }

            private Double _TotalPenalty = 0;
            public tbl_DogovorList dlItem;

            [DisplayName("Удалить из брони")]
            [ReadOnly(false)]
            [DefaultWidth(55)]
            public bool CheckForDelete
            {
                get { return _CheckForDelete; }
                set
                {
                    if (IsNotDeleted)
                        value = false;
                                       
                    _CheckForDelete = value;
                }
            }

            [DisplayName("Создать штраф")]
            [ReadOnly(false)]
            [DefaultWidth(55)]
            public bool CheckForPenalty
            {
                get { return _CheckForPenalty; }
                set
                {
                    if (IsNotCreatePenalty)
                        value = false;
                    
                    _CheckForPenalty = value;
                    
                    if (!value)
                        TotalPenalty = 0;
                    else
                    {
                        TotalPenalty = (Double)DLCost.GetValueOrDefault(0);
                        CheckForDelete = true;
                    }
                }
            }

            [DisplayName("Сумма штрафа")]
            [ReadOnly(false)]
            [DefaultWidth(55)]
            public Double TotalPenalty
            {
                get { return _TotalPenalty; }
                set
                {
                    if (CheckForPenalty)
                        _TotalPenalty = value;
                    else
                        _TotalPenalty = 0;
                }
            }

            [DisplayName("Дата")]
            [ReadOnly(true)]
            [DefaultWidth(100)]
            public string DLDate { get; set; }

            [DisplayName("День начала")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public int? DLDay { get; set; }

            [DisplayName("Продолжительность")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public int? DLNDays { get; set; }

            [DisplayName("Услуга")]
            [ReadOnly(true)]
            public string DLName { get; set; }

            [DisplayName("Человек на услуге")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public int DLNMen { get; set; }

            [DisplayName("Стоимость")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public decimal? DLCost { get; set; }

            [DisplayName("Оплата")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public decimal DLPayed { get; set; }

            [DisplayName("На квоте")]
            [ReadOnly(true)]
            [DefaultWidth(55)]
            public bool CheckedQuotes { get; set; }

            [DisplayName("Партнер")]
            [ReadOnly(true)]
            public string DLPartner { get; set; }

            public helperResultOut(tbl_DogovorList value)
            {
                dlItem = value;
                SVKey = value.DL_SVKEY;
                if (value.DL_DATEBEG.HasValue)
                    DLDate = value.DL_DATEBEG.Value.ToString("dd.MM.yyyy");
                DLName = value.DL_NAME;
                DLNMen = value.DL_NMEN;
                DLDay = value.DL_DAY;
                DLNDays = value.DL_NDAYS;
                DLCost = value.DL_COST;
                DLPayed = value.DL_PAYED.GetValueOrDefault(0);
                DLPartner = (value.tbl_Partner != null ? value.tbl_Partner.PR_NAME : "");
                CheckForDelete = DLPayed == 0 && !(new int[] { 3, 1, 3149 }).Any(x => x == value.DL_SVKEY);
                CheckedQuotes = value.DL_QUOTEKEY.GetValueOrDefault(0) != 0;
            }
        }
        #endregion

        #region Свойства
        private sqlDataContext SqlDC;
        private String DGCode;
        private tbl_Dogovor CurrentDG;
        private rep6043.frmExtended frmRep6043;
        private rep25991.frmExtended frmRep25991;
        #endregion

        #region Методы
        private void InitializeForm(Form sender, ltp_v2.Controls.Forms.lwGroupContainer container)
        {
            sender.TopLevel = false;
            container.PnlContainer.Controls.Add(sender);
            container.Height = (container.PnlContainer.Height = sender.MinimumSize.Height) + 20;
            sender.Show();
            sender.Dock = DockStyle.Fill;
            sender.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void SetCellsStyle()
        {
            Font normFont = null;

            foreach (DataGridViewRow dgvr in ServicesDGV.Rows)
            {
                if (normFont == null)
                {
                    normFont = dgvr.DefaultCellStyle.Font;
                }
                if (dgvr.DataBoundItem is helperResultOut)
                {
                    var itemHDGV = (helperResultOut)dgvr.DataBoundItem;

                    dgvr.DefaultCellStyle.Font = normFont;
                    foreach(DataGridViewCell col in dgvr.Cells)
                    {
                        col.Style.SelectionBackColor = Color.FromArgb(0, 0, 255);
                        col.Style.BackColor = Color.FromArgb(200, 200, 200);
                        col.Style.ForeColor = Color.FromArgb(0, 0, 0);
                        col.Style.Font = normFont;
                    }

                    dgvr.Cells["CheckForDelete"].Style.BackColor = dgvr.Cells["CheckForPenalty"].Style.BackColor = Color.White;

                    if (dgvr.Cells["TotalPenalty"].ReadOnly = !itemHDGV.CheckForPenalty)
                    {
                        dgvr.Cells["TotalPenalty"].Style.SelectionBackColor = Color.FromArgb(0, 0, 100);
                        dgvr.Cells["TotalPenalty"].Style.SelectionForeColor = Color.FromArgb(0, 0, 0);
                        dgvr.Cells["TotalPenalty"].Style.BackColor = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        dgvr.Cells["TotalPenalty"].Style.SelectionBackColor = Color.FromArgb(0, 0, 255);
                        dgvr.Cells["TotalPenalty"].Style.SelectionForeColor = Color.FromArgb(255, 255, 255);
                        dgvr.Cells["TotalPenalty"].Style.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    if (itemHDGV.IsNotCreatePenalty)
                    {
                        dgvr.Cells["CheckForPenalty"].Style.SelectionBackColor = Color.FromArgb(0, 0, 100);
                        dgvr.Cells["CheckForPenalty"].Style.BackColor = Color.FromArgb(0, 0, 0);
                    }
                    if (itemHDGV.IsNotDeleted)
                    {
                        dgvr.Cells["CheckForDelete"].Style.SelectionBackColor = Color.FromArgb(0, 0, 100);
                        dgvr.Cells["CheckForDelete"].Style.BackColor = Color.FromArgb(0, 0, 0);
                    }
                    if (itemHDGV.CheckedQuotes)
                    {
                        dgvr.Cells["CheckedQuotes"].Style.SelectionBackColor = Color.FromArgb(100, 0, 255);
                        dgvr.Cells["CheckedQuotes"].Style.BackColor = Color.FromArgb(255, 0, 0);
                    }
                    if (itemHDGV.DLPayed > 0)
                    {
                        dgvr.Cells["DLPayed"].Style.SelectionBackColor = Color.FromArgb(100, 0, 255);
                        dgvr.Cells["DLPayed"].Style.BackColor = Color.FromArgb(255, 0, 0);
                        dgvr.Cells["DLPayed"].Style.ForeColor = Color.White;
                    }
                }
            }
        }
        #endregion

        public frmMain(string dgCode)
        {
            this.DGCode = dgCode;
            InitializeComponent();
        }

        private void InitializeDataValues(object sender, EventArgs e)
        {
            lblError.Text = "";
            if (SqlDC != null)
                SqlDC.Dispose();

            if (frmRep6043 != null)
            {
                gpInsurances.PnlContainer.Controls.Clear();
                frmRep6043.Close();
            }
            if (frmRep25991 != null)
            {
                gpVoucher.PnlContainer.Controls.Clear();
                frmRep25991.Close();
            }

            SqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);

            CurrentDG = SqlDC.tbl_Dogovors.First(x => x.DG_CODE == DGCode);
            var query = CurrentDG.tbl_DogovorLists
                .Where(x => x.DL_DGKEY == CurrentDG.DG_Key)
                .OrderBy(x => x.DL_DAY)
                .ThenBy(x => x.DL_KEY);
            if (query.Where(x => x.DL_PAYED.GetValueOrDefault(0) != 0).Count() > 0)
                lblError.Text += (lblError.Text != "" ? "\r\n" : "") + "- Есть оплаты партнерам за услуги";

            lblBronNum.Text = DGCode;
            lblPricePayed.Text = CurrentDG.DG_PRICE + " / " + CurrentDG.DG_PAYED;
            lblTourDate.Text = CurrentDG.DG_TURDATE.ToString("dd.MM.yyyy");

            edtAnnulReasons.DataSource = SqlDC.AnnulReasons.OrderBy(x => x.AR_NAME);
            edtAnnulReasons.SelectedIndex = 0;

            if (CurrentDG.PresendPayTransaction(SqlDC))
                lblError.Text += (lblError.Text != "" ? "\r\n" : "") + "- Есть движение денежных средств";

            if (CurrentDG.DG_LOCKED.GetValueOrDefault(0) == 1)
            {
                lblError.Text += (lblError.Text != "" ? "\r\n" : "") + "- Путевка блокирована";
                pnlForms.Visible = false;
                btnSubmit.Enabled = false;
                return;
            }

            pnlForms.Visible = true;
            btnSubmit.Enabled = true;

            if (!query.ToArray().Any(x => x.DL_SVKEY == 3168))
            {
                tbl_DogovorList newAnnulService = new tbl_DogovorList(CurrentDG, SqlDC.Services.First(x => x.SV_KEY == 3168));

                query = CurrentDG.tbl_DogovorLists
                    .Where(x => x.DL_DGKEY == CurrentDG.DG_Key)
                    .OrderBy(x => x.DL_DAY)
                    .ThenBy(x => x.DL_KEY);
            }

            ServicesDGV.DatasourceType = typeof(helperResultOut);
            ServicesDGV.DataSource = query.Select(x => new helperResultOut(x)).ToArray();

            frmRep6043 = new rep6043.frmExtended(DGCode, false);
            InitializeForm(frmRep6043, gpInsurances);

            frmRep25991 = new rep25991.frmExtended(DGCode, false);
            InitializeForm(frmRep25991, gpVoucher);

            lblError.Visible = (lblError.Text != "");
        }

        private void ServicesDGV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (ServicesDGV.Columns[e.ColumnIndex].Name == "TotalPenalty")
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(e.FormattedValue.ToString(), @"^[0-9]{1,}(,[0-9]{1,}|)$"))
                {
                    MessageBox.Show(e.FormattedValue.ToString() + " не является суммой", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void ServicesDGV_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (ServicesDGV.Columns[e.ColumnIndex].Name != "TotalPenalty")
                ServicesDGV.EndEdit();
        }

        private void ServicesDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetCellsStyle();
        }

        private void ServicesDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SetCellsStyle();
        }

        private void PnlContainer_VisibleChanged(object sender, EventArgs e)
        {
            if (!gpInsurances.PnlContainer.Visible && !gpVoucher.PnlContainer.Visible)
            {
                int maxFullWidth = pnlForms.Height - pnlSubmit.Height - gpInsurances.HeaderHeight - gpVoucher.HeaderHeight - 10;
                if (gpServices.Height < maxFullWidth)
                    gpServices.Height = maxFullWidth;
            }
            else
            {
                gpServices.Height = gpServices.MinimumSize.Height;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var workList = (helperResultOut[])ServicesDGV.DataSource;
            bool skipAnnulBron = false;

            ServicesDGV.EndEdit();

            if (edtAnnulReasons.SelectedItem == null)
            {
                MessageBox.Show("Выберите причину аннуляции", "Ошибка при ануляции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Вы точно хотите аннулировать бронь №" + DGCode, "Аннуляция", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                return;

            if (workList.Any(x => !x.IsService && !x.CheckForDelete))
            {
                skipAnnulBron = true;
                if (MessageBox.Show("В путевке остались услуги\r\nпутевка сохранит статус и даты тура\r\nВы хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) 
                    return;
            }

            if (CurrentDG.PresendPayTransaction(SqlDC))
            {
                skipAnnulBron = true;
                if (MessageBox.Show("По путевке существуют движения денежных средств\r\nпутевка сохранит статус и даты тура\r\nВы хотите продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No) 
                    return;
            }

            #region Создание штрафов
            foreach (var item in workList.Where(x => x.CheckForPenalty))
            {
                Service sv = SqlDC.Services.First(x => x.SV_KEY == 10);

                ServiceList newSL = new ServiceList()
                {
                    SL_CNKEY = item.dlItem.tbl_Dogovor.DG_CNKEY,
                    SL_CTKEY = 0,
                    SL_NAME = item.DLName.Trim() + " Бронь №" + item.dlItem.DL_DGCOD + ".",
                    SL_NAMELAT = item.dlItem.DL_NameLat.Trim() + " Бронь №" + item.dlItem.DL_DGCOD + ".",
                    SL_SVKEY = 10
                };

                tbl_DogovorList newDL = new tbl_DogovorList(item.dlItem.tbl_Dogovor, item.dlItem, sv, newSL);
                foreach (TuristService ts in item.dlItem.TuristServices.ToArray())
                {
                    ts.tbl_DogovorList = newDL;
                }

                new tbl_Cost(item.dlItem.DL_PARTNERKEY.GetValueOrDefault(0), newSL, item.dlItem.tbl_Dogovor, item.TotalPenalty);
            }
            #endregion

            #region Удаление отмеченных услуг
            foreach (var serviceItem in workList.Where(x => x.DLPayed == 0).Where(x => x.CheckForDelete || x.CheckForPenalty).ToArray())
            {
                foreach (var turistItem in serviceItem.dlItem.TuristServices)
                {
                    SqlDC.TuristServices.DeleteOnSubmit(turistItem);
                }
                SqlDC.tbl_DogovorLists.DeleteOnSubmit(serviceItem.dlItem);
            }
            #endregion

            #region Аннулирование связанных документов
            frmRep6043.Annul();
            frmRep25991.Annul();
            #endregion

            if (skipAnnulBron)
                CurrentDG.WriteAnnulHistory((AnnulReason)edtAnnulReasons.SelectedItem);
            else
                CurrentDG.Annul((AnnulReason)edtAnnulReasons.SelectedItem);

            SqlDC.SubmitChanges();

            #region Пересчет стоимости брони
            try
            {
                Megatec_Web.Service1 sc = new Megatec_Web.Service1();
                sc.WebRecalculateDogovor(DGCode);
            }
            catch 
            {
                MessageBox.Show("Ошибка в расчете стоимости тура, необходимо пересчитать вручную");
            }
            MessageBox.Show("Бронь аннулирована");
            this.Close();
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
