using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class TicketDAO
    {
        public MySqlConnection conn { get; set; }

        public TicketDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }

        public int createSchedule(int id_Sche, int id_S)
        {
            //kết nối database
            using (this.conn)
            {
                //lệnh select all trong sql
                string query = "insert into ticket(id_Sche, id_S, status) values(@id_Sche, @id_S, @status)";

                //chuyển lệnh sql sang định dạng của thư viện MySQL
                MySqlCommand comm = new MySqlCommand(query);
                comm.Connection = conn;
                comm.Parameters.AddWithValue("@id_Sche", id_Sche);
                comm.Parameters.AddWithValue("@id_S", id_S);
                comm.Parameters.AddWithValue("@status", true);

                //mở database
                conn.Open();

                int rs = comm.ExecuteNonQuery();

                return rs;
            }
        }
    }
}