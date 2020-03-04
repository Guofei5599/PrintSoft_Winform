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
using System.Xml;

namespace Client
{
    public class SQLiteHelper
    {
        public static SQLiteConnection conn;

        /// <summary>
        /// Creates a new <see cref="SQLiteHelper"/> instance. The ctor is marked private since all members are static.
        /// </summary>
        private SQLiteHelper()
        {
            //var trans = conn.BeginTransaction(IsolationLevel.RepeatableRead);
        }

        public static bool SQLiteInit(string path,string password)
        {
            try
            {
                conn = new SQLiteConnection(path);
                conn.SetPassword(password);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                conn = null;
                return false;
            }
        }
        public static SQLiteConnection GetSQLiteConnection()
        {
            return conn;
        }
        public static bool ChangePassword(string path, string password)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(path);
                conn.Open();
                conn.ChangePassword("123");
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static SQLiteDataReader ExecuteDataReader(SQLiteConnection cn, string commandText)
        {
            SQLiteCommand cmd = new SQLiteCommand(commandText,cn);
            DataSet ds = new DataSet();
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            var sdr = cmd.ExecuteReader( CommandBehavior.CloseConnection);
            //SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            //da.Fill(ds);
            //da.Dispose();
            cmd.Dispose();
            return sdr;
        }

        public static object ExecuteScalar(SQLiteConnection cn, string commandText)
        {
            SQLiteCommand cmd = new SQLiteCommand(commandText,cn);
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            object result = cmd.ExecuteScalar();
            cmd.Dispose();
            return result;
        }
        public static int ExecuteNonQuery(SQLiteConnection cn, string commandText)
        {
            SQLiteCommand cmd = cn.CreateCommand();
            cmd.CommandText = commandText;
            if (cn.State == ConnectionState.Closed)
                cn.Open();
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return result;
        }
    }
}
