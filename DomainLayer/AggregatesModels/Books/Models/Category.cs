namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Category
    {
        public int id { get; set; }
        public int parent { get; set; }
        public string title { get; set; }
        public string slug { get; set; }
        public string icon { get; set; }
    }
}