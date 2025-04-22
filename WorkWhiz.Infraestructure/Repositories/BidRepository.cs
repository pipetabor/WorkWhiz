using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Models;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.Infraestructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public BidRepository(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BidDto> PostBid(BidDto bidDto)
        {            
            // Map DTO to the Bid entity
            var bid = _mapper.Map<Bid>(bidDto);

            // Retrieve the job and bidder entities based on IDs
            var job = await _context.Jobs.Include(j => j.Bids).FirstOrDefaultAsync(j => j.Id == bidDto.JobId);
            var bidder = await _context.Bidders.FirstOrDefaultAsync(b => b.Id == bidDto.BidderId);

            // Validate that the job and bidder exist
            if (job == null)
                throw new Exception("Job not found.");
            if (bidder == null)
                throw new Exception("Bidder not found.");

            // Associate the bid with the job and the bidder
            bid.Job = job;

            // Add the bid to the context and save changes
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();

            // Return the mapped BidDto
            return bidDto;
        }
    }
}
