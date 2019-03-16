using GoTProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagementSystem.Models
{
    public class Seat
    {
        public int SeatID { get; set; }

        public GoTProjectUser Occupant { get; set; }
        public int UserID { get; set; }

        public Reservation TheReservation { get; set; }

        public Table TheTable { get; set; }
        public int TableID { get; set; }
    }
}