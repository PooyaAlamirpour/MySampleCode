using System;
using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class BookInfoCacheRepository : BookInfoBaseHandler
    {
        private readonly IMemoryCache _memoryCache;
        public BookInfoCacheRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public override async ValueTask<BookInfo> GetBookInfoById(int bookId)
        {
            BookInfo? bookInfo;
            var hasValue = _memoryCache.TryGetValue(bookId.ToString(), out string bookInfoStr);
            if (hasValue)
            {
                bookInfo = JsonConvert.DeserializeObject<BookInfo>(bookInfoStr);
                if(bookInfo is null) return EmptyResponse();

                bookInfo.IsDataReady = true;
                return bookInfo;
            }

            if (NextHandler is null) return EmptyResponse();
            
            bookInfo = await NextHandler.GetBookInfoById(bookId);
            Update(bookInfo);
            return bookInfo;

        }

        private BookInfo EmptyResponse() => new() {IsDataReady = false};

        private void Update(BookInfo bookInfo)
        {
            var serializedBookInfo = JsonConvert.SerializeObject(bookInfo);
            _memoryCache.Set(bookInfo.book.id.ToString(), serializedBookInfo, TimeSpan.FromMinutes(20));
        }
    }
}