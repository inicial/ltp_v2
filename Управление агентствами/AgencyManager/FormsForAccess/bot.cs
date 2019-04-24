using System;
using System.Drawing;
using System.Windows.Forms;

using ltp_v2.Framework;
using ltp_v2.Controls;

namespace AgencyManager.FormsForAccess
{
    public partial class bot : Form
    {
        private State BrauserState = State.Step1_Login;
        private string EMail;
        private string Inn;
        private string lCompanyName;
        private string LoginPassword;

        public bot(string lCompanyName, string EMail, string Inn, string LoginPassword)
        {
            this.InitializeComponent();

            this.lCompanyName = lCompanyName;
            this.EMail = EMail;
            this.Inn = Inn;
            this.LoginPassword = LoginPassword;
            
            this.Text = "Автоматическая регистрация / Логин-Пароль: " + LoginPassword;
            this.WindowState = FormWindowState.Maximized;
            this.webBrowser1.ProgressChanged += new WebBrowserProgressChangedEventHandler(this.webBrowser1_ProgressChanged);
            Timer timer = new Timer();
            timer.Interval = 1;
            timer.Tick += new EventHandler(this.tmr_Tick);
            timer.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        private void DocumentIsLoad()
        {
            if (!this.VerifyLostSession())
            {
                HtmlElement elementById = null;
                if (this.BrauserState < State.Step3_EnterValue)
                {
                    if (this.BrauserState == State.Step1_Login)
                    {
                        elementById = this.webBrowser1.Document.GetElementById("lnkSignIn");
                    }
                    if (this.BrauserState == State.Step2_MoveToRegistrate)
                    {
                        elementById = this.webBrowser1.Document.GetElementById("btnCreateSign");
                    }
                    if (elementById == null)
                    {
                        MessageBox.Show("Ошибка добавления элемент данных в HTML не найден");
                    }
                    else
                    {
                        this.BrauserState += 1;
                        this.webBrowser1.Url = new Uri(elementById.GetAttribute("Href"));
                    }
                }
                else
                {
                    if (this.BrauserState == State.Step3_EnterValue)
                    {
                        this.BrauserState = State.Step4_Exit;
                        this.InsertValues(this.webBrowser1.Document);
                    }
                }
            }
        }

        private void InsertValues(HtmlDocument Document)
        {
            string NormalizeFirstName = this.Translate(this.lCompanyName);
            if (NormalizeFirstName.Length > 25)
                NormalizeFirstName = NormalizeFirstName.Substring(0, 24);

            if (this.SetValueIntoInput(Document, "LAST_NAME_1", this.Translate(this.lCompanyName))
                && this.SetValueIntoInput(Document, "FIRST_NAME_1", NormalizeFirstName)
                && this.SetValueIntoSelect(Document, "DATE_OF_BIRTH_DAY_1", DateTime.Now.Day.ToString()) 
                && this.SetValueIntoSelect(Document, "DATE_OF_BIRTH_MONTH_1", DateTime.Now.Month.ToString())
                && this.SetValueIntoInput(Document, "DATE_OF_BIRTH_YEAR_1", DateTime.Now.Year.ToString()) 
                && this.SetValueIntoInput(Document, "CONTACT_POINT_EMAIL_1", this.EMail)
                && this.SetValueIntoInput(Document, "CONTACT_POINT_HOME_PHONE", this.Inn) 
                && this.SetValueIntoInput(Document, "USER_ID", this.LoginPassword)
                && this.SetValueIntoInput(Document, "PASSWORD_1", this.LoginPassword)
                && this.SetValueIntoInput(Document, "PASSWORD_2", this.LoginPassword))
            {
                Document.GetElementById("btnSave").InvokeMember("click");
            }
        }

        private bool SetValueIntoInput(HtmlDocument Document, string InputID, string Value)
        {
            HtmlElement elementById = Document.GetElementById(InputID);
            if (elementById == null)
            {
                MessageBox.Show("Ошибка добавления элемент данных в HTML не найден");
                return false;
            }
            elementById.SetAttribute("value", Value);
            return true;
        }

        private bool SetValueIntoSelect(HtmlDocument Document, string SelectID, string Value)
        {
            HtmlElement elementById = Document.GetElementById(SelectID);
            if (elementById == null)
            {
                MessageBox.Show("Ошибка добавления элемент данных в HTML не найден");
                return true;
            }
            foreach (HtmlElement element2 in elementById.Children)
            {
                if (element2.GetAttribute("value") == Value)
                {
                    element2.SetAttribute("Selected", "true");
                    break;
                }
            }
            return true;
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            ((Timer) sender).Enabled = false;
            string uriString = "http://wftc2.e-travel.com/plnext/AIEBDGFBDGF/CleanUpSessionPui.action?SITE=BDGFBDGF&LANGUAGE=RU";
            this.webBrowser1.Url = new Uri(uriString);
        }

        private string Translate(string INText)
        {
            return INText.ToUpper()
                .Replace("(", "")
                .Replace(")", "")
                .Replace("  ", " ")
                .Replace("А", "A")
                .Replace("Б", "B")
                .Replace("В", "V")
                .Replace("Г", "G")
                .Replace("Д", "D")
                .Replace("Е", "E")
                .Replace("Ё", "E")
                .Replace("Ж", "Zh")
                .Replace("З", "Z")
                .Replace("И", "I")
                .Replace("Й", "I")
                .Replace("К", "K")
                .Replace("Л", "L")
                .Replace("М", "M")
                .Replace("Н", "N")
                .Replace("О", "O")
                .Replace("П", "P")
                .Replace("Р", "R")
                .Replace("С", "S")
                .Replace("Т", "T")
                .Replace("У", "U")
                .Replace("Ф", "F")
                .Replace("Х", "H")
                .Replace("Ц", "C")
                .Replace("Ч", "Ch")
                .Replace("Ъ", "'")
                .Replace("Ы", "'")
                .Replace("Ь", "'")
                .Replace("Э", "E")
                .Replace("Ю", "Yu")
                .Replace("Я", "Ya");
        }

        private bool VerifyLostSession()
        {
            foreach (HtmlElement element in this.webBrowser1.Document.GetElementsByTagName("a"))
            {
                if (element.InnerText.CheckEntryValue("заново"))
                {
                    this.BrauserState = State.Step1_Login;
                    this.webBrowser1.Url = new Uri(element.GetAttribute("Href"));
                    return true;
                }
            }
            return false;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

            if (!this.webBrowser1.IsBusy
                && this.webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                if (this.webBrowser1.Document.Body.InnerText.CheckEntryValue("профиль сохранен")
                    && this.webBrowser1.Document.Body.InnerText.CheckEntryValue("вернуться к заказу"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                if (this.webBrowser1.Document.Body.InnerText.CheckEntryValue("(1039)"))
                {
                    if (this.webBrowser1.Document.GetElementById("WDSErrorContainer") != null
                        && this.webBrowser1.Document.GetElementById("WDSErrorContainer").InnerText != null
                        && this.webBrowser1.Document.GetElementById("WDSErrorContainer").InnerText.IndexOf("(1039)") >= 0)
                    {
                        webBrowserPanel.Enabled = false;
                        MessageBox.Show(this.webBrowser1.Document.GetElementById("WDSErrorContainer").InnerText + "\r\n\r\n" +
                            "Попробуйте создать другой логин/пароль");
                        this.Close();
                    }
                }

                if (this.webBrowser1.Document.GetElementById("WDSErrorContainer") != null
                    && this.webBrowser1.Document.GetElementById("WDSErrorContainer").InnerHtml == null
                    && this.webBrowser1.Document.Body.InnerText != "")
                {
                    this.DocumentIsLoad();
                }
            }
        }

        private enum State
        {
            Step1_Login,
            Step2_MoveToRegistrate,
            Step3_EnterValue,
            Step4_Exit
        }
    }
}

