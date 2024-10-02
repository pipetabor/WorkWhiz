using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.DTOs;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.Infraestructure.Repositories
{
    public class PosterRepository : IPosterRepository
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public PosterRepository(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PosterDto> GetPosters()
        {
            var posters = _context.Posters
                .Include(a => a.Jobs)
                .ToList();

            // Map Posters to PosterDto
            return _mapper.Map<List<PosterDto>>(posters);

            /*var list = _context.Posters
            .Include(a => a.Jobs)
            .Select(p => new PosterDto
            {
                Id = p.Id,
                Name = p.Name,
                Email = p.Email,
                Jobs = p.Jobs.Select(j => new JobDto
                {
                    Id = j.Id,
                    Name = j.Name,
                    Description = j.Description,
                    Status = j.Status
                }).ToList()
            })
            .ToList();
            return list;*/
        }
    }
}
