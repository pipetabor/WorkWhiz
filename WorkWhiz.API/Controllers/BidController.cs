using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Hubs;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        readonly IBidRepository _bidRepository;
        private readonly IJobRepository _jobRepository;
        private readonly IHubContext<JobHub> _hubContext;

        public BidController(IBidRepository bidRepository, IJobRepository jobRepository, IHubContext<JobHub> hubContext)
        {
            _bidRepository = bidRepository;
            _jobRepository = jobRepository;
            _hubContext = hubContext;
        }
        [HttpPost]
        public async Task<ActionResult<BidDto>> Post(BidDto bidDto)
        {
            var createBid = await _bidRepository.PostBid(bidDto);

            if (createBid == null)
                return BadRequest("Error placing a bid");

            // Get the updated list of top active jobs after creating the bid
            var topActiveJobs = await _jobRepository.GetTopActiveJobsAsync(10);

            // Broadcast the updated job list to all connected clients
            await _hubContext.Clients.All.SendAsync("ReceiveUpdatedJobs", topActiveJobs);

            return Ok(createBid);
        }
    }
}
