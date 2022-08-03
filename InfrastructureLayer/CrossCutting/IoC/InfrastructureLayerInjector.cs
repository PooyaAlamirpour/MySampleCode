using System;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Repositories.Implementations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer.CrossCutting.IoC
{
    public static class InfrastructureLayerInjector
    {
        public static void Use(IServiceCollection services)
        {
            services.AddHttpClient<HttpBookInfoRepository>();
            services.AddSingleton<IMemoryCache>(x => new MemoryCache(new MemoryCacheOptions()));
            services.AddTransient<IBookInfoRepositoryFactory, BookInfoRepositoryFactory>();

            services.AddStackExchangeRedisCache(option =>
            {
                option.Configuration = "localhost:6379";
            });
            
            services.AddScoped<BookInfoCacheRepository>()
                .AddScoped<IBookInfoRepository, BookInfoCacheRepository>(x => 
                    x.GetService<BookInfoCacheRepository>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(BookInfoCacheRepository)}"));
            
                
            services.AddScoped<BookInfoRedisRepository>()
                .AddScoped<IBookInfoRepository, BookInfoRedisRepository>(x => 
                    x.GetService<BookInfoRedisRepository>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(BookInfoRedisRepository)}"));
            
            services.AddScoped<HttpBookInfoRepository>()
                .AddScoped<IBookInfoRepository, HttpBookInfoRepository>(x => 
                    x.GetService<HttpBookInfoRepository>() ?? 
                    throw new InvalidOperationException($"There is an issue in making an instance for {nameof(HttpBookInfoRepository)}"));
        }
    }
}