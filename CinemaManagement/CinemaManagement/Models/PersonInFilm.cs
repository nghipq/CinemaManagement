using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class PersonInFilm
    {
        public int id_Per { get; set; }
        public int id_F { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
    }
}