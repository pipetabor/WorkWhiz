using WorkWhiz.Core.Models;

namespace WorkWhiz.Core.DTOs
{
    public class JobTop10Dto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public PosterNameDto Poster { get; set; }
        public int BidCount { get; set; }
    }
}
