using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess
{
    public abstract class WarehouseDbContext: DbContext 
    {
        public DbSet<Location> Locations { get; set; }
        
        public DbSet<Item> Items { get; set; }
        
        public DbSet<Inventory> Inventory { get; set; }
        
        public DbSet<Order> Orders { get; set; }
       
        public DbSet<User> Users { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            
            options.EnableSensitiveDataLogging();
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(order => order.OrderNumber).IsUnique();
            modelBuilder.Entity<User>().HasKey(user => user.Username);

        }
        
    }
}