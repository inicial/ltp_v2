using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ltp_v2.Controls.Forms
{
    public class lwCalendar : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.PictureBox picMPK_Cal;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblMonth;
        public event EventHandler OnChangeSelectedDate;
        #region Локальные переменные
        private DateTime[,] arrDates;
        private DateTime selectedDate;
        private DateTime _currentDate;
        public DateTime CurrentDate
        {
            get { return _currentDate; }
            set
            {
                _currentDate = value;
                picMPK_Cal.Invalidate();
                lblMonth.Text = _currentDate.ToString("MMMM yyyy");
            }
        }
        private DateTime[] boldedDates = new DateTime[0];
        private string[] strDay = new string[] { "пн", "вт", "ср", "чт", "пт", "сб", "вс" };
        private string[] strDays = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private Color _backcolorSelectedDay = SystemColors.Highlight;
        private Color _backcolorWeekendDay = SystemColors.Highlight;
        private Color _backcolorHeader = SystemColors.ButtonFace;
        private Color _backcolorAnyDay = SystemColors.ButtonFace;

        private Color _forecolorSelectedDay = SystemColors.HighlightText;
        private Color _forecolorBoldedDay = Color.Red;
        private Color _forecolorWeekendDay = SystemColors.ControlText;
        private Color _forecolorHeader = SystemColors.ControlText;
        private Color _forecolorAnyDay = SystemColors.GrayText;

        private Size DaySize
        {
            get
            {
                int intXSize = (int)Math.Truncate((double)picMPK_Cal.Size.Width / 7f);
                int intYSize = (int)Math.Truncate((double)(picMPK_Cal.Size.Height) / 7f);
                return new Size(intXSize, intYSize);
            }
        }
        private bool isVisibleBorder = true;
        #endregion

        #region Внешние переменные
        public DateTime[] BoldedDates
        {
            get { return boldedDates; }
            set
            {
                boldedDates = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Показывать рамку
        /// </summary>
        public bool IsVisibleBorder
        {
            get { return isVisibleBorder; }
            set
            {
                isVisibleBorder = value;
                picMPK_Cal.Invalidate();
            }

        }

        /// <summary>
        /// Выбранная дата
        /// </summary>
        public DateTime SelectedDate
        {
            get { return this.selectedDate; }
            set {
                this.selectedDate = value;
                this.CurrentDate = value;
                if (OnChangeSelectedDate != null)
                {
                    OnChangeSelectedDate(this, null);
                }
            }
        }

        /// <summary>
        /// Задний фон выбранной даты
        /// </summary>
        public Color BackColorSelectedDay
        {
            get { return _backcolorSelectedDay; }
            set
            {
                _backcolorSelectedDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Задний фон выходных дней
        /// </summary>
        public Color BackColorWeekendDay
        {
            get { return _backcolorWeekendDay; }
            set
            {
                _backcolorWeekendDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Задний фон заголовков
        /// </summary>
        public Color BackColorHeader
        {
            get { return _backcolorHeader; }
            set
            {
                _backcolorHeader = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Задний фон дней не из этого месяца
        /// </summary>
        public Color BackColorAnyDay
        {
            get { return _backcolorAnyDay; }
            set
            {
                _backcolorAnyDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Основной цвет выбранной даты
        /// </summary>
        public Color ForeColorSelectedDay
        {
            get { return _forecolorSelectedDay; }
            set
            {
                _forecolorSelectedDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Основной цвет выделенных дат
        /// </summary>
        public Color ForeColorBoldedDay
        {
            get { return _forecolorBoldedDay; }
            set
            {
                _forecolorBoldedDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Основной цвет выходных дней
        /// </summary>
        public Color ForeColorWeekendDay
        {
            get { return _forecolorWeekendDay; }
            set
            {
                _forecolorWeekendDay = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Основной цвет заголовков
        /// </summary>
        public Color ForeColorHeader
        {
            get { return _forecolorHeader; }
            set
            {
                _forecolorHeader = value;
                picMPK_Cal.Invalidate();
            }
        }

        /// <summary>
        /// Основной цвет дней не из этого месяца
        /// </summary>
        public Color ForeColorAnyDay
        {
            get { return _forecolorAnyDay; }
            set
            {
                _forecolorAnyDay = value;
                picMPK_Cal.Invalidate();
            }
        }
        #endregion

        public lwCalendar()
        {
            InitializeComponent();
            if (SelectedDate == DateTime.MinValue)
                SelectedDate = DateTime.Now;
        }

        #region Дизайн компонентов
        private void InitializeComponent()
        {
            picMPK_Cal = new System.Windows.Forms.PictureBox();
            btnPrev = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            lblMonth = new System.Windows.Forms.Label();

            //
            // picMPK_Cal
            //
            this.picMPK_Cal.Location = new System.Drawing.Point(0, 23);
            this.picMPK_Cal.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 23);
            this.picMPK_Cal.Paint += new System.Windows.Forms.PaintEventHandler(picMPK_Cal_Paint);
            this.picMPK_Cal.MouseDown += new System.Windows.Forms.MouseEventHandler(picMPK_Cal_MouseDown);
            //
            // btnPrev
            //
            this.btnPrev.Location = new Point(0, 0);
            this.btnPrev.Size = new Size(23, 23);
            this.btnPrev.Text = "<<";
            this.btnPrev.Click += new EventHandler(btnPrev_Click);
            //
            // btnNext
            //
            this.btnNext.Location = new Point(this.Size.Width - 23, 0);
            this.btnNext.Size = new Size(23, 23);
            this.btnNext.Text = ">>";
            this.btnNext.Click += new EventHandler(btnNext_Click);
            //
            // lblMonth
            //
            this.lblMonth.AutoSize = false;
            this.lblMonth.Location = new Point(23, 0);
            this.lblMonth.TextAlign = ContentAlignment.MiddleCenter;
            this.lblMonth.Size = new Size(this.Size.Width - 23 * 2, 23);          
            //
            // lwCalendar
            //
            this.Controls.Add(picMPK_Cal);
            this.Controls.Add(lblMonth);
            this.Controls.Add(btnPrev);
            this.Controls.Add(btnNext);
            this.Resize += new EventHandler(lwCalendar_Resize);
        }
        #endregion

        private void lwCalendar_Resize(object sender, EventArgs e)
        {
            if (this.Width < 150) this.Width = 150;
            if (this.Height < 150) this.Height = 150;

            this.picMPK_Cal.Location = new System.Drawing.Point(0, 23);
            this.picMPK_Cal.Size = new System.Drawing.Size(this.Width, this.Height - 23);

            this.lblMonth.Location = new Point(23, 0);
            this.lblMonth.Size = new Size(this.Size.Width - 23 * 2, 23);

            this.btnNext.Location = new Point(this.Size.Width - 23, 0);
            this.btnNext.Size = new Size(23, 23);

            this.btnPrev.Location = new Point(0, 0);
            this.btnPrev.Size = new Size(23, 23);

            picMPK_Cal.Invalidate();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(-1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CurrentDate = CurrentDate.AddMonths(1);
        }

        private void picMPK_Cal_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int SelectedWeek = e.Y / DaySize.Height;
            int SelectedDayOfWeek = e.X / DaySize.Width;
            if (SelectedWeek > 0)
            {
                SelectedDate = arrDates[SelectedWeek - 1, SelectedDayOfWeek];
            }
        }

        public SizeF getSizeString(Graphics gx, string inStr, Font Font)
        {
            SizeF result = new SizeF();
            result.Width = gx.MeasureString(inStr, Font).Width;
            result.Height = gx.MeasureString(inStr, Font).Height;

            return result;
        }

        private void picMPK_Cal_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            GenerateArrayDates();
            Rectangle rect = new Rectangle(new Point(), picMPK_Cal.Size);
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(base.BackColor), rect);

            #region Шапка
            for (int iDayOfWeek = 0; iDayOfWeek < 7; iDayOfWeek++)
            {
                SizeF lStringSize = getSizeString(g, strDay[iDayOfWeek], base.Font);
                g.FillRectangle(new SolidBrush(BackColorHeader), DaySize.Width * iDayOfWeek, 0, DaySize.Width, DaySize.Height);

                if (IsVisibleBorder)
                    g.DrawRectangle(new Pen(base.ForeColor), DaySize.Width * iDayOfWeek, 0, DaySize.Width, DaySize.Height);

                g.DrawString(
                        strDay[iDayOfWeek],
                        base.Font,
                        new SolidBrush(ForeColorHeader),
                        new PointF(
                            (float)(DaySize.Width * iDayOfWeek) + (float)DaySize.Width / 2f - (float)lStringSize.Width / 2f,
                            (float)DaySize.Height / 2f - (float)lStringSize.Height / 2f));
            }
            #endregion

            
            for (int iWeek = 0; iWeek < 6; iWeek++)
            {
                for (int iDayOfWeek = 0; iDayOfWeek < 7; iDayOfWeek++)
                {
                    Rectangle CurrRect = new Rectangle(
                        DaySize.Width * iDayOfWeek,
                        DaySize.Height * (iWeek + 1),
                        DaySize.Width,
                        DaySize.Height);


                    Color currForeColor = this.ForeColor;
                    Color currBackColor = base.BackColor;
                    Font StringFont = this.Font;

                    if (arrDates[iWeek, iDayOfWeek].Month != CurrentDate.Month) // если не текущий месяц
                    {
                        currBackColor = BackColorAnyDay;
                        currForeColor = ForeColorAnyDay;
                    }
                    else if (iDayOfWeek >= 5) // если выходные
                    {
                        currBackColor = BackColorWeekendDay;
                        currForeColor = ForeColorWeekendDay;
                    }

                    if (Array.IndexOf(boldedDates, arrDates[iWeek, iDayOfWeek].Date) >= 0) // если выделенная дата
                    {
                        currForeColor = ForeColorBoldedDay;
                        StringFont = new Font(this.Font, FontStyle.Bold);
                    }

                    if (arrDates[iWeek, iDayOfWeek].Date == SelectedDate.Date) // если выбранная дата
                    {
                        currBackColor = BackColorSelectedDay;
                        currForeColor = ForeColorSelectedDay;
                    }

                    g.FillRectangle(new SolidBrush(currBackColor), CurrRect);

                    if (IsVisibleBorder)
                        g.DrawRectangle(new Pen(base.ForeColor), CurrRect);

                    SizeF lStringSize = getSizeString(g, arrDates[iWeek, iDayOfWeek].Day.ToString(), StringFont);

                    g.DrawString(arrDates[iWeek, iDayOfWeek].Day.ToString()
                        , base.Font, new SolidBrush(currForeColor)
                        , new PointF(
                            CurrRect.X + CurrRect.Width / 2f - lStringSize.Width / 2f,
                            CurrRect.Y + CurrRect.Height / 2f - lStringSize.Height / 2f
                        ));
                }
            }
        }

        private void GenerateArrayDates()
        {
            DateTime CurrMonth = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DateTime PrevMonth = CurrMonth.AddMonths(-1);
            DateTime NextMonth = CurrMonth.AddMonths(1);

            int DaysInMonthCurr = DateTime.DaysInMonth(CurrMonth.Year, CurrMonth.Month);
            int DaysInMonthPrev = DateTime.DaysInMonth(PrevMonth.Year, PrevMonth.Month);
            int DaysInMonthNext = DateTime.DaysInMonth(NextMonth.Year, NextMonth.Month);

            DateTime[] datesCurr = new DateTime[DaysInMonthCurr];
            DateTime[] datesPrev = new DateTime[DaysInMonthPrev];
            DateTime[] datesNext = new DateTime[DaysInMonthNext];

            for (int i = 0; i < DaysInMonthCurr; i++)
            {
                datesCurr[i] = new DateTime(CurrMonth.Year, CurrMonth.Month, i + 1);
            }

            for (int i = 0; i < DaysInMonthPrev; i++)
            {
                datesPrev[i] = new DateTime(PrevMonth.Year, PrevMonth.Month, i + 1);
            }

            for (int i = 0; i < DaysInMonthNext; i++)
            {
                datesNext[i] = new DateTime(NextMonth.Year, NextMonth.Month, i + 1);
            }
            
            arrDates = new DateTime[6, 7];

            int DayOfWeek = Array.IndexOf(strDays, CurrMonth.DayOfWeek.ToString());

            int iWeek = 0;
            //if (DayOfWeek > 0)
            {
                if (DayOfWeek == 0)
                {
                    DayOfWeek = 7;
                    iWeek++;
                }
                int intDay = DaysInMonthPrev;
                for (int i = DayOfWeek - 1; i >= 0; i--)
                {
                    arrDates[0, i] = datesPrev[intDay - 1];
                    intDay--;
                }
            }

            for (int iDay = 0; iDay < DaysInMonthCurr; iDay++)
            {
                DayOfWeek = Array.IndexOf(strDays, datesCurr[iDay].DayOfWeek.ToString());
                arrDates[iWeek, DayOfWeek] = datesCurr[iDay];
                if (DayOfWeek == 6)
                {
                    iWeek++;
                }
            }

            if (DayOfWeek < 7 || iWeek < 5)
            {
                int intDay = 0;
                for (int iW = iWeek; iW < 6; iW++)
                {
                    if (DayOfWeek == 6) 
                        DayOfWeek = -1;

                    for (int i = DayOfWeek + 1; i < 7; i++)
                    {
                        arrDates[iW, i] = datesNext[intDay];
                        intDay++;
                    }
                    DayOfWeek = -1;
                }
            }
        }
    }
}
