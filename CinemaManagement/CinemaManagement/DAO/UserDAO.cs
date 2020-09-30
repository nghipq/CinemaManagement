using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class UserDAO
    {
        private MySqlConnection conn { get; set; }
        public UserDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateUser(string Username, string Password, int id_N, int Gender, DateTime Birthday, String Email, String Address, String Phone, DateTime RegisDate, int Permission)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    string insertData = "insert into User(Username,Password,id_N,Gender,Birthday,Email,Address,Phone,RegisDate,Permission,Status" +
                                         "values (@Username,@Password,@id_N,Gender,@Birthday,@Email,@Address,@Phone,@RegisDate,@Permission,@Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);


                    command.Parameters.AddWithValue("@Username", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@id_N", id_N);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Birthday", Birthday);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Address", Address);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@RegisDate", RegisDate);
                    command.Parameters.AddWithValue("@Permission", Permission);
                    command.Parameters.AddWithValue("@Status", true);
                    result = command.ExecuteNonQuery();
                    conn.Open();
                    if (result < 0)
                    {
                        return -1;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database due to" + ex.ToString());
                    MessageBox.Show("Failed to insert data due to" + ex.ToString());
                }

            }
            return result;
        }
    }
}