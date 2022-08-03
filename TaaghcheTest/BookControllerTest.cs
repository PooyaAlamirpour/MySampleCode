using System;
using System.Net.Http;
using System.Threading.Tasks;
using ApiPresentationLayer.Controllers;
using ApplicationLayer.DataTransferObjects;
using ApplicationLayer.MappingConfigurations;
using ApplicationLayer.Services;
using AutoMapper;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using DomainLayer.ConfigurationModels;
using DomainLayer.Services;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Repositories.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Moq;
using TaaghcheTest.SampleData;
using Xunit;

namespace TaaghcheTest
{
    public class BookControllerTest
    {
        private readonly BookController _bookController;
        private readonly IBookInfoRepositoryFactory _bookInfoRepositoryFactory;
        IOptionsMonitor<CacheConfiguration> _optionsCacheConfiguration;
        IOptionsMonitor<ApiConfiguration> _optionsApiConfiguration;
        
        public BookControllerTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            var httpClientFactory = new Mock<IHttpClientFactory>();
            httpClientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(new HttpClient());

            _optionsCacheConfiguration = Mock.Of<IOptionsMonitor<CacheConfiguration>>(x =>
                x.CurrentValue.UseRedis == true && x.CurrentValue.UseLocalCache == true);
            
            _optionsApiConfiguration = Mock.Of<IOptionsMonitor<ApiConfiguration>>(x =>
                x.CurrentValue.ApiUrl == "https://get.taaghche.com/v2/book/");
            
            serviceProvider.Setup(x => x.GetService(typeof(IMemoryCache)))
                .Returns(new MemoryCache(new MemoryCacheOptions()));
            
            serviceProvider.Setup(x => x.GetService(typeof(BookInfoCacheRepository)))
                .Returns(new BookInfoCacheRepository(new MemoryCache(new MemoryCacheOptions())));
            
            serviceProvider.Setup(x => x.GetService(typeof(BookInfoRedisRepository)))
                .Returns(new BookInfoRedisRepository(new RedisCache(Options.Create(new RedisCacheOptions()
                {
                    Configuration = "localhost:6379"
                }))));
            
            serviceProvider.Setup(x => x.GetService(typeof(HttpBookInfoRepository)))
                .Returns(new HttpBookInfoRepository(httpClientFactory.Object, _optionsApiConfiguration));
            
            _bookInfoRepositoryFactory = new BookInfoRepositoryFactory(serviceProvider.Object);
            
            var mapper = AutoMapping.RegisterMappings().CreateMapper();
            _bookController = new BookController(new BookInfoService(mapper, new BookInfoDomainService(_bookInfoRepositoryFactory)));
        }

        [Fact]
        public async Task GetBookInfo_ShouldReturnsSuccess_WhenIsCalled()
        {
            // Initial
            var bookId = 103657;
            
            // Action
            var result = await _bookController.GetBookInfo(bookId);

            // Assert
            Assert.IsType<OkObjectResult>(result as OkObjectResult);
        }
        
        [Theory]
        [ClassData(typeof(BookInfoRealData))]
        public async Task GetBookInfo_ShouldReturnsBookInfo_WhenIsCalled(int bookId, BookInfo expectedBookInfo)
        {
            // Initial
            
            // Action
            var result = await _bookController.GetBookInfo(bookId) as OkObjectResult;;

            // Assert
            var bookInfo = (BookInfoDto)result.Value.GetType().GetProperty("Results").GetValue(result.Value);
            Assert.Equal(expectedBookInfo.book.title, bookInfo?.Title);
            Assert.Equal( expectedBookInfo.book.price, bookInfo?.Price);
            Assert.Equal(expectedBookInfo.book.numberOfPages, bookInfo?.NumberOfPages);
        }
    }
}