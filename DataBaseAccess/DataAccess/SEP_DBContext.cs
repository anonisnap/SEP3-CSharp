using Entities.Models;
using Microsoft.EntityFrameworkCore;
using WebDBserverAPI;


namespace DataBaseAccess
{
    public class SEP_DBContext : DbContext
    {
    
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Name of database
            optionsBuilder.UseNpgsql(ConnStr.Get(), options => options.UseAdminDatabase("geoxbaal"));
        }

     
    }
}