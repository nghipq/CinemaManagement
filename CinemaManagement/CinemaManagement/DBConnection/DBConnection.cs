using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace CinemaManagement.DBConnection
{
    public class DBConnection
    {

        public MySqlConnection conn { get; set; }

        public DBConnection()
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Mysqlconnection"].ConnectionString;

            this.conn = new MySqlConnection(mainconn);
        }
    }
}