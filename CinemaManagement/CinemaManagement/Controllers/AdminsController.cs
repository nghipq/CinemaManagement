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
        public ActionResult CreateCinema()
        {
            return View();
        }

        // Post: insertProducers
        [HttpPost]
        public ActionResult CreateCinema(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }
            CinemaDAO cnDAO = new CinemaDAO();
            cnDAO.CreateCinema("1", "1", "1", "1", "1");
            return View();
        }

        [HttpGet]
        public ActionResult insertFilm()
        {
            return View();
        }

        // Post: insertProducers
        [HttpPost]
        public ActionResult insertProducer(FormCollection formCollection)
        {
            foreach(string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }      
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
            return View();
        }

        [HttpGet]
        public ActionResult insertShedule()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View();
        }

    }
}