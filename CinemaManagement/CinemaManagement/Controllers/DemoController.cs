using CinemaManagement.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CinemaManagement.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            //Khai báo mảng quốc gia
            List<Nationality> NList = new List<Nationality>();

            //kết nối database
            MySqlConnection conn = new DBConnection.DBConnection().conn;

            //lệnh select all trong sql
            string query = "select * from Nationality";

            //chuyển lệnh sql sang định dạng của thư viện MySQL
            MySqlCommand comm = new MySqlCommand(query);
            comm.Connection = conn;

            //mở database
            conn.Open();

            //đọc dữ liệu trong database
            MySqlDataReader dr = comm.ExecuteReader();

            //dùng vòng lặp để lặp hết các hàng dữ liệu
            while (dr.Read())
            {
                NList.Add(new Nationality{
                    id_N = Convert.ToInt32(dr["id_N"]), 
                    N_Name = dr["N_Name"].ToString(),
                    Status = Convert.ToBoolean(dr["status"])
                });
            }

            //đóng db sau khi dùng xong nhe
            conn.Close();

            //truyền dữ liệu vào giao diện
            return View(NList);
        }
    }
}