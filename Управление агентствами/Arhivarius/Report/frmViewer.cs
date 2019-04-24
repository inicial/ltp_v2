using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Arhivarius.Report
{
    public partial class frmViewer : Form
    {
        private Reporting reportingStruct;
        public frmViewer(Arhivarius.ObjectModel.ArhiveDocument ad)
        {
            InitializeComponent();
            reportingStruct = new Reporting(ad);
            this.Load += new EventHandler(Viewer_Load);
        }

        void Viewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();

            BindingSource bsRoot = new BindingSource();
            bsRoot.DataSource = reportingStruct;
            ReportDataSource rdsRoot = new ReportDataSource();
            rdsRoot.Name = "DocumentRoot";
            rdsRoot.Value = bsRoot;

            BindingSource bsChield = new BindingSource();
            bsChield.DataSource = reportingStruct;
            ReportDataSource rdsChield = new ReportDataSource();
            rdsChield.Name = "DocumentChield";
            rdsChield.Value = reportingStruct.Chield;

            this.reportViewer.Reset();

            this.reportViewer.LocalReport.DataSources.Add(rdsRoot);
            this.reportViewer.LocalReport.DataSources.Add(rdsChield);
            this.reportViewer.LocalReport.ReportEmbeddedResource = "Arhivarius.Report.marker.rdlc";
            this.reportViewer.RefreshReport();
            this.reportViewer.SetDisplayMode(DisplayMode.Normal);
            this.reportViewer.ZoomMode = ZoomMode.Percent;
            this.reportViewer.ZoomPercent = 75;
            this.reportViewer.RefreshReport();
        }
    }
}
