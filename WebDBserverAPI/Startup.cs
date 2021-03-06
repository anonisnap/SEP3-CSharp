using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DataBaseAccess;
using DataBaseAccess.DataAccess.DbContextImpl;
using DataBaseAccess.DataRepos;
using DataBaseAccess.DataRepos.Impl;

namespace WebDBserverAPI {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}
		public IConfiguration Configuration {
			get;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddControllers( );
			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebDBserverAPI", Version = "v1" });
			});
			services.AddDbContext<WarehouseDbContext, SEP_DBContext>(); //can be switched; TestDbContext, SEP_DBContext.
			services.AddScoped<IItemDataRepo, ItemDataRepo>();
			services.AddScoped<ILocationDataRepo, LocationDataRepo>();
			services.AddScoped<IInventoryDataRepo, InventoryDataRepo>();
			services.AddScoped<IOrderDataRepo, OrderDataRepo>();
			services.AddScoped<IUserDataRepo, UserDataRepo>();

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment( )) {
				app.UseDeveloperExceptionPage( );
				app.UseSwagger( );
				app.UseSwaggerUI(c => 
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebDBserverAPI v1"));
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
