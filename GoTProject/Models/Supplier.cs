using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace GoTProject.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Phone Number")]
        public string Phone { get; set; }

        public IList<Product> Products { get; set; }
    }
}