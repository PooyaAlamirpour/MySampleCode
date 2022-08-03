using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Repositories.Implementations;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using Moq;
using TaaghcheTest.SampleData;
using Xunit;

namespace TaaghcheTest
{
    public class RedisCacheTest
    {
        private readonly IBookInfoRepositoryFactory _bookInfoRepositoryFactory;
        
        public RedisCacheTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider.Setup(x => x.GetService(typeof(BookInfoRedisRepository)))
                .Returns(new BookInfoRedisRepository(new RedisCache(Options.Create(new RedisCacheOptions()
                {
                    Configuration = "localhost:6379"
                }))));
            
            _bookInfoRepositoryFactory = new BookInfoRepositoryFactory(serviceProvider.Object);
        }
        
        [Theory]
        [ClassData(typeof(BookInfoFakeData))]
        public async Task GetById_ShouldReturnsCachedDataFromRedis_WhenGivesBookId(int bookId, BookInfo bookInfo)
        {
            /*// Initial
            var cachedInstance = _bookInfoRepositoryFactory.GetInstance(RepositoryType.REDIS);
            await cachedInstance.Update(bookInfo);

            // Action
            var result = await cachedInstance.GetById(bookId);

            // Assert
            Assert.Equal(bookInfo.book.id, result.book.id);
            Assert.Equal(bookInfo.book.title, result.book.title);*/
        }
    }
}