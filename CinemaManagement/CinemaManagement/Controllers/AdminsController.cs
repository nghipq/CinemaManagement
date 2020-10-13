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
        public ActionResult insertFilm()
        {
            return View();
        }

        // Post: Admins/insertProducers
        [HttpPost]
        public ActionResult insertProducer(FormCollection formCollection)
        {
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
        
        //GET: Admins/insertSchedule
        [HttpGet]
        public ActionResult insertShedule()
        {
            return View();
        }

        //GET: Admins/insertRoom
        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View();
        }

    }
}