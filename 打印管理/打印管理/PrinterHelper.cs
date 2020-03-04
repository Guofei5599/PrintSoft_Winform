using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace 打印管理
{
    public class GetPrinterStatue
    {
        public enum PrinterStatus
        {
            其他状态 = 1,
            未知,
            空闲,
            正在打印,
            预热,
            停止打印,
            打印中,
            离线
        }
        public void asyncGetPrinterStat(string PrinterDevice,GroupMsg groupMsg)
        {
            Action<string, GroupMsg> act = (printerDevice, groupmsg) =>
              {
                  List<string> list = new List<string>();
                  foreach (var v in groupmsg.FileMsgList.FindAll(t => int.Parse(t.state) == 3))
                      list.Add(v.Printer);
              };
        }

        public PrinterStatus GetPrinterState(string PrinterDevice)
        {
            PrinterStatus ret = 0;
            string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
            ManagementObject printer = new ManagementObject(path);
            printer.Get();
            ret = (PrinterStatus)Convert.ToInt32(printer.Properties["PrinterStatus"].Value);
            return ret;
        }

        /// <summary>
        /// 获取打印机的当前状态
        /// </summary>
        /// <param name="PrinterDevice">打印机设备名称</param>
        /// <returns>打印机状态</returns>
        public static PrinterStatus GetPrinterStat(string PrinterDevice)
        {
            PrinterStatus ret = 0;
            string path = @"win32_printer.DeviceId='" + PrinterDevice + "'";
            ManagementObject printer = new ManagementObject(path);
            printer.Get();
            ret = (PrinterStatus)Convert.ToInt32(printer.Properties["PrinterStatus"].Value);
            return ret;
        }
    }
}
