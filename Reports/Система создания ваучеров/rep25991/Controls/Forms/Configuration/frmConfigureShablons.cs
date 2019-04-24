using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep25991.Controls.Forms.Configuration
{
    public partial class frmConfigureShablons : Form
    {
        #region Вспомогательные классы
        private class helperValue
        {
            public int ID;
            public string Name;

            public helperValue(int id, string name)
            {
                ID = id;
                Name = name;
            }

            public override string ToString()
            {
                return Name + "[" + ID + "] ";
            }
        }
        #endregion

        #region Свойства
        sqlDataContext sqlDC;
        private helperValue selectedShablon
        {
            get { return (helperValue)fltShablons.SelectedItem; }
        }
        private LT_V_ShablonTourNames selectedVTour
        {
            get { return (LT_V_ShablonTourNames)fltVTour.SelectedItem; }
        }
        private helperValue selectedService
        {
            get { return (helperValue)fltServices.SelectedItem; }
        }

        private LT_V_ShablonFormatService selectedFormat
        {
            get { return (LT_V_ShablonFormatService)fltFormat.SelectedItem; }
        }

        private helperValue selectedCountry
        {
            get { return (helperValue)fltCountry.SelectedItem; }
        }

        #endregion

        private void ReloadServiceList()
        {
            int lastCountryId = (selectedCountry == null ? -1 : selectedCountry.ID);
            int lastVTourId = (selectedVTour == null ? -1 : selectedVTour.SHTN_Id);
            int lastShablonId = (selectedShablon == null ? -1 : selectedShablon.ID);

            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);
            fltCountry.DataSource = sqlDC.COUNTRies.OrderBy(x => x.CN_NAME).Select(x => new helperValue(x.CN_KEY, x.CN_NAME));
            fltShablons.DataSource = sqlDC.LT_V_Shablons.OrderBy(x => x.SH_Name).Select(x => new helperValue(x.SH_Id, x.SH_Name));
            fltServices.DataSource = sqlDC.Services.Where(x => x.tbl_DogovorLists.Count() > 0 && x.LT_V_ShablonFormatServices.Count() > 0).OrderBy(x => x.SV_NAME).Select(x => new helperValue(x.SV_KEY, x.SV_NAME));

            fltCountry.SelectedItem = fltCountry.Items.OfType<helperValue>().FirstOrDefault(x => x.ID == lastCountryId);
            fltVTour.SelectedItem = fltVTour.Items.OfType<LT_V_ShablonTourNames>().FirstOrDefault(x => x.SHTN_Id == lastVTourId);
            fltShablons.SelectedItem = fltShablons.Items.OfType<helperValue>().FirstOrDefault(x => x.ID == lastShablonId);
        }

        public frmConfigureShablons()
        {
            InitializeComponent();
            ReloadServiceList();
            lblFormatOut.Text = "";
        }

        private void fltCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltVTour.Enabled = selectedCountry != null)
                fltVTour.DataSource = sqlDC.LT_V_ShablonTourNames.Where(x => x.SHTN_CNKey == selectedCountry.ID).OrderBy(x => x.SHTN_Name);
        }

        private void fltShablons_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fltShablonServices.Enabled = selectedShablon != null)
                fltShablonServices.DataSource = sqlDC.LT_V_ShablonServices.Where(x => x.SHS_SHId == selectedShablon.ID).OrderBy(x => x.SHS_LineOut).Select(x => new helperValue(x.SHS_Id,
                    x.LT_V_ShablonFormatService.Service.SV_NAME + " " + (x.SHS_UseCommentToBron ? "[comment]" : "") + "[L:" + x.SHS_LineOut.ToString() + "]"
                    ));
        }

        private void fltServices_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFormatOut.Text = "";
            if (fltFormat.Enabled = selectedService != null)
                fltFormat.DataSource = sqlDC.LT_V_ShablonFormatServices.Where(x => x.SHFS_SVKey == selectedService.ID);
        }

        private void fltFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblFormatOut.Enabled = selectedFormat != null)
                lblFormatOut.Text = selectedFormat.SHFS_FormatOut;
        }

        private void fltVTour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblListUsedShablons.Enabled = selectedVTour != null)
                lblListUsedShablons.DataSource = sqlDC.LT_V_ShablonTourGroups
                    .Where(x => x.SHTR_SHTNId == selectedVTour.SHTN_Id)
                    .Select(x => x.LT_V_Shablon).OrderBy(x => x.SH_Name);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            int lastSelectedShablonId = selectedShablon.ID;

            sqlDC.LT_V_ShablonServices.InsertOnSubmit(new LT_V_ShablonService()
            {
                SHS_IsGroupToOneVoucher = edtGroup.Checked,
                SHS_IsMultiVariant = edtMany.Checked,
                SHS_UseCommentToBron = edtComment.Checked,
                SHS_LineOut = int.Parse(edtLine.Text.Trim()),
                SHS_SHId = lastSelectedShablonId,
                SHS_SHFSId = selectedFormat.SHFS_Id
            });

            sqlDC.SubmitChanges();
            ReloadServiceList();

            fltShablons.SelectedItem = fltShablons.Items.OfType<helperValue>().FirstOrDefault(x => x.ID == lastSelectedShablonId);
        }

        private void btnSetShablonToTour_Click(object sender, EventArgs e)
        {
            sqlDC.LT_V_ShablonTourGroups.InsertOnSubmit(
                new LT_V_ShablonTourGroup() { SHTR_SHId = selectedShablon.ID, SHTR_SHTNId = selectedVTour.SHTN_Id });
            sqlDC.SubmitChanges();
            ReloadServiceList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Controls.Forms.Configuration.frmMain(0).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int shablonID = ((LT_V_Shablon)lblListUsedShablons.SelectedItem).SH_Id;
            
            foreach (var delItem in sqlDC.LT_V_ShablonTourGroups.Where(x => x.SHTR_SHId == shablonID && x.SHTR_SHTNId == selectedVTour.SHTN_Id))
                sqlDC.LT_V_ShablonTourGroups.DeleteOnSubmit(delItem);
            
            sqlDC.SubmitChanges();
            ReloadServiceList();
        }
    }
}
