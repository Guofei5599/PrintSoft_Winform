using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace 打印管理
{
    public class SQLiteHelper
    {
        /// <summary>
        /// Creates a new <see cref="SQLiteHelper"/> instance. The ctor is marked private since all members are static.
        /// </summary>
        private SQLiteHelper()
        {
            //var trans = conn.BeginTransaction(IsolationLevel.RepeatableRead);
        }
        static object lockObj = new object();

        public static bool SQLiteInit(string path,string password)
        {
            try
            {
                lock(lockObj)
                {
                    using (var conn = new SQLiteConnection(path))
                    {
                        conn.SetPassword(password);
                        conn.Open();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static SQLiteConnection GetSQLiteConnection()
        {
            var conn = new SQLiteConnection(string.Format(@"Data Source={0}\PrintDB.db", Application.StartupPath));
            conn.SetPassword("jtmes");
            return conn;
        }
        public DataTable GetMsdr(string sql)
        {
            lock (lockObj)
            {
                var conn = GetSQLiteConnection();
                conn.Open();
                SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                conn.Close();
                return ds.Tables[0];
            }
        }
        public static bool ChangePassword(string path, string password)
        {
            try
            {
                lock (lockObj)
                {
                    SQLiteConnection conn = new SQLiteConnection(path);
                    conn.Open();
                    conn.ChangePassword("123");
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static SQLiteDataReader ExecuteDataReader(string commandText)
        {
            try
            {
                lock(lockObj)
                {
                    var cn = GetSQLiteConnection();
                    cn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(commandText, cn);
                    DataSet ds = new DataSet();
                    if (cn.State == ConnectionState.Closed)
                        cn.Open();
                    var sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    cmd.Dispose();
                    return sdr;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static object ExecuteScalar(string commandText)
        {
            try
            {
                lock(lockObj)
                {
                    var conn = GetSQLiteConnection();
                    conn.Open();
                    SQLiteCommand cmd = new SQLiteCommand(commandText, conn);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    object result = cmd.ExecuteScalar();
                    cmd.Dispose();
                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static int ExecuteNonQuery(string commandText)
        {
            try
            {
                lock(lockObj)
                {
                    var conn = GetSQLiteConnection();
                    conn.Open();
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = commandText;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static double GetUserID()
        {

            string sql1 = @"SELECT userid  from userid where ID = '1'";
            string sql2 = @"UPDATE UserID SET userid = userid+1";

            double ID = (double)ExecuteScalar(sql1);
            int result = ExecuteNonQuery(sql2);
            if (result == 1)
                return ID;
            else
                return -1;
            //MySqlConnection conn = mysqlConnect();
            //conn.Open();
            //MySqlCommand mysqlCommand = new MySqlCommand();
            //mysqlCommand.Connection = conn;
            //mysqlCommand.CommandText = @"GetUserID";
            //mysqlCommand.CommandType = CommandType.StoredProcedure;
            //MySqlParameter currentUserID_parameter = new MySqlParameter("?currentUserID", MySqlDbType.Double);
            //mysqlCommand.Parameters.Add(currentUserID_parameter);
            ////输出参数获取方法
            //currentUserID_parameter.Direction = ParameterDirection.Output;
            ////执行
            //mysqlCommand.ExecuteNonQuery();
            //conn.Close();
            //return (double)currentUserID_parameter.Value;
        }
    }
}
