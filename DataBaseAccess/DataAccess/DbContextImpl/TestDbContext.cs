using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataAccess.DbContextImpl
{
    public class TestDbContext : WarehouseDbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\Sander\RiderProjects\SEP3-CSharp\DataBaseAccess\TestWarehouseDb.db");
        }
        
    }
}