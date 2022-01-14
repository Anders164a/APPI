using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace APPI_DB
{
    public static class connection
    {
        //private static string conn_str = "datasource=qrgfwg3;port=3306;username=root;password=;database=hjv;";
        private static string conn_str = "Server=localhost;Database=test;Uid=root;Pwd=;";
        public static MySqlConnection conn = null;

        public async static void open_connection()
        {
            try
            {
                // set these values correctly for your database server
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = "127.0.0.1",
                    UserID = "root",
                    Password = "",
                    Database = "test",
                };

                // open a connection asynchronously
                var connection = new MySqlConnection(builder.ConnectionString);

                await connection.OpenAsync();

                /*conn = new MySqlConnection(conn_str);

                conn.Open();*/
            } catch (TypeInitializationException ex)
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
