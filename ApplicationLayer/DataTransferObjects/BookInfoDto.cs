namespace ApplicationLayer.DataTransferObjects
{
    public class BookInfoDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int NumberOfPages { get; set; }
        public double Rating { get; set; }
        public string PublishDate { get; set; }
        public double CurrencyPrice { get; set; }
    }
}