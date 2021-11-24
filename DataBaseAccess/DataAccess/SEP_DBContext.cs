using Entities.Models;
using Microsoft.EntityFrameworkCore;
using SEP3_WebServerClient.Models;

namespace WebDBserverAPI.DataAccess
{
    public class SEP_DBContext : DbContext
    {
        public DbSet<Spike> Spikes { get; set; }
        
        public DbSet<Location> Locations { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<WarehouseItemLocationDB> WarehouseItemLocationsDB { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
            //optionsBuilder.UseSqlite(@"Data Source = D:\GitHubProjects\SEP 3\SEP3_DB_Server\WebDBserverAPI\warehouse.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spike>().HasKey(spike => spike.SpikeName);
            
            modelBuilder.Entity<Location>().HasKey((location => location.Id));
            modelBuilder.Entity<WarehouseItem>().HasKey((warehouseItem => warehouseItem.Id));
            modelBuilder.Entity<WarehouseItemLocationDB>().HasKey(locations => new {locations.ItemId, locations.LocationId});
            
        }
    }
}