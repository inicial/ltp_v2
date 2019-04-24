using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using AgencyManager.ObjectModel;

using ltp_v2.Framework;
using Microsoft.Office.Interop.Word;
using iTextSharp.text.pdf;

namespace AgencyManager.FormsForDogovor
{
    public class PrintDogovor
    {
        #region Методы
        private static string NormalizeText(string inString)
        {
            if (string.IsNullOrEmpty(inString))
                inString = "";

            inString = inString.Replace(@"\", "/");
            inString = inString.Replace("//", "/");
            inString = inString.Replace("#", " ");
            return inString;
        }

        public static string Generate(LTP_PrtDog DCItem)
        {
            PartnersListDataContext PLDC = new PartnersListDataContext(SqlConnection.ConnectionData);
            tbl_Partners PIM = PLDC.tbl_Partners.Where(x => x.PR_KEY == DCItem.LTPD_PRKey).First();
            if (DCItem.PrtDogTypes == null)
            {
                MessageBox.Show("Договор № " + DCItem.LTPD_DogNum + " с неопределенным типом не может быть создан");
                return null;
            }
            if (DCItem.PrtDogTypes.LTP_DogType == null)
            {
                MessageBox.Show("Нет настроек для договора");
                return null;
            }
            if (DCItem.PrtDogTypes.LTP_DogType.PrtDogTypesSources.Count() == 0)
            {
                MessageBox.Show("Нет шаблонов для договора");
                return null;
            }


            Dictionary<string, string> prtTypes = new Dictionary<string,string>();
            foreach (var pttp in PIM.PrtTypesToPartners.OrderBy(x=>x.PrtType.PT_NameLat))
            {
                if (pttp.PrtType.PT_NameLat.ToLower().Contains("prtgroup"))
                {
                    if (prtTypes.Keys.Contains(pttp.PrtType.PT_NameLat))
                    {
                        prtTypes[pttp.PrtType.PT_NameLat] += "," + pttp.PrtType.PT_Name;
                    }else {
                        prtTypes.Add(pttp.PrtType.PT_NameLat, pttp.PrtType.PT_Name);
                    }
                }
            }

            return Generate(DCItem.GetActualShablon()
                , DCItem.LTPD_DogNum, DCItem.LTPD_DateStart, DCItem.LTPD_DateEnd
                , (DCItem.Dogovor_Root != null ? DCItem.Dogovor_Root.LTPD_DogNum : "")
                , (DCItem.Dogovor_Root != null ? DCItem.Dogovor_Root.LTPD_DateStart : DateTime.MaxValue)
                , PIM.PR_FULLNAME
                , PIM.PR_BOSS, (PIM.LTP_PartnerAddsValue != null ? PIM.LTP_PartnerAddsValue.PRL_BossWorkWith : "")
                , PIM.BossName, PIM.BossFName, PIM.BossSName
                , PIM.PR_POSTINDEX, PIM.PR_CITY, PIM.PR_ADRESS, PIM.PR_LEGALPOSTINDEX, PIM.PR_LEGALADDRESS
                , PIM.PR_PHONES, PIM.PR_FAX, PIM.PR_FAX1, PIM.PR_EMAIL, (PIM.LTP_PartnerAddsValue != null ? PIM.LTP_PartnerAddsValue.PRL_EMailBuh : PIM.PR_EMAIL), PIM.PR_Http
                , PIM.PR_INN, PIM.PR_KPP, PIM.PR_CODEOKPO, PIM.PR_CODEOKONH, (PIM.LTP_PartnerAddsValue != null ? PIM.LTP_PartnerAddsValue.PRL_CodeOKVED : ""), (PIM.LTP_PartnerAddsValue != null ? PIM.LTP_PartnerAddsValue.PRL_CodeOGRN : ""), (PIM.LTP_PartnerAddsValue != null ? PIM.LTP_PartnerAddsValue.PRL_CodeOKATO : "")
                , (PIM.PrtAccounts != null && PIM.PrtAccounts.Count > 0 ? PIM.PrtAccounts.Last().PA_Account : "")
                , (PIM.PrtAccounts != null && PIM.PrtAccounts.Count > 0 && PIM.PrtAccounts.Last().Bank != null ? PIM.PrtAccounts.Last().Bank.BN_CorAccount : "")
                , (PIM.PrtAccounts != null && PIM.PrtAccounts.Count > 0 && PIM.PrtAccounts.Last().Bank != null ? PIM.PrtAccounts.Last().Bank.BN_Name : "")
                , (PIM.PrtAccounts != null && PIM.PrtAccounts.Count > 0 && PIM.PrtAccounts.Last().Bank != null ? PIM.PrtAccounts.Last().Bank.BN_BIK : "")
                , PIM.PR_LICENSENUMBER, PIM.PR_ADDITIONALINFO, prtTypes
                );
        }

        public static string SaveToTempFile(byte[] wordMl)
        {
            Random r = new Random();
            string sourcePath = string.Format("{0}\\dog-{1}-{2}.doc", MasterValue.PathToOutDoc, r.Next(), System.DateTime.Now.Ticks);
            File.WriteAllBytes(sourcePath, wordMl);
            return sourcePath;
        }

        public static void ReplaceAll(Microsoft.Office.Interop.Word.Application sender, string from, string to)
        {
            var docFind = sender.Selection.Find;
            docFind.ClearFormatting();
            docFind.Text = from;
            docFind.Replacement.Text = to;
            docFind.Wrap = WdFindWrap.wdFindContinue;

            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            object missing = System.Type.Missing;

            sender.Selection.Find.Execute(ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref replaceAll,
                                ref missing, ref missing, ref missing, ref missing);

        }

        public static void InsertBarCode(Microsoft.Office.Interop.Word.Application sender, string Code)
        {
            string tempDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData).TrimEnd('\\');

            if (!Directory.Exists(tempDirectory))
                Directory.CreateDirectory(tempDirectory);

            Random r = new Random();
            string sourcePath = string.Format("{0}\\gnr-barcode-{1}-{2}.jpg", tempDirectory, r.Next(), System.DateTime.Now.Ticks);

            // читать спецификацию и пример тут: ### http://www.codeproject.com/KB/graphics/BarcodeLibrary.aspx
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            BarcodeLib.TYPE type = BarcodeLib.TYPE.CODE39Extended;
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            b.RotateFlipType = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            b.IncludeLabel = false;
            System.Drawing.Image image = b.Encode(type, Code, System.Drawing.Color.Black, System.Drawing.Color.White, 220, 20);
            b.SaveImage(sourcePath, BarcodeLib.SaveTypes.JPG);

            object oMissing = System.Reflection.Missing.Value;
            object wdStory = 6;
            // Добавление баркода в OOOXComponent
            sender.Selection.HomeKey(ref wdStory, ref oMissing);
            sender.Selection.TypeParagraph(); // Key press - Enter
            sender.Selection.HomeKey(ref wdStory, ref oMissing);
            sender.Selection.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            
            object True = true;
            sender.Selection.InlineShapes.AddPicture(sourcePath, ref True, ref True, ref oMissing);

            // Удаления файла barcode за ненадобностью
            File.Delete(sourcePath);
        }

