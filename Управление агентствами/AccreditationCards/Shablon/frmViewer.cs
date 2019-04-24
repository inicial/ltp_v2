using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace AccreditationCards.Shablon
{
    public partial class frmViewer : Form
    {
        #region 
        public event EventHandler OnPrinted;
        #endregion

        #region Свойства
        private Reporting[] _ReportingStruct;
        public LTP_AccreditationCard[] UsingCards;
        #endregion

        #region Конструктор
       
        public frmViewer(LTP_AccreditationCard[] cards)
        {
            InitializeComponent();
            UsingCards = cards;
            _ReportingStruct = new Reporting[0];
            foreach (LTP_AccreditationCard card in cards)
            {
                Array.Resize(ref _ReportingStruct, _ReportingStruct.Length + 1);
                _ReportingStruct[_ReportingStruct.Length - 1] = new Reporting(card);
            }
            this.Load += new EventHandler(Viewer_Load);
        }
        #endregion

        #region Обработка событий
        void Viewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();
            this.reportViewer.Reset();

            BindingSource bsRoot = new BindingSource();
            bsRoot.DataSource = _ReportingStruct;
            ReportDataSource rdsRoot = new ReportDataSource();
            rdsRoot.Name = "DocumentRoot";
            rdsRoot.Value = bsRoot;
            this.reportViewer.LocalReport.DataSources.Add(rdsRoot);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "AccreditationCards.Shablon.AKA.rdlc";

            this.reportViewer.RefreshReport();
            this.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer.ZoomMode = ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();
        }

        private void reportViewer_Print(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {
            if (OnPrinted != null)
                OnPrinted(this, null);
        }
        #endregion
    }
}
