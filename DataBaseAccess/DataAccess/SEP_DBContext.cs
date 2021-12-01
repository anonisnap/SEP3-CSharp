using Entities.Models;
using Microsoft.EntityFrameworkCore;


namespace DataBaseAccess
{
    public class SEP_DBContext : DbContext
    {
    
        public DbSet<Location> Locations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemLocationDB> ItemLocationsDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ItemLocationDB>().HasKey(locations => new {locations.ItemId, locations.LocationId});
            modelBuilder.Entity<Location>().HasIndex(l => l.Description).IsUnique();

        }
    }
}