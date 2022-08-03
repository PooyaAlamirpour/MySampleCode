using System;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class BookInfoRedisRepository : BookInfoBaseHandler
    {
        private readonly IDistributedCache _distributedCache;
        public BookInfoRedisRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }
        
        public override async ValueTask<BookInfo> GetBookInfoById(int bookId)
        {
            BookInfo? bookInfo;
            var bookInfoBytes = await _distributedCache.GetAsync(bookId.ToString());
            if (bookInfoBytes is not null)
            {
                string serializedBookIfo = Encoding.UTF8.GetString(bookInfoBytes);
                bookInfo = JsonConvert.DeserializeObject<BookInfo>(serializedBookIfo) ?? EmptyResponse();
                return bookInfo;
            }
            
            if (NextHandler is null) return EmptyResponse();
            
            bookInfo = await NextHandler.GetBookInfoById(bookId);
            await Update(bookInfo);
            return bookInfo;
        }

        private BookInfo EmptyResponse() => new() {IsDataReady = false};
        
        private async Task Update(BookInfo bookInfo)
        {
            var serializedBookInfo = JsonConvert.SerializeObject(bookInfo);
            var bookInfoBytes = Encoding.UTF8.GetBytes(serializedBookInfo);
            var options = new DistributedCacheEntryOptions()
                .SetAbsoluteExpiration(DateTime.Now.AddMinutes(20))
                .SetSlidingExpiration(TimeSpan.FromMinutes(10));  
            await _distributedCache.SetAsync(bookInfo.book.id.ToString(), bookInfoBytes, options);
        }
    }
}