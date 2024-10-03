namespace WorkWhiz.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int BidderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidDate { get; set; }
        public Job Job { get; set; } = new Job();
    }
}
