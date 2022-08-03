using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using DomainLayer.Services.Abstracts;

namespace DomainLayer.Services
{
    public class BookInfoDomainService : IBookInfoDomainService
    {
        private readonly IBookInfoRepository _bookInfoRepository;

        public BookInfoDomainService(IBookInfoRepositoryFactory bookInfoRepositoryFactory)
        {
            var memoryBookInfoRepository = bookInfoRepositoryFactory.GetInstance(RepositoryType.MEMORY);
            var redisBookInfoRepository = bookInfoRepositoryFactory.GetInstance(RepositoryType.REDIS);
            var httpBookInfoRepository = bookInfoRepositoryFactory.GetInstance(RepositoryType.HTTP);

            memoryBookInfoRepository.RegisterNext(redisBookInfoRepository);
            redisBookInfoRepository.RegisterNext(httpBookInfoRepository);

            _bookInfoRepository = memoryBookInfoRepository;
        }

        /// <summary>
        /// PrepareBookInfo collects data by using 3 ways.
        /// First: The local memory is checked, if there would be data, it will be returned.
        /// Second: The Redis is checked, if there would be data, it will be returned.
        /// Third: If there would not be any data in cache, book data will be collected by calling an api. 
        /// </summary>
        /// <param name="bookId">Identity of a book</param>
        /// <returns>All detail about a requested book</returns>
        public async ValueTask<BookInfo> PrepareBookInfo(int bookId)
        {
            BookInfo bookInfo = await _bookInfoRepository.GetBookInfoById(bookId);
            return bookInfo;
        }
    }
}