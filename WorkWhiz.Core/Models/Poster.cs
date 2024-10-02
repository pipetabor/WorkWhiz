using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWhiz.Core.Models
{
    public class Poster
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Job> Jobs { get; set; }
    }
}
