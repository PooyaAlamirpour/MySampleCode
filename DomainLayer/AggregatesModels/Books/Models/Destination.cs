namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Destination
    {
        public int type { get; set; }
        public int order { get; set; }
        public int navigationPage { get; set; }
        public int operationType { get; set; }
        public int bookId { get; set; }
        public string pageTitle { get; set; }
    }
}