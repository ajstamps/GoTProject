using GoTProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoTProject.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string OrderNumber { get; set; }
        public GoTProjectUser Consumer { get; set; }
        public DateTime OrderDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }
        public float Completion { get; set; }
        public Table RecepientTable { get; set; }

        public IList<MealOrder> MealOrders { get; set; }
    }
}