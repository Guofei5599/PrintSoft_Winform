using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    [Serializable]
    public class FileMsg
    {
        public bool isInit  { set; get; }
        public string FileName { set; get; }
        public string Count { set; get; }
        public string state { set; get; }
        public string LoadTime { set; get; }
        public string FinishTime { set; get; }
        public string DeleteTime { set; get; }
        public string VerForm { set; get; }
        public string PrintColor { set; get; }
        public string PaperType { set; get; }
        public string Printer { set; get; }
        public string PageCount { set; get; }
        public string Price { set; get; }
        public string InitPrice { set; get; }
        public string FullName { set; get; }
        public string UserID { set; get; }
        public bool isNew { set; get; }
        public bool isNormalFile { set; get; }
        public bool isRemove { set; get; }
        public double FileSize { set; get; }

        /// <summary>
        /// 单击控件时设置版面
        /// </summary>
        public void SetClickVerForm()
        {
            string[] elementArr = new string[] { "正反", "单面","首单" };
            int index = Array.IndexOf(elementArr, VerForm);
            if (PrintColor == "彩色")
                VerForm = elementArr[1];
            else if (PageCount == "1")
            {
                VerForm = elementArr[1];
            }
            else
            {
                index += 1;
                if (index >= elementArr.Length)
                    index = 0;
                VerForm = elementArr[index];
            }
        }

        public void SetDefaultVerForm()
        {
            if (PrintColor == "彩色")
            {
                VerForm = "单面";
            }
        }

        /// <summary>
        /// 单击控件时设置颜色
        /// </summary>
        public void SetClickColor()
        {
            string[] elementArr = new string[] {"黑白", "彩色" };
            int index = Array.IndexOf(elementArr, PrintColor);
            index += 1;
            if (index >= elementArr.Length)
                index = 0;
            PrintColor = elementArr[index];
        }

        /// <summary>
        /// 单击控件时设置颜色
        /// </summary>
        public void SetClickPaper()
        {
            List<string> list = new List<string>();
            if (PrintColor == "彩色")
            {
                foreach (var v in GetPaperType.ColorPaperList)
                    list.Add(v);
            }
            else
            {
                foreach (var v in GetPaperType.BWPaperList)
                    list.Add(v);
            }
            if (list.Count == 0)
                PaperType = "----";
            else
            {
                string[] elementArr = list.ToArray();
                int index = Array.IndexOf(elementArr, PaperType);
                index += 1;
                if (index >= elementArr.Length)
                    index = 0;
                PaperType = elementArr[index];
            }
        }
        public void SetDefaultPaper()
        {
            if (PrintColor == "彩色")
            {
                PaperType = GetPaperType.defaultColorPaper;
            }
            else
            {
                PaperType = GetPaperType.defaultBWPaper;
            }
        }

        public void SetClickPrinter()
        {
            List<string> list = new List<string>();
            if (PrintColor == "彩色")
            {
                foreach (var v in GetPrinterType.ColorPrinterList)
                    list.Add(v);
            }
            else
            {
                foreach (var v in GetPrinterType.BWPrinterList)
                    list.Add(v);
            }
            if (list.Count == 0)
                Printer = "----";
            else
            {
                string[] elementArr = list.ToArray();
                int index = Array.IndexOf(elementArr, Printer);
                index += 1;
                if (index >= elementArr.Length)
                    index = 0;
                Printer = elementArr[index];
            }
        }
        public void SetDefaultPrinter()
        {
            if (PrintColor == "彩色")
            {
                Printer = GetPrinterType.defaultColorPrinter;
            }
            else
            {
                Printer = GetPrinterType.defaultBWPrinter;
            }
        }

        public string GetPrice()
        {
            if (VerForm == "首单")
            {
                return isNormalFile ? "----" : (Math.Round(double.Parse(Count) * (double.Parse(PageCount) + 1) * double.Parse(GetPaperPrice.PriceList.Find(t => t.ColorVerForm == (PrintColor + "正反") && t.PaperType == PaperType.Split(':')[0]).price), 2, MidpointRounding.AwayFromZero)).ToString();
            }
            return isNormalFile ? "----" : (Math.Round(double.Parse(Count) * double.Parse(PageCount) * double.Parse(GetPaperPrice.PriceList.Find(t => t.ColorVerForm == (PrintColor + VerForm.ToString()) && t.PaperType == PaperType.Split(':')[0]).price),2, MidpointRounding.AwayFromZero)).ToString();
        }

    }

    [Serializable]
    public class GroupMsg
    {
        public List<FileMsg> FileMsgList { set; get; }
        public bool isCheck { set; get; }
        public string UserID { set; get; }
        public string state { set; get; }
        public bool isRemove = false;
        public bool isManual { set; get; }
        public bool isClearFile { set; get; }
        public bool isChange { set; get; }
        public string LoadTime { set; get; }
        public string FinishTime { set; get; }
        public string DeleteTime { set; get; }
        public string SetTime { set; get; }
        public string CreateTime { set; get; }
        public bool isInit { set; get; }
        public string FileDirectory { set; get; }
        public bool isPrint { set; get; }
        public bool isShow { set; get; }
        public bool isAbort { set; get; }
        public bool isCanceling { set; get; }
        public string FileName { set; get; }
        public string GroupName { set; get; }
        public string Count { set; get; }
        public string VerForm { set; get; }
        public string PrintColor { set; get; }
        public string PaperType { set; get; }
        public string Printer { set; get; }
        public string PageCount { set; get; }
        public string InitPageCount { set; get; }
        public string Price { set; get; }
        public string InitPrice { set; get; }
        public string Time { set; get; }
        public string Area { set; get; }
        public string Phone { set; get; }
        public string Note { set; get; }
        public string FullName { set; get; }
        public string PayType { set; get; }
        private float fileSum
        {
            get
            {
                int sum = 0;
                foreach (var v in FileMsgList)
                    sum += int.Parse(v.Count);
                return sum;
            }
        }
        public double fileSize
        {
            get
            {
                double sum = 0;
                foreach (var v in FileMsgList)
                    sum += v.FileSize;
                return sum;
            }
        }
        private float finishCount
        {
            get
            {
                int sum = 0;
                foreach (var v in FileMsgList)
                {
                    if (int.Parse(v.state) >= 3)
                        sum += int.Parse(v.Count);
                }
                return sum;
            }
        }
        //private float fileSum { get { return FileMsgList.Count * int.Parse( Count); } }
        //private float finishCount { get { return FileMsgList.Count(t => int.Parse( t.state) >= 3) * int.Parse(Count); } }

        /// <summary>
        /// 获取订单列表的文件名显示字符串
        /// </summary>
        /// <returns></returns>
        public string GetDisplayFileName()
        {
            string tmpName = null;
            if (isManual == false)
            {
                tmpName = FileMsgList.Count == 1 ? FileMsgList[0].FileName : string.Format("共{0}个文件({1}/{2})", fileSum, finishCount, fileSum);
                return ((finishCount) / fileSum * 100).ToString() + "," + tmpName;
            }
            else
            {
                return FileName;
            }
        }

        /// <summary>
        /// 获取订单列表份数显示字符
        /// </summary>
        /// <returns></returns>
        public string GetDisplayCount()
        {
            if (FileMsgList == null || FileMsgList.Count == 0)
                return Count.ToString();
            else
            {
                if (FileMsgList.Count == FileMsgList.FindAll(t => t.Count == FileMsgList[0].Count).Count)
                {
                    Count = FileMsgList[0].Count.ToString();
                    return FileMsgList[0].Count.ToString();
                }

                else
                {
                    Count = "多选";
                    return "多选";
                }
            }

        }
        public void SetClickCount(int tmpcount)
        {
            Count = tmpcount.ToString();
            if (FileMsgList != null)
                FileMsgList.ForEach(t=>t.Count = tmpcount.ToString());
        }


        /// <summary>
        /// 获取订单版面
        /// </summary>
        /// <returns></returns>
        public string GetDisplayVerForm()
        {
            if (FileMsgList == null || FileMsgList.Count == 0)
                return VerForm;
            else
            {
                if (FileMsgList.Count == FileMsgList.FindAll(t => t.VerForm == FileMsgList[0].VerForm).Count)
                {
                    VerForm = FileMsgList[0].VerForm;
                    return FileMsgList[0].VerForm.ToString();
                }
                else
                {
                    VerForm = "多选";
                    return "多选";
                } 
            }
        }
        /// <summary>
        /// 单击控件时设置版面
        /// </summary>
        public void SetClickVerForm()
        {
            string[] elementArr = new string[] { "多选", "正反", "单面","首单" };
            int index = Array.IndexOf(elementArr, VerForm);
            if (PrintColor == "彩色")
                VerForm = elementArr[2];
            else if (FileMsgList != null && (FileMsgList.Count ==  FileMsgList.FindAll(t=>t.PageCount == "1").Count))
            {
                VerForm = elementArr[2];
            }
            else
            {
                if (index == -1)
                    index = 0;
                index += 1;
                if (index >= elementArr.Length)
                    index = 1;
                if(VerForm == "多选" && FileMsgList != null && FileMsgList.FindIndex(t=>t.PageCount == "1") != -1)
                    VerForm = elementArr[2];
                else
                    VerForm = elementArr[index];
            }
            if (FileMsgList != null)
            {
                foreach (var v in FileMsgList)
                    v.VerForm = (v.PageCount == "1" ? "单面" : VerForm);
            }
        }

        public void SetDefaultVerForm()
        {
            if (PrintColor == "彩色")
            {
                if (FileMsgList != null)
                {
                    foreach (var v in FileMsgList)
                    {
                        v.VerForm = "单面";
                    }
                }
                    
            }
        }

        /// <summary>
        /// 获取订单版面
        /// </summary>
        /// <returns></returns>
        public string GetDisplayColor()
        {
            //string[] elementArr = new string[] { "正反","单面"};
            if (FileMsgList == null || FileMsgList.Count == 0)
                return PrintColor;
            else
            {
                if (FileMsgList.Count == FileMsgList.FindAll(t => t.PrintColor == FileMsgList[0].PrintColor).Count)
                {
                    PrintColor = FileMsgList[0].PrintColor.ToString();
                    return FileMsgList[0].PrintColor.ToString();
                }
                else
                {
                    PrintColor = "多选";
                    return "多选";
                } 
            }
        }
        /// <summary>
        /// 单击控件时设置颜色
        /// </summary>
        public void SetClickColor()
        {
            string[] elementArr = new string[] { "多选", "黑白", "彩色" };
            int index = Array.IndexOf(elementArr, PrintColor);
            if (index == -1)
                index = 0;
            index += 1;
            if (index >= elementArr.Length)
                index = 1;
            PrintColor = elementArr[index];
            if (FileMsgList != null)
                FileMsgList.ForEach(t=>t.PrintColor = PrintColor);
        }

        /// <summary>
        /// 获取纸张类型
        /// </summary>
        /// <returns></returns>
        public string GetDisplayPaper()
        {
            //string[] elementArr = new string[] { "正反","单面"};
            if (FileMsgList == null || FileMsgList.Count == 0)
                return PaperType;
            else
            {
                if (FileMsgList.Count == FileMsgList.FindAll(t => t.PaperType == FileMsgList[0].PaperType).Count)
                {
                    PaperType = FileMsgList[0].PaperType.ToString();
                    return FileMsgList[0].PaperType.ToString();
                }
                else
                {
                    PaperType = "多选";
                    return "多选";
                } 
            }
        }
        /// <summary>
        /// 单击控件时设置颜色
        /// </summary>
        public void SetClickPaper()
        {
            List<string> list = new List<string>();
            if (PrintColor == "多选")
                return;
            else if (PrintColor == "彩色")
            {
                foreach (var v in GetPaperType.ColorPaperList)
                    list.Add(v);
            }
            else
            {
                foreach (var v in GetPaperType.BWPaperList)
                    list.Add(v);
            }
            if (list.Count == 0)
                PaperType = "----";
            else
            {
                list.Insert(0, "多选");
                string[] elementArr = list.ToArray();
                int index = Array.IndexOf(elementArr, PaperType);
                if (index == -1)
                    index = 0;
                index += 1;
                if (index >= elementArr.Length)
                    index = 1;
                PaperType = elementArr[index];
            }
            if (FileMsgList != null)
                FileMsgList.ForEach(t=>t.PaperType = PaperType);
        }
        public void SetDefaultPaper()
        {
            if (PrintColor == "彩色")
            {
                PaperType = GetPaperType.defaultColorPaper;
            }
            else
            {
                PaperType = GetPaperType.defaultBWPaper;
            }
            if (FileMsgList != null)
                FileMsgList.ForEach(t => t.PaperType = PaperType);
        }

        /// <summary>
        /// 获取打印机类型
        /// </summary>
        /// <returns></returns>
        public string GetDisplayPrinter()
        {
            if (FileMsgList == null || FileMsgList.Count == 0)
                return Printer;
            else
            {
                if (FileMsgList.Count == FileMsgList.FindAll(t => t.Printer == FileMsgList[0].Printer).Count)
                {
                    Printer = FileMsgList[0].Printer.ToString();
                    return FileMsgList[0].Printer.ToString();
                }
                else
                {
                    Printer = "多选";
                    return "多选";
                }
                    
            }
        }
        public void SetClickPrinter()
        {
            List<string> list = new List<string>();
            if (PrintColor == "多选")
                return;
            else if (PrintColor == "彩色")
            {
                foreach (var v in GetPrinterType.ColorPrinterList)
                    list.Add(v);
            }
            else
            {
                foreach (var v in GetPrinterType.BWPrinterList)
                    list.Add(v);
            }
            if (list.Count == 0)
                Printer = "----";
            else
            {
                list.Insert(0, "多选");
                string[] elementArr = list.ToArray();
                int index = Array.IndexOf(elementArr, Printer);
                if (index == -1)
                    index = 0;
                index += 1;
                if (index >= elementArr.Length)
                    index = 1;
                Printer = elementArr[index];
            }
            if (FileMsgList != null)
                FileMsgList.ForEach(t=>t.Printer = Printer);
        }
        public void SetDefaultPrinter()
        {
            if (PrintColor == "彩色")
            {
                Printer = GetPrinterType.defaultColorPrinter;
            }
            else
            {
                Printer = GetPrinterType.defaultBWPrinter;
            }
            if (FileMsgList != null)
                FileMsgList.ForEach(t => t.Printer = Printer);
        }

        public string GetPrice()
        {
            if (FileMsgList == null || FileMsgList.Count == 0)
            {
                return Price;
            }
            else
            {
                double tmpPrice = 0;
                foreach (var subv in FileMsgList)
                {
                    if (subv.InitPrice == "-1" || subv.InitPrice == null)
                    {
                        subv.InitPrice = "-2";
                        subv.Price = subv.GetPrice();
                    }
                    else if (subv.InitPrice == "-2")
                        subv.Price = subv.GetPrice();
                    else
                        subv.Price = subv.InitPrice;
                    //subv.Price = subv.isNormalFile ? "----" : (int.Parse(subv.Count) * int.Parse(subv.PageCount) * float.Parse(GetPaperPrice.PriceList.Find(t=>t.ColorVerForm == ("黑白" + subv.VerForm.ToString()) && t.PaperType == subv.PaperType.Split(':')[0]).price)).ToString();
                    tmpPrice += (subv.Price == "----" ? 0 : double.Parse(subv.Price));
                }
                double tmpPrice1 = (tmpPrice * double.Parse(FileHelper.rowMsg["活动折扣"]) + double.Parse(FileHelper.rowMsg["附加费用"]) + double.Parse(FileHelper.rowMsg["配送费"]));
                tmpPrice1 = tmpPrice1 > double.Parse(FileHelper.rowMsg["起步价"]) ? tmpPrice1 : double.Parse(FileHelper.rowMsg["起步价"]);
                string p = Math.Round(tmpPrice1, 1, MidpointRounding.AwayFromZero).ToString();
                return p;
                //string sd = FileMsgList.Count() == FileMsgList.Count(t => t.isNormalFile) ? "----" : Math.Round(Math.Max((tmpPrice * float.Parse(FileHelper.rowMsg["活动折扣"]) + float.Parse(FileHelper.rowMsg["附加费用"]) + float.Parse(FileHelper.rowMsg["配送费"])), float.Parse(FileHelper.rowMsg["起步价"])), 1, MidpointRounding.AwayFromZero).ToString();
                //return FileMsgList.Count() == FileMsgList.Count(t => t.isNormalFile) ? "----" : Math.Round(Math.Max((tmpPrice * float.Parse(FileHelper.rowMsg["活动折扣"]) + float.Parse(FileHelper.rowMsg["附加费用"]) + float.Parse(FileHelper.rowMsg["配送费"])), float.Parse(FileHelper.rowMsg["起步价"])), 1, MidpointRounding.AwayFromZero).ToString();
            }
        }
             
    }

    public enum emVerForm
    {
        多选 = 0,
        正反,
        单面
    }
    public enum emPrintColor
    {
        多选 = 0,
        黑白 ,
        彩色
    }
}
