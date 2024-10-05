using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.DTOs;
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

        public List<JobDto> GetTop10MostActiveJobsAsync()
        {            
            throw new NotImplementedException();
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
    }
}
