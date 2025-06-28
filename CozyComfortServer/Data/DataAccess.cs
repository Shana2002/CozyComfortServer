using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace CozyComfortServer.Data
{
    public static class DataAccess
    {
        private static string connectionString = "Server=(localdb)\\Local;Database=cozy_comfort_db;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}