using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ltp_v2.Framework;
using ltp_v2.Controls;

using Arhivarius.ObjectModel;

namespace Arhivarius
{
    public partial class frmPacket : Form
    {
        #region Свойства
        ArhivDataContext ArhivDC;
        ArhiveDocument _UsePkgArhive;
        
        IBindingList ObjectsInPacketBinding
        {
            get
            {
                if (ObjectsInPacketDGV.DataSource != null)
                    return (IBindingList)ObjectsInPacketDGV.DataSource;
                else
                    return null;
            }
            set
            {
                ObjectsInPacketDGV.DataSource = value;
            }
        }

        ArhiveDocument UsePkgArhive
        {
            get { return _UsePkgArhive; }
            set
            {
                _UsePkgArhive = value;
                if (value != null)
                {
                    ObjectsInPacketBinding = value.Chield.GetNewBindingList();
                    edtComment.Text = value.ARH_Comment;

                    if (value.ARH_Number != null)
                    {
                        edtPacketNumber.Text = value.ARH_Number;
                        edtStatus.Text = (value.Parent == null ? "На руках" : value.Parent.DocumentType.ARDT_Name + " №" + value.Parent.ARH_Number);
                    }
                    else
                    {
                        edtPacketNumber.Text = "Новый пакет";
                        edtStatus.Text = "Новый";
                    }

                    if (value.Chield.Count == 0)
                        edtLastManager.Text = value.ARH_UserName;
                    else
                        edtLastManager.Text = value.Chield.Where(x => x.ARH_Id == value.Chield.Max(x2 => x2.ARH_Id)).First().ARH_UserName;

                    edtDocumentType.Items.Clear();
                    if (value.DocumentType == null)
                        edtDocumentType.Items.AddRange(ArhivDC.DocumentTypes.Where(x => x.ARDT_CanHaveChildren && !x.ARDT_IsRoot).ToArray());
                    else
                        edtDocumentType.Items.Add(value.DocumentType);
                    edtDocumentType.SelectedIndex = -1;
                    if (value.DocumentType == null)
                        edtDocumentType.SelectedIndex = 0;
                    else
                        edtDocumentType.SelectedItem = value.DocumentType;
                }
                else
                {
                    ObjectsInPacketBinding = null;
                    
                    edtDocumentType.SelectedItem = null;
                    edtLastManager.Text = "";
                    edtStatus.Text = "Введите № архива или Код склада или нажмите на создать";
                    edtPacketNumber.Text = "";
                    edtComment.Text = "";
                }
                SetEnableProperty();
            }
        }
        #endregion

        #region Конструктор
        public frmPacket()
        {
            InitializeComponent();
            UsePkgArhive = null;
            SetEnableProperty();
        }
        #endregion

        #region Методы
        /// <summary>
        /// Поиск архива
        /// </summary>
        private void SearchArhivePaket()
        {
            string SearchingDocument = edtPacketNumber.Text.Trim().ToLower();
            ArhivDC = new ArhivDataContext(SqlConnection.ConnectionData);
            UsePkgArhive = null;
            var qArh = from xA in ArhivDC.ArhiveDocuments
                       where xA.DocumentType.ARDT_CanHaveChildren
                            && xA.ARH_Number.ToLower() == SearchingDocument
                       select xA;

            if (qArh.Count() == 0)
            {
                MessageBox.Show("Архив не найден");
            }
            else
                UsePkgArhive = qArh.First();
        }

