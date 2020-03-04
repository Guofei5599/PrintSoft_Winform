using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 打印管理
{
    public class pictureDataDeal
    {

        public static byte[] GetPictureData(string imgPath)
        {
            FileStream file = new FileStream(imgPath, FileMode.Open);
            byte[] by = new byte[file.Length];
            file.Read(by,0,by.Length);
            file.Close();
            return by;
        }

        public static byte[] GetPictureData(Image img)
        {
            MemoryStream msStream = new MemoryStream();
            img.Save(msStream,ImageFormat.Png);
            byte[] bData = new byte[msStream.Length];
            msStream.Position = 0;
            msStream.Read(bData,0,bData.Length);
            msStream.Close();
            return bData;
        }

        public static Image ReturnPicture(byte [] streamByte)
        {
            MemoryStream me = new MemoryStream(streamByte);
            return Image.FromStream(me);
        }
        public static void SavePicture(Image img,string path)
        {
            if (img == null)
                img = Properties.Resources.空二维码; 
            else
                img.Save(path, ImageFormat.Png);
        }

        public static string ByteToStr(byte[] b)
        {
            string str = System.Convert.ToBase64String(b);
            return str;
        }
        public static byte[] StrToByte(string str)
        {
            byte[] by = Convert.FromBase64String(str);
            return by;
        }
    }
}
