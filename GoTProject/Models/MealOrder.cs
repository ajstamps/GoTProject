using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoTProject.Models
{
    public class MealOrder
    {
        public int MealOrderID { get; set; }

        public int MealID { get; set; }
        public Meal TheMeal { get; set; }

        public int OrderID { get; set; }
        public Order TheOrder { get; set; }
    }
}