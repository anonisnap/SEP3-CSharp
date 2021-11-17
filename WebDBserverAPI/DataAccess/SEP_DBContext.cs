using Microsoft.EntityFrameworkCore;
using WebDBserverAPI.Models;

namespace WebDBserverAPI.DataAccess
{
    public class SEP_DBContext : DbContext
    {
        public DbSet<Spike> Spikes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
            //optionsBuilder.UseSqlite(@"Data Source = D:\GitHubProjects\SEP 3\SEP3_DB_Server\WebDBserverAPI\warehouse.db");
        }
    }
}