using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoparc.SwaggerConfiguration
{
    public static class SwaggerExtension

    {



        public static void AddSwaggerConfigCustom(this IApplicationBuilder app, IConfiguration Configuration)
        {

            var swagger = new SwaggerOption();

            Configuration.GetSection(nameof(SwaggerOption)).Bind(swagger);



            app.UseSwagger(op => { op.RouteTemplate = swagger.JsonRoute; });

            app.UseSwaggerUI(op => { op.SwaggerEndpoint(swagger.UIEndPoint, swagger.Description); });



        }





        public static void AddSwaggerGenCustom(this IServiceCollection services, string _Title, string _Version)

        {

            services.AddSwaggerGen(op =>



          op.SwaggerDoc(_Version, new Microsoft.OpenApi.Models.OpenApiInfo { Title = _Title, Version = _Version })



          );



        }





    }
}
