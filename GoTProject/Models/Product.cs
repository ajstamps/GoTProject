using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using GoTProject.Areas.Identity.Data;

namespace RestaurantManagementSystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Display(Name = "Product")]
        public string ProductName { get; set; }

        [Display(Name = "Supplier")]
        public Supplier _Supplier { get; set; }
        public int SupplierID { get; set; }

        [Display(Name = "Price Per Unit")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Amount Left (Pounds)")]
        public float AmountInLBS { get; set; }

        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set;}

        [Display(Name = "Acceptor")]
        public GoTProjectUser InvAdminAcceptor { get; set; }

        public IList<MealInventory> MealInventories { get; set; }

    }
}