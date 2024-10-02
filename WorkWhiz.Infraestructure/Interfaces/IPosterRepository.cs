using WorkWhiz.Core.Models;

namespace WorkWhiz.Infraestructure.Interfaces
{
    public interface IPosterRepository
    {
        public List<Poster> GetPosters();
    }
}
