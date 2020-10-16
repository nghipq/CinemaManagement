using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CinemaManagement.DAO;
using CinemaManagement.Models;

namespace CinemaManagement.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
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


        //Insert Producer
        [HttpGet]
        public ActionResult insertProducers()
        {
            return View();
        }

        // Post: Admins/insertProducers
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

        //POST: Admins/insertFilm
        //Get Film
        [HttpGet]
        public ActionResult insertFilm()
        {
            return View();
        }

        //post insert film
        [HttpPost]
        public ActionResult insertFilm(FormCollection formCollection)
        {
            FilmDAO fDAO = new FilmDAO();
            string F_Name = formCollection["F_Name"];
            int id_P = Convert.ToInt32(formCollection["Producers"]);
            DateTime ReleaseDate = Convert.ToDateTime(formCollection["ReleaseDate"]);
            Double Rating = Convert.ToDouble(formCollection["Rating"]);
            int LimitAge = Convert.ToInt32(formCollection["LimitAge"]);
            DateTime AirDate = Convert.ToDateTime(formCollection["AirDate"]);
            DateTime EndDate = Convert.ToDateTime(formCollection["EndDate"]);
            String Description = formCollection["Description"];

            fDAO.CreateFilm(F_Name, id_P, ReleaseDate, Rating, LimitAge, AirDate, EndDate, Description, true);

            return View();
        }

        //GetPerson
        [HttpGet]
        public ActionResult insertPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertPerson(FormCollection formCollection)
        {

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


        [HttpGet]
        public ActionResult Formality()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Formality(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }
            FormalityDAO fodao = new FormalityDAO();
            String F_Name = formCollection["F_Name"];
            String Description = formCollection["Description"];
            int F_Price = Convert.ToInt32(formCollection["F_Price"]);
            Boolean Status = Convert.ToBoolean(formCollection["Status"]);
            fodao.CreateFormality(F_Name, Description, F_Price, Status);//0 la chua hoat dong
            return View();
        }


        [HttpGet]
        public ActionResult insertSchedule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertSchedule(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

            DateTime StartTime = Convert.ToDateTime(formCollection["StartTime"]);
            DateTime EndTime = Convert.ToDateTime(formCollection["EndTime"]);
            DateTime Sche_Date = Convert.ToDateTime(formCollection["Sche_Date"]);

            SessionDAO sesDAO = new SessionDAO();
            Session session = sesDAO.getSessionByTime(StartTime, EndTime);

            int id_Ses = -1;

            if (session == null)
            {
                id_Ses = sesDAO.createSession(StartTime, EndTime);
            }
            else
            {
                id_Ses = session.id_Ses;
            }

            int id_F = Convert.ToInt32(formCollection["id_F"]);

            ScheduleDAO scheDAO = new ScheduleDAO();
            scheDAO.createSchedule(id_Ses, Sche_Date, id_F);
            return View();
        }
    }
}
