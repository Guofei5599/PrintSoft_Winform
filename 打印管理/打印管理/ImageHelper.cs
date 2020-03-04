using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打印管理
{
    public class ImageHelper
    {
        /// <summary>
        /// 生成文字图片
        /// </summary>
        /// <param name="text"></param>
        /// <param name="isBold"></param>
        /// <param name="fontSize"></param>
        public static Image CreateImage(GroupMsg msg,out int height)
        {
            height = 0;
            int[] column = new int[] {140,30,40 };
            int[] margin = new int[] { 3, 3, 3, 3 };
            int rowSpan = 3;
            int high = margin[3];
            Point startPoint = new Point(margin[0],margin[3]);
            Image image = new Bitmap(column[0]+ column[1]+column[2]+margin[0] + margin[2],margin[3]);

            Font font = new Font("宋体", 20, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image,column[0] + column[1] + column[2] + margin[0] + margin[2],margin[1], 30 , msg.GroupName,font);
            high += AddText(ref image, startPoint, msg.GroupName, font, column[0] + column[1] + column[2], 30,true,true,0);
            high += rowSpan;
            font = new Font("宋体", 19, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 25, msg.Area, font);
            high += AddText(ref image, startPoint,msg.Area, font, column[0] + column[1] + column[2], 25, true, false, 0);
            high += rowSpan;
            int sum = 0;
            if (msg.FileMsgList != null && msg.FileMsgList.Count != 0)
            {
                var tmpVar = msg.FileMsgList.GroupBy(t => t.Printer).ToList();
                foreach (var v in tmpVar)
                {
                    font = new Font("宋体", 10, FontStyle.Regular);
                    startPoint.Y = high;
                    image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, FileHelper.SubStringByByte(v.Key, 16) + "输出", font);
                    high += AddText(ref image, startPoint, FileHelper.SubStringByByte(v.Key, 16) + "输出", font, column[0] + column[1] + column[2], 20, true, true, 2);
                    high += rowSpan;
                    var Enum = v.GetEnumerator();
                    Enum.MoveNext();
                    while (true)
                    {
                        var flist = Enum.Current;
                        sum += int.Parse(flist.Count);
                        string fileName = flist.FileName;
                        string count = flist.Count.ToString();
                        string verForm = flist.VerForm.ToString();

                        if (!Enum.MoveNext() || Enum == null)
                        {
                            font = new Font("宋体", 10, FontStyle.Regular);
                            startPoint.Y = high;
                            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 17, FileHelper.SubStringByByte2(fileName, 6), font);
                            high += AddText(ref image, startPoint, FileHelper.SubStringByByte2(fileName, 12), font, column[0], 17, true, false, 2);
                            high += rowSpan;
                            AddText(ref image, new Point(startPoint.X + column[0], startPoint.Y), count, font, column[1], 17, false, false, 2);
                            AddText(ref image, new Point(startPoint.X + column[0] + column[1], startPoint.Y), verForm, font, column[2], 17, false, false, 2);
                            break;
                        }
                        else
                        {
                            font = new Font("宋体", 10, FontStyle.Regular);
                            startPoint.Y = high;
                            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 17, FileHelper.SubStringByByte2(fileName, 6), font);
                            high += AddText(ref image, startPoint, FileHelper.SubStringByByte2(fileName, 12), font, column[0], 17, true, false, 0);
                            high += rowSpan;
                            AddText(ref image, new Point(startPoint.X + column[0], startPoint.Y), count, font, column[1], 17, false, false, 0);
                            AddText(ref image, new Point(startPoint.X + column[0] + column[1], startPoint.Y), verForm, font, column[2], 17, false, false, 0);
                        }
                    }
                }
                font = new Font("宋体", 10, FontStyle.Bold);
                startPoint.Y = high;
                image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, string.Format(@"文件总数：{0}", sum.ToString()), font);
                high += AddText(ref image, startPoint, string.Format(@"文件总数：{0}", sum.ToString()), font, column[0] + column[1] + column[2], 20, true, true, 0);
                high += rowSpan;
            }
            else
            {
                font = new Font("宋体", 10, FontStyle.Regular);
                startPoint.Y = high;
                image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, "打印输出", font);
                high += AddText(ref image, startPoint, "打印输出", font, column[0] + column[1] + column[2], 20, true, true, 2);
                high += rowSpan;

                font = new Font("宋体", 10, FontStyle.Regular);
                startPoint.Y = high;
                image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 17, FileHelper.SubStringByByte2(msg.FileName, 12), font);
                high += AddText(ref image, startPoint, FileHelper.SubStringByByte2(msg.FileName, 12), font, column[0], 17, true, false, 2);
                high += rowSpan;
                AddText(ref image, new Point(startPoint.X + column[0], startPoint.Y), msg.Count.ToString(), font, column[1], 17, false, false, 2);
                AddText(ref image, new Point(startPoint.X + column[0] + column[1], startPoint.Y), msg.VerForm.ToString(), font, column[2], 17, false, false, 2);

            }
            font = new Font("宋体", 10, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, 3, msg.Note,font);
            high += AddHeightText(ref image, startPoint, msg.Note, font, column[0] + column[1] + column[2], 20, 3, true, true, 0xF);
            high += rowSpan;
            if (!File.Exists(frm_Main.sysConfigData.BarcodePath))
            {
                MessageBox.Show("二维码路径设置异常！");
                return null;
            }
            Image i = Image.FromFile(frm_Main.sysConfigData.BarcodePath);
            //if (i.Size.Width > column[0] + column[1] + column[2])
            //{
            //    MessageBox.Show("二维码图片尺寸过大！");
            //    height = high;
            //    return null;
            //}
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, i.Height + 10);
            high += AddImage(ref image, i, startPoint, column[0] + column[1] + column[2], i.Height + 10, 0);
            high += rowSpan;
            font = new Font("宋体", 16, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 22, msg.Price.ToString(), font);
            high += AddText(ref image, startPoint, msg.Price.ToString() + "元", font, column[0] + column[1] + column[2], 22, false, false, 0);
            high += rowSpan;
            string shopName = frm_Main.sysConfigData.ShopName;
            font = new Font("宋体", 14, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, shopName, font);
            high += AddText(ref image, startPoint, shopName, font, column[0] + column[1] + column[2], 20, false, false, 0);
            high += rowSpan;
            font = new Font("宋体", 14, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 20, string.Format(@"{0}/{1}", msg.Area, msg.Time), font);
            high += AddText(ref image, startPoint, string.Format(@"{0}/{1}", msg.Area, msg.Time), font, column[0] + column[1] + column[2], 20, false, false, 0);
            high += rowSpan;
            font = new Font("宋体", 14, FontStyle.Bold);
            startPoint.Y = high;
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 25, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font);
            high += AddText(ref image, startPoint, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font, column[0] + column[1] + column[2], 25, false, false, 0);
            high += rowSpan;
            font = new Font("宋体", 14, FontStyle.Bold);
            startPoint.Y = high;
            string p = msg.Phone == null ? "" : msg.Phone.ToString();
            image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high, 25, p, font);
            high += AddText(ref image, startPoint, p, font, column[0] + column[1] + column[2], 25, false, false, 0);
            high += rowSpan;
            //font = new Font("宋体", 20, FontStyle.Bold);
            //startPoint.Y = high;
            //image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], margin[1], high,10, "打印机1 输出...打印机1 输出...打印机1 输出...",
            //    font);
            //high += AddHeightText(ref image, startPoint, "打印机1 输出...打印机1 输出...打印机1 输出...", font, 200, 35,10, true, true, 0xF);

            //Image i = Image.FromFile(@"二维码.png");
            //startPoint.Y = high;
            //image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high,i.Height+10);
            //AddImage(ref image,i,startPoint, column[0] + column[1] + column[2], i.Height + 10,0);
            //startPoint.Y = high;
            //high += 30;
            //image = addRow(image, column[0] + column[1] + column[2] + margin[0] + margin[2], high + margin[1]);
            //AddText(ref image, startPoint, "文件1", font, column[0], 30, true, false, 0x0);
            //AddText(ref image, new Point(startPoint.X + column[0],startPoint.Y), "12", font, column[1], 30, true, false, 0x0);
            //AddText(ref image, new Point(startPoint.X + column[0] + column[1], startPoint.Y), "正反", font, column[2], 30, true, false, 0x0);
            height = high;
            return image;
        }


        public static Image addRow(Image image,int width,int preHeight,int high,string value,Font font)
        {
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Graphics g = Graphics.FromImage(image);
            SizeF sizef = g.MeasureString(value, font, PointF.Empty, format);//得到文本的宽高
            int x = (int)sizef.Width / width;
            x = x + 1;
            Image tmpImage = new Bitmap(width, preHeight+ high * x);
            g = Graphics.FromImage(tmpImage);
            g.DrawImage(image, new PointF());
            return tmpImage;
        }
        public static Image addRow(Image image, int width, int preHeight, int high,int rows, string value, Font font)
        {
            int x ;
            x = rows;
            Image tmpImage = new Bitmap(width, preHeight + high * x);
            Graphics g = Graphics.FromImage(tmpImage);
            g.DrawImage(image, new PointF());
            return tmpImage;
        }
        public static Image addRow(Image image, int width, int preHeight, int high)
        {
            Image tmpImage = new Bitmap(width, preHeight + high);
            Graphics g = Graphics.FromImage(tmpImage);
            g.DrawImage(image, new PointF());
            return tmpImage;
        }
        public static int AddText(ref Image image, Point startPoint, string value, Font font, int width, int height, bool isLeft, bool isBottom, int border)
        {
            int RealHeight;
            Point initPoint = new Point(startPoint.X, startPoint.Y);
            //绘笔颜色
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Graphics g = Graphics.FromImage(image);
            SizeF sizef = g.MeasureString(value, font, PointF.Empty, format);//得到文本的宽高
            int x = (int)sizef.Width / width;
            x = x + 1;
            string realStr = "";
            int index = 0;
            for (int i = 0; i < x; i++)
            {
                string s = "";
                while ((value.Length > index))
                {
                    if ((g.MeasureString(s, font, PointF.Empty, format).Width >= (float)(width)))
                        break;
                    s += value[index ++];
                }
                realStr += s + ";";
            }
            RealHeight = height * x;
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(startPoint,new Size(width, RealHeight));
            Point drawPoint = startPoint;
            string[] valueArr = realStr.Split(';');
            for (int i = 0; i < x; i++)
            {
                if (isLeft)
                    drawPoint.X = startPoint.X ;
                else
                {
                    drawPoint.X = (int)(width - sizef.Width) / 2 + startPoint.X;
                }
                if (isBottom)
                {
                    drawPoint.Y = startPoint.Y + (int)(height - sizef.Height) + i* height;
                }
                else
                {
                    drawPoint.Y = startPoint.Y + (int)(height - sizef.Height) / 2 + i * height;
                }
                RectangleF rect1 = new RectangleF(drawPoint.X, drawPoint.Y, width, sizef.Height);
                //绘制图片
                g.DrawString(valueArr[i], font, brush, rect1);
            }
            Pen p = new Pen(brush,1);
            if ((border & 0x01) == 0x01)
                g.DrawLine(p,initPoint, new Point(initPoint.X + width, initPoint.Y));
            if (((border >> 1) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X, initPoint.Y + RealHeight-1), new Point(initPoint.X + width, initPoint.Y + RealHeight-1));
            if (((border >> 2) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X, initPoint.Y), new Point(initPoint.X, initPoint.Y + RealHeight));
            if (((border >> 3) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X + width, initPoint.Y), new Point(initPoint.X + width, initPoint.Y + RealHeight));
            //释放对象
            g.Dispose();
            return RealHeight;
        }

        public static int AddHeightText(ref Image image, Point startPoint, string value, Font font, int width, int height,int rows, bool isLeft, bool HeightCenter, int border)
        {
            int RealHeight;
            Point initPoint = new Point(startPoint.X, startPoint.Y);
            //绘笔颜色
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Graphics g = Graphics.FromImage(image);
            SizeF sizef = g.MeasureString(value, font, PointF.Empty, format);//得到文本的宽高
            int realrow = (int)sizef.Width / width + 1;
            int x = rows;
            int tmprow = (rows - realrow) / 2;
            tmprow = Math.Max(0,tmprow);

            string realStr = "";
            int index = 0;
            for (int i = 0; i < x; i++)
            {
                string s = "";
                while ((value.Length > index))
                {
                    if ((g.MeasureString(s, font, PointF.Empty, format).Width >= (float)(width)))
                        break;
                    s += value[index++];
                }
                realStr += s + ";";
            }
            RealHeight = height * x;
            SolidBrush brush = new SolidBrush(Color.Black);
            Rectangle rect = new Rectangle(startPoint, new Size(width, RealHeight));
            Point drawPoint = startPoint;
            string[] valueArr = realStr.Split(';');
            for (int i = 0; i < x; i++)
            {
                if (i >= valueArr.Length)
                    break;
                if (isLeft)
                    drawPoint.X = startPoint.X;
                else
                {
                    drawPoint.X = (int)(width - sizef.Width) / 2;
                }
                if (HeightCenter)
                {
                    drawPoint.Y = startPoint.Y + (int)(height - sizef.Height)/2 + (i+ tmprow) * height;
                }
                else
                {
                    drawPoint.Y = startPoint.Y + (int)(height - sizef.Height) / 2 + i * height;
                }
                RectangleF rect1 = new RectangleF(drawPoint.X, drawPoint.Y, width, sizef.Height);
                //绘制图片
                g.DrawString(valueArr[i], font, brush, rect1);
            }
            Pen p = new Pen(brush, 1);
            if ((border & 0x01) == 0x01)
                g.DrawLine(p, initPoint, new Point(initPoint.X + width, initPoint.Y));
            if (((border >> 1) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X, initPoint.Y + RealHeight-1), new Point(initPoint.X + width, initPoint.Y + RealHeight-1));
            if (((border >> 2) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X, initPoint.Y), new Point(initPoint.X, initPoint.Y + RealHeight));
            if (((border >> 3) & 0x01) == 0x01)
                g.DrawLine(p, new Point(initPoint.X + width, initPoint.Y), new Point(initPoint.X + width, initPoint.Y + RealHeight));
            //释放对象
            g.Dispose();
            return RealHeight;
        }
        public static int AddImage(ref Image image,Image newImg ,Point startPoint,  int width, int height, int border)
        {
            Point initPoint = new Point(startPoint.X, startPoint.Y);
            SizeF sizef = newImg.Size;
            float tmpW = width - 50;
            float tmpH = tmpW / sizef.Width * sizef.Height;
            height = (int)tmpH + 10;
            Point drawPoint = new Point(initPoint.X+(int)(width - tmpW)/2, initPoint.Y + (int)(height - tmpH) /2);
            //绘笔颜色
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            Graphics g = Graphics.FromImage(image);
            SolidBrush brush = new SolidBrush(Color.Black);
            RectangleF rect = new RectangleF(drawPoint.X, drawPoint.Y, tmpW, tmpH);
            g.DrawImage(newImg, rect);
            //Pen p = new Pen(brush, 1);
            //if ((border & 0x01) == 0x01)
            //    g.DrawLine(p, initPoint, new Point(initPoint.X + width, initPoint.Y));
            //if (((border >> 1) & 0x01) == 0x01)
            //    g.DrawLine(p, new Point(initPoint.X, initPoint.Y + RealHeight), new Point(initPoint.X + width, initPoint.Y + RealHeight));
            //if (((border >> 2) & 0x01) == 0x01)
            //    g.DrawLine(p, new Point(initPoint.X, initPoint.Y), new Point(initPoint.X, initPoint.Y + RealHeight));
            //if (((border >> 3) & 0x01) == 0x01)
            //    g.DrawLine(p, new Point(initPoint.X + width, initPoint.Y), new Point(initPoint.X + width, initPoint.Y + RealHeight));
            //释放对象
            g.Dispose();
            return height;
        }
    }
}
