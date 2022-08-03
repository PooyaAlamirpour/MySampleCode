using System;

namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Quote
    {
        public string id { get; set; }
        public Data data { get; set; }
        public int likeCount { get; set; }
        public int bookId { get; set; }
        public int accountId { get; set; }
        public int commentCount { get; set; }
        public string creationDate { get; set; }
        public DateTime date { get; set; }
        public bool showComment { get; set; }
        public string coverUri { get; set; }
        public string bookName { get; set; }
        public string authorName { get; set; }
        public string publisherName { get; set; }
        public string profileImageUri { get; set; }
        public string nickname { get; set; }
        public string description { get; set; }
    }
}