using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace APPI_DB
{
    public static class connection
    {
        private static string mysql_conn_str = "datasource=127.0.0.1;port=3306;username=root;password=;database=hjv;";
        private static string mssql_conn_str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hjv;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static MySqlConnection mysql_conn = null;
        public static SqlConnection mssql_conn = null;

        // Open the connection to the MySQL DB
        public async static void mysql_open_connection()
        {
            
            try
            {
                // set these values correctly for your database server
                MySqlConnection conn = new MySqlConnection(mysql_conn_str);
                conn.Open();
            } catch (TypeInitializationException ex)
            {
                throw ex;
            }
        }

        // Open the connection to the local SQL DB
        public async static void mssql_open_connection()
        {

            try
            {
                SqlConnection conn = new SqlConnection(mssql_conn_str);
                conn.Open();
            }
            catch (TypeInitializationException ex)
            {
                throw ex;
            }
        }

        // Close the connection to the MySQL DB
        public static void mysql_close_connection()
        {
            try
            {
                mysql_conn.Close();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        // Close the connection to the local SQL DB
        public static void mssql_close_connection()
        {
            try
            {
                mssql_conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
