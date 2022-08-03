namespace DomainLayer.AggregatesModels.Books.Models
{
    public class BookFile
    {
        public int id { get; set; }
        public int size { get; set; }
        public int type { get; set; }
        public int bookId { get; set; }
        public int sequenceNo { get; set; }
        public string title { get; set; }
    }
}