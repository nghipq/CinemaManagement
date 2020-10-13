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
                string sql = "select * from Bill";
                MySqlCommand com = new MySqlCommand(sql);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Bill
                    {
                        id_B = Convert.ToInt32(dr["id_B"]),
                        id_Cus = Convert.ToInt32(dr["id_Cus"]),
                        id_Staff = Convert.ToInt32(dr["id_Staff"]),
                        DateBuy = Convert.ToDateTime(dr["DateBuy"]),
                        Total = Convert.ToInt32(dr["Total"]),
                        Status = Convert.ToBoolean(true)
                    });
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return list;
        }
    }
}