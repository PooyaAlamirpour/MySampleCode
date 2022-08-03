using System.Threading.Tasks;
using ApplicationLayer.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace ApiPresentationLayer.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        /// <summary>
        /// Get book detail info by using BookId
        /// </summary>
        /// <param name="bookId">Identity of a book(103657)</param>
        /// <returns>Metadata of requested book</returns>
        [HttpGet("id")]
        public async Task<IActionResult> GetBookInfo(int bookId)
        {
            if (bookId == 0) return BadRequest(new {IsSuccessStatusCode = false, Error = "Book id is required."});
            var bookInfo = await _bookService.GetBookInfo(bookId);
            return Ok(new {IsSuccessStatusCode = true, Results = bookInfo});
        }
    }
}