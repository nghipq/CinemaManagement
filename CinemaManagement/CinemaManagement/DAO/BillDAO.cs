using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class BillDAO
    {
        public MySqlConnection conn { get; set; }

        public BillDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public List<Bill> getAllBill() 
        {
            List<Bill> list = new List<Bill>();
            using (conn)
            {
                string aql = "Select * from Bill";
            }

            return list;
        }
    }
}