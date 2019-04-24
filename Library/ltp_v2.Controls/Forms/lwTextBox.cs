using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.ComponentModel;

namespace ltp_v2.Controls.Forms
{
    public class lwTextBox : TextBox
    {
        #region Локальные переменныые
        private Color backgroundColor = SystemColors.Window;
        private Color changeBackGroundColor = Color.PaleTurquoise;
        private string defaultText = "";
        private Color errorBackGroundColor = Color.Pink;
        private System.Windows.Forms.ErrorProvider errorProvider = null;
        private ErrorIconAlignment errorIconAlignment = ErrorIconAlignment.MiddleLeft;
        private string messageInformationError = "";
        private string regexVerify = "";
        private int verifyMaxLength = -1;
        #endregion

        #region Глобальные переменные
        [DefaultValue(typeof(Color), "Window"), Description("Цвет заднего фона"), Category("Appearance"), Browsable(true)]
        public Color BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
            set
            {
                if (value == Color.Empty)
                    value = SystemColors.Window;
                this.backgroundColor = value;
            }
        }

        [DefaultValue(typeof(Color), "PaleTurquoise"), Description("Цвет заднего фона при изменение данных"), Category("Appearance"), Browsable(true)]
        public Color ChangeBackGroundColor
        {
            get
            {
                return this.changeBackGroundColor;
            }
            set
            {
                if (value == Color.Empty)
                    value = Color.PaleTurquoise;
                this.changeBackGroundColor = value;
            }
        }

        [DefaultValue(typeof(Color), "Pink"), Description("Цвет заднего фона при некорректном заполнение данных"), Category("Appearance"), Browsable(true)]
        public Color ErrorBackGroundColor
        {
            get
            {
                return this.errorBackGroundColor;
            }
            set
            {
                if (value == Color.Empty)
                    value = Color.Pink;
                this.errorBackGroundColor = value;
            }
        }

        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public string DefaultText
        {
            private get
            {
                return ((this.defaultText == null) ? "" : this.defaultText);
            }
            set
            {
                this.defaultText = (value == null) ? "" : value;
                this.Text = this.defaultText;
                this.CheckValue();
            }
        }

        /// <summary>
        /// Указание объект на ErrorProvider
        /// </summary>
        public System.Windows.Forms.ErrorProvider ErrorProvider
        {
            get
            {
                return this.errorProvider;
            }
            set
            {
                this.errorProvider = value;
                if (this.errorProvider != null)
                    this.errorProvider.SetIconAlignment(this, this.ErrorIconAlignment);
            }
        }

        public ErrorIconAlignment ErrorIconAlignment
        {
            get
            {
                return this.errorIconAlignment;
            }
            set
            {
                this.errorIconAlignment = value;
                if (this.errorProvider != null)
                    this.errorProvider.SetIconAlignment(this, this.ErrorIconAlignment);
            }
        }

        /// <summary>
        /// Флаг изменения данных
        /// </summary>
        public bool isEdit
        {
            get
            {
                if (base.DesignMode)
                {
                    return false;
                }
                return (this.Text != this.DefaultText);
            }
        }

        /// <summary>
        /// Флаг ошибки заполнения
        /// </summary>
        public bool isErrorText
        {
            get
            {
                if (base.DesignMode)
                {
                    return false;
                }
                bool flag = false;
                if ((this.Text.Length > this.VerifyMaxLength) && (this.VerifyMaxLength > 0))
                {
                    flag = true;
                    if (this.ErrorProvider != null)
                    {
                        this.ErrorProvider.SetError(this, "Длинна поля превышает " + this.VerifyMaxLength.ToString() + " символов");
                    }
                    return flag;
                }
                if (this.RegexVerify != "")
                {
                    flag = (Regex.Matches(this.Text, this.RegexVerify).Count <= 0) || (Regex.Matches(this.Text, this.RegexVerify)[0].Length != this.Text.Length);
                }
                if (this.ErrorProvider != null)
                {
                    this.ErrorProvider.SetError(this, flag ? this.MessageInformationError : "");
                }
                return flag;
            }
        }

        /// <summary>
        /// Сообщение об ошибке заполнения
        /// </summary>
        public string MessageInformationError
        {
            get
            {
                return this.messageInformationError;
            }
            set
            {
                this.messageInformationError = value;
            }
        }

        /// <summary>
        /// Регулярное значение для проверки данных
        /// </summary>
        public string RegexVerify
        {
            get
            {
                return ((this.regexVerify == null) ? "" : this.regexVerify);
            }
            set
            {
                this.regexVerify = value;
            }
        }

        /// <summary>
        /// Значение длинны поля которое не должно превышать
        /// </summary>
        public int VerifyMaxLength
        {
            get
            {
                return this.verifyMaxLength;
            }
            set
            {
                this.verifyMaxLength = value;
            }
        }

        #endregion

        #region Обработка событий
        protected override void OnTextChanged(EventArgs e)
        {
            this.CheckValue();
            base.OnTextChanged(e);
        }
        #endregion

        #region Функции
        private void CheckValue()
        {
            if (!this.isErrorText)
            {
                if (this.isEdit)
                {
                    base.BackColor = this.ChangeBackGroundColor;
                }
                else
                {
                    base.BackColor = this.BackgroundColor;
                }
            }
            else
            {
                base.BackColor = this.ErrorBackGroundColor;
            }
        }
        #endregion
    }
}

