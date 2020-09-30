using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Producers
    {
        public int id_P { get; set; }
        public String P_Name { get; set; }
        public int id_N { get; set; }
        public String Description { get; set; }
        public DateTime Birthday { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public Boolean Status { get; set; }
    }
}