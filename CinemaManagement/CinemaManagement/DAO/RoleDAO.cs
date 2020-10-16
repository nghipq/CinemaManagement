using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class RoleDAO
    {
        private MySqlConnection conn { get; set; }

        public RoleDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public List<Role> getAllRole()
        {
            List<Role> Rlist = new List<Role>();

            using (conn)
            {
                string sql = "select * from Role";
                MySqlCommand com = new MySqlCommand(sql, conn);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Rlist.Add(new Role {
                        id_Role = Convert.ToInt32(dr["id_Role"]),
                        Role_Name = dr["Role_Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Status = Convert.ToBoolean(dr["Status"]),
                    });
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return Rlist;
        }
    }
}