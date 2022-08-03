namespace DomainLayer.AggregatesModels.Books.Models
{
    public class CorrespondingBook
    {
        public string title { get; set; }
        public string color { get; set; }
        public string icon { get; set; }
        public Destination destination { get; set; }
    }
}