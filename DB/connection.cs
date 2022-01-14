using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB
{
    public static class connection
    {
        private static string conn_str = "datasource=127.0.0.1;port=3306;username=root;password=;database=hjv";
        public static MySqlConnection conn = null;

        public static void open_connection()
        {
            try
            {
                conn = new MySqlConnection(conn_str);

                conn.Open();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void close_connection()
        {
            try
            {
                conn.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
