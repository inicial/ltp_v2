using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace rep25991.Controls.Forms.GroupTours
{
    public partial class frmGroupTour : Form
    {
        sqlDataContext sqlDC;
        private int CNKey;
        private int TLKey;

        private void ReloadTree()
        {
            sqlDC = new sqlDataContext(ltp_v2.Framework.SqlConnection.ConnectionData);

            var actualTour = sqlDC.tbl_TurLists.Where(x => x.TL_CNKEY == CNKey && x.TurDates.Any(xTD => xTD.TD_DATE.Date > ltp_v2.Framework.SqlConnection.ServerDateTime.Date));
            edtBaseTour.DataSource = actualTour
                /* Убранно для облегчения поиска базового тура.Where(x => !sqlDC.LT_GroupToBaseTours.Any(xGT=>xGT.GT_ParentTLKey == x.TL_KEY))*/
                .OrderBy(x => x.TL_NAME);
            edtBaseTour.SelectedItem = edtBaseTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == TLKey);
            treeView1.Nodes.Clear();

            foreach (var qTour in actualTour.Where(x => !sqlDC.LT_GroupToBaseTours.Any(xGT=>xGT.GT_ParentTLKey == x.TL_KEY || xGT.GT_RootTLKey == x.TL_KEY)).OrderBy(x => x.TL_NAME))
            {
                var addNode = treeView1.Nodes.Add(qTour.TL_KEY.ToString(), qTour.TL_NAME);
                if (qTour.TL_KEY == TLKey)
                    addNode.Checked = true;
                
            }
            var rootTours =
            from xAT in actualTour
            from xRT in sqlDC.LT_GroupToBaseTours
            where xAT.TL_KEY == xRT.GT_RootTLKey
            select new { xAT.TL_KEY, xAT.TL_NAME, xRT.ChieldTour };

            foreach (var qTour in rootTours.GroupBy(x=>new {x.TL_KEY, x.TL_NAME}).OrderBy(x => x.Key.TL_NAME))
            {
                var newNode = treeView1.Nodes.Add(qTour.Key.TL_KEY.ToString(), qTour.Key.TL_NAME);
                foreach (var chldTour in qTour.Select(x => x.ChieldTour).OrderBy(x => x.TL_NAME))
                {
                    newNode.Nodes.Add(chldTour.TL_KEY.ToString(), chldTour.TL_NAME);
                }
            }
        }

        public frmGroupTour(int cnKey, int tlKey)
        {
            this.CNKey = cnKey;
            this.TLKey = tlKey;
            InitializeComponent();
            ReloadTree();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            int selectedRootID = ((tbl_TurList)edtBaseTour.SelectedItem).TL_KEY;
            if (sqlDC.LT_GroupToBaseTours.Any(xGT => xGT.GT_ParentTLKey == selectedRootID))
            {
                selectedRootID = sqlDC.LT_GroupToBaseTours.FirstOrDefault(xGT => xGT.GT_ParentTLKey == selectedRootID).GT_RootTLKey;
            }

            foreach (var selectedParent in treeView1.GetCheckedNodes().Select(x => new {ID =int.Parse(x.Name), x.Text}))
            {
                var parentServices = sqlDC.tbl_TurLists.FirstOrDefault(x => x.TL_KEY == selectedParent.ID).GetIndexedTurService();
                var rootServices = sqlDC.tbl_TurLists.FirstOrDefault(x => x.TL_KEY == selectedRootID).GetIndexedTurService();

                var exRS = parentServices.Select(x=>new {x.SVKey, x.Index}).Except(rootServices.Select(x=>new {x.SVKey, x.Index}));
                if (exRS.Count() > 0)
                {
                    string msg = string.Join("\r\n", exRS.Select(x=>sqlDC.Services.FirstOrDefault(xSV => xSV.SV_KEY == x.SVKey).SV_NAME + " " + x.Index.ToString()).ToArray());
                    MessageBox.Show("Невозможно добавить тур: " + selectedParent.Text + " так как у него больше услуг чем у базового \r\n" + msg);
                    continue;
                }

                if (sqlDC.LT_GroupToBaseTours.Any(x => x.GT_RootTLKey == selectedParent.ID) || selectedParent.ID == selectedRootID)
                {
                    MessageBox.Show("Невозможно добавить тур: " + selectedParent.Text + " определен как базовый");
                    continue;
                }

                if (sqlDC.LT_V_MappingTurLists.Any(x => x.VT_TLKey == selectedParent.ID))
                {
                    MessageBox.Show("Для тура: " + selectedParent.Text + " есть свои настройки");
                    continue;
                }

                foreach (var delItem in sqlDC.LT_GroupToBaseTours.Where(x => x.GT_ParentTLKey == selectedParent.ID))
                {
                    sqlDC.LT_GroupToBaseTours.DeleteOnSubmit(delItem);
                }
                foreach (var delItem in sqlDC.LT_GroupToBaseTours.Where(x => x.GT_RootTLKey == selectedParent.ID))
                {
                    sqlDC.LT_GroupToBaseTours.DeleteOnSubmit(delItem);
                }

                sqlDC.LT_GroupToBaseTours.InsertOnSubmit(
                    new LT_GroupToBaseTour()
                    {
                        GT_ParentTLKey = selectedParent.ID,
                        GT_RootTLKey = selectedRootID
                    });
                sqlDC.CopyMapppingTurList(selectedRootID, selectedParent.ID);
            }
            sqlDC.SubmitChanges();
            ReloadTree();

            edtBaseTour.SelectedItem = edtBaseTour.Items.OfType<tbl_TurList>().FirstOrDefault(x => x.TL_KEY == selectedRootID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (var selectedParent in treeView1.GetCheckedNodes().Select(x => new { ID = int.Parse(x.Name), x.Name }))
            {
                foreach (var delItem in sqlDC.LT_GroupToBaseTours.Where(x => x.GT_ParentTLKey == selectedParent.ID))
                {
                    sqlDC.LT_GroupToBaseTours.DeleteOnSubmit(delItem);
                }

                foreach (var delItem in sqlDC.LT_GroupToBaseTours.Where(x => x.GT_RootTLKey == selectedParent.ID))
                {
                    sqlDC.LT_GroupToBaseTours.DeleteOnSubmit(delItem);
                    foreach (var chldItem in sqlDC.LT_GroupToBaseTours.Where(x => delItem.ChieldTour != null && x.GT_ParentTLKey == delItem.ChieldTour.TL_KEY))
                    {
                        sqlDC.LT_GroupToBaseTours.DeleteOnSubmit(chldItem);
                    }
                }
            }
            sqlDC.SubmitChanges();
            ReloadTree();
        }

        private void fltTourSearch_TextChanged(object sender, EventArgs e)
        {
            var findingNode = treeView1.FindNode(fltTourSearch.Text);
            if (findingNode != null)
                treeView1.SelectedNode = findingNode;
        }    
    }
}
