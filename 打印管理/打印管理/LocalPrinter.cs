using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class LocalPrinter
    {
        private static PrintDocument fPrintDocument = new PrintDocument();
        /// <summary> 
        /// 获取本机默认打印机名称 
        /// </summary> 
        public static String DefaultPrinter
        {
            get { return fPrintDocument.PrinterSettings.PrinterName; }
        }
        /// <summary> 
        /// 获取本机的打印机列表。列表中的第一项就是默认打印机。 
        /// </summary> 
        public static List<String> GetLocalPrinters()
        {
            List<String> fPrinters = new List<string>();
            fPrinters.Add(DefaultPrinter); // 默认打印机始终出现在列表的第一项 
            foreach (String fPrinterName in PrinterSettings.InstalledPrinters)
            {
                if (!fPrinters.Contains(fPrinterName))
                    fPrinters.Add(fPrinterName);
            }
            return fPrinters;
        }

        public static List<string> GetPapers()
        {
            List<string> paperlist = new List<string>();
            List<string> printer = GetLocalPrinters();
            foreach (string name in printer)
            {
                fPrintDocument.PrinterSettings.PrinterName = name;
                foreach (PaperSize paper in fPrintDocument.PrinterSettings.PaperSizes)
                {
                    paperlist.Add(paper.PaperName);
                }
            }
            return paperlist;
        }
    }
}
