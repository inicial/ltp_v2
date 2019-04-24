using System;
using System.Collections.Generic;
using System.Text;

namespace ltp_v2.Controls.Forms
{
    public class lwDateTimePicker : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.TextBox edtDateTime;
        private System.Windows.Forms.Button btnShowCalendar;

        #region Локальные переменные
        private DateTime value = DateTime.Now;
        private lwCalendar lCalendar = null;
        private System.Drawing.Color changeBackColor = System.Drawing.Color.FromArgb(192, 255, 255);
        private DateTime defaultValue = DateTime.MinValue;
        #endregion

        #region Переменные
        /// <summary>
        /// Добавить выделенные даты
        /// </summary>
        /// <param name="BoldedDate">Дата которая будет выделенна в календаре</param>
        public void AddBoldedDate(DateTime BoldedDate)
        {
            DateTime[] tmpBoldedDates = this.lCalendar.BoldedDates;
            Array.Resize(ref tmpBoldedDates, tmpBoldedDates.Length + 1);
            tmpBoldedDates[tmpBoldedDates.Length - 1] = BoldedDate;
            this.lCalendar.BoldedDates = tmpBoldedDates;
        }

        /// <summary>
        /// Очистить список выделенных дат календаря
        /// </summary>
        public void ClearBoldedData()
        {
            this.lCalendar.BoldedDates = new DateTime[0];
        }

        /// <summary>
        /// Цвет заднего фона по умолчанию
        /// </summary>
        public new System.Drawing.Color BackColor
        {
            get { return base.BackColor; }
            set { 
                edtDateTime.BackColor = value;
                base.BackColor = value;
            }
        }

        /// <summary>
        /// Цвет заднего фона измененного значения
        /// </summary>
        public System.Drawing.Color ChangeBackColor
        {
            get { return changeBackColor; }
            set { changeBackColor = value; }
        }

        /// <summary>
        /// Значение по умолчанию если равно DateTime.minValue то отслеживание изменения не используется
        /// </summary>
        public DateTime DefaultValue
        {
            set { 
                this.defaultValue = value;
                this.Value = value;
            }
        }

        /// <summary>
        /// Выводимое и результирующие значение
        /// </summary>
        public DateTime Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;

                edtDateTime.BackColor = (IsEdit)
                    ? this.ChangeBackColor
                    : base.BackColor;

