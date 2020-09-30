using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class User
    {
        public int id_U { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int id_N { get; set; }
        public int Gender { get; set; }
        public DateTime Birthday { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public DateTime RegisDate { get; set; }
        public int Permission { get; set; }
        public Boolean Status { get; set; }
    }
}