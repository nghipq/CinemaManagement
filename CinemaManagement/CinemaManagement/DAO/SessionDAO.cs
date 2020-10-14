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

        public Session getSessionByTime(DateTime StartTime, DateTime EndTime)
        {
            string sql = "select * from Session where StartTime = @Starttime and EndTime = @EndTime";
            using (MySqlConnection conn = new DBConnection.DBConnection().conn)
            {
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@StartTime", StartTime.ToString());
                command.Parameters.AddWithValue("@EndTime", EndTime.ToString());

                conn.Open();

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
            String sql1 = "Insert into Session (StartTime, EndTime, Status) values (@StartTime, @EndTime, @Status) ";

            using (MySqlConnection conn = new DBConnection.DBConnection().conn)
            {
                MySqlCommand command1 = new MySqlCommand(sql1, conn);
                command1.Parameters.AddWithValue("@StartTime", StartTime.ToString("hh:mm:ss"));
                command1.Parameters.AddWithValue("@EndTime", EndTime.ToString("hh:mm:ss"));
                command1.Parameters.AddWithValue("@Status", true);

                conn.Open();
                int result = command1.ExecuteNonQuery();
                conn.Close();

                if(result > 0)
                {
                    string sql2 = "select max(id_Ses) as id_Ses from Session";
                    MySqlCommand command2 = new MySqlCommand(sql2, conn);

                    conn.Open();

                    MySqlDataReader dr = command2.ExecuteReader();

                    conn.Close();
                    if(dr.Read())
                    {
                        return Convert.ToInt32(dr["id_Ses"]);
                    }
                }

                return result;
            }

        }
    }
}