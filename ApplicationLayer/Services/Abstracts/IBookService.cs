using System.Threading.Tasks;
using ApplicationLayer.DataTransferObjects;

namespace ApplicationLayer.Services.Abstracts
{
    public interface IBookService
    {
        ValueTask<BookInfoDto> GetBookInfo(int bookId);
    }
}