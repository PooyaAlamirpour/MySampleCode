using System;
using DomainLayer.AggregatesModels.Books.Repository;
using InfrastructureLayer.Repositories.Implementations;

namespace InfrastructureLayer.Repositories
{
    public class BookInfoRepositoryFactory : IBookInfoRepositoryFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public BookInfoRepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public BookInfoBaseHandler GetInstance(RepositoryType repositoryCacheType) => repositoryCacheType switch
        {
            RepositoryType.MEMORY => (BookInfoBaseHandler)_serviceProvider.GetService(typeof(BookInfoCacheRepository))!,
            RepositoryType.REDIS => (BookInfoBaseHandler)_serviceProvider.GetService(typeof(BookInfoRedisRepository))!,
            RepositoryType.FILE => (BookInfoBaseHandler)_serviceProvider.GetService(typeof(BookInfoFileRepository))!,
            RepositoryType.HTTP => (BookInfoBaseHandler)_serviceProvider.GetService(typeof(HttpBookInfoRepository))!,
            _ => throw new ArgumentOutOfRangeException(nameof(repositoryCacheType), repositoryCacheType, null)
        } ?? throw new InvalidOperationException($"It is not possible to make an instance right now({nameof(BookInfoRepositoryFactory)})");
    }
}