using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class RoomDAO
    {

        private MySqlConnection conn { get; set; }
        public RoomDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateRoom(int r_SeatNumber, int r_Size, int r_Type, int status)
        {
            String query = "Insert into Room(R_SeatNumber, R_Size, R_Type, Status) values(@r_SeatNumber, @r_Size, @r_Type, @status)";
            //chuyển lệnh sql sang định dạng của thư viện MySQL

            using (conn)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@r_SeatNumber", r_SeatNumber);
                command.Parameters.AddWithValue("@r_Size", r_Size);
                command.Parameters.AddWithValue("@r_Type", r_Type);
                command.Parameters.AddWithValue("@Status", status);
                conn.Open();
                int result = command.ExecuteNonQuery();
                return result;

            }


        }
    }
}