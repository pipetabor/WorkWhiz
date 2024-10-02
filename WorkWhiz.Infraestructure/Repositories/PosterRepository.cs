using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.Models;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.Infraestructure.Repositories
{
    public class PosterRepository : IPosterRepository
    {
        private readonly ApiContext _context;

        public PosterRepository(ApiContext context)
        {
            _context = context;
        }

        public List<Poster> GetPosters()
        {
            var list = _context.Posters
                .Include(a => a.Jobs)
                .ToList();
            return list;
        }
    }
}
