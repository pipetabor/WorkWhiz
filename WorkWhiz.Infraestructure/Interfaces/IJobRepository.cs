using WorkWhiz.Core.DTOs;

namespace WorkWhiz.Infraestructure.Interfaces
{
    public interface IJobRepository
    {
        public Task<List<JobTop10Dto>> GetTop10MostRecentJobsAsync();
        public List<JobDto> GetTop10MostActiveJobsAsync();
    }
}
