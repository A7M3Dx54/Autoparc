using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Autoparc.Models;
using Autoparc.SwaggerConfiguration;
using Autoparc.Services;
using Autoparc.Dao;
using NgrokAspNetCore;

namespace Autoparc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<VehiculeContext>(opt =>opt.UseInMemoryDatabase("TodoList"));
            services.AddDbContext<VehiculeContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("AutoparcConnection")));
            services.AddSwaggerGenCustom("autoparc","v1");

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IVehiculeRepository, VehiculeRepository>();
            services.AddTransient<ITacheRepository, TacheRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEntretienRepository, EntretienRepository>();
            services.AddTransient<IEntretienTypeRepository, EntretienTypeRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();


            services.AddTransient<IVehiculeService, VehiculeService>();
            services.AddTransient<ITacheService, TacheService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IEntretienService, EntretienService>();
            services.AddTransient<IEntretienTypeService, EntretienTypeService>();
            services.AddTransient<ILocationService, LocationService>();

            services.AddNgrok();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.AddSwaggerConfigCustom(Configuration);

            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
