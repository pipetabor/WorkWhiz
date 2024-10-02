using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWhiz.Core.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public int Job_Id { get; set; }
        public int Bidder_Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Bid_Date { get; set; }
    }
}
