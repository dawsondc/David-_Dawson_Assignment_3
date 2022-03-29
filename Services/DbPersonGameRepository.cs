using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// class to talk to database
    /// </summary>
    public class DbPersonGameRepository : IPersonGameRepository
    {
        private readonly GameDbContext _db;
        private readonly IGameRepository _gameRepo;
        private readonly IPersonRepository _personRepo;

        /// <summary>
        /// instance of repository giving it the DB Context as well as the interfaces
        /// </summary>
        /// <param name="db">repesents the context file</param>
        /// <param name="gameRepo">will be used to represent the interface</param>
        /// <param name="personRepo">will be used to represent the interface</param>
        public DbPersonGameRepository(GameDbContext db, IGameRepository gameRepo, IPersonRepository personRepo)
        {
            _db = db;
            _gameRepo = gameRepo;
            _personRepo = personRepo;
        }

        /// <summary>
        /// Implementing Read Method
        /// </summary>
        /// <param name="ID">represents the personID from the game entity</param>
        /// <returns>the selected person</returns>
        public PersonGame? Read(int ID)
        {
            return _db.PersonGame
          .Include(x => x.Person)
          .Include(x => x.Game)
          .FirstOrDefault(x => x.personGameID == ID);
        }

        /// <summary>
        /// implementing the ReadAll method
        /// </summary>
        /// <returns>the list of people</returns>
        public ICollection<PersonGame> ReadAll()
        {
            return _db.PersonGame
         .Include(x => x.Person)
         .Include(x => x.Game)
          .ToList();
        }

        /// <summary>
        /// implementing the Create (Delete)
        /// </summary>
        /// <param name="personID">passthrough variable to represent the personID from the entity</param>
        /// <param name="gameID">passthrough variable to represent the gameID from the entity</param>
        /// <returns>returns the view model of properties</returns>
        public PersonGame? Create(int personID, int gameID)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                // The person was not found
                return null;
            }
            var personGame = person.GameRating
                .FirstOrDefault(x => x.gameID == gameID);
            if (personGame != null)
            {
                // The person already has a game budget for this course
                return null;
            }
            var game = _gameRepo.Read(gameID);
            if (game == null)
            {
                // The game was not found
                return null;
            }
            var PersonGameRating = new PersonGame
            {
                Person = person,
                Game = game
            };
            person.GameRating.Add(PersonGameRating);
            game.PersonRating.Add(PersonGameRating);
            _db.SaveChanges();
            return PersonGameRating;
        }

        /// <summary>
        /// implementing update view
        /// </summary>
        /// <param name="personGameID">represents the personGameID variable from the PersonGame entity</param>
        /// <param name="Rating">represents the rating variable from the PersonGame Entity</param>
        public void UpdateGameRating(int personGameID, string Rating)
        {
            var personGame = Read(personGameID);
            if (personGame != null)
            {
                personGame.Rating = Rating;
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// implementing Remove method
        /// </summary>
        /// <param name="personID">represents the personID variable from the person entity</param>
        /// <param name="personGameID">represents the personGameID variable from the PersonGame entity</param>
        public void Remove(int personID, int personGameID)
        {
            var person = _personRepo.Read(personID);
            var personGame = person!.GameRating
                .FirstOrDefault(x => x.personID == personGameID);
            var game = personGame!.Game;
            person!.GameRating.Remove(personGame);
            game!.PersonRating.Remove(personGame);
            _db.SaveChanges();
        }
    }
}
