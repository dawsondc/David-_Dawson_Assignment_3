using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public class Initializer
    {
        private readonly GameDbContext _db;

        public Initializer(GameDbContext db)
        {
            _db = db;
        }

        public void SeedDatabase()
        {
            _db.Database.EnsureCreated();

            // If there are any companies then assume the database is already
            // seeded.
            if (_db.Company.Any()) return;

            var companies = new List<Company>
        {
           new Company
              { Name = "From Software"},
           new Company
              { Name = "Bethesda"},
           new Company
              { Name = "Nintendo"},
           new Company
              { Name = "Game Freak"}
        };

            _db.Company.AddRange(companies);
            _db.SaveChanges();

            var game = new List<Game>
        {
           new Game
            { Name = "Elden Ring", Genre = "RPG/Adventrue" },
           new Game 
            { Name = "Skyrim", Genre = "RPG/Adventure" },
           new Game
            { Name = "Kirby: The Forgotten Lands", Genre = "Adventure/Platform" },
           new Game
            { Name = "Pokemon Legends: Arceus", Genre = "Adventure/Action" }
        };

            _db.Game.AddRange(game);
            _db.SaveChanges();
        }
    }
}
