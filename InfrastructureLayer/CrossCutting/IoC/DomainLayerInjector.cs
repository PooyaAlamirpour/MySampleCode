using ApplicationLayer.Services.Abstracts;
using DomainLayer.Services;
using DomainLayer.Services.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer.CrossCutting.IoC
{
    public static class DomainLayerInjector
    {
        public static void Use(IServiceCollection services)
        {
            services.AddTransient<IBookInfoDomainService, BookInfoDomainService>();
        }
    }
}