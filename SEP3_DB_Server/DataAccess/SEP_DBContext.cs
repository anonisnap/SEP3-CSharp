using Microsoft.EntityFrameworkCore;
using SEP3_DB_Server.Models;

namespace SEP3_DB_Server.DataAccess
{
    public class SEP_DBContext : DbContext
    {
        public DbSet<Spike> Snors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseSqlite("Data Source = warehouse.db");
        }
    }
}