using System.Threading.Tasks;
using ApplicationLayer.DataTransferObjects;
using ApplicationLayer.Services.Abstracts;
using AutoMapper;
using DomainLayer.AggregatesModels.Books.Models;
using DomainLayer.Services.Abstracts;

namespace ApplicationLayer.Services
{
    public class BookInfoService : IBookService
    {
        private readonly IBookInfoDomainService _bookInfoDomainService;
        private readonly IMapper _mapper;
        
        public BookInfoService(IMapper mapper, IBookInfoDomainService bookInfoDomainService)
        {
            _bookInfoDomainService = bookInfoDomainService;
            _mapper = mapper;
        }

        /// <summary>
        /// Some specific detail about a book will be prepared by calling this method. Please be considered, all book data
        /// will not be mapped. Just some few data will be chosen by auto mapper.
        /// </summary>
        /// <param name="bookId">Identity of a book</param>
        /// <returns>Specific data of a book</returns>
        public async ValueTask<BookInfoDto> GetBookInfo(int bookId)
        {
            BookInfo bookInfo = await _bookInfoDomainService.PrepareBookInfo(bookId);
            return _mapper.Map<BookInfoDto>(bookInfo);
        }
    }
}