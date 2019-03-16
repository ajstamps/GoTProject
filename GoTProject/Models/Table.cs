using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoTProject.Models
{
    public class Table
    {
        public int TableID { get; set; }
        public int TableColumn { get; set; }
        public int TableRow { get; set; }
        public Seat[] Seats {get; set;}
    }
}