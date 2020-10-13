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

        public Session getSessionById(DateTime StartTime, DateTime EndTime)
        {
            string sql = "select * from Session where StartTime = @Starttime and EndTime = @EndTime";
            using (MySqlConnection conn = new DBConnection.DBConnection().conn)
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@StartTime", StartTime.ToString());
                command.Parameters.AddWithValue("@EndTime", EndTime.ToString());

                MySqlDataReader dr = command.ExecuteReader();
                Session session = null;

                if(dr.Read())
                {
                    session = new Session
                    {
                        id_Ses = Convert.ToInt32(dr["id_Ses"]),
                        StartTime = Convert.ToDateTime(dr["StartTime"]),
                        EndTime = Convert.ToDateTime(dr["EndTime"]),
                        Status = Convert.ToBoolean(dr["Status"]),
                    };
                }

                conn.Close();

                return session;
            }
        } 

        public int createSession(DateTime StartTime, DateTime EndTime)
        {
            String sql = "Insert into Session (StartTime, EndTime, Status) values (@StartTime, @EndTime, @Status) ";

            using (MySqlConnection conn = new DBConnection.DBConnection().conn)
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@StartTime", StartTime.ToString());
                command.Parameters.AddWithValue("@EndTime", EndTime.ToString());
                command.Parameters.AddWithValue("@Status", true);

                conn.Open();
                int result = command.ExecuteNonQuery();
                conn.Close();

                return result;
            }

        }
    }
}