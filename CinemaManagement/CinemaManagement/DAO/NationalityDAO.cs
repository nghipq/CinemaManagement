using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class NationalityDAO
    {
        private MySqlConnection conn { get; set; }

        public NationalityDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public List<Nationality> getAllNationality()
        {
            List<Nationality> list = new List<Nationality>();

            using(conn)
            {
                string sql = "select * from Nationality";
                MySqlCommand com = new MySqlCommand(sql);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Nationality
                    {
                        id_N = Convert.ToInt32(dr["id_N"]),
                        N_Name = dr["N_Name"].ToString(),
                        Status = Convert.ToBoolean(dr["status"])
                    });
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return list;
        }
    }
}