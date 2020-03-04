using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public enum img
    {
        none,
        up,
        down
    }
    public class DataGridViewProgressBarCell : DataGridViewCell
    {
        public DataGridViewProgressBarCell()
        {
            this.ValueType = typeof(object);
            this.ReadOnly = false;
        }
        public  img currentImg = img.up;
        //设置进度条的背景色；
        public DataGridViewProgressBarCell(Color progressBarColor)
        : base()
        {
            ProgressBarColor = progressBarColor;
            //form
        }

        protected Color ProgressBarColor = Color.FromArgb(0, 255, 54); //进度条的默认背景颜色,绿色；
        protected override void Paint(Graphics graphics, Rectangle clipBounds,
        Rectangle cellBounds, int rowIndex,
        DataGridViewElementStates cellState,

        object value, object formattedValue,
        string errorText, DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            Color color;
            if (Selected)
                color = cellStyle.SelectionBackColor;
            else
                color = cellStyle.BackColor;
            using (SolidBrush backBrush = new SolidBrush(color))
            {
                graphics.FillRectangle(backBrush, cellBounds);
            }
            base.PaintBorder(graphics, clipBounds, cellBounds, cellStyle, advancedBorderStyle);

            using (SolidBrush brush = new SolidBrush(ProgressBarColor))
            {
                if (value != null)
                {
                    if (!string.IsNullOrEmpty(value.ToString()))
                    {
                        if (value.ToString().IndexOf(',') == -1)
                            return;
                        string temp1 = value.ToString().Split(',')[0];
                        string temp2 = value.ToString().Split(',')[1];
                        float num = Convert.ToSingle(temp1);
                        if (num == -1)
                        {
                            ProgressBarColor = Color.Gray;
                            graphics.FillRectangle(brush, cellBounds.X, cellBounds.Y + cellBounds.Height - 9, cellBounds.Width, 3);
                        }
                        else
                        {
                            ProgressBarColor = Color.FromArgb(0,255,54);
                            float percent = Math.Max(num / 100F, 0.01f);
                            graphics.FillRectangle(brush, cellBounds.X, cellBounds.Y + cellBounds.Height - 9, cellBounds.Width * percent, 3);
                        }
                        switch (currentImg)
                        {
                            case img.none:
                                break;
                            case img.up:
                                graphics.DrawImage(Image.FromFile("up.png"), new Point(cellBounds.X + cellBounds.Width - 20, cellBounds.Y + 10));
                                break;
                            case img.down:
                                graphics.DrawImage(Image.FromFile("down.png"), new Point(cellBounds.X + cellBounds.Width - 20, cellBounds.Y + 10));
                                break;
                        }
                        //string text = string.Format("{0}%", num);
                        this.ToolTipText = temp2;
                        SizeF rf = graphics.MeasureString(temp2, cellStyle.Font);
                        while (rf.Width > cellBounds.Width)
                        {
                            temp2 = temp2.Substring(0,temp2.Length-1);
                            rf = graphics.MeasureString(temp2, cellStyle.Font);
                        }
                        //float x = cellBounds.X + (cellBounds.Width - rf.Width) / 2f;
                        //float y = cellBounds.Y + (cellBounds.Height - rf.Height) / 2f;
                        float x = cellBounds.X + 2;
                        float y = cellBounds.Y + (cellBounds.Height - rf.Height) / 2f;
                        if (Selected)
                            color = cellStyle.SelectionForeColor;
                        else
                            color = cellStyle.ForeColor;
                        graphics.DrawString(temp2, cellStyle.Font, new SolidBrush(color), x, y);
                    }
                }
            }
        }
    }
    public class DataGridViewProgressBarColumn : DataGridViewColumn
    {
        public DataGridViewProgressBarColumn()
            : base(new DataGridViewProgressBarCell() )
        {
           
        }
    }
}
