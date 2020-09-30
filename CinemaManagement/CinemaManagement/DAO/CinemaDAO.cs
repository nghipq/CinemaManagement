using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class CinemaDAO
    {
        private MySqlConnection conn { get; set; }
        public CinemaDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateCinema(string C_Name, string C_Address, string C_Phone, string C_Email, string Description)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    string insertData = "insert into Cinema(C_Name,C_Address,C_Phone,C_Email,Description,Status)" +
                                         "values (@C_Name, @C_Address, @C_Phone, @C_Email, @Description,@Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);


                    command.Parameters.AddWithValue("@C_Name", C_Name);
                    command.Parameters.AddWithValue("@C_Address", C_Address);
                    command.Parameters.AddWithValue("@C_Phone", C_Phone);
                    command.Parameters.AddWithValue("@C_Email", C_Email);
                    command.Parameters.AddWithValue("@Description", Description);
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