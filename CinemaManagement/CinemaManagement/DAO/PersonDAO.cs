using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.DAO
{
    public class PersonDAO
    {
        private List<Persons> PList = new List<Persons>();
        private MySqlConnection conn { get; set; }

        public PersonDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreatePerson(String Per_Name, int id_N, int id_Role, int Gender, DateTime Birthday, String Description, Boolean Status)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    string insertData = "insert into Person(Per_Name,id_N,id_Role,Gender,Birthday,Description,Status" +
                    "values (@Per_Name, @id_N, @id_Role, @Gender, @Birthday , @Description , @Status)";
                    MySqlCommand command = new MySqlCommand(insertData, conn);

                    command.Parameters.AddWithValue("@Per_Name", Per_Name);
                    command.Parameters.AddWithValue("@id_N", id_N);
                    command.Parameters.AddWithValue("@id_Role", id_Role);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@Birthday", Birthday);
                    command.Parameters.AddWithValue("@Description", Description);
                    command.Parameters.AddWithValue("@Status", Status);

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