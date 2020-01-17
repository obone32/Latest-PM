using System;
using System.Data;
using System.Data.SqlClient;

namespace CloudTrixApp.Data
{
    public class PMMSData
    {
        public static string connectionString
                = "Data Source=(local);Initial Catalog=PMMS;Integrated Security=SSPI;";

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}



 
