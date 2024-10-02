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
        public List<Poster> GetPosters()
        {
            throw new NotImplementedException();
        }
    }
}
