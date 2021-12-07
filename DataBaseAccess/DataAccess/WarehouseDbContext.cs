using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess
{
    public abstract class WarehouseDbContext: DbContext 
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        
        public DbSet<ItemLocation> ItemLocations { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            
            options.EnableSensitiveDataLogging();
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();
        }
        
    }
}