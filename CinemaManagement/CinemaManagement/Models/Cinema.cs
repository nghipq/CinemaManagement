using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Cinema
    {
        public int id_C { get; set; }
        public String C_Name { get; set; }
        public String C_Address { get; set; }
        public String C_Phone { get; set; }
        public String C_Email { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
    }
}