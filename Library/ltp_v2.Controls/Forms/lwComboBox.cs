using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.ComponentModel;

namespace ltp_v2.Controls.Forms
{
    public class lwComboBox : ComboBox
    {
        #region Структуры
        public struct ItemHandAdd
        {
            public ItemHandAdd(String Text, int Value)
            {
                this.Text = Text;
                this.Value = Value;
            }
            public String Text;
            public int Value;
            public override string ToString()
            {
                return this.Text;
            }
        }
        #endregion

        #region Переменные
        private ErrorIconAlignment errorIconAlignment = ErrorIconAlignment.MiddleLeft;
        private Color backgroundColor = SystemColors.Window;
        private Color changeBackGroundColor = Color.FromArgb(192, 255, 255);
        private object defaultValue;
        private Color errorBackGroundColor = Color.Red;
        private System.Windows.Forms.ErrorProvider errorProvider = null;
        private bool isNotNullValue = false;
        private string messageInformationError = "";
        /// <summary>
        /// Флаг использования DataSource
        /// </summary>
        private bool IsUseDataSource
        {
            get
            {
                return base.Items.Count > 0 
                    && (
                        base.Items[0].GetType() == typeof(DataRowView)
                        || base.DataSource != null);
            }
        }

        private bool IsItemHandAdd
        {
            get
            {
                return base.Items.Count > 0 && base.Items[0].GetType() == typeof(ItemHandAdd);
            }
        }
        #endregion

        #region Свойства
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

        [DefaultValue(typeof(Color), "Window"), Description("Цвет заднего фона"), Category("Appearance"), Browsable(true)]
        public Color BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
            set
            {
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
                this.errorBackGroundColor = value;
            }
        }

        public new object SelectedValue
        {
            get
            {
                if (this.DataSource != null)
                    return base.SelectedValue;
                else if (this.SelectedItem.GetType() == typeof (ItemHandAdd))
                    return ((ItemHandAdd)base.SelectedItem).Value;
                else 
                    return null;
            }
            set
            {
                if (this.DataSource != null)
                    base.SelectedValue = value;
                else if (value.GetType() == typeof(int))
                {
                    foreach (ItemHandAdd tmpIHA in base.Items)
                    {
                        if (tmpIHA.Value == (int)value)
                        {
                            base.SelectedItem = tmpIHA;
                            break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Значение по умолчанию
        /// </summary>
        public object DefaultValue
        {
            private get
            {
                return this.defaultValue;
            }
            set
            {
                this.defaultValue = value;

                if (value != null)
                {
                    if (base.Items.Count != 0)
                    {
                        if (IsUseDataSource)
                        {
                            if (base.ValueMember == "")
                            {
                                throw new Exception("Перед вводом начального значения необходимо указать ValueMember");
                            }
                            else
                            {
                                try
                                {
                                    base.SelectedValue = this.defaultValue;
                                }
                                catch
                                {
                                    this.SelectedIndex = -1;
                                }
                            }
                        }
                        else if (!IsItemHandAdd)
                        {
                            throw new Exception("Тип данных в DefaultValue и тип данных Items должен быть ItemHandAdd");
                        }
                        else
                        {
                            try
                            {
                                foreach (ItemHandAdd tmpIHA in base.Items)
                                {
                                    if (this.defaultValue.GetType() == typeof(ItemHandAdd) && tmpIHA.Value == ((ItemHandAdd)this.defaultValue).Value)
                                    {
                                        base.SelectedItem = tmpIHA;
                                        break;
                                    }
                                    else if (this.defaultValue.GetType() == typeof(int) && tmpIHA.Value == (int)this.defaultValue)
                                    {
                                        base.SelectedItem = tmpIHA;
                                        break;
                                    }
                                }
                            }
                            catch
                            {
                                this.SelectedIndex = -1;
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Перед вводом начального значения необходимо указать DataSource или внести Items");
                    }
                }
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
            }
        }

        /// <summary>
        /// Флаг изменения данных
        /// </summary>
        public bool isEdit
        {
            get
            {
                if (this.defaultValue == null && this.SelectedValue != null)
                    return true;

                if (
                    base.DesignMode // Если режим редактирования
                    || this.DefaultValue == null //Если не указанно значение по умолчанию
                    || (base.SelectedValue == null && base.SelectedItem == null) // Если не выбранно значение
                    || (base.ValueMember == "" && IsUseDataSource) // Если используется DataSource и не указанно ValueMember
                ) {
                    return false;
                }
                if (IsUseDataSource)
                    return (base.SelectedValue.ToString() != this.DefaultValue.ToString());
                else
                {
                    if (this.DefaultValue.GetType() == typeof(ItemHandAdd))
                        return ((ItemHandAdd)base.SelectedItem).Value != ((ItemHandAdd)this.DefaultValue).Value;
                    else if (this.DefaultValue.GetType() == typeof(int))
                        return ((ItemHandAdd)base.SelectedItem).Value != (int)this.DefaultValue;
                    else
                        return false;
                }
            }
        }

        /// <summary>
        /// Флаг ошибки заполнения
        /// </summary>
        public bool isErrorText
        {
            get
            {
                try
                {
                    return (
                        this.IsNotNullValue &&
                        (base.SelectedValue == null && IsUseDataSource || base.SelectedItem == null && !IsUseDataSource));
                }
                catch (Exception err)
                {
                    throw new Exception(this.Name + " " + err.Message);
                }
            }
        }

        /// <summary>
        /// Флаг предупреждения о том что значение не может быть null
        /// </summary>
        public bool IsNotNullValue
        {
            get
            {
                return this.isNotNullValue;
            }
            set
            {
                this.isNotNullValue = value;
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
        #endregion

        #region Локальные функции
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

        #region Обработка событий
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            this.CheckValue();
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
            this.CheckValue();
        }

        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            this.CheckValue();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.CheckValue();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }
        #endregion
    }
}

