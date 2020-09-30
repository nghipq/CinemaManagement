using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Role
    {
        public int id_Role { get; set; }
        public String Role_Name { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
    }
}