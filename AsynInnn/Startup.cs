using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsynInnn.Data;
using AsynInnn.Models.Interfaces;
using AsynInnn.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AsynInnn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        //Add for future dependency injection

        public Startup(IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder().AddEnvironmentVariables();
            builder.AddUserSecrets<Startup>();
            Configuration = builder.Build();
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            //needed for database
            services.AddDbContext<AsyncInnDbContext>(options =>
            options.UseSqlServer(Configuration["ConnectionStrings:ProductionConnection"]));
            //options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //run the service
            services.AddScoped<IRoomManager, RoomManagementService>();
            services.AddScoped<IHotelManager, HotelManagementService>();
            services.AddScoped<IAmenityManager, AmenityManagerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
