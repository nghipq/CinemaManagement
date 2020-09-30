using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Bill
    {
        public int id_B { get; set; }
        public int id_Cus { get; set; }
        public int id_Staff { get; set; }
        public DateTime DateBuy { get; set; }
        public long Total { get; set; }
        public Boolean Status { get; set; }
    }
}