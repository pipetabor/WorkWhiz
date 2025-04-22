namespace WorkWhiz.Core.DTOs
{
    public class JobTopActiveDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public int BidCount { get; set; }
        public decimal LowestBid { get; set; }
    }
}
