using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWhiz.Core.Models
{
    public class Job
    {
        public int Id { get; set; }
        public int Poster_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Requirements { get; set; }
        public DateTime Posted_Date { get; set; } = DateTime.Now;
        public DateTime Expiration_Date { get; set; }
        public List<Bid> Bids { get; set; }
    }
}
