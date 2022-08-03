
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DomainLayer.AggregatesModels.Books.Models
{
    public class BookInfo
    {
        [JsonIgnore]
        public bool IsDataReady { get; set; }
        public Book book { get; set; }
        public List<Comment> comments { get; set; }
        public int commentsCount { get; set; }
        public List<RelatedBook> relatedBooks { get; set; }
        public string shareText { get; set; }
        public List<Quote> quotes { get; set; }
        public int quotesCount { get; set; }
        public bool hideOffCoupon { get; set; }
    }
}