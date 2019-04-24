using System;
using Microsoft.Office.Interop.Excel;

namespace Rep22341.ExportVariants
{
    public class ExcelControl
    {
        private Application APP;
        private Worksheet WorkSheet;

        public ExcelControl()
        {
            APP = new Application();
            APP.ScreenUpdating = false;
            APP.Workbooks.Add("");
            APP.Visible = true;
            Workbook WorkBook = APP.Workbooks[1];
            WorkSheet = (Worksheet)WorkBook.Worksheets[1];
        }

        public void SetCellFormat(int y)
        {
            WorkSheet.get_Range("A" + y, "Z" + y).NumberFormat = "@";
        }

        public void SetCellValue(int x, int y, object text, bool IsUpper)
        {
            if (text == null)
                return;

            WorkSheet.Cells[y, x] = (IsUpper ? text.ToString().ToUpper() : text.ToString());
        }

        public void SetCellValue(int x, int y, object text)
        {
            SetCellValue(x, y, text, true);
        }

        public void End()
        {
            APP.ScreenUpdating = true;
        }
    }
}
