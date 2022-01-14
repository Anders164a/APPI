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
        private static string conn_str = "datasource=185.19.132.71;user=root;password=;database=test;";
        public static MySqlConnection conn = null;

        public async static void open_connection()
        {
            try
            {
                // set these values correctly for your database server
                var builder = new MySqlConnectionStringBuilder
                {
                    Server = "185.19.132.71",
                    UserID = "root",
                    Password = "",
                    Database = "test",

                };

                // open a connection asynchronously
                using var connection = new MySqlConnection(builder.ConnectionString);
                connection.Open();

                await connection.OpenAsync();

                using var conn = new MySqlConnection("Server=127.0.0.1;User ID=root;Password=;Database=test");

                //await conn.OpenAsync();
                conn.Open();
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
