namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Author
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }
}