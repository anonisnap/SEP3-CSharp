using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess
{
    public abstract class WarehouseDbContext: DbContext 
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DbSet<ItemLocation> ItemLocations { get; set; }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderEntry> OrderEntries { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            
            options.EnableSensitiveDataLogging();
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();
            
            //modelBuilder.Entity<OrderEntry>().has
            modelBuilder.Entity<OrderEntry>().HasKey(entry => new{entry.ItemId, entry.OrderId});
        }
        
    }
}