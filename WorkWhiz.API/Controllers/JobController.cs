using Microsoft.AspNetCore.Mvc;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet("most-recent")]
        public async Task<ActionResult<List<JobTop10Dto>>> GetTop10MostRecentJobs()
        {
            return Ok(await _jobRepository.GetTop10MostRecentJobsAsync());
        }

        [HttpGet("top-active")]
        public async Task<ActionResult<List<JobTopActiveDto>>> GetTopActiveJobs()
        {
            return Ok(await _jobRepository.GetTopActiveJobsAsync(10));
        }
    }
}