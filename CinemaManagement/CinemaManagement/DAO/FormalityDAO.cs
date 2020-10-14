using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class FormalityDAO : Controller
    {
        private List<Formality> FoList = new List<Formality>();
        private MySql.Data.MySqlClient.MySqlConnection conn { get; set; }
        // GET: Formality
        public FormalityDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateFormality(String F_Name, String Description, int F_Price, bool Status)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    conn.Open();
                    string insertData = "insert into Formality(F_Name, Description, F_Price, Status)" +
                    "values (@F_Name, @Description,@F_Price, @Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);

                    command.Parameters.AddWithValue("@F_Name", F_Name);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@F_Price", F_Price);
                    command.Parameters.AddWithValue("@Status", Status);
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database due to" + ex.ToString());
                    MessageBox.Show("Failed to insert data due to" + ex.ToString());
                }

            }
            return result;
        }
        public List<Formality> getAllFormality()
        {
            using (conn)
            {
                string sql = "select * from Formality";
                MySqlCommand com = new MySqlCommand(sql);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    FoList.Add(new Formality
                    {
                        id_F = Convert.ToInt32(dr["id_F"]),
                        F_Name = dr["F_Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        F_Price = Convert.ToInt32(dr["F_Price"]),
                        Status = Convert.ToBoolean(dr["Status"]),
                    }) ;
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return FoList;
        }
    }
}