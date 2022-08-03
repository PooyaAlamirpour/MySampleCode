using System;
using ApiPresentationLayer.Extensions;
using DomainLayer.ConfigurationModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiPresentationLayer
{
    public class Startup
    {
        public readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Taaghche API Service",
                    Version = "v1",
                });
            });
            
            services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));
            services.Configure<CacheConfiguration>(Configuration.GetSection("CacheConfiguration"));
            
            services.RegisterAllRequiredServices();
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSwagger().UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Taaghche API Service");
                config.RoutePrefix = "api/docs";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}