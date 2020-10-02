using CinemaManagement.Models;
using MySql.Data.MySqlClient;
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
        public int getAllRoomSeatByRoomId(int Id_R)
        {
            conn.Open();
            MySqlCommand command = conn.CreateCommand();
            command.Parameters.AddWithValue("@id_R", Id_R);
            command.CommandText = "SELECT * FROM `RoomSeat` WHERE id_R=@Id_R";
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
            {
                int id_S = rdr.GetInt32(0);
                int id_R = rdr.GetInt32(1);
                String S_Name = rdr.GetString(3);
                Boolean Status = rdr.GetBoolean(4);
            }
            conn.Close();
            return 1;

        }
    }
}