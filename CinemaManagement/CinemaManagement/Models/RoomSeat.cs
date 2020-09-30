using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class RoomSeat
    {
        public int id_S { get; set; }
        public int id_R { get; set; }
        public String S_Name { get; set; }
        public Boolean Status { get; set; }
    }
}