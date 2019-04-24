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
    public partial class frmFindDocument : Form
    {
        #region События
        public delegate void AddDocumentEventHandler(ArhiveDocument findingDocument);
        public event AddDocumentEventHandler OnFindDocument;
        public event AddDocumentEventHandler OnFindNotActiveDocument;
        #endregion

        #region Свойства
        private string DefaultText = "Отсканируйте штрих код документа или введите его номер и нажмите Enter в поле для ввода номера";
        private ArhivDataContext ArhivDC;
        private bool IsAutomaticChangeTypeDogovor = false;
        private ArhiveDocument FindingDocument;
        private string _InfoCaption;
        private string InfoCaption
        {
            get 
            {
                return _InfoCaption;
            }
            set
            {
                _InfoCaption = value;
                webBrowser1.DocumentText = _InfoCaption;
            }
        }
        #endregion

        #region Конструктор
        public frmFindDocument(ArhivDataContext arhiveDC)
        {
            InitializeComponent();
            ArhivDC = arhiveDC;
            FindingDocument = null;

            edtDocumentType.Items.Clear();
            edtDocumentType.Items.Add("Автоматический поиск");

            tsBtnCancel.Text = "Закрыть";
        }

        public frmFindDocument() : this (new ArhivDataContext(SqlConnection.ConnectionData))
        {
            edtDocumentType.Items.AddRange(ArhivDC.DocumentTypes.OrderBy(x => x.ARDT_Name).ToArray());
            edtDocumentType.SelectedIndex = 0;

            tsBtnFind.Checked = true;
            toolStripPanel.Visible = false;

            //edtDocumentType.Items.AddRange(ArhivDC.DocumentTypes.OrderBy(x => x.ARDT_Name).ToArray());
        }

        public frmFindDocument(ArhivDataContext arhivDC, DocumentType baseDocumentType)
            : this(arhivDC)
        {
            edtDocumentType.Items.AddRange(baseDocumentType.CheldDocType.OrderBy(x => x.ARDT_Name).ToArray());
            edtDocumentType.SelectedIndex = 0;
        }
        #endregion

        #region Методы
        /// <summary>
        /// Загрузка данных о документе из БД
        /// </summary>
        /// <returns>Информация о найденном документе</returns>
        private string FindDocumentFromSQLQuery(DocumentType docType)
        {
            string result = "";
            var executeQueryDog = ArhivDC.ExecuteQuery<dict_Document>(docType.ARDT_Sql, edtDocumentNum.Text.Trim()).ToList();

            if (executeQueryDog.Count() > 0)
            {
                var documentInformation = executeQueryDog.First();
                result += documentInformation.Info;

                var findingDocuments = ArhivDC.ArhiveDocuments.Where(x =>
                    (
                        x.ARH_Id == documentInformation.Id
                        ||  x.ARH_CodeKey == documentInformation.Id
                    ) && x.ARH_Number == documentInformation.Number).ToList();
                

                if (findingDocuments.Count() == 0)
                {
                    findingDocuments = ArhivDC.FindInSubmintItems(documentInformation);
                }

                if (findingDocuments.Count() == 0)
                {
                    FindingDocument = new ArhiveDocument();
                    FindingDocument.ARH_Number = documentInformation.Number;
                    FindingDocument.DocumentType = docType;
                    FindingDocument.ARH_CodeKey = documentInformation.Id;
                }
                else
                {
                    FindingDocument = findingDocuments.First();
                }

                var partnersInFindingDocument = executeQueryDog.Where(x => x.Number == documentInformation.Number).Select(x => x.tbl_Partner).Where(x => x != null);
                if (partnersInFindingDocument.Count() > 0)
                {
                    result += "<p>Документ зарегестрирован на компанию(ии):<ul>";
                    foreach (tbl_Partner prtItem in partnersInFindingDocument)
                    {
                        result += "<li>" + prtItem.PR_NAME + " [" + prtItem.PR_COD + "]</li>";
                    }
                    result += "</ul></p>";
                }
            }
            return result;
        }

        /// <summary>
        /// Запуск поиска документа
        /// </summary>
        private void StartFindDocument()
        {
            if (IsAutomaticChangeTypeDogovor)
            {
                IsAutomaticChangeTypeDogovor = false;
                return;
            }

            FindingDocument = null;
            InfoCaption = "<head><style>body{font-size:10pt} b{color:#0000dd}</style></head><body>";

            if (edtDocumentNum.Text.IsNullOrEmptyOrSpace())
            {
                InfoCaption += "<br><b><font color=red>" + DefaultText + "</font></b>";
            }else {
                string rResult = "";
                if (edtDocumentType.SelectedItem.GetType() != typeof(DocumentType))
                {
                    foreach (object dtItem in edtDocumentType.Items)
                    {
                        if (dtItem is DocumentType)
                        {
                            if ((dtItem as DocumentType).ARDT_Sql != null)
                            {
                                rResult = FindDocumentFromSQLQuery(dtItem as DocumentType);
                                if (FindingDocument != null)
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    rResult = FindDocumentFromSQLQuery(edtDocumentType.SelectedItem as DocumentType);
                }

                if (FindingDocument != null)
                {
                    /*
                     * Сбор парентов и запись информации о них в Result;
                     */
                    InfoCaption += "<hr><b>Место нахождение документа</b><hr><ul>";
                    for (ArhiveDocument сurrentArhItem = FindingDocument; сurrentArhItem != null; сurrentArhItem = сurrentArhItem.Parent)
                    {
                        if (сurrentArhItem.DocumentType != null && !сurrentArhItem.DocumentType.ARDT_IsRoot)
                        {
                            if (сurrentArhItem.Parent == null)
                                InfoCaption += "<li><b>" + сurrentArhItem.ARH_Number + "</b> Находится на руках";
                            else
                                InfoCaption += "<li><b>" + сurrentArhItem.ARH_Number + "</b> =&gt;&gt; <b>" + " №" + сurrentArhItem.Parent.ARH_Number + "(" + сurrentArhItem.Parent.DocumentType.ARDT_Name + ") </b>";
                        }
                    }
                    InfoCaption += "</ul><hr>";

                    // Если текущий документ принадлежит уже кому-то то сбрасываем его в null
                    IsAutomaticChangeTypeDogovor = true;
                    edtDocumentType.SelectedItem = FindingDocument.DocumentType;
                    InfoCaption += rResult;
                }
                else
                {
                    InfoCaption += "<br><b><font color=red>Документ не найден</font></b>";
                }
            }
        }
        #endregion

        #region Обработка событий
        private void edtDocumentNum_Leave(object sender, EventArgs e)
        {
            StartFindDocument();
        }

        private void edtDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartFindDocument();
        }

        private void edtDocumentType_TextUpdate(object sender, EventArgs e)
        {
            if (edtDocumentType.Text.IsNullOrEmptyOrSpace())
                edtDocumentType.SelectedIndex = -1;
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void edtDocumentNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                StartFindDocument();
                if (FindingDocument != null)
                {
                    if (OnFindDocument != null)
                        OnFindDocument(FindingDocument);

                    if (OnFindNotActiveDocument != null && !tsBtnFind.Checked && FindingDocument.Parent == null)
                    {
                        OnFindNotActiveDocument(FindingDocument);
                        InfoCaption =
                            "<b>Документ добавлен в: " + FindingDocument.Parent.DocumentTypeName +
                            " №" + FindingDocument.Parent.ARH_Number +
                            "</b><hr>" + InfoCaption;
                        edtDocumentNum.Text = "";
                        IsAutomaticChangeTypeDogovor = true;
                        edtDocumentType.SelectedIndex = 0;
                    }
                }
            }
        }

        private void tsBtnFind_CheckedChanged(object sender, EventArgs e)
        {
            tsBtnFind.Image = (tsBtnFind.Checked
                ? global::Arhivarius.Properties.Resources.Check
                : global::Arhivarius.Properties.Resources.UnCheck);
        }
        #endregion
    }
}