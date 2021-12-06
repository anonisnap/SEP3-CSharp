using DataBaseAccess;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ServiceConfigurator
{
    public class ServiceExtensions
    {

        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<WarehouseDbContext, SEP_DBContext>();
            services.AddScoped<IItemDataRepo, ItemDataRepo>();
            services.AddScoped<ILocationDataRepo, LocationDataRepo>();
        }
        
    }
}