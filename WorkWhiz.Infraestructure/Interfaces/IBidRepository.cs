using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Models;

namespace WorkWhiz.Infraestructure.Interfaces
{
    public interface IBidRepository
    {
        public Task<BidDto> PostBid(BidDto bidDto);
    }
}
