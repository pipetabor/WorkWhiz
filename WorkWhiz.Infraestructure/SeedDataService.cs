using WorkWhiz.Core.Models;

namespace WorkWhiz.Infraestructure
{
    public class SeedDataService
    {
        private readonly ApiContext _context;

        public SeedDataService(ApiContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            var posters = new List<Poster>();
            var jobs = new List<Job>();
            var bidders = new List<Bidder>();
            if (!_context.Posters.Any())
            {
                 posters = GeneratePosters(20);
                _context.Posters.AddRange(posters);
            }

            if (!_context.Bidders.Any())
            {
                bidders = GenerateBidders(20);
                _context.Bidders.AddRange(bidders);
            }
            if (!_context.Jobs.Any())
            {
                jobs = GenerateJobs(20, posters);
                _context.Jobs.AddRange(jobs);
            }
            if (!_context.Bids.Any())
            {
                var bids = GenerateBids(20, jobs, bidders);
                _context.Jobs.AddRange(jobs);
            }
            await _context.SaveChangesAsync();
        }

        //Generate Random Posters Data
        private static List<Poster> GeneratePosters(int count)
        {
            var posters = new List<Poster>();
            var firstNames = new List<string> { "John", "Jane", "Mary", "David", "Emily", "Olivia", "Noah", "Ava", "William", "Sophia" };
            var lastNames = new List<string> { "Doe", "Smith", "Johnson", "Williams", "Jones", "Brown", "Miller", "Davis", "Garcia", "Rodriguez" };

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var firstName = firstNames[i % firstNames.Count];
                var lastName = lastNames[random.Next(lastNames.Count)];
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@{i}@work.com";

                posters.Add(new Poster
                {
                    Id = i + 1,
                    Name = $"{firstName} {lastName}",
                    Email = email
                });
            }

            return posters;
        }

        private static List<Bidder> GenerateBidders(int count)
        {
            var bidders = new List<Bidder>();
            var firstNames = new List<string> { "Alice", "Bob", "Charlie", "Diana", "Eve", "Frank", "Grace", "Henry", "Ivy", "Jack" };
            var lastNames = new List<string> { "Doe", "Smith", "Johnson", "Williams", "Jones", "Brown", "Miller", "Davis", "Garcia", "Rodriguez" };

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var firstName = firstNames[i % firstNames.Count];
                var lastName = lastNames[random.Next(lastNames.Count)];
                var email = $"{firstName.ToLower()}.{lastName.ToLower()}@{i}@bidder.com";

                bidders.Add(new Bidder
                {
                    Id = i + 1,
                    Name = $"{firstName} {lastName}",
                    Email = email,
                    Bids = new List<Bid>() // Initialize Bids list
                });
            }

            return bidders;
        }

        private static List<Job> GenerateJobs(int count, List<Poster> posters)
        {
            var jobs = new List<Job>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var poster = posters[random.Next(posters.Count)];
                var job = new Job
                {
                    Id = i + 1,
                    PosterId = poster.Id,
                    Poster = poster,
                    Name = $"Job Title {i + 1}",
                    Description = $"This is a detailed description for Job Title {i + 1}. It includes information about the responsibilities, qualifications, and other relevant details.",
                    Status = random.Next(1, 4) switch 
                    {
                        1 => "Open",
                        2 => "In Progress",
                        3 => "Completed",
                        _ => throw new ArgumentOutOfRangeException() // Handle unexpected random value
                    },
                    Requirements = $"Here are the specific requirements for Job Title {i + 1}.",
                    Posted_Date = DateTime.Now.Subtract(TimeSpan.FromDays(random.Next(1, 14))), 
                    Expiration_Date = DateTime.Now.AddDays(random.Next(7, 30)) 
                };
                jobs.Add(job);
            }

            return jobs;
        }

        private static List<Bid> GenerateBids(int count, List<Job> jobs, List<Bidder> bidders)
        {
            var bids = new List<Bid>();
            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var job = jobs[random.Next(jobs.Count)];
                var bidder = bidders[random.Next(bidders.Count)];

                var bid = new Bid
                {
                    Id = i + 1,
                    Job_Id = job.Id,
                    Bidder_Id = bidder.Id,
                    Amount = (decimal)(random.Next(100, 1000) + random.NextDouble() * 100),
                    Bid_Date = DateTime.Now.Subtract(TimeSpan.FromDays(random.Next(1, 7))) // Bid within the last week
                };

                bids.Add(bid);
            }

            return bids;
        }
    }
}