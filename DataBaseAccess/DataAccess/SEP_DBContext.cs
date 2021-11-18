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
        //public DbSet<WarehouseItemLocation> WarehouseItemLocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
            //optionsBuilder.UseSqlite(@"Data Source = D:\GitHubProjects\SEP 3\SEP3_DB_Server\WebDBserverAPI\warehouse.db");
        }

        // Migrating is a little weird, and it refuses to accept this as is...
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spike>().HasKey(spike => spike.SpikeName);
            //modelBuilder.Entity<WarehouseItemLocation>().HasNoKey();
            //modelBuilder.Entity<WarehouseItemLocation>().HasKey(locations => new {locations.Item, locations.Location});
            base.OnModelCreating(modelBuilder);
            
        }
    }
}