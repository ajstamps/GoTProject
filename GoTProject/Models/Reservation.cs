using GoTProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantManagementSystem.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public GoTProjectUser Reservee { get; set; }
        public DateTime DateOfReservation { get; set; }
        public bool Cancelled { get; set; }
        public string PartyName { get; set; }
        public IList<Seat> Seats { get; set; }
    }
}