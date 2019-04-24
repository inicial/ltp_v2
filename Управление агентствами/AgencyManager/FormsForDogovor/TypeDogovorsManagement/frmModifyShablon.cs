using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AgencyManager.ObjectModel;

namespace AgencyManager.FormsForDogovor.TypeDogovorsManagement
{
    public partial class frmModifyShablon : Form
    {
        #region Свойства
        private string PathToShablon;
        #endregion

        #region Конструктор
        public frmModifyShablon()
        {
            InitializeComponent();
        }

        public frmModifyShablon(string pathToShablon) : this()
        {
            this.PathToShablon = pathToShablon;
        }
        #endregion

        #region Методы
        private void NormalizeDocument()
        {
            lwWordControl1.ReplaceText("#DOGOVOR_NUM", "<!--Договор - номер-->");
            lwWordControl1.ReplaceText("#DATE_DOGOVOR", "<!--Договор - дата начала-->");
            lwWordControl1.ReplaceText("#ENDDATE_DOGOVOR", "<!--Договор - дата завершения-->");

            lwWordControl1.ReplaceText("#FULLAGENTNAME", "<!--Полное название партнера-->");

            lwWordControl1.ReplaceText("#BOSSTYPE", "<!--Руководитель - должность-->");
            lwWordControl1.ReplaceText("#BOSSWORKTYPE", "<!--Руководитель - действует на основание-->");
            lwWordControl1.ReplaceText("#BOSSNAME", "<!--Руководитель - Фамилия Имя Отчество-->");
            lwWordControl1.ReplaceText("#BOSSFAM", "<!--Руководитель - Фамилия И.О.-->");

            lwWordControl1.ReplaceText("#ADDRESS", "<!--Индекс, Город, Адрес фактический-->");
            lwWordControl1.ReplaceText("#LEGALADDRESS", "<!--Индекс, Адрес юридический-->");

            lwWordControl1.ReplaceText("#PHONE", "<!--Номер(а) телефона(ов)-->");
            lwWordControl1.ReplaceText("#FAX", "<!--Номер(а) факса(ов)-->");

            lwWordControl1.ReplaceText("#EMAILBASE", "<!--E-Mail Основной-->");
            lwWordControl1.ReplaceText("#EMAILGLAVBUH", "<!--E-Mail Гал.Бухгалтера-->");
            lwWordControl1.ReplaceText("#WWW", "<!--Интернет адрес-->");

            lwWordControl1.ReplaceText("#INN", "<!--ИНН-->");
            lwWordControl1.ReplaceText("#KPP", "<!--КПП-->");
            lwWordControl1.ReplaceText("#OKPO", "<!--ОКПО-->");
            lwWordControl1.ReplaceText("#OKONH", "<!--ОКОНХ-->");
            lwWordControl1.ReplaceText("#OKVED", "<!--ОКВЕД-->");
            lwWordControl1.ReplaceText("#OGRN", "<!--ОГРН-->");
            lwWordControl1.ReplaceText("#OKATO", "<!--ОКАТО-->");
            lwWordControl1.ReplaceText("#RS", "<!--Р/Счет-->");
            lwWordControl1.ReplaceText("#BANK", "<!--Название банка-->");
            lwWordControl1.ReplaceText("#KS", "<!--Корр/Счет-->");
            lwWordControl1.ReplaceText("#BIK", "<!--БИК-->");

            lwWordControl1.ReplaceText("#LICENSE", "<!--Лицензия - номер-->");
            lwWordControl1.ReplaceText("#LICINFO", "<!--Лицензии - дата выдачи-->");
        }
        #endregion

        #region Обработка событий
        private void frmModifyShablon_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(PathToShablon))
                return;

            lwWordControl1.LoadDocument(PathToShablon);

