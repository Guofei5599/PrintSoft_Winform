using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace 打印管理
{
    public class Log
    {
        public DateTime CurrentTime { set; get; }
        public string NoteString { set; get; }
    }
    public class LogOperate
    {
        static ConcurrentQueue<Log> msg_Queue = new ConcurrentQueue<Log>();
        public static void Init()
        {
            if (!frm_Main.logFlag)
                return;
            if (!Directory.Exists(Application.StartupPath + @"\log"))
            {
                Directory.CreateDirectory(Application.StartupPath + @"\log");
            }
            DirectoryInfo info = new DirectoryInfo(Application.StartupPath + @"\log");
            foreach (var v in info.GetFiles())
            {
                try
                {
                    if ((DateTime.Now - v.CreationTime).TotalHours > 48)
                        v.Delete();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public static void Add(string msg)
        {
            if (!frm_Main.logFlag)
                return;
            msg_Queue.Enqueue( new Log() { CurrentTime = DateTime.Now, NoteString = msg });
        }
        static IAsyncResult iar = null;
        public static void Start()
        {
            if (!frm_Main.logFlag)
                return;
            StartFlag = true;
            iar = act.BeginInvoke(null,null);
        }
        public static void Stop()
        {
            if (!frm_Main.logFlag)
                return;
            StartFlag = false;
            act.EndInvoke(iar);
        }


        static bool StartFlag = false;
        static Action act = () =>
          {
              string path = Application.StartupPath + @"\log\logtext " + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt";
              while (StartFlag || msg_Queue.Count > 0)
              {
                  if (msg_Queue.Count > 0)
                  {
                      Log tmp = null;
                      List<string> list = new List<string>();
                      while (msg_Queue.Count > 0)
                      {
                          if(msg_Queue.TryDequeue(out tmp))
                            list.Add(tmp.CurrentTime.ToString() + " :" + tmp.NoteString);
                      }
                      try
                      {
                          File.AppendAllLines(path, list);  
                      }
                      catch (Exception ex)
                      {
                          MessageBox.Show(ex.Message);
                      }
                  }
                  Thread.Sleep(100);
              }
          };
    }
}
