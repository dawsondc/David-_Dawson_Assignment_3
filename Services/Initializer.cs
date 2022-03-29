using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// initializer to load data into database
    /// </summary>
    public class Initializer
    {
        private readonly GameDbContext _db;

        /// <summary>
        /// instance of repository giving it the DB Context
        /// </summary>
        /// <param name="db">repesents the context file</param>
        public Initializer(GameDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// seeding the database with data
        /// </summary>
        public void SeedDatabase()
        {
            _db.Database.EnsureCreated();

            // If there are any people then assume the database is already
            // seeded.
            if (_db.Person.Any()) return;

            var people = new List<Person>
        {
            //Adding people
           new Person
              { FirstName = "Cameron", LastName = "Dawson"},
           new Person
              { FirstName = "James", LastName = "Frank"},
           new Person
              { FirstName = "Matt", LastName = "Murdock"},
           new Person
              { FirstName = "Frank", LastName = "Castle"}
        };

            _db.Person.AddRange(people);
            _db.SaveChanges();

            var game = new List<Game>
        {
            //Adding games
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
