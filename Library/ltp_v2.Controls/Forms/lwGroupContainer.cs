using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace ltp_v2.Controls.Forms
{
    [Designer(typeof(Design.dsgnLwGroupContainerDesigner))]
    public partial class lwGroupContainer : System.Windows.Forms.UserControl
    {
        #region Локальные переменные
        private System.Drawing.Drawing2D.LinearGradientMode pLinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
        private Color pLinearGradientColorFrom = Color.GhostWhite;
        private Color pLinearGradientColorTo = Color.LightGray;
        #endregion

        #region Глобальные переменные
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = true; }
        }

        /// <summary>
        /// Цвет текста заголовка
        /// </summary>
        [Category("Header"), DefaultValue(typeof(Color), "Black"), Description("Конечное значение градиента")]
        public Color ForeColorHeaderText
        {
            get { return lblGBText.ForeColor; }
            set
            {
                if (value == Color.Empty) value = Color.Black;
                lblGBText.ForeColor = value;
            }
        }

        /// <summary>
        /// Шрифт текста заголовка
        /// </summary>
        [Category("Header")]
        public Font FontHeaderText
        {
            get { return lblGBText.Font; }
            set
            {
                lblGBText.Font = value;
            }
        }

        /// <summary>
        /// Тип закраски загаловка
        /// </summary>
        [Category("Header"), DefaultValue(System.Drawing.Drawing2D.LinearGradientMode.Vertical)]
        public System.Drawing.Drawing2D.LinearGradientMode LinearGradientMode
        {
            get { return this.pLinearGradientMode; }
            set
            {
                this.pLinearGradientMode = value;
                pnlTop.Invalidate();
            }
        }

        /// <summary>
        /// Отрисовка градиента загаловка начальное значение
        /// </summary>
        [Category("Header"), DefaultValue(typeof(Color), "GhostWhite"), Description("Начальное значение градиента")]
        public Color LinearGradientColorFrom
        {
            get { return pLinearGradientColorFrom; }
            set
            {
                if (value == Color.Empty) value = Color.GhostWhite;
                pLinearGradientColorFrom = value;
                pnlTop.Invalidate();
            }
        }

        /// <summary>
        /// Отрисовка градиента загаловка конечное значение
        /// </summary>
        [Category("Header"), DefaultValue(typeof(Color), "LightGray"), Description("Конечное значение градиента")]
        public Color LinearGradientColorTo
        {
            get { return pLinearGradientColorTo; }
            set
            {
                if (value == Color.Empty) value = Color.LightGray;
                pLinearGradientColorTo = value;
                pnlTop.Invalidate();
            }
        }

        /// <summary>
        /// Заголовок группы
        /// </summary>
        [Category("Header")]
        public new string Text
        {
            get { return lblGBText.Text; }
            set { lblGBText.Text = value; }
        }

        public string TextHeader
        {
            get { return lblGBText.Text; }
            set { lblGBText.Text = value; }
        }

        // Высота загаловка
        public int HeaderHeight
        {
            get { return this.pnlTop.Height; }
        }

        /// <summary>
        /// Флаг полного отображения
        /// </summary>
        public bool FullView
        {
            get { return pnlContainer.Visible; }
            set
            {
                pnlContainer.Visible = value;
                if (OnChangeFullView != null)
                    OnChangeFullView(this, null);
                pbMinimizeButton.Invalidate();
            }
        }
        #endregion

        #region События
        public event EventHandler OnChangeFullView;
        #endregion

        public lwGroupContainer()
        {
            InitializeComponent();
            base.AutoSize = false;
            this.OnChangeFullView += new EventHandler(lwGroupContainer_OnChangeFullView);
        }

        #region Обработка событий
        private void lwGroupContainer_OnChangeFullView(object sender, EventArgs e)
        {
            if (!FullView)
                this.Height = pnlTop.Top + pnlTop.Height;
            else
                this.Height = pnlTop.Top + pnlTop.Height + pnlContainer.Height;
        }

        private void pnlContainer_DockChanged(object sender, EventArgs e)
        {
            if (pnlContainer.Dock != DockStyle.Top)
                pnlContainer.Dock = DockStyle.Top;
        }

        private void lwGroupContainer_Resize(object sender, EventArgs e)
        {
            if (FullView)
            {
                pnlContainer.Height = this.Height - pnlTop.Height - pnlTop.Top;
            }
        }

        private void pbMinimizeButton_Click(object sender, EventArgs e)
        {
            this.FullView = !this.FullView;
        }

        private void pbMinimizeButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle CurrRect = new Rectangle(0, 0, pbMinimizeButton.Width, pbMinimizeButton.Height);

            Graphics gx = e.Graphics;

            float PercentDraw = 0.2f;
            gx.FillRectangle(new SolidBrush(this.LinearGradientColorTo), new Rectangle(0, 0, CurrRect.Width, (int)(CurrRect.Height * PercentDraw)));
            gx.FillRectangle(new SolidBrush(this.pLinearGradientColorFrom), new Rectangle(0, (int)(CurrRect.Height - CurrRect.Height * PercentDraw), CurrRect.Width, (int)(CurrRect.Height * PercentDraw)));
            gx.DrawRectangle(new Pen(this.ForeColor), CurrRect);

            Icon UseIco = (this.FullView)
                ? global::ltp_v2.Controls.Properties.Resources.Minimaze16x16
                : global::ltp_v2.Controls.Properties.Resources.Maximize16x16;

            gx.DrawIcon(UseIco
                , CurrRect.Width / 2 - UseIco.Width / 2
                , CurrRect.Height / 2 - UseIco.Height / 2);
        }

        private void pnlTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (this.pnlTop.Width <= 0 || this.pnlTop.Height <= 0)
                return;

            int TopCenter = (int)((float)this.pnlTop.Height * 40f / 100f);
            int BottomCenter = (int)((float)this.pnlTop.Height - (float)TopCenter * 2f);

            using (LinearGradientBrush lgb = new LinearGradientBrush(
                    new Rectangle(new Point(0, (int)TopCenter - 1), new Size(this.pnlTop.Width, (int)BottomCenter + 1)),
                    this.LinearGradientColorFrom,
                    this.LinearGradientColorTo,
                    this.LinearGradientMode))
            {
                e.Graphics.FillRectangle(new SolidBrush(this.LinearGradientColorFrom), new RectangleF(0, 0, this.pnlTop.Width, TopCenter));
                e.Graphics.FillRectangle(new SolidBrush(this.LinearGradientColorTo), new RectangleF(0, TopCenter + BottomCenter, this.pnlTop.Width, TopCenter));
                e.Graphics.FillRectangle(lgb, 0, TopCenter, this.pnlTop.Width, BottomCenter);
            }
            base.OnPaint(e);
        }
        #endregion
    }
}
