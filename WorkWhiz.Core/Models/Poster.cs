using System.ComponentModel.DataAnnotations;

namespace WorkWhiz.Core.Models
{
    public class Poster
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Job> Jobs { get; set; } = new List<Job>();
    }
}
