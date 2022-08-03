using System.Collections.Generic;

namespace DomainLayer.AggregatesModels.Books.Models
{
    public class Comment
    {
        public int id { get; set; }
        public int accountId { get; set; }
        public bool verifiedAccount { get; set; }
        public string nickname { get; set; }
        public string profileImageUri { get; set; }
        public int bookId { get; set; }
        public string bookCoverUri { get; set; }
        public string bookType { get; set; }
        public string bookName { get; set; }
        public string creationDate { get; set; }
        public double rate { get; set; }
        public List<LatestReply> latestReplies { get; set; }
        public int repliesCount { get; set; }
        public int likeCount { get; set; }
        public int dislikeCount { get; set; }
        public string comment { get; set; }
        public bool isLiked { get; set; }
        public bool isDisliked { get; set; }
        public List<RateDetail> rateDetails { get; set; }
        public int recommendation { get; set; }
    }
}