        private static bool CheckFindingValue(ApplicationClass wordApp, string findingValue)
        {
            var docFind = wordApp.Selection.Find;
            docFind.ClearFormatting();
            docFind.Text = findingValue;
            docFind.Replacement.Text = "";
            docFind.Wrap = WdFindWrap.wdFindContinue;

            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            object missing = System.Type.Missing;
            wordApp.Selection.Find.Execute(ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing);

            if (wordApp.Selection.Text.IndexOf(findingValue[0]) >= 0)
            {
                MessageBox.Show("Остались необработанные записи! проверьте документ");
                wordApp.Visible = true;
                return true;
            }

            return false;
        }
      
        public static string Generate(byte[] shablon
            , string dogovorNumber, DateTime DogStart, DateTime DogEnd
            , string baseDogovorNumber, DateTime baseDogStart
            , String PartnerFullName
            , string bossJobType, string bossJobWith
            , string bossName, string bossFName, string bossSName
            , string postIndex, string city, string address, string legalPostIndex, string legalAddress
            , string phones, string fax1, string fax2, string eMail, string eMailBuh, string http
            , string inn, string kpp, string okpo, string okonh, string okved, string ogrn, string okato
            , string rs, string ks, string bank, string bik
            , string license, string licenseInfo, Dictionary<string, string> prtTypeGroup)
        {
            object False = false;
            object True = true;
            object oMissing = System.Reflection.Missing.Value;

            var wordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            Random r = new Random();
            string PathToTmpFile = string.Format("{0}\\dog-{1}.{2}.{3}.pdf", MasterValue.PathToOutDoc, dogovorNumber, r.Next(), System.DateTime.Now.Ticks);

            object wFilePath = SaveToTempFile(shablon);
            try
            {
                var wordDoc = wordApp.Documents.Open(ref wFilePath, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    
                string ExtBossFam = bossName
                    + (!String.IsNullOrEmpty(bossFName.Trim()) ? " " + bossFName[0] + "." : "")
                    + (!String.IsNullOrEmpty(bossSName.Trim()) ? " " + bossSName[0] + "." : "");

                #region OLD Variant OUT
                ReplaceAll(wordApp, "#DOGOVOR_NUM", NormalizeText(dogovorNumber));
                ReplaceAll(wordApp, "#DATE_DOGOVOR", NormalizeText(DogStart.ToString("dd MMMM yyyy")));
                ReplaceAll(wordApp, "#ENDDATE_DOGOVOR", NormalizeText(DogEnd.ToString("dd MMMM yyyy")));
                
                ReplaceAll(wordApp, "#FULLAGENTNAME", NormalizeText(PartnerFullName));
                
                ReplaceAll(wordApp, "#BOSSTYPE", NormalizeText(bossJobType));
                ReplaceAll(wordApp, "#BOSSWORKTYPE", NormalizeText((string.IsNullOrEmpty(bossJobWith.Trim()) ? "устава" : bossJobWith)));
                ReplaceAll(wordApp, "#BOSSNAME", NormalizeText(bossName.Trim() + " " + bossFName.Trim() + " " + bossSName.Trim()));
                ReplaceAll(wordApp, "#BOSSFAM", NormalizeText(ExtBossFam));

                ReplaceAll(wordApp, "#ADDRESS", NormalizeText(postIndex + ", г." + city + " " + address));
                ReplaceAll(wordApp, "#LEGALADDRESS", NormalizeText(legalPostIndex + " " + legalAddress));

                ReplaceAll(wordApp, "#PHONE", NormalizeText(phones));
                ReplaceAll(wordApp, "#FAX", NormalizeText(string.Join(";", new string[] {fax1 ,fax2})));

                ReplaceAll(wordApp, "#EMAILBASE", NormalizeText(eMail));
                ReplaceAll(wordApp, "#EMAILGLAVBUH", NormalizeText(eMailBuh));
                ReplaceAll(wordApp, "#WWW", NormalizeText(http));

                ReplaceAll(wordApp, "#INN", NormalizeText(inn));
                ReplaceAll(wordApp, "#KPP", NormalizeText(kpp));
                ReplaceAll(wordApp, "#OKPO", NormalizeText(okpo));
                ReplaceAll(wordApp, "#OKONH", NormalizeText(okonh));
                ReplaceAll(wordApp, "#OKVED", NormalizeText(okved));
                ReplaceAll(wordApp, "#OGRN", NormalizeText(ogrn));
                ReplaceAll(wordApp, "#OKATO", NormalizeText(okato));
                ReplaceAll(wordApp, "#RS", NormalizeText(rs));
                ReplaceAll(wordApp, "#BANK", NormalizeText(bank));
                ReplaceAll(wordApp, "#KS", NormalizeText(ks));
                ReplaceAll(wordApp, "#BIK", NormalizeText(bik));

                ReplaceAll(wordApp, "#LICENSE", NormalizeText(license));
                ReplaceAll(wordApp, "#LICINFO", NormalizeText(licenseInfo));
                #endregion

                #region Новый тип замены данных
                ReplaceAll(wordApp, "<!--Договор - номер-->", NormalizeText(dogovorNumber));
                ReplaceAll(wordApp, "<!--Договор - дата начала-->", NormalizeText(DogStart.ToString("dd MMMM yyyy")));
                ReplaceAll(wordApp, "<!--Договор - дата завершения-->", NormalizeText(DogEnd.ToString("dd MMMM yyyy")));

                ReplaceAll(wordApp, "<!--Основной договор - номер-->", NormalizeText(baseDogovorNumber));
                ReplaceAll(wordApp, "<!--Основной договор - дата начала-->", (baseDogStart != DateTime.MaxValue ? NormalizeText(baseDogStart.ToString("dd MMMM yyyy")) : ""));

                ReplaceAll(wordApp, "<!--Полное название партнера-->", NormalizeText(PartnerFullName));

                ReplaceAll(wordApp, "<!--Руководитель - должность-->", NormalizeText(bossJobType));
                ReplaceAll(wordApp, "<!--Руководитель - должность в род.падеже-->", NormalizeText(bossJobType.TranslateText()));
                ReplaceAll(wordApp, "<!--Руководитель - действует на основание-->", NormalizeText((string.IsNullOrEmpty(bossJobWith.Trim()) ? "устава" : bossJobWith)));
                ReplaceAll(wordApp, "<!--Руководитель - Фамилия Имя Отчество-->", NormalizeText(bossName.Trim() + " " + bossFName.Trim() + " " + bossSName.Trim()));
                ReplaceAll(wordApp, "<!--Руководитель - Фамилия Имя Отчество в род.падеже-->", NormalizeText((bossName.Trim() + " " + bossFName.Trim() + " " + bossSName.Trim()).TranslateFIO()));
                ReplaceAll(wordApp, "<!--Руководитель - Фамилия И.О.-->", NormalizeText(ExtBossFam));

                ReplaceAll(wordApp, "<!--Индекс, Город, Адрес фактический-->", NormalizeText(postIndex + ", г." + city + " " + address));
                ReplaceAll(wordApp, "<!--Индекс, Адрес юридический-->", NormalizeText(legalPostIndex + " " + legalAddress));

                ReplaceAll(wordApp, "<!--Номер(а) телефона(ов)-->", NormalizeText(phones));
                ReplaceAll(wordApp, "<!--Номер(а) факса(ов)-->", NormalizeText(string.Join(";", new string[] {fax1 ,fax2})));

                ReplaceAll(wordApp, "<!--E-Mail Основной-->", NormalizeText(eMail));
                ReplaceAll(wordApp, "<!--E-Mail Гал.Бухгалтера-->", NormalizeText(eMailBuh));
                ReplaceAll(wordApp, "<!--Интернет адрес-->", NormalizeText(http));

                ReplaceAll(wordApp, "<!--ИНН-->", NormalizeText(inn));
                ReplaceAll(wordApp, "<!--КПП-->", NormalizeText(kpp));
                ReplaceAll(wordApp, "<!--ОКПО-->", NormalizeText(okpo));
                ReplaceAll(wordApp, "<!--ОКОНХ-->", NormalizeText(okonh));
                ReplaceAll(wordApp, "<!--ОКВЕД-->", NormalizeText(okved));
                ReplaceAll(wordApp, "<!--ОГРН-->", NormalizeText(ogrn));
                ReplaceAll(wordApp, "<!--ОКАТО-->", NormalizeText(okato));
                ReplaceAll(wordApp, "<!--Р/Счет-->", NormalizeText(rs));
                ReplaceAll(wordApp, "<!--Название банка-->", NormalizeText(bank));
                ReplaceAll(wordApp, "<!--Корр/Счет-->", NormalizeText(ks));
                ReplaceAll(wordApp, "<!--БИК-->", NormalizeText(bik));

                ReplaceAll(wordApp, "<!--Лицензия - номер-->", NormalizeText(license));
                ReplaceAll(wordApp, "<!--Лицензии - дата выдачи-->", NormalizeText(licenseInfo));

                using (ObjectModel.PartnersListDataContext pldc = new PartnersListDataContext(ltp_v2.Framework.SqlConnection.ConnectionData))
                {
                    foreach (var prtTypeGroupItem in pldc.PrtTypes
                        .Where(x => x.PT_NameLat.ToLower().Contains("prtgroup"))
                        .Select(x => x.PT_NameLat)
                        .Distinct()
                        .OrderBy(x => x))
                    {
                        if (prtTypeGroup.Keys.Contains(prtTypeGroupItem))
                            ReplaceAll(wordApp, "<!--" + prtTypeGroupItem + "-->", prtTypeGroup[prtTypeGroupItem]);
                        else
                            ReplaceAll(wordApp, "<!--" + prtTypeGroupItem + "-->", "");
                    }
                }
                prtTypeGroup.Clear();
                prtTypeGroup = null;

                #endregion

                InsertBarCode(wordApp, dogovorNumber);

                #region Проверка на оставшиеся коды
                CheckFindingValue(wordApp, "#");
                CheckFindingValue(wordApp, "<!--");
                CheckFindingValue(wordApp, "-->");
                #endregion

                wordDoc.ExportAsFixedFormat(PathToTmpFile,
                    WdExportFormat.wdExportFormatPDF,
                    false,
                    WdExportOptimizeFor.wdExportOptimizeForPrint,
                    WdExportRange.wdExportAllDocument,
                    0,
                    0,
                    WdExportItem.wdExportDocumentContent,
                    true,
                    true,
                    WdExportCreateBookmarks.wdExportCreateNoBookmarks,
                    false,
                    true,
                    false,
                    ref oMissing);
                wordApp.Application.Quit(ref False, ref oMissing, ref oMissing);
             }
             catch (Exception err)
             {
                 MessageBox.Show("Ошибка в обработке документа, обратитесь в тех. отдел");
                 MessageBox.Show(err.Message);
                 MessageBox.Show(err.Source);
                 MessageBox.Show(PathToTmpFile);
                 wordApp.Visible = true;
                 PathToTmpFile = null;
                 return PathToTmpFile;
             }
            
            try {
                Stream fout = new FileStream(PathToTmpFile + ".pdf", FileMode.Create, FileAccess.Write);
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(PathToTmpFile);
                reader.Info.Clear();
                PdfEncryptor.Encrypt(reader, fout, PdfWriter.STRENGTH128BITS, null, null, PdfWriter.AllowPrinting);
                fout.Close();
                reader.Close();
                File.Delete(PathToTmpFile);
                File.Move(PathToTmpFile + ".pdf", PathToTmpFile);
            }
            catch (Exception err)
            {
                MessageBox.Show("Ошибка в защите документа, обратитесь в тех. отдел");
                MessageBox.Show(err.Message);
                PathToTmpFile = null;
            }
            finally
            {
            }
            return PathToTmpFile;
        }
        #endregion

        public PrintDogovor(LTP_PrtDog DCItem)
        {
            if (DCItem.IsActive && DCItem.PrtDogTypes == null)
            {
                MessageBox.Show("Не удалось распознать тип договора у договора № " + DCItem.PrtDogs.PD_DogNumber);
                return;
            }

            ResultSaveFile = Generate(DCItem);
        }

        public string ResultSaveFile = null;
    }
}
