using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Schedule
    {
        public int id_Sche { get; set; }
        public int id_Ses { get; set; }
        public int id_F { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Status { get; set; }
        public DateTime Sche_Date { get; set; }


    }
}