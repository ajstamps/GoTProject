using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoTProject.Models
{
    public class MealInventory
    {
        public int MealInventoryID { get; set; }

        public int MealID { get; set; }
        public Meal TheMeal { get; set; }

        public int ProductID { get; set; }
        public Product TheProduct { get; set; }
    }
}