using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;

namespace DomainLayer.AggregatesModels.Books.Repository
{
    public interface IBookInfoRepository
    {
        public ValueTask<BookInfo> GetBookInfoById(int bookId);
    }
}