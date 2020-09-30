using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int CreateFilm(String F_Name, int id_P, DateTime ReleaseDate, Double Rating, int LimitAge, DateTime AirDate, DateTime EndDate, String Description, int Status)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    string insertData = "insert into Producer(F_Name,id_P,ReleaseDate,Rating,LimitAge,AirDate,EndDate,Description,Status" +
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

                    conn.Open();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database due to" + ex.ToString());
                    MessageBox.Show("Failed to insert data due to" + ex.ToString());
                }

            }
            return result;
        }
    }
}