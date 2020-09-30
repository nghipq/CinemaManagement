using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class RoomSeatDAO
    {
        private MySqlConnection conn { get; set; }
        public RoomSeatDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateSeat(String seatName, bool status)
        {
            String query = "Insert into RoomSeat(`S_Name`, `Status`) values(@seatName, @status)";
            //chuyển lệnh sql sang định dạng của thư viện MySQL

            using (conn)
            {
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@SeatName", seatName);
                command.Parameters.AddWithValue("@Status", status);
                conn.Open();
                int result = command.ExecuteNonQuery();
                return result;

            }


        }
    }
}