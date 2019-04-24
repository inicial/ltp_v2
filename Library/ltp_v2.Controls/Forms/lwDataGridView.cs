using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ltp_v2.Controls.Forms
{
    public class lwDataGridView : System.Windows.Forms.DataGridView
    {
        public Type DatasourceType;

        public lwDataGridView()
        {
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(lwDataGridView_DataBindingComplete);
        }

        void lwDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DatasourceType != null && this.Columns.Count > 0)
            {
                var myPropertyInfo = DatasourceType.GetProperties();
                foreach (var prop in myPropertyInfo)
                {
                    var defWidth = prop.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(DefaultWidth));
                    if (defWidth != null)
                    {
                        this.Columns[prop.Name].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        this.Columns[prop.Name].Width = ((DefaultWidth)defWidth).Width;
                    }
                    
                    var defVisible = prop.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(VisibleColumns));
                    if (defVisible != null)
                    {
                        this.Columns[prop.Name].Visible = ((VisibleColumns)defVisible).Visible;
                    }
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            CColumnHaderCell clsHeader = new CColumnHaderCell();
            clsHeader.Value = e.Column.HeaderCell.Value;
            e.Column.HeaderCell = clsHeader;
            e.Column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            base.OnColumnAdded(e);
        }

        protected override void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
        {
            base.OnColumnWidthChanged(e);

            this.Invalidate();
        }
    }

    public class CColumnHaderCell : DataGridViewColumnHeaderCell
    {
        public CColumnHaderCell()
        {
        }

        public int GetMinHeight(Graphics graphics)
        {
            int result = 0;
            foreach (DataGridViewColumn dgvc in this.DataGridView.Columns)
            {
                var ms = graphics.MeasureString(dgvc.HeaderText, this.DataGridView.Font);
                int CoutRows = (int)Math.Round(ms.Width / dgvc.Width + 0.5f);
                result = (int)Math.Max(CoutRows * ms.Height, result);
            }
            return result + 4;
        }

        private Rectangle CalculatePaintRect(Rectangle cellBounds)
        {
            Rectangle ctResult = new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Width, cellBounds.Height);
            string[] textsLine = this.Value.ToString().Split('|');
            
            string currentHeader = "";

            if (textsLine.Length > 1 && (currentHeader = textsLine[0].Trim()) != "")
            {
                //смещение ячейки влево
                bool notEnd = true;
                int leftColumnIndex = this.ColumnIndex;
                while (notEnd)
                {
                    leftColumnIndex--;
                    
                    if (leftColumnIndex < 0)
                        break;
                    if (currentHeader != this.DataGridView.Columns[leftColumnIndex].HeaderText.Split('|')[0])
                        break;

                    CColumnHaderCell clsLeftHeader = this.DataGridView.Columns[leftColumnIndex].HeaderCell as CColumnHaderCell;
                    ctResult.X = ctResult.X - clsLeftHeader.Size.Width;
                    ctResult.Width = ctResult.Width + clsLeftHeader.Size.Width;
                }

                notEnd = true;
                int rightColumnIndex = this.ColumnIndex;
                while (notEnd)
                {
                    rightColumnIndex++;

                    if (rightColumnIndex >= this.DataGridView.Columns.Count)
                        break;
                    if (currentHeader != this.DataGridView.Columns[rightColumnIndex].HeaderText.Split('|')[0])
                        break;

                    CColumnHaderCell clsLeftHeader = this.DataGridView.Columns[rightColumnIndex].HeaderCell as CColumnHaderCell;
                    ctResult.Width = ctResult.Width + clsLeftHeader.Size.Width;
                }
            }

            return ctResult;
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates dataGridViewElementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Rectangle groupCellBound = CalculatePaintRect(cellBounds);

            if (groupCellBound != cellBounds)
            {
                String OutText = value.ToString();

                cellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
                OutText = OutText.Split('|')[0];

                groupCellBound.Height = this.DataGridView.Font.Height + 5;

                this.DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.DataGridView.ColumnHeadersHeight = GetMinHeight(graphics) + groupCellBound.Height;

                base.Paint(graphics,
                    clipBounds,
                    groupCellBound,
                    rowIndex,
                    dataGridViewElementState,
                    OutText,
                    OutText,
                    errorText,
                    cellStyle,
                    advancedBorderStyle,
                    paintParts);

                OutText = value.ToString().Replace(OutText + "|", "");

                base.Paint(graphics,
                    clipBounds,
                    new Rectangle(cellBounds.X, cellBounds.Y + groupCellBound.Height - 1, cellBounds.Width, cellBounds.Height - groupCellBound.Height),
                    rowIndex,
                    dataGridViewElementState,
                    OutText,
                    OutText,
                    errorText,
                    cellStyle,
                    advancedBorderStyle,
                    paintParts);
            }
            else
            {
                base.Paint(graphics,
                    clipBounds,
                    cellBounds,
                    rowIndex,
                    dataGridViewElementState,
                    value,
                    formattedValue,
                    errorText,
                    cellStyle,
                    advancedBorderStyle,
                    paintParts);
            }
        }
    }
}
