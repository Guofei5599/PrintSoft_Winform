using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 打印管理
{
   public class ConfigClass
    {
        [DllImport("Kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("Kernel32.dll")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
        public static string GetConfigString(string section, string key,string def)
        {
            string path = System.Environment.CurrentDirectory;
            path += "\\config.ini";
            StringBuilder language = new StringBuilder(255);
            GetPrivateProfileString(section, key, def, language, 255, path);
            return language.ToString();
        }
        public static void SetConfigString(string section, string key, string val)
        {
            string path = System.Environment.CurrentDirectory;
            path += "\\config.ini";
            WritePrivateProfileString(section, key, val, path);
        }

        public static void SaveCookie<T>(T tempT, string CookieName)
        {
            List<T> TempList = new List<T>();
            TempList.Add(tempT);
            using (FileStream fs = new FileStream(CookieName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, TempList);
            }
        }
        public static void SaveCookie_List<T>(T TempList, string CookieName)
        {
            if (TempList == null)
                return;
            using (FileStream fs = new FileStream(CookieName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, TempList);
            }
        }
        public static void SaveClass<T>(T TempClass, string CookieName)
        {
            using (FileStream fs = new FileStream(CookieName, FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, TempClass);
            }
        }
        public static List<T> LoadCookie<T>(string CookieName) where T : class
        {
            List<T> TempList = new List<T>();
            try
            {
                using (FileStream fs = new FileStream(CookieName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(fs);
                    return TempList = (List<T>)obj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static T LoadClass<T>(string CookieName) where T : class
        {
            try
            {
                using (FileStream fs = new FileStream(CookieName, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    object obj = bf.Deserialize(fs);
                    return (T)obj;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static List<Comm_Config> CommConfigList = new List<Comm_Config>();
        public static List<WarnLog> WarnLogList = new List<WarnLog>();
    }
    [Serializable]
    public class WarnLog
    {
        public string 报警编号 = "";
        public string 工位名称 = "";
        public string 报警名称 = "";
        public DateTime 报警时间 ;
        public DateTime 处理时间 ;
    }


    [Serializable]
    public class Comm_Config
    {
        public Comm_Config(int rows ,string type,string gw,string WriteAddr,string MBAddr,string WriteLength,string ReadAddr ,string RMBAddr,string ReadLength,string commstr)
        {
            序号 = rows.ToString();
            类型 = type;
            工位名称 = gw;
            写地址 = WriteAddr;
            目标地址 = MBAddr;
            写长度 = WriteLength;
            读长度 = ReadLength;
            读目标地址 = RMBAddr;
            读地址 = ReadAddr;
            通信字符串 = commstr;
        }
        public enum comm_Type
        {
            Serial = 0,
            Tcp
        }
        public string 序号 = "-1";
        public string 类型 = "";
        public string 工位名称 = "";
        public string 写地址 = "";
        public string 目标地址 = "";
        public string 写长度 = "";
        public string 读地址 = "";
        public string 读目标地址 = "";
        public string 读长度 = "";
        public string 通信字符串 = "";
    }
}
