using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Core.Models;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.Infraestructure.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public JobRepository(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JobTopActiveDto>> GetTopActiveJobsAsync(int topNumber)
        {
            var topActiveJobs = await _context.Jobs
                .Include(b => b.Bids)
                .OrderByDescending(b => b.Bids.Count())
                .Take(topNumber)
                .Where(j => j.Status == "Open")
                .Select(j => new JobTopActiveDto
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description.Substring(0, Math.Min(100, j.Description.Length)) + "...",
                    Status = j.Status,
                    PostedDate = j.PostedDate,
                    ExpirationDate = j.ExpirationDate,
                    BidCount = j.Bids.Count,
                    LowestBid = j.Bids.Select(b => b.Amount).Min()
                })
                .ToListAsync();

            return _mapper.Map<List<JobTopActiveDto>>(topActiveJobs);
        }

        public async Task<List<JobTop10Dto>> GetTop10MostRecentJobsAsync()
        {
            var topTenJobs = await _context.Jobs
                .Include(j => j.Bids)
                .OrderByDescending(j => j.PostedDate)
                .Take(10)
                .Select(j => new JobTop10Dto
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description.Substring(0, Math.Min(100, j.Description.Length)) + "...",
                    Status = j.Status,
                    PostedDate = j.PostedDate,
                    ExpirationDate = j.ExpirationDate,
                    Poster = _mapper.Map<PosterNameDto>(j.Poster),
                    BidCount = j.Bids.Count
                })
                .ToListAsync();

            var t = Task.Run(async delegate
            {
                await Task.Delay(3000);
                return 42;
            });
            t.Wait();

            return _mapper.Map<List<JobTop10Dto>>(topTenJobs);
        }

        public async Task<JobCreateDto> CreateJobAsync(JobCreateDto jobCreateDto)
        {
            var newJob = _mapper.Map<Job>(jobCreateDto);

            var poster = await _context.Posters.FindAsync(jobCreateDto.PosterId);
            if (poster == null)
            {
                throw new Exception("Poster not found");
            }

            newJob.Poster = poster;

            _context.Jobs.Add(newJob);

            await _context.SaveChangesAsync();

            return jobCreateDto;
        }

        public Task<List<JobTop10Dto>> GetPaginatedActiveJobsAsync(int page, int pagesize)
        {
            throw new NotImplementedException();
        }
    }
}
