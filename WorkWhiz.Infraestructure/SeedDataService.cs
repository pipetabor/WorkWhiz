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
            if (!_context.Posters.Any())
            {
                var posters = GeneratePosters(20);
                _context.Posters.AddRange(posters);
            }

            if (!_context.Bidders.Any())
            {
                var bidders = GenerateBidders(20);
                _context.Bidders.AddRange(bidders);
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
    }
}