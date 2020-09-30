using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Persons
    {
        public int id_Per { get; set; }
        public String Per_Name { get; set; }
        public int id_N { get; set; }
        public int id_Role { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
    }
}