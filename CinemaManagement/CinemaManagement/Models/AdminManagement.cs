using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class AdminManagement
    {
        public int id_M { get; set; }
        public int id_A { get; set; }
        public String Content { get; set; }
        public String Note { get; set; }
        public DateTime DateManage { get; set; }
        public Boolean Status { get; set; }
    }
}