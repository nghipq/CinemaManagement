using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Room
    {
        public int id_R { get; set; }
        public int id_C { get; set; }
        public int R_SeatNumber { get; set;}
        public int R_Row { get; set; }
        public int R_Col { get; set; }
        public int R_Size { get; set; }
        public int R_Type { get; set; }
        public int Status { get; set; }
    }
}