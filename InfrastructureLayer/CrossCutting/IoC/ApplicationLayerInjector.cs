using ApplicationLayer.MappingConfigurations;
using ApplicationLayer.Services;
using ApplicationLayer.Services.Abstracts;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer.CrossCutting.IoC
{
    public static class ApplicationLayerInjector
    {
        public static void Use(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookInfoService>();
            services.AddSingleton(AutoMapping.RegisterMappings().CreateMapper());
        }
    }
}