                edtDateTime.Text = this.value.ToString("dd.MM.yyyy");
            }
        }

        /// <summary>
        /// Флаг изменения данных
        /// </summary>
        public bool IsEdit
        {
            get
            {
                return (this.value.Date != this.defaultValue.Date && this.defaultValue != DateTime.MinValue);
            }
        }
        #endregion

        public lwDateTimePicker()
        {
            InitializeComponent();
        }

        #region Дизайн компонентов
        private void InitializeComponent()
        {
            this.edtDateTime = new System.Windows.Forms.TextBox();
            this.btnShowCalendar = new System.Windows.Forms.Button();
            this.lCalendar = new ltp_v2.Controls.Forms.lwCalendar();
            this.SuspendLayout();
            // 
            // edtDateTime
            // 
            this.edtDateTime.BackColor = System.Drawing.SystemColors.Control;
            this.edtDateTime.Location = new System.Drawing.Point(0, 0);
            this.edtDateTime.Name = "edtDateTime";
            this.edtDateTime.ReadOnly = true;
            this.edtDateTime.Size = new System.Drawing.Size(77, 20);
            this.edtDateTime.TabIndex = 1;
            // 
            // btnShowCalendar
            // 
            this.btnShowCalendar.BackColor = System.Drawing.SystemColors.Control;
            this.btnShowCalendar.Location = new System.Drawing.Point(0, 0);
            this.btnShowCalendar.Name = "btnShowCalendar";
            this.btnShowCalendar.Size = new System.Drawing.Size(23, 20);
            this.btnShowCalendar.TabIndex = 2;
            this.btnShowCalendar.Text = "...";
            this.btnShowCalendar.UseVisualStyleBackColor = false;
            this.btnShowCalendar.Click += new System.EventHandler(this.btnShowCalendar_Click);
            // 
            // lCalendar
            // 
            this.lCalendar.BackColor = System.Drawing.Color.White;
            this.lCalendar.BackColorAnyDay = System.Drawing.Color.White;
            this.lCalendar.BackColorHeader = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lCalendar.BackColorSelectedDay = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lCalendar.BackColorWeekendDay = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lCalendar.BoldedDates = new System.DateTime[0];
            this.lCalendar.CurrentDate = new System.DateTime(2009, 8, 5, 10, 33, 49, 37);
            this.lCalendar.ForeColor = System.Drawing.Color.Black;
            this.lCalendar.ForeColorAnyDay = System.Drawing.Color.Silver;
            this.lCalendar.ForeColorBoldedDay = System.Drawing.Color.Red;
            this.lCalendar.ForeColorHeader = System.Drawing.Color.Black;
            this.lCalendar.ForeColorSelectedDay = System.Drawing.SystemColors.HighlightText;
            this.lCalendar.ForeColorWeekendDay = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lCalendar.IsVisibleBorder = true;
            this.lCalendar.Location = new System.Drawing.Point(0, 23);
            this.lCalendar.Name = "lCalendar";
            this.lCalendar.SelectedDate = new System.DateTime(2009, 8, 5, 10, 33, 49, 37);
            this.lCalendar.Size = new System.Drawing.Size(150, 150);
            this.lCalendar.TabIndex = 3;
            // 
            // lwDateTimePicker
            // 
            this.Controls.Add(this.edtDateTime);
            this.Controls.Add(this.btnShowCalendar);
            this.Name = "lwDateTimePicker";
            this.Size = new System.Drawing.Size(150, 175);
            this.Resize += new System.EventHandler(this.lwDateTimePicker_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Обработка событий
        private void lwDateTimePicker_Resize(object sender, EventArgs e)
        {
            if (base.Size.Height > 23)
                this.Height = 23;

            if (base.Size.Height < edtDateTime.Height)
                this.Height = edtDateTime.Height;

            this.btnShowCalendar.Size = new System.Drawing.Size(23, 23);
            this.btnShowCalendar.Location = new System.Drawing.Point(base.Size.Width - this.btnShowCalendar.Width, 0);
            this.edtDateTime.Size = new System.Drawing.Size(base.Size.Width - this.btnShowCalendar.Width, 23);
            this.lCalendar.Width = base.Size.Width;
        }

        private void btnShowCalendar_Click(object sender, EventArgs e)
        {
            if (lCalendar.Parent == null)
            {
                bool notFindParent = true;
                System.Windows.Forms.Control tmpCtrl = this;
                System.Drawing.Point location = new System.Drawing.Point();
                while (notFindParent)
                {
                    if (tmpCtrl.Parent == null)
                    {
                        notFindParent = false;
                    }
                    else
                    {
                        location.X += tmpCtrl.Left;
                        location.Y += tmpCtrl.Top;
                        tmpCtrl = tmpCtrl.Parent;
                    }
                }
                tmpCtrl.Controls.Add(this.lCalendar);
                this.lCalendar.BringToFront();
                this.lCalendar.Location = new System.Drawing.Point(location.X, location.Y + this.Height - 10);
            }
            lCalendar.Show();
            lCalendar.OnChangeSelectedDate -= lCalendar_OnChangeSelectedDate;
            lCalendar.SelectedDate = this.Value;
            lCalendar.OnChangeSelectedDate += new EventHandler(lCalendar_OnChangeSelectedDate);
        }

        private void lCalendar_OnChangeSelectedDate(object sender, EventArgs e)
        {
            lCalendar.Hide();
            this.Value = lCalendar.SelectedDate;
        }
        #endregion
    }
}
