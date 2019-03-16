using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoTProject.Models
{
    public class Meal
    {
        public int MealID { get; set; }

        [Display(Name = "Course Name")]
        public string MealName { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        public decimal MealPrice { get; set; }

        [Display(Name = "Active")]
        public bool Active { get; set; }

        public IList<MealOrder> MealOrders { get; set; }
        public IList<MealInventory> MealInventories { get; set; }
    }
}