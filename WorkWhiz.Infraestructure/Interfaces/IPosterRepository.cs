using WorkWhiz.Core.DTOs;

namespace WorkWhiz.Infraestructure.Interfaces
{
    public interface IPosterRepository
    {
        public List<PosterDto> GetPosters();
    }
}
