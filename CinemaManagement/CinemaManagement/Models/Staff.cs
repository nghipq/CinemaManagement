using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Staff
    {
        public int id_Staff { get; set; }
        public int id_U { get; set; }
        public int id_C { get; set; }
        public int LevelStaff { get; set; }
        public String CMND { get; set; }
        public Boolean Status { get; set; }
    }
}