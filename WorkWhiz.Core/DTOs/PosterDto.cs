namespace WorkWhiz.Core.DTOs
{
    public class PosterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<JobDto> Jobs { get; set; }
    }
}
