using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess
{
    public abstract class WarehouseDbContext: DbContext 
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemLocationDB> ItemLocationsDb { get; set; }
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemLocationDB>().HasKey(locations => new {locations.ItemId, locations.LocationId});
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();
        }
        
    }
}