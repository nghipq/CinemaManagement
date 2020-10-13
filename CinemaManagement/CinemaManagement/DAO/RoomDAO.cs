using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class RoomDAO
    {

        private MySqlConnection conn { get; set; }
        public RoomDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateRoom(int id_C, int r_SeatNumber, int R_Size, int R_Type, int Status, int R_Row, int R_Col)
        {
            String query1 = "Insert into Room(id_C, R_SeatNumber, R_Size, R_Type, Status, R_Row, R_Col) values(@id_C ,@r_SeatNumber, @R_Size, @R_Type, @Status, @R_Row, @R_Col)";
            //chuyển lệnh sql sang định dạng của thư viện MySQL

            using (conn)
            {
                MySqlCommand command1 = new MySqlCommand(query1, conn);
                command1.Parameters.AddWithValue("@id_C", id_C);
                command1.Parameters.AddWithValue("@r_SeatNumber", r_SeatNumber);
                command1.Parameters.AddWithValue("@r_Size", R_Size);
                command1.Parameters.AddWithValue("@r_Type", R_Type);
                command1.Parameters.AddWithValue("@Status", Status);
                command1.Parameters.AddWithValue("@R_Row", R_Row);
                command1.Parameters.AddWithValue("@R_Col", R_Col);
                conn.Open();
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
                        for(int j = 0; j < R_Col; j++)
                        {
                            char word = (char)(i);
                            string nameSeat = Convert.ToString(word + j);
                            rsDAO.CreateSeat(nameSeat, true);
                        }

                    }
                }

                return result;
            }


        }

        public int SelectRoomById(int id_R)
        {
            int result = 0;
            using (conn)
            {
                
                try
                {
                    conn.Open();
                    String query = "SELECT * FROM `ROOM` WHERE id_R=@id_R";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@id_R", id_R);
                    result = command.ExecuteNonQuery();
                    MySqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        //int id_R = rdr.GetInt32(0);
                        int id_C = rdr.GetInt32(0);
                        int R_SeatNumber = rdr.GetInt32(1);
                        int R_Row = rdr.GetInt32(2);
                        int R_Col = rdr.GetInt32(3);
                        int R_Size = rdr.GetInt32(4);
                        int R_Type = rdr.GetInt32(5);
                        int Status = rdr.GetInt32(6);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed connect database" + ex.ToString());
                }
                conn.Close();
            }
            return result;
        }

        public int GetAllRoomByCinemaId(int id_C)
        {
            int result = 0;
            using (conn)
            {

                try
                {
                    conn.Open();
                    String query = "SELECT * FROM `ROOM` WHERE id_C=@id_C";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@id_C", id_C);
                    result = command.ExecuteNonQuery();
                    MySqlDataReader rdr = command.ExecuteReader();
                    while (rdr.Read())
                    {
                        //int id_R = rdr.GetInt32(0);
                        int id_R = rdr.GetInt32(0);
                        int R_SeatNumber = rdr.GetInt32(1);
                        int R_Row = rdr.GetInt32(2);
                        int R_Col = rdr.GetInt32(3);
                        int R_Size = rdr.GetInt32(4);
                        int R_Type = rdr.GetInt32(5);
                        int Status = rdr.GetInt32(6);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connect database" + ex.ToString());
                }
                conn.Close();
            }
            return result;
        }
    }
}