using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaManagement.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getAllRoomSeatByRoomId()
        {
            return View();
        }
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