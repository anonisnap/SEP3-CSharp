using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SEP3_WebServerClient.Models;


namespace DataBaseAccess
{
    public class SEP_DBContext : DbContext
    {
        public DbSet<Spike> Spikes { get; set; }
        
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
            modelBuilder.Entity<Spike>().HasKey(spike => spike.SpikeName);
            
            modelBuilder.Entity<Location>().HasKey(location => location.Id);
            modelBuilder.Entity<Item>().HasKey(warehouseItem => warehouseItem.Id);
            modelBuilder.Entity<ItemLocationDB>().HasKey(locations => new {locations.ItemId, locations.LocationId});
            
        }
    }
}