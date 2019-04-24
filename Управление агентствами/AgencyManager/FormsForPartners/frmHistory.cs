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
using ltp_v2.Controls;

namespace AgencyManager.FormsForPartners
{
    public partial class frmHistory : Form
    {
        #region Свойства
        private PartnersListDataContext CurrentUsePLDC;
        private int UsePRKey;
        #endregion 

        #region Методы
        public void RefreshBindingData()
        {
            var History = CurrentUsePLDC.Histories
                //.Where(x =>
                //    x.HI_DATE.Date >= flt_DT_Beg.Value.Date
                //    && x.HI_DATE.Date <= flt_DT_End.Value.Date)
                .Where(x =>
                    x.HI_PRKEY == UsePRKey 
                    && (
                        x.HI_Type == "Account_G" && tsBtnFltAccount.Checked
                        || x.HI_Type == "AKK_G" && tsBtnFltAKK.Checked
                        || x.HI_Type == "PARTNERS" && tsBtnFltPartner.Checked
                        || x.HI_Type == "PARTNERS_G" && tsBtnFltPartner.Checked
                        || x.HI_Type == "PrtDogs_G" && tsBtnFltPrtDogs.Checked
                        || x.HI_Type == "PARTNERS_CC_G" && tsBtnFltCC.Checked));

            if (tsBtnHiModIns.Checked != tsBtnHiModUpd.Checked || tsBtnHiModUpd.Checked != tsBtnHiModDel.Checked)
            {
                History = History.Where(x =>
                    x.HI_MOD == "INS" && tsBtnHiModIns.Checked
                    || x.HI_MOD == "UPD" && tsBtnHiModUpd.Checked
                    || x.HI_MOD == "BLC" && tsBtnHiModDel.Checked
                    || x.HI_MOD == "DEL" && tsBtnHiModDel.Checked
                );
            }

            var lwWaitScreen = new ltp_v2.Controls.Forms.lwWaitScreen();
            lwWaitScreen.Show();

            HistoryDGV.AutoGenerateColumns = false;
            HistoryDGV.Columns.Clear();
            HistoryDGV.DataSource = History.OrderByDescending(x => x.HI_DATE).ToList();
            HistoryDGV.Columns.AddColumns("HI_Date", "Дата записи", "dd.MM.yyyy HH:mm:ss");
            HistoryDGV.Columns.AddColumns("HI_ModAndText", "Заголовок");
            HistoryDGV.Columns.AddColumns("HI_Who", "Менеджер");
            HistoryDGV_RowEnter(HistoryDGV, new DataGridViewCellEventArgs(0, 0));

            lwWaitScreen.Close();
        }
        #endregion

        #region Конструктор
        public frmHistory(int PRKey)
        {
            CurrentUsePLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            UsePRKey = PRKey;
            InitializeComponent();
        }
        #endregion

        private void tsBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem CurrentTsBtn = (ToolStripMenuItem)sender;
                if (CurrentTsBtn.Checked)
                    CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.Check;
                else
                    CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.UnCheck;
            }
            else if (sender is ToolStripButton)
            {
                ToolStripButton CurrentTsBtn = (ToolStripButton)sender;
                if (CurrentTsBtn.Checked)
                    CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.Check;
                else
                    CurrentTsBtn.Image = global::AgencyManager.Properties.Resources.UnCheck;
            }
        }

        private void HistoryDGV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (HistoryDGV.Rows.Count == 0 || HistoryDGV.Rows.Count < e.RowIndex)
            {
                webBrowser.DocumentText = "";
                return;
            }
            
            History selectedHistoryItem = (History)HistoryDGV.Rows[e.RowIndex].DataBoundItem;
            var historyDetails = selectedHistoryItem.HistoryDetails.OrderBy(x => x.HD_Text);
            
            string Result = "<table border=1><tr><td>Что менялось</td><td>Старое значение</td><td>Новое значение</td></tr>";
            Boolean TraceColor = false;
            foreach (HistoryDetail hdItem in historyDetails)
            {
                Result += "<tr style='background:" + (TraceColor ? "#DDDDFF" : "#FFFFDD") + "'><td>"
                    + hdItem.HD_Text + "</td><td>"
                    + (hdItem.HD_DateTimeValueOld.HasValue
                        ? hdItem.HD_DateTimeValueOld.Value.ToString("dd.MM.yyyy HH:mm:ss")
                        : !hdItem.HD_ValueOld.IsNullOrEmptyOrSpace() || !hdItem.HD_IntValueOld.HasValue
                            ? hdItem.HD_ValueOld
                            : hdItem.HD_IntValueOld.Value.ToString())
                            + "</td><td>"
                    + (hdItem.HD_DateTimeValueNew.HasValue
                        ? hdItem.HD_DateTimeValueNew.Value.ToString("dd.MM.yyyy HH:mm:ss")
                        : !hdItem.HD_ValueNew.IsNullOrEmptyOrSpace() || !hdItem.HD_IntValueNew.HasValue
                            ? hdItem.HD_ValueNew
                            : hdItem.HD_IntValueNew.Value.ToString())
                            + "</td><td>";
                TraceColor = !TraceColor;
            }
            Result += "</table>";
            this.webBrowser.DocumentText = historyDetails.Count() == 0 ? "" : Result;
        }

        private void tsBtnRefresh_Click(object sender, EventArgs e)
        {
            RefreshBindingData();
        }
    }
}
