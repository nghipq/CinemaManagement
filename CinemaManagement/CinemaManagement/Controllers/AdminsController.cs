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
        [HttpGet]
        
        public ActionResult insertProducers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertProducers(FormCollection formCollection)
        {

            foreach(string key in formCollection.AllKeys)
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

        //Get Film
        [HttpGet]
        public ActionResult insertFilm()
        {
            return View();
        }

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

        //GetPerson
        [HttpGet]
        public ActionResult insertPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult insertPerson(FormCollection formCollection)
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

       

    }
}