        /// <summary>
        /// Установка прав оступа к тем или иным кнопкам
        /// </summary>
        private void SetEnableProperty()
        {
            edtPacketNumber.ReadOnly = tsBtnPrint.Enabled = (UsePkgArhive != null);

            tsBtnPrint.Enabled = (tsBtnPrint.Enabled && !UsePkgArhive.DocumentType.ARDT_IsRoot);

            tsBtnSave.Enabled = (
                UsePkgArhive != null
                && ArhivDC.PresetSubmint(typeof(ArhiveDocument))
                && edtDocumentType.SelectedItem != null);

            edtComment.Enabled = (UsePkgArhive != null);
            edtDocumentType.Enabled = UsePkgArhive != null && UsePkgArhive.Chield.Count == 0;
            tsBtnDelete.Enabled = tsBtnAddDocument.Enabled = (
                UsePkgArhive != null
                && edtDocumentType.SelectedItem != null
                && UsePkgArhive.Parent == null);

            tsBtnDelete.Enabled = (tsBtnDelete.Enabled && ObjectsInPacketDGV.SelectedRows.Count != 0);

            tsBtnEject.Visible = (UsePkgArhive != null && UsePkgArhive.Parent != null);
                tsBtnArhive.Visible = (!tsBtnEject.Visible
                    && UsePkgArhive != null
                    && UsePkgArhive.DocumentType.ARDT_ParentGroupId != null
                    && UsePkgArhive.DocumentType.ParentDocType.ARDT_IsRoot);
        }
        #endregion

        #region Обработка событий

        private void frmFindDocument_OnFindNotActiveDocument(ArhiveDocument findingDocument)
        {
            if (UsePkgArhive.Chield.Where(x => x.ARH_Number == findingDocument.ARH_Number).Count() == 0)
            {
                UsePkgArhive.Chield.Add(findingDocument);
            }
            SetEnableProperty();
            ObjectsInPacketBinding = UsePkgArhive.Chield.GetNewBindingList();
        }

