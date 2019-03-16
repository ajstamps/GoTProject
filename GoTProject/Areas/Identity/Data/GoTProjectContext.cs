using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoTProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoTProject.Models
{
    public class GoTProjectContext : IdentityDbContext<GoTProjectUser>
    {
        public DbSet<RestaurantManagementSystem.Models.Order> Orders { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Meal> Meals { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Product> Inventory { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Reservation> Reservations { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Seat> Seats { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Supplier> Suppliers { get; set; }
        public DbSet<RestaurantManagementSystem.Models.Table> Tables { get; set; }

        public GoTProjectContext(DbContextOptions<GoTProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
