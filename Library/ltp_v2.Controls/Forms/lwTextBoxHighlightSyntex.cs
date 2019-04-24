using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using System.Drawing;
using ltp_v2.Controls.Forms.TBHS.Util;
using System.Text.RegularExpressions;

namespace ltp_v2.Controls.Forms
{
    public class lwTextBoxHighlightSyntex : RichTextBox
    {
        #region Свойства
        /// <summary>
        /// Определитель обработки текстовых данных
        /// </summary>
        private bool mParsing = false;

        private HighlightItemCollection lHighlightItems;

        public HighlightItemCollection HighlightItems
        {
            get
            {
                if (lHighlightItems == null)
                {
                    lHighlightItems = new HighlightItemCollection();
                    lHighlightItems.AfterAddHL += new EventHandler(lHighlightItems_AfterAddHL);
                }
                return lHighlightItems;
            }
            set
            {
                HighlightItems.Clear();
                foreach (HighlightItem tmpHlI in value)
                {
                    this.HighlightItems.Add(tmpHlI);
                }
            }
        }

        void lHighlightItems_AfterAddHL(object sender, EventArgs e)
        {
            this.Invalidate();
            this.OnTextChanged(null);
        }

        public new String Text
        {
            get { return base.Text; }
            set
            {
                base.Text = value;
            }
        }
        #endregion

        #region Методы
        /// <summary>
        /// Получение позиции скрола
        /// </summary>
        /// <returns></returns>
        private unsafe Win32.POINT GetScrollPos()
        {
            Win32.POINT res = new Win32.POINT();
            IntPtr ptr = new IntPtr(&res);
            Win32.SendMessage(Handle, Win32.EM_GETSCROLLPOS, 0, ptr);
            return res;
        }

        private unsafe void SetScrollPos(Win32.POINT point)
        {
            IntPtr ptr = new IntPtr(&point);
            Win32.SendMessage(Handle, Win32.EM_SETSCROLLPOS, 0, ptr);

        }

        /// <summary>
        /// Добавление шрифтов в RTF 
        /// </summary>
        /// <param name="sb">RTF string builder</param>
        /// <param name="font">Добавляемый шрифт</param>
        /// <param name="fonts"></param>
        private void AddFontToTable(StringBuilder sb, Font font, ref int counter, Hashtable fonts)
        {
            if (!fonts.ContainsKey(font.Name + font.Size + font.Style))
            {
                sb.Append(@"{\f").Append(counter).Append(@"\fnil\fcharset204").Append(font.Name).Append(";}");
                fonts.Add(font.Name + font.Size + font.Style, counter++);
            }
        }
        /// <summary>
        /// Добавление цветов в RTF
        /// </summary>
        /// <param name="sb">RTF string builder</param>
        /// <param name="color">Добавляемый цвет</param>
        /// <param name="colors"></param>
        private void AddColorToTable(StringBuilder sb, Color color, ref int counter, Hashtable colors)
        {
            sb.Append(@"\red").Append(color.R).Append(@"\green").Append(color.G).Append(@"\blue").Append(color.B).Append(";");
            colors.Add(color, counter++);
        }

        private string GetColor(Color color, Hashtable colors)
        {
            return @"\cf" + colors[color];
        }

        private string GetBackColor(Color color, Hashtable colors)
        {
            return @"\cb" + colors[color];
        }

        private string GetFont(Font font, Hashtable fonts)
        {
            if (font == null)
                return "";

            return @"\f" + fonts[font.Name+font.Size+font.Style]
                + (font.Bold ? @"\b" : "")
                + (font.Italic ? @"\i" : "")
                + (font.Underline ? @"\ul" : "")
                + @"\fs" + ((int)(font.Size * 2)).ToString();
        }

        private string GetNewLine()
        {
            return "\\par\n";
        }

        private string GetEndTags()
        {
            return " ";
        }

        private string GetDefaultSettings(StringBuilder sb, Hashtable colors, Hashtable fonts)
        {
            return GetColor(ForeColor, colors) +
            GetFont(Font, fonts) +
            GetEndTags();
        }
        #endregion

        #region Подмена методов
        protected override void OnTextChanged(EventArgs e)
        {
            if (mParsing) return;
            mParsing = true;
            Win32.LockWindowUpdate(Handle);
            base.OnTextChanged(e);
            int cursorLoc = SelectionStart;

            Win32.POINT scrollPos = GetScrollPos();
            StringBuilder sb = new StringBuilder((int)(base.Text.Length * 1.5 + 150));
            sb.Append(@"{\rtf1\ansi\ansicpg1251\deff0\deflang1049{\fonttbl");

            //Создание таблицы шрифтов
            Hashtable fonts = new Hashtable();
            int fontCounter = 0;
            AddFontToTable(sb, this.Font, ref fontCounter, fonts);
            foreach (HighlightItem hlItem in HighlightItems)
            {
                if (hlItem.Font != null && !fonts.ContainsKey(hlItem.Font))
                    AddFontToTable(sb, hlItem.Font, ref fontCounter, fonts);
            }
            sb.Append("}");

            //Создание таблицы цвета
            sb.Append(@"{\colortbl ;");
            Hashtable colors = new Hashtable();
            int colorCounter = 1;
            AddColorToTable(sb, ForeColor, ref colorCounter, colors);
            AddColorToTable(sb, BackColor, ref colorCounter, colors);
            foreach (HighlightItem hlItem in HighlightItems)
            {
                if (!colors.ContainsKey(hlItem.ForeColor))
                    AddColorToTable(sb, hlItem.ForeColor, ref colorCounter, colors);
            }
            sb.Append("}").Append(@"\viewkind4\uc1\pard\ltrpar");
            sb.Append(GetDefaultSettings(sb, colors, fonts));

            //Нормализация синтексиса для RTF
            string lines = base.Text.Replace(@"\", @"\\").Replace("{", "\\{").Replace("}", "\\}");
            if (!string.IsNullOrEmpty(lines))
            {
                lines = lines.Replace("\r","").Replace("\n", "\\par");
                lines = lines.Replace("\\par", "\\par ");
                foreach (HighlightItem hlItem in HighlightItems)
                {
                    string Settings = GetColor(hlItem.ForeColor, colors) + GetFont(hlItem.Font, fonts) + GetEndTags();
                    Regex rx = new Regex(hlItem.MatchRegexSyntax, RegexOptions.IgnoreCase);
                    lines = rx.Replace(lines, "$1{" + Settings + "$2" + "}$3"); // + GetDefaultSettings(sb, colors, fonts) + "$3"
                }
            }
            sb.Append(lines);
            Rtf = sb.ToString();

            //Востановление первоначальных данных
            mParsing = false;
            SelectionStart = cursorLoc;
            SetScrollPos(scrollPos);
            Win32.LockWindowUpdate((IntPtr)0);
            Invalidate();
        }
        #endregion
    }
}
