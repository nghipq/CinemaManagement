using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using CinemaManagement.DAO;

namespace CinemaManagement.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admins/insertProducers
        [HttpGet]
        public ActionResult insertProducer()
        {
            return View();
        }
        
        //GET: Admins/insertFilm
        [HttpGet]
        public ActionResult InsertCinema()
        {
            return View();
        }
        //POST Admin/InsertCinema/InsertCinemaDAO
        [HttpPost]
        public ActionResult InsertCinema(FormCollection formCollection)
        {

            CinemaDAO cDAO = new CinemaDAO();
            string C_Name = formCollection["C_Name"];       
            string C_Address = formCollection["C_Address"];       
            string C_Phone = formCollection["C_Phone"];
            string C_Email = formCollection["C_Email"];
            string Description = formCollection["Description"];

            cDAO.CreateCinema(C_Name, C_Address, C_Phone, C_Email, Description);

            return View();
        }

        [HttpGet]
        public ActionResult insertProducers()
        {
            return View();
        }

<<<<<<< HEAD

        // Post: Admins/insertProducers
=======
>>>>>>> 343a0acfbce2166e940d71df208c506761498196
        [HttpPost]
        public ActionResult insertProducers(FormCollection formCollection)
        {

            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

            ProducerDAO pDAO = new ProducerDAO();

            string P_Name = formCollection["P_Name"];
            int id_N = Convert.ToInt32(formCollection["id_N"]);
            string Description = formCollection["Description"];
            DateTime Birthday = Convert.ToDateTime(formCollection["Birthday"]);
            string PhoneNumber = formCollection["PhoneNumber"];
            string Address = formCollection["Address"];
            string Email = formCollection["Email"];

            pDAO.CreateProducer(P_Name, id_N, Description, Birthday, Address, PhoneNumber, Email, true);

            return View();
        }
<<<<<<< HEAD
        
        //POST: Admins/insertFilm
=======

        //Get Film
        [HttpGet]
        public ActionResult insertFilm()
        {
            return View();
        }

>>>>>>> 343a0acfbce2166e940d71df208c506761498196
        [HttpPost]
        public ActionResult insertFilmAction(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

            FilmDAO fDAO = new FilmDAO();
            string F_Name = formCollection["F_Name"];
            int id_P = Convert.ToInt32(formCollection["id_P"]);
            DateTime ReleaseDate = Convert.ToDateTime(formCollection["ReleaseDate"]);
            Double Rating = Convert.ToDouble(formCollection["Rating"]);
            int LimitAge = Convert.ToInt32(formCollection["LimitAge"]);
            DateTime AirDate = Convert.ToDateTime(formCollection["AirDate"]);
            DateTime EndDate = Convert.ToDateTime(formCollection["EndDate"]);
            String Description = formCollection["Description"];


            fDAO.CreateFilm(F_Name, id_P, ReleaseDate, Rating, LimitAge, AirDate, EndDate, Description, true);

            return View();
        }
<<<<<<< HEAD
        
        //GET: Admins/insertSchedule
=======

        //GetPerson
>>>>>>> 343a0acfbce2166e940d71df208c506761498196
        [HttpGet]
        public ActionResult insertPerson()
        {
            return View();
        }
<<<<<<< HEAD

        //GET: Admins/insertRoom
=======
        
>>>>>>> 343a0acfbce2166e940d71df208c506761498196
        [HttpGet]
        public ActionResult InsertRoom()
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

            PersonDAO PerDAO = new PersonDAO();
            string Per_Name = formCollection["Per_Name"];
            int id_N = Convert.ToInt32(formCollection["id_N"]);
            int id_Role = Convert.ToInt32(formCollection["id_Role"]);
            int Gender = Convert.ToInt32(formCollection["Gender"]);
            DateTime Birthday = Convert.ToDateTime(formCollection["Birthday"]);
            String Description = formCollection["Description"];

            PerDAO.CreatePerson(Per_Name, id_N, id_Role, Gender, Birthday, Description, true);

            return View();
        }
        [HttpPost]
        public ActionResult insertRoom(FormCollection formCollection)
        {
            RoomDAO rdao = new RoomDAO();
            int id_C = Convert.ToInt32(formCollection["id_C"]);
            int R_SeatNumber = Convert.ToInt32(formCollection["R_SeatNumber"]);
            int R_Size = Convert.ToInt32(formCollection["R_Size"]);
            int R_Type = Convert.ToInt32(formCollection["R_Type"]);
            int R_Row = Convert.ToInt32(formCollection["R_Row"]);
            int R_Col = Convert.ToInt32(formCollection["R_Col"]);
            rdao.CreateRoom(id_C,R_SeatNumber,R_Size,R_Type,0,R_Row,R_Col);//0 la chua hoat dong
            return View();
        }
    }
}
