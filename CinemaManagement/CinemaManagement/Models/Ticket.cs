using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Ticket
    {
        public int id_T { get; set; }
        public int id_Sche { get; set; }
        public int id_S { get; set; }
        public int Status { get; set; }
    }
}