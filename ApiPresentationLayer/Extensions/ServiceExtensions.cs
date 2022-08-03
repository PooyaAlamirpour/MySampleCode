using InfrastructureLayer.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPresentationLayer.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterAllRequiredServices(this IServiceCollection services)
        {
            ApiPresentationInjector.Use(services);
            ApplicationLayerInjector.Use(services);
            DomainLayerInjector.Use(services);
            InfrastructureLayerInjector.Use(services);
        }
    }
}