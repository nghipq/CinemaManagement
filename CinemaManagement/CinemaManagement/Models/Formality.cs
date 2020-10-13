using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Formality
    {
        public int id_F { get; set; }
        public String F_Name { get; set; }
        public String Description { get; set; }
        public int F_Price { get; set; }
        public Boolean Status { get; set; }
    }
}