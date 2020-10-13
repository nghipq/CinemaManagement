﻿using System;
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
<<<<<<< HEAD
<<<<<<< HEAD

        // GET: Admins/insertProducers
        [HttpGet]
        public ActionResult insertProducer()
        {
            return View();
        }
        
        //GET: Admins/insertFilm
=======
=======
        //Get Admin/InsertCinema/InsertCinemaDAO
>>>>>>> edec25290693819261de470de9f4c53e9c20c012
        [HttpGet]
        public ActionResult InsertCinema()
        {
            return View();
        }
        //POST Admin/InsertCinema/InsertCinemaDAO
        [HttpPost]
        public ActionResult InsertCinema(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key = " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }

<<<<<<< HEAD
>>>>>>> d532f2390c7a826bc0bac4eced7568769a64782e
        [HttpGet]
        public ActionResult insertFilm()
        {
=======
            CinemaDAO cDAO = new CinemaDAO();
            string C_Name = formCollection["C_Name"];       
            string C_Address = formCollection["C_Address"];       
            string C_Phone = formCollection["C_Phone"];
            string C_Email = formCollection["C_Email"];
            string Description = formCollection["Description"];

            cDAO.CreateCinema(C_Name, C_Address, C_Phone, C_Email, Description);

>>>>>>> edec25290693819261de470de9f4c53e9c20c012
            return View();
        }

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
<<<<<<< HEAD
        
        //POST: Admins/insertFilm
=======

>>>>>>> d532f2390c7a826bc0bac4eced7568769a64782e
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
<<<<<<< HEAD

        //GET: Admins/insertRoom
=======
>>>>>>> d532f2390c7a826bc0bac4eced7568769a64782e
        [HttpGet]
        public ActionResult InsertRoom()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insertRoom(FormCollection formCollection)
        {
            foreach (string key in formCollection.AllKeys)
            {
                Response.Write("Key + " + key + " ");
                Response.Write(formCollection[key] + "</br>");
            }
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