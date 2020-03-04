using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace 打印管理
{
    // class SqlHelper
    //{
    //    public static MySqlConnection mysqlConnect()
    //    {
    //        MySqlConnection conn = new MySqlConnection(@"Data Source='127.0.0.1';Database = 'Printermanager';User Id='root';Password='jtmes';charset='gbk';pooling=false");
    //        conn.Open();
    //        return conn;
    //    }

    //    public static MySqlDataReader GetMsdr(string sql)
    //    {
    //        MySqlConnection conn = mysqlConnect();
    //        //if (conn.State == ConnectionState.Open)
    //        //    conn.Close();
    //        MySqlCommand cmd = new MySqlCommand(sql,conn);
    //        cmd.CommandTimeout = 60000;
    //        return cmd.ExecuteReader( System.Data.CommandBehavior.CloseConnection);
    //    }

    //    public static int ExectCmd(string sql, MySqlConnection conn)
    //    {
    //        MySqlCommand cmd = new MySqlCommand(sql, conn);
    //        cmd.CommandTimeout = 60000;
    //        int result = cmd.ExecuteNonQuery();
    //        return result;
    //    }
    //    public static int ExectCmd(string sql)
    //    {
    //        MySqlConnection conn = mysqlConnect();
    //        MySqlCommand cmd = new MySqlCommand(sql, conn);
    //        cmd.CommandTimeout = 60000;
    //        int result = cmd.ExecuteNonQuery();
    //        return result;
    //    }
    //    public static object GetFirstCell(string sql, MySqlConnection conn)
    //    {
    //        MySqlCommand cmd = new MySqlCommand(sql, conn);
    //        cmd.CommandTimeout = 60000;
    //        object result = cmd.ExecuteScalar();
    //        return result;
    //    }

    //    public static double GetUserID()
    //    {
            
    //        string sql1 = @"SELECT userid  from userid where ID = '1'";
    //        string sql2 = @"UPDATE UserID SET userid = userid+1";
    //        double ID = (double)GetFirstCell(sql1,mysqlConnect());
    //        MySqlConnection conn = mysqlConnect();
    //        int result = ExectCmd(sql2, conn);
    //        conn.Close();
    //        if (result == 1)
    //            return ID;
    //        else
    //            return -1;
    //        //MySqlConnection conn = mysqlConnect();
    //        //conn.Open();
    //        //MySqlCommand mysqlCommand = new MySqlCommand();
    //        //mysqlCommand.Connection = conn;
    //        //mysqlCommand.CommandText = @"GetUserID";
    //        //mysqlCommand.CommandType = CommandType.StoredProcedure;
    //        //MySqlParameter currentUserID_parameter = new MySqlParameter("?currentUserID", MySqlDbType.Double);
    //        //mysqlCommand.Parameters.Add(currentUserID_parameter);
    //        ////输出参数获取方法
    //        //currentUserID_parameter.Direction = ParameterDirection.Output;
    //        ////执行
    //        //mysqlCommand.ExecuteNonQuery();
    //        //conn.Close();
    //        //return (double)currentUserID_parameter.Value;
    //    }

        
    //}
}
