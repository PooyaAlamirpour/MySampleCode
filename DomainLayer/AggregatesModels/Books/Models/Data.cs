namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Data
    {
        public string quote { get; set; }
        public int startAtomId { get; set; }
        public int endAtomId { get; set; }
        public int chapterIndex { get; set; }
        public int endOffset { get; set; }
        public int startOffset { get; set; }
    }
}