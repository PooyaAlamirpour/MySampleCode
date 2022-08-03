namespace DomainLayer.AggregatesModels.Books.Models
{
    public class RelatedBook
    {
        public int type { get; set; }
        public string title { get; set; }
        public int backgroundStyle { get; set; }
        public BookData bookData { get; set; }
        public Destination destination { get; set; }
        public BackgroundConfig backgroundConfig { get; set; }
    }
}