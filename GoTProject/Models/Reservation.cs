using GoTProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoTProject.Models
{
    public class Reservation
    {
        public int ID { get; set; }

        [Display(Name = "Reservee")]
        public GoTProjectUser Reservee { get; set; }

        [Display(Name = "Reservation Date")]
        public DateTime DateOfReservation { get; set; }

        public bool Cancelled { get; set; }

        [Display(Name = "Party Name")]
        public string PartyName { get; set; }

        public IList<Seat> Seats { get; set; }

        public Reservation()
        {
            Cancelled = false;
        }
    }
}
