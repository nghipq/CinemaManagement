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

        // GET: insertProducers
        [HttpGet]
        public ActionResult insertProducer()
        {
            return View();
        }

        // Post: insertProducers
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
    }
}