﻿namespace WorkWhiz.Core.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int PosterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Requirements { get; set; }
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public DateTime ExpirationDate { get; set; }
        public List<Bid> Bids { get; set; } = new List<Bid>();
        public Poster Poster { get; set; }
    }
}
