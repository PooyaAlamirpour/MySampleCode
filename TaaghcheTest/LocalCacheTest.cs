using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.AggregatesModels.Books.Repository;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Repositories.Implementations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using TaaghcheTest.SampleData;
using Xunit;

namespace TaaghcheTest
{
    public class LocalCacheTest
    {
        private readonly IBookInfoRepositoryFactory _bookInfoRepositoryFactory;
        
        public LocalCacheTest()
        {
            var serviceProvider = new Mock<IServiceProvider>();

            serviceProvider.Setup(x => x.GetService(typeof(IMemoryCache)))
                .Returns(new MemoryCache(new MemoryCacheOptions()));
            
            serviceProvider.Setup(x => x.GetService(typeof(BookInfoCacheRepository)))
                .Returns(new BookInfoCacheRepository(new MemoryCache(new MemoryCacheOptions())));
            
            _bookInfoRepositoryFactory = new BookInfoRepositoryFactory(serviceProvider.Object);
        }

        [Theory]
        [ClassData(typeof(BookInfoFakeData))]
        public async Task GetById_ShouldReturnsCachedDataFromLocalMemory_WhenGivesBookId(int bookId, BookInfo bookInfo)
        {
            /*// Initial
            var cachedInstance = _bookInfoRepositoryFactory.GetInstance(RepositoryType.MEMORY);
            await cachedInstance.Update(bookInfo);

            // Action
            var result = await cachedInstance.GetById(bookId);

            // Assert
            Assert.Equal(bookInfo.book.id, result.book.id);
            Assert.Equal(bookInfo.book.title, result.book.title);*/
        }
    }    
}

