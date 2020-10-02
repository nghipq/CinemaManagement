using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class SessionDAO
    {
        public List<Session> listSes = new List<Session>();
        public MySqlConnection conn { get; set; }

        public SessionDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public int createSession(DateTime StartTime, DateTime EndTime)
        {

            String sql = "Insert into Session (StartTime, EndTime, Status) values (@StartTime, @EndTime, @Status) ";

            Console.WriteLine(StartTime.ToString());

            using (MySqlConnection conn = new DBConnection.DBConnection().conn)
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@StartTime", StartTime.ToString());
                command.Parameters.AddWithValue("@EndTime", EndTime.ToString());
                command.Parameters.AddWithValue("@Status", true);

                conn.Open();
                int result = command.ExecuteNonQuery();


                return result;
            }

        }
    }
}