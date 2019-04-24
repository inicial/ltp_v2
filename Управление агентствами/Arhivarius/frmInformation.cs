using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Arhivarius.ObjectModel;

using ltp_v2.Controls;
using ltp_v2.Framework;

namespace Arhivarius
{
    public partial class frmInformation : Form
    {
        ArhivDataContext ArhivDC;
        ArhiveDocument InformationDocument
        {
            set
            {
                List<LTArh_History> HistoryList = new List<LTArh_History>();
                HistoryList.AddRange(value.HistoryChield.ToList());
                HistoryList.AddRange(value.HistoryParent.ToList());
                HistoryListDGV.DataSource = HistoryList.OrderByDescending(x => x.LTARH_Date).ToList();
                this.Text = "Информация изменения :" + value.ARH_Number;
            }
        }

        public frmInformation() 
            : this (new ArhivDataContext(SqlConnection.ConnectionData))
        {
            frmFindDocument fFD = new frmFindDocument();
            fFD.TopLevel = false;
            fFD.FormBorderStyle = FormBorderStyle.None;
            panel1.Controls.Add(fFD);
            fFD.Show();
            fFD.Dock = DockStyle.Fill;
            fFD.OnFindDocument += new frmFindDocument.AddDocumentEventHandler(frmFindDocument_OnFindDocument);
        }

        public frmInformation(ArhivDataContext arhivDC)
        {
            InitializeComponent();
            this.ArhivDC = arhivDC;
        }

        public frmInformation(ArhivDataContext arhivDC, ArhiveDocument informationDocument) : this(arhivDC)
        {
            InformationDocument = informationDocument;
            panel1.Visible = false;
        }

        private void HistoryListDGV_DataSourceChanged(object sender, EventArgs e)
        {
            HistoryListDGV.AutoGenerateColumns = false;
            HistoryListDGV.Columns.Clear();
            HistoryListDGV.Columns.AddColumns("LTARH_Date", "Дата записи", "dd.MM.yyyy HH:mm:ss");
            HistoryListDGV.Columns.AddColumns("LTARH_Comment", "");
            HistoryListDGV.Columns.AddColumns("LTARH_UserName", "ФИО Менеджера");
        }

        void frmFindDocument_OnFindDocument(ArhiveDocument findingDocument)
        {
            InformationDocument = findingDocument;
        }
    }
}
