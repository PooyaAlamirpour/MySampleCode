using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using DomainLayer.ConfigurationModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace InfrastructureLayer.Repositories.Implementations
{
    public class HttpBookInfoRepository : BookInfoBaseHandler
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptionsMonitor<ApiConfiguration> _options;
        
        public HttpBookInfoRepository(IHttpClientFactory httpClientFactory, IOptionsMonitor<ApiConfiguration> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
        }
        
        public override async ValueTask<BookInfo> GetBookInfoById(int bookId)
        {
            var bookInfo = await CallAsync<BookInfo>($"{_options.CurrentValue.ApiUrl}{bookId}");
            if (bookInfo is null) return new BookInfo() {IsDataReady = false};
            bookInfo.IsDataReady = true;
            return bookInfo;
        }
        
        private async Task<TResult?> CallAsync<TResult>(string url)
        {
            try
            {
                var requestMsg = new HttpRequestMessage(HttpMethod.Get, url);
                var task = await _httpClientFactory.CreateClient().SendAsync(requestMsg);
                var result = await task.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        private BookInfo EmptyResponse() => new() {IsDataReady = false};
    }
}