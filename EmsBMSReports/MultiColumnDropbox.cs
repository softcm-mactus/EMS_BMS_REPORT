using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;

namespace DataGridViewMultiColumnComboColumnDemo
{
    public class DataGridViewMultiColumnComboColumn : DataGridViewComboBoxColumn
    {
        public DataGridViewMultiColumnComboColumn()
        {
            //Set the type used in the DataGridView
            this.CellTemplate = new DataGridViewMultiColumnComboCell();
        }
    }
    public class DataGridViewMultiColumnComboCell : DataGridViewComboBoxCell
    {
        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewMultiColumnComboEditingControl);
            }
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DataGridViewMultiColumnComboEditingControl ctrl = DataGridView.EditingControl as DataGridViewMultiColumnComboEditingControl;
            ctrl.ownerCell = this;
        }
    }
    public class DataGridViewMultiColumnComboEditingControl : DataGridViewComboBoxEditingControl
    {
        /**************************************************************************************************/
        const int fixedAlignColumnSize = 100; //TODO: change to be configurable for every column...
        const int lineWidth = 1; //TODO: make this line width configurable
        public DataGridViewMultiColumnComboCell ownerCell = null;
        /**************************************************************************************************/
        public DataGridViewMultiColumnComboEditingControl()
            : base()
        {
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected override void OnSelectedValueChanged(EventArgs e)
        {
            base.OnSelectedValueChanged(e);
            if (ownerCell != null && Text != null && Text.Length>0 && ownerCell.RowIndex>-1) {
                var m = EmsBMSReports.DlgConfigureViewGroup.metaData[int.Parse(Text)];
                ownerCell.DataGridView.Rows[ownerCell.RowIndex].Cells[1].Value = m.name;
            }
        }
        /**************************************************************************************************/
        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            Rectangle rec = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            DataGridViewMultiColumnComboColumn column = ownerCell.OwningColumn as DataGridViewMultiColumnComboColumn;
            var values = column.DataSource as List<EmsBMSReports.DlgConfigureViewGroup.ColumnMetaData>;
            SolidBrush NormalText = new SolidBrush(System.Drawing.SystemColors.ControlText);
            SolidBrush normalBack = new SolidBrush(Color.White); //TODO: fix to be system edit box background
            string currentText = "";
            //If there is an item
            if (e.Index > -1 && e.Index<EmsBMSReports.DlgConfigureViewGroup.metaDataValues.Count)
            {
                //EmsBMSReports.DlgConfigureViewGroup.ColumnMetaData currentRow = Items[e.Index] as EmsBMSReports.DlgConfigureViewGroup.ColumnMetaData;
                var i = EmsBMSReports.DlgConfigureViewGroup.metaDataValues[e.Index];
                if (i != null)
                {
                    currentText = i.idName;

                    //first redraw the normal while background
                    e.Graphics.FillRectangle(normalBack, rec);
                    if (DroppedDown && !(Margin.Top == rec.Top))
                    {
                        int currentOffset = rec.Left;

                        SolidBrush HightlightedBack = new SolidBrush(System.Drawing.SystemColors.Highlight);
                        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        {
                            //draw selected color background
                            e.Graphics.FillRectangle(HightlightedBack, rec);
                        }

                        bool addBorder = false;

                        {

                            if (addBorder)
                            {
                                //draw dividing line
                                //currentOffset ++; 
                                SolidBrush gridBrush = new SolidBrush(Color.Gray); //TODO: make the border color configurable
                                long linesNum = lineWidth;
                                while (linesNum > 0)
                                {
                                    linesNum--;
                                    Point first = new Point(rec.Left + currentOffset, rec.Top);
                                    Point last = new Point(rec.Left + currentOffset, rec.Bottom);
                                    e.Graphics.DrawLine(new Pen(gridBrush), first, last);
                                    currentOffset++;
                                }
                            }
                            else
                                addBorder = true;

                            //now draw the relevant to this column value text
                            addColumnData(e, NormalText, normalBack, HightlightedBack, 5, rec.Top+1, 30, rec.Height-2, i.idName);
                            addColumnData(e, NormalText, normalBack, HightlightedBack, 35, rec.Top + 1, 360, rec.Height - 2, i.name);
                            addColumnData(e, NormalText, normalBack, HightlightedBack, 365, rec.Top + 1, 600, rec.Height - 2, i.source);
                        }
                    }
                    else
                        //if happens when the combo is closed, draw single standard item view
                        e.Graphics.DrawString(currentText, e.Font, NormalText, rec);

                }
            }
        }

        private static void addColumnData(DrawItemEventArgs e, SolidBrush NormalText, SolidBrush normalBack, SolidBrush HightlightedBack, int x, int y, int width, int height, string value)
        {
            SizeF extent = e.Graphics.MeasureString(value, e.Font);
            Rectangle textRec = new Rectangle(x, y, width, height);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                //draw selected
                SolidBrush HightlightedText = new SolidBrush(System.Drawing.SystemColors.HighlightText);
                //now redraw the backgrond it order to wrap the previous field if was too large
                e.Graphics.FillRectangle(HightlightedBack, x,y,width, height);
                //draw text as is 
                e.Graphics.DrawString(value, e.Font, HightlightedText, textRec);
            }
            else
            {
                //now redraw the backgrond it order to wrap the previous field if was too large
                e.Graphics.FillRectangle(normalBack, x,y,width,height);
                //draw text as is 
                e.Graphics.DrawString(value, e.Font, NormalText, textRec);
            }
        }
        /**************************************************************************************************/
    }
}