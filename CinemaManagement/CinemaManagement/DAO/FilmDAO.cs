using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class FilmDAO
    {
        private List<Films> ProList = new List<Films>();
        private MySqlConnection conn { get; set; }

        public FilmDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateFilm(String F_Name, int id_P, DateTime ReleaseDate, Double Rating, int LimitAge, DateTime AirDate, DateTime EndDate, String Description, Boolean Status)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    conn.Open();
                    string insertData = "insert into Films(F_Name,id_P,ReleaseDate,Rating,LimitAge,AirDate,EndDate,Description,Status)" +
                    "values (@F_Name, @id_P, @ReleaseDate, @Rating, @LimitAge, @AirDate, @EndDate, @Description, @Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);

                    command.Parameters.AddWithValue("@F_Name", F_Name);
                    command.Parameters.AddWithValue("@id_P", id_P);
                    command.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
                    command.Parameters.AddWithValue("@Rating", Rating);
                    command.Parameters.AddWithValue("@LimitAge", LimitAge);
                    command.Parameters.AddWithValue("@AirDate", AirDate);
                    command.Parameters.AddWithValue("@EndDate", EndDate);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Status", true);
                    result = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database due to" + ex.ToString());
                    MessageBox.Show("Failed to insert data due to" + ex.ToString());
                }

            }
            return result;
        }

        public List<Films> getAllFilm()
        {
            List<Films> list = new List<Films>();

            using (conn)
            {
                string sql = "select * from Films";
                MySqlCommand com = new MySqlCommand(sql);
                com.Connection = conn;

                conn.Open();

                MySqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Films
                    {
                        id_F = Convert.ToInt32(dr["id_F"]),
                        F_Name = dr["F_Name"].ToString(),
                        id_P = Convert.ToInt32(dr["id_P"]),
                        ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]),
                        Description = dr["Description"].ToString(),
                        Rating = Convert.ToDouble(dr["Rating"]),
                        LimitAge = Convert.ToInt32(dr["LimitAge"]),
                        AirDate = Convert.ToDateTime(dr["AirDate"]),
                        EndDate = Convert.ToDateTime(dr["EndDate"]),
                        Status = Convert.ToInt32(dr["status"])
                    });
                }

                //đóng db sau khi dùng xong nhe
                conn.Close();
            }

            return list;
        }
    }
}