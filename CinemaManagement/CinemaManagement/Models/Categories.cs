using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaManagement.Models
{
    public class Categories
    {
        public int id_Cate { get; set; }
        public String Cate_Name { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
    }
}