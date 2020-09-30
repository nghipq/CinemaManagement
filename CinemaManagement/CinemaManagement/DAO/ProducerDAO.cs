﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                    string insertData = "insert into Producer(P_Name,id_N,Description,Birthday,Address,PhoneNumber,Email,Status" +
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

                    conn.Open();

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