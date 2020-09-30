using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Films
    {
        public int id_F { get; set; }
        public String F_Name { get; set; }
        public int id_P { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Double Rating { get; set; }
        public int LimitAge { get; set; }
        public DateTime AirDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Description { get; set; }
        public int Status { get; set; }
    }
}