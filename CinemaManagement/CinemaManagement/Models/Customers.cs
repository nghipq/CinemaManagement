using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Customers
    {
        public int id_Cus { get; set; }
        public int id_U { get; set; }
        public int LevelAccount { get; set; }
        public long TotalPrice { get; set; }
        public DateTime TotalTime { get; set; }
        public Boolean Status { get; set; }
    }
}