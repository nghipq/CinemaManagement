using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CinemaManagement.DAO
{
    public class RoomDAO
    {
        private List<Room> RoomList = new List<Room>();
        private MySqlConnection conn { get; set; }
        public RoomDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateRoom(int id_C, int r_SeatNumber, int R_Size, int R_Type, int Status, int R_Row, int R_Col)
        {
            //Console.WriteLine("" + id_C + r_SeatNumber + R_Size + R_Type + Status + R_Row + R_Col);
            String query1 = "Insert into Room(id_C, R_SeatNumber, R_Size, R_Type, Status, R_Row, R_Col) values(@id_C ,@r_SeatNumber, @R_Size, @R_Type, @Status, @R_Row, @R_Col)";
            //chuyển lệnh sql sang định dạng của thư viện MySQL

            using (conn)
            {
                conn.Open();

                MySqlCommand command1 = new MySqlCommand(query1, conn);
                command1.Parameters.AddWithValue("@id_C", id_C);
                command1.Parameters.AddWithValue("@r_SeatNumber", r_SeatNumber);
                command1.Parameters.AddWithValue("@R_Size", R_Size);
                command1.Parameters.AddWithValue("@R_Type", R_Type);
                command1.Parameters.AddWithValue("@Status", Status);
                command1.Parameters.AddWithValue("@R_Row", R_Row);
                command1.Parameters.AddWithValue("@R_Col", R_Col);

                int result = command1.ExecuteNonQuery();

                String query2 = "select max(id_R) as id_R from Room";
                MySqlCommand command2 = new MySqlCommand(query2, conn);
                MySqlDataReader dr = command2.ExecuteReader();

                if (dr.Read())
                {
                    int id_R = Convert.ToInt32(dr["id_R"]);

                    RoomSeatDAO rsDAO = new RoomSeatDAO();
                    for (int i = 65; i < R_Row + 65; i++)
                    {
                        for (int j = 1; j <= R_Col; j++)
                        {
                            string s = Encoding.ASCII.GetString(new byte[] { Convert.ToByte(i) });
                            string nameSeat = Convert.ToString(s + j);
                            rsDAO.CreateSeat(id_R, nameSeat, true);
                        }

                    }
                }

                return result;
            }
        }
        public List<Room> GetAllRoom()
        {

            using (conn)
            {
                string query = "select * from Room";
                
                MySqlCommand command = new MySqlCommand(query);
                command.Connection = conn;
                conn.Open();
                MySqlDataReader md = command.ExecuteReader();

                while (md.Read())
                {
                    RoomList.Add(
                        new Room
                        {
                            id_R = Convert.ToInt32(md["id_R"]),
                            id_C = Convert.ToInt32(md["id_C"]),
                            R_SeatNumber = Convert.ToInt32(md["R_SeatNumber"]),
                            R_Size = Convert.ToInt32(md["R_Size"]),
                            R_Type = Convert.ToInt32(md["R_Type"]),
                            Status = Convert.ToInt32(md["Status"]),
                            R_Row = Convert.ToInt32(md["R_Row"]),
                            R_Col = Convert.ToInt32(md["R_Col"]),
                        });
                }
            }
            conn.Close();
            return RoomList;
        }
        public int updateRoom(int id_R, int id_C, int R_SeatNumber, int R_Size, int R_Type, int Status, int R_Row, int R_Col)
        {
            string query = "UPDATE `Room` SET `id_C`= @id_C,`R_SeatNumber`=@R_SeatNumber," +
                "`R_Size`=@R_Size,`R_Type`=@R_Type,`Status`=@Status,`R_Row`=@R_Row,`R_Col`=@R_Col WHERE `id_R`= @id_R";
            using (conn)
            {
                MySqlCommand command = new MySqlCommand(query,conn);
                command.Connection = conn;
                conn.Open();
                MySqlDataReader md = command.ExecuteReader();
                command.Parameters.AddWithValue("@id_C", id_C);
                command.Parameters.AddWithValue("@r_SeatNumber", R_SeatNumber);
                command.Parameters.AddWithValue("@R_Size", R_Size);
                command.Parameters.AddWithValue("@R_Type", R_Type);
                command.Parameters.AddWithValue("@Status", Status);
                command.Parameters.AddWithValue("@R_Row", R_Row);
                command.Parameters.AddWithValue("@R_Col", R_Col);
                command.Parameters.AddWithValue("@id_R", id_R);
                int result = command.ExecuteNonQuery();
                return result;
            }
            

        }

    }
}