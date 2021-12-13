using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Blazor.Data;
using Blazor.Data.Implementation;
using GrpcClient;
using Radzen;
using ServerCommunication;
using T1Contracts.ServerCommunicationInterfaces;
using GrpcClient.Clients;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            
            services.AddScoped<IItemHandler, ItemHandler>();
            services.AddScoped<ILocationHandler, LocationHandler>();
            services.AddScoped<IInventoryHandler, InventoryHandler>();
            services.AddScoped<IOrderHandler, OrderHandler>();

            services.AddScoped<GRPCConnStr>();
            services.AddScoped<IItemDataServerComm, GrpcItemClient>();
            services.AddScoped<ILocationDataServerComm, GrpcLocationClient>();
            services.AddScoped<IInventoryDataServerComm, GrpcInventoryClient>();
            services.AddScoped<IOrderDataServerComm, GrpcOrderClient>();
            services.AddScoped<IUserDataServerComm, GrpcUserClient>();
            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
          
            services.AddScoped<DialogService>();
            services.AddScoped<NotificationService>();
            
            services.AddSingleton<GlobalNotificationService>();
            
            services.AddAuthorization(options =>
            {
                options.AddPolicy("SecurityLevel1", a => a.RequireClaim("Level", "1", "2"));
                options.AddPolicy("SecurityLevel2", a => a.RequireClaim("Level", "2"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}