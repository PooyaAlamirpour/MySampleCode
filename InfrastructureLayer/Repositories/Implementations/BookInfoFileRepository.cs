using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class BookInfoFileRepository : BookInfoBaseHandler
    {
        public override ValueTask<BookInfo> GetBookInfoById(int bookId)
        {
            throw new System.NotImplementedException();
        }
    }
}