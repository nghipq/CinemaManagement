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

        public Role()
        {
        }

        public Role(int id_Role, string role_Name, string description, bool status)
        {
            this.id_Role = id_Role;
            Role_Name = role_Name;
            Description = description;
            Status = status;
        }
    }
}