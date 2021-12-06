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
            DbContextOptionsBuilder options = new DbContextOptionsBuilder();
            options.EnableSensitiveDataLogging(true);
            modelBuilder.Entity<ItemLocationDB>().HasIndex(db => new {db.ItemId, db.LocationId}).IsUnique();
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();
            modelBuilder.Entity<ItemLocationDB>().HasKey(db => db.Id);
        }
        
    }
}