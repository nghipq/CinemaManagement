using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class ScheduleDAO
    {
        public MySqlConnection conn { get; set; }
        public ScheduleDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public int createSchedule(int id_Ses, int id_F)
        {
            //kết nối database
            using (this.conn)
            {
                //lệnh select all trong sql
                string query = "insert into schedule(id_Ses, id_F, status) values(@id_Ses, @id_F, @status)";

                //chuyển lệnh sql sang định dạng của thư viện MySQL
                MySqlCommand comm = new MySqlCommand(query);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@id_Ses", id_Ses);
                comm.Parameters.AddWithValue("@id_F", id_F);
                comm.Parameters.AddWithValue("@status", true);

                //mở database
                conn.Open();

                int rs = comm.ExecuteNonQuery();

                return rs;
            }
        }
    }
}