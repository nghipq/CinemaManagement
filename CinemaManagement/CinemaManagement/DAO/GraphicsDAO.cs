using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows;

namespace CinemaManagement.DAO
{
    public class GraphicsDAO
    {
        private MySqlConnection conn;
        public GraphicsDAO()
        {
            this.conn = new DBConnection.DBConnection().conn;
        }
        public int CreateGraphics(int G_Type, DateTime DateUpdate, String Path)
        {
            int result = 0;
            using (conn)
            {
                try
                {
                    conn.Open();
                    String insertData = "INSERT INTO `Graphics`(id_F, G_Type, DateUpdate, Path, Status)" + "VALUES (@id_F,@G_Type,@DateUpdate,@Path,@Status) ";
                    MySqlCommand cmd = new MySqlCommand(insertData, conn);
                    cmd.Parameters.AddWithValue("@id_F", 1);//gia tri thu test nha khi nao get duoc thi tinh tiep
                    cmd.Parameters.AddWithValue("@G_Type", G_Type);
                    cmd.Parameters.AddWithValue("@DateUpdate", DateUpdate);
                    cmd.Parameters.AddWithValue("@Path", Path);
                    cmd.Parameters.AddWithValue("@Status", 1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to connect to database due to" + ex.ToString());
                    MessageBox.Show("Failed to insert data due to" + ex.ToString());
                }
            }
            return result;
        }
        public List<Graphics> getAllGraphics()
        {
            List<Graphics> listGraphic = new List<Graphics>();
            using (conn)
            {
                String getData = "SELECT * FROM Graphics";
                MySqlCommand cmd = new MySqlCommand(getData);
                cmd.Connection = conn;
                conn.Open();
                MySqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    listGraphic.Add(new Graphics
                    {
                       id_G=Convert.ToInt32(drd["id_G"]),
                       id_F=Convert.ToInt32(drd["id_F"]),
                       G_Type=Convert.ToInt32(drd["G_Type"]),
                       DateUpdate=Convert.ToDateTime(drd["DateUpdate"]),
                       Path=drd["Path"].ToString(),
                        Status=Convert.ToInt32(drd["Status"]),
                    }) ;
                }
                conn.Close();

            }
            return listGraphic;
        }
    }
}