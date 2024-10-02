using Microsoft.EntityFrameworkCore;
using WorkWhiz.Core.Models;

namespace WorkWhiz.Infraestructure
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Poster> Posters { get; set; }
        public DbSet<Bidder> Bidders { get; set; }
    }
}
