using System.Threading.Tasks;
using DomainLayer.AggregatesModels.Books.Models;

namespace DomainLayer.Services.Abstracts
{
    public interface IBookInfoDomainService
    {
        ValueTask<BookInfo> PrepareBookInfo(int bookId);
    }
}