using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class FileInfoMsg
    {
        public static double GetFileKB(string path)
        {
            FileInfo info = new FileInfo(path);
            double d = Math.Ceiling(info.Length / 1024.0);
            return d;
        }
    }
}