        #region toolStripMain
        private void tsBtnNewFind_Click(object sender, EventArgs e)
        {
            if (ArhivDC != null && ArhivDC.PresetSubmint(typeof(ArhiveDocument)))
                if (MessageBox.Show("Есть несохранненные данные продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            this.UsePkgArhive = null;
        }

        private void tsBtnNewArh_Click(object sender, EventArgs e)
        {
            if (ArhivDC != null && ArhivDC.PresetSubmint(typeof(ArhiveDocument)))
                if (MessageBox.Show("Есть несохранненные данные продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            ArhivDC = new ArhivDataContext(SqlConnection.ConnectionData);
            UsePkgArhive = new ArhiveDocument();
            ArhivDC.ArhiveDocuments.InsertOnSubmit(UsePkgArhive);
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            UsePkgArhive.ARH_Comment = edtComment.Text;
            UsePkgArhive.DocumentType = (DocumentType)edtDocumentType.SelectedItem;
            ArhivDC.SubmitChanges();
            edtPacketNumber.Text = UsePkgArhive.ARH_Number;

            if (!UsePkgArhive.DocumentType.ARDT_IsRoot)
            {
                SearchArhivePaket();
                new Report.frmViewer(UsePkgArhive).ShowDialog();
            }
            SearchArhivePaket();
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            if (ArhivDC != null && ArhivDC.PresetSubmint(typeof(ArhiveDocument)))
                if (MessageBox.Show("Есть несохранненные данные продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            new Report.frmViewer(UsePkgArhive).ShowDialog();
        }

        private void tsBtnEject_Click(object sender, EventArgs e)
        {
            if (ArhivDC != null && ArhivDC.PresetSubmint(typeof(ArhiveDocument)))
                if (MessageBox.Show("Есть несохранненные данные продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

            if (MessageBox.Show("Вы точно хотите изъять документ из архива?", "Изъятие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (UsePkgArhive.Parent.Parent != null)
            {
                MessageBox.Show(@"Вы не можете изъять из архива " +
                    UsePkgArhive.Parent.DocumentTypeName + " №" +UsePkgArhive.Parent.ARH_Number + ", так как он находится в " +
                    UsePkgArhive.Parent.Parent.DocumentTypeName + " №" + UsePkgArhive.Parent.Parent.ARH_Number);
                return;
            }

            UsePkgArhive.Parent = null;
            ArhivDC.SubmitChanges();

            edtPacketNumber.Enabled = true;
            edtPacketNumber.Text = UsePkgArhive.ARH_Number;
            SearchArhivePaket();
        }
        #endregion

        #region toolStripDocument
        private void tsBtnAddDocument_Click(object sender, EventArgs e)
        {
            frmFindDocument frmFindDocument = new frmFindDocument(ArhivDC, ((DocumentType)edtDocumentType.SelectedItem));
            frmFindDocument.OnFindNotActiveDocument += new frmFindDocument.AddDocumentEventHandler(frmFindDocument_OnFindNotActiveDocument);
            frmFindDocument.ShowDialog();            
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (ObjectsInPacketDGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(@"Вы точно хотите изъять документы из архива?", "Изъятие документов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                foreach (DataGridViewRow dgvrItem in ObjectsInPacketDGV.SelectedRows)
                {
                    ((ArhiveDocument)dgvrItem.DataBoundItem).ARH_ARHID = null;
                }
            }
            SetEnableProperty();
        }
        #endregion

        private void ObjectsInPacketDGV_DataSourceChanged(object sender, EventArgs e)
        {
            ObjectsInPacketDGV.AutoGenerateColumns = false;
            ObjectsInPacketDGV.Columns.Clear();
            ObjectsInPacketDGV.Columns.AddColumns("ARH_Number", "Номер");
            ObjectsInPacketDGV.Columns["ARH_Number"].DefaultCellStyle.ForeColor = Color.Blue;
            ObjectsInPacketDGV.Columns["ARH_Number"].DefaultCellStyle.Font = new Font(ObjectsInPacketDGV.Font, FontStyle.Underline);
            ObjectsInPacketDGV.Columns.AddColumns("DocumentType", "Тип");
            ObjectsInPacketDGV.Columns.AddColumns("ARH_UserName", "Кто добавил");
            ObjectsInPacketDGV.Columns.AddColumns("ARH_CRDate", "Дата добавления");
        }

        private void ObjectsInPacketDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvr in ObjectsInPacketDGV.Rows)
            {
                Label useLblLegend = lblLegendActive;
                ArhiveDocument dgvrTypedDR = (ArhiveDocument)dgvr.DataBoundItem;
                if (dgvrTypedDR.ARH_Id == 0)
                    useLblLegend = lblLegendNew;
                if (dgvrTypedDR.ARH_ARHID == null)
                    useLblLegend = lblLegendDelete;

                dgvr.DefaultCellStyle.ForeColor = useLblLegend.ForeColor;
                dgvr.DefaultCellStyle.BackColor = useLblLegend.BackColor;
                dgvr.DefaultCellStyle.Font = useLblLegend.Font;
            }
        }

        private void ObjectsInPacketDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ObjectsInPacketDGV.Columns["ARH_Number"].Index == e.ColumnIndex)
            {
                edtPacketNumber.Text = ((ArhiveDocument)ObjectsInPacketDGV.Rows[e.RowIndex].DataBoundItem).ARH_Number;
                SearchArhivePaket();
            }
        }

        private void edtStatus_DoubleClick(object sender, EventArgs e)
        {
            if (UsePkgArhive.Parent != null)
            {
                edtPacketNumber.Text = UsePkgArhive.Parent.ARH_Number;
                SearchArhivePaket();
            }
        }

        private void btnSearchArh_Click(object sender, EventArgs e)
        {
            SearchArhivePaket();
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (edtDocumentType.SelectedItem != null)
                UsePkgArhive.DocumentType = (DocumentType)edtDocumentType.SelectedItem;
            SetEnableProperty();
        }

        private void edtDocumentType_TextUpdate(object sender, EventArgs e)
        {
            if (edtDocumentType.Text.IsNullOrEmptyOrSpace())
                edtDocumentType.SelectedIndex = -1;
        }

        private void edtPacketNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchArhivePaket();
        }
        
        private void tsBtnInfo_Click(object sender, EventArgs e)
        {
            new frmInformation(ArhivDC, UsePkgArhive).ShowDialog();
        }

        private void tsBtnArhive_Click(object sender, EventArgs e)
        {
            ArhiveDocument adArh = ArhivDC.ArhiveDocuments.Where(x => x.DocumentType.ARDT_IsRoot).First();
            UsePkgArhive.Parent = adArh;
            ArhivDC.SubmitChanges();
            SearchArhivePaket();
        }
        #endregion
    }
}
