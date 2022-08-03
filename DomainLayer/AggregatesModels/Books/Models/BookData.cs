
using System.Collections.Generic;

namespace DomainLayer.AggregatesModels.Books.Models
{
    public class BookData
    {
        public List<Book> books { get; set; }
        public int layout { get; set; }
        public bool showPrice { get; set; }
    }
}