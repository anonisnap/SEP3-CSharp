using Microsoft.EntityFrameworkCore;

namespace DataBaseAccess.DataAccess.DbContextImpl
{
    public class SEP_DBContext : WarehouseDbContext
    {
    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
        }
        
    }
}