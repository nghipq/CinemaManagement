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
            foreach(string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

            return View();
        }
    }
}