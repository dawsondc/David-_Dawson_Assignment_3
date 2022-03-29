using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// class to talk to database
    /// </summary>
    public class DbGameRepository : IGameRepository
    {
        private readonly GameDbContext _db;

        /// <summary>
        /// instance of repository giving it the DB Context
        /// </summary>
        /// <param name="db">repesents the context file</param>
        public DbGameRepository(GameDbContext db)
        {
            _db = db;
        }
        
        /// <summary>
        /// Omplementing Read Method
        /// </summary>
        /// <param name="ID">represents the gameID from the game entity</param>
        /// <returns>the selected game</returns>
        public Game? Read(int ID)
        {
            return _db.Game
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Person)
           .FirstOrDefault(x => x.gameID == ID);
        }

        /// <summary>
        /// implementing the ReadAll method
        /// </summary>
        /// <returns>the list of games</returns>
        public ICollection<Game> ReadAll()
        {
            return _db.Game
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Person)
              .ToList();
        }
    }
}
