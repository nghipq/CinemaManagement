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
        [HttpGet]
        public ActionResult insertProducers()
        {
            return View();
        }


        // Post: insertProducers
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
        /**
        [HttpPost]
        public ActionResult insertFilmAction(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }
        }*/

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

        //get all bill
        [HttpGet]
        public ActionResult getAllBill()
        {
            return View();
        }


        // Post: all bill
        [HttpPost]
        public ActionResult getAllBill(FormCollection formCollection)
        {

            BillDAO bDAO = new BillDAO();


            bDAO.getAllBill();
            

            return View();
        }

        //get all film
        [HttpGet]
        public ActionResult getAllFilm()
        {
            return View();
        }


        // Post: all bill
        [HttpPost]
        public ActionResult getAllFilm(FormCollection formCollection)
        {

            


            return View();
        }

    }
}