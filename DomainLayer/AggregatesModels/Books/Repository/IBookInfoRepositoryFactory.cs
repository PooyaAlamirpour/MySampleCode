using DomainLayer.Services;

namespace DomainLayer.AggregatesModels.Books.Repository
{
    public interface IBookInfoRepositoryFactory
    {
        BookInfoBaseHandler GetInstance(RepositoryType repositoryCacheType);
    }
}