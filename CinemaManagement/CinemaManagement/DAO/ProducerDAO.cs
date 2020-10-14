using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class ProducerDAO
    {
        private List<Producers> ProList = new List<Producers>();
        private MySqlConnection conn { get; set; }

        public ProducerDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateProducer(String P_Name, int id_N, String Description, DateTime Birthday, String Address, String PhoneNumber, String Email, Boolean Status)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    conn.Open();
                    string insertData = "insert into Producers(P_Name, id_N, Description, Birthday, Address, PhoneNumber, Email, Status)" +
                    "values (@P_Name, @id_N, @Description, @Birthday, @Address, @PhoneNumber, @Email, @Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);

                    command.Parameters.AddWithValue("@P_Name", P_Name);
                    command.Parameters.AddWithValue("@id_N", id_N);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Birthday", Birthday);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    command.Parameters.AddWithValue("@Email", Email);
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


        public List<Producers> getAllProducer()
        {
            
            using (conn)
            {
                string sql = "select * from Producers";
                MySqlCommand com = new MySqlCommand(sql);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    ProList.Add(new Producers
                    {
                        id_P = Convert.ToInt32(dr["id_P"]),
                        P_Name = dr["P_Name"].ToString(),
                        id_N = Convert.ToInt32(dr["id_N"]),
                        Description = dr["Description"].ToString(),
                        Birthday = Convert.ToDateTime(dr["Birthday"]),
                        Address = dr["Address"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Email = dr["Email"].ToString(),
                        Status = Convert.ToBoolean(true)
                    });
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return ProList;
        }
    }
}