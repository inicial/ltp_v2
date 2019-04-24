using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ltp_v2.Controls
{
    public static class em_DataGridView
    {
        /// <summary>
        /// Добавление колонки в DataGridView
        /// </summary>
        public static void AddColumns(this DataGridViewColumnCollection sender, string CellName, string HeaderName, string FormatDateTime)
        {
            sender.Add(CellName, HeaderName);
            sender[CellName].DataPropertyName = CellName;
            sender[CellName].DefaultCellStyle.Format = FormatDateTime;
        }

        /// <summary>
        /// Добавление колонки в DataGridView
        /// </summary>
        public static void AddColumns(this DataGridViewColumnCollection sender, string CellName, string HeaderName)
        {
            sender.Add(CellName, HeaderName);
            sender[CellName].DataPropertyName = CellName;
        }

        /// <summary>
        /// Добавление колонки в DataGridView с использованием сортировки
        /// </summary>
        public static void AddColumns(this DataGridViewColumnCollection sender, string CellName, string HeaderName, DataGridViewColumnSortMode SortMode)
        {
            sender.AddColumns(CellName, HeaderName);
            sender[CellName].SortMode = SortMode;
        }

        /// <summary>
        /// Добавление колонки в DataGridView с использованием видимости
        /// </summary>
        public static void AddColumns(this DataGridViewColumnCollection sender, string CellName, string HeaderName, bool Visible)
        {
            sender.AddColumns(CellName, HeaderName);
            sender[CellName].Visible = Visible;
        }

        public static void AddColumns(this DataGridViewColumnCollection sender, string CellName, string HeaderName, Type CellType)
        {
            if (CellType == typeof(DataGridViewCheckBoxColumn)
                || CellType == typeof(bool)
                || CellType == typeof(Boolean))
            {
                DataGridViewCheckBoxColumn DGVCBC = new DataGridViewCheckBoxColumn();
                DGVCBC.DataPropertyName = CellName;
                DGVCBC.HeaderText = HeaderName;
                sender.Add(DGVCBC);
            }

            //sender[CellName].
        }
    }
}
