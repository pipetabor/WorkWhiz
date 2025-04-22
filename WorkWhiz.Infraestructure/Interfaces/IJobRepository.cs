using WorkWhiz.Core.DTOs;

namespace WorkWhiz.Infraestructure.Interfaces
{
    public interface IJobRepository
    {
        public Task<List<JobTop10Dto>> GetTop10MostRecentJobsAsync();
        public Task<List<JobTopActiveDto>> GetTopActiveJobsAsync(int topNumber);
        public Task<JobCreateDto> CreateJobAsync(JobCreateDto jobCreateDto);
        public Task<List<JobTop10Dto>> GetPaginatedActiveJobsAsync(int page, int pagesize);
    }
}