            lbVariants.Items.AddRange(new string[] {
                "Договор - номер",//DOGOVOR_NUM
                "Договор - дата начала", //DATE_DOGOVOR
                "Договор - дата завершения", //ENDDATE_DOGOVOR

                "Основной договор - номер",
                "Основной договор - дата начала",

                "Полное название партнера", //FULLAGENTNAME
                "Руководитель - должность", //BOSSTYPE
                "Руководитель - должность в род.падеже",
                "Руководитель - действует на основание", //BOSSWORKTYPE
                "Руководитель - Фамилия Имя Отчество", //BOSSNAME
                "Руководитель - Фамилия Имя Отчество в род.падеже", 
                "Руководитель - Фамилия И.О.", //BOSSFAM
                "Индекс, Город, Адрес фактический", //ADDRESS
                "Индекс, Адрес юридический", //LEGALADDRESS
                "Номер(а) телефона(ов)", //PHONE
                "Номер(а) факса(ов)", //FAX
                "E-Mail Основной", //EMAILBASE
                "E-Mail Гал.Бухгалтера", //EMAILGLAVBUH
                "Интернет адрес", //WWW
                "ИНН", //INN
                "КПП", //KPP
                "ОКПО", //OKPO
                "ОКОНХ", //OKONH
                "ОКВЕД", //OKVED
                "ОГРН", //OGRN
                "ОКАТО", //OKATO
                "Р/Счет", //RS
                "Название банка", //BANK
                "Корр/Счет", //KS
                "БИК", //BIK
                "Лицензия - номер", //LICENSE
                "Лицензии - дата выдачи" //LICINFO
            });

            using (ObjectModel.PartnersListDataContext pldc = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
            {
                foreach (var prtTypeGroup in pldc.PrtTypes
                    .Where(x => x.PT_NameLat.ToLower().Contains("prtgroup"))
                    .Select(x=>x.PT_NameLat)
                    .Distinct())
                {
                    lbVariants.Items.Add(prtTypeGroup);
                }
            }

            NormalizeDocument();
        }

        private void btnAddConstant_Click(object sender, EventArgs e)
        {
            if (lbVariants.SelectedIndex >= 0)
                lwWordControl1.InsertFieldComment("<!--" + lbVariants.SelectedItem.ToString() + "-->");
        }

        private void tsBtnExport_Click(object sender, EventArgs e)
        {
            lwWordControl1.SaveDocument();
            lwWordControl1.CloseControl();
            byte[] docSource = System.IO.File.ReadAllBytes(PathToShablon);

            string FileResult = PrintDogovor.Generate(docSource,
                "99-99999-9-M", DateTime.Now, DateTime.Now,
                "99-99999-9", DateTime.Now,
                "ПОЛНОЕ_НАЗВАНИЕ_АГЕНТСТВА",
                "ДОЛЖНОСТЬ РУКОВОДИТЕЛЯ", "НА ОСНОВАНИЕ", 
                "ФАМИЛИЯ", "ИМЯ", "ОТЧЕСТВО",
                "ИНДЕКС1", "ГОРОД", "ФАКТИЧЕСКИЙ_АДРЕС",
                "ИНДЕКС2", "ЮРИДИЧЕСКИЙ_АДРЕС",
                "ТЕЛЕФОНЫ", "ФАКС", "ФАКС2", "E-MAIL_БАЗОВЫЙ", "E-MAIL БУХГАЛТЕРИИ", "ИНТЕРНЕТ_АДРЕС",
                "ИНН", "КПП", "ОКОП", "ОКОНХ", "ОКВЕД", "ОГРН", "ОКАТО", "Р/Счет", "КОРР/СЧЕТ", "НАЗВАНИЕ_БАНКА", "БИК",
                "ЛИЦЕНЗИЯ №", "ВЫДАНА ОТ",
                new Dictionary<string, string>() { { "prtGroup1", "Признак1" }, { "prtGroup2", "Признак2" }, { "prtGroup3", "Признак3" }, { "prtGroup4", "Признак4" }, { "prtGroup5", "Признак5" } }
                );

            System.Diagnostics.Process.Start(FileResult);
            lwWordControl1.LoadDocument(PathToShablon);
        }
        #endregion

        private void frmModifyShablon_FormClosed(object sender, FormClosedEventArgs e)
        {
            lwWordControl1.Dispose();
        }

        private void tsBtnSave_Click(object sender, EventArgs e)
        {
            lwWordControl1.SaveDocument();
            DialogResult = DialogResult.OK;
        }

        private void tsBtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
