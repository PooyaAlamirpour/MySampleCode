using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;

namespace DomainLayer.AggregatesModels.Books.Repository
{
    public abstract class BookInfoBaseHandler : IBookInfoRepository
    {
        protected IBookInfoRepository? NextHandler;

        public void RegisterNext(IBookInfoRepository bookInfoHandler)
        {
            NextHandler = bookInfoHandler;
        }
        
        public abstract ValueTask<BookInfo> GetBookInfoById(int bookId);
    }
}