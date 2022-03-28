using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class DbPersonGameRepository : IPersonGameRepository
    {
        private readonly GameDbContext _db;
        private readonly IGameRepository _gameRepo;
        private readonly IPersonRepository _personRepo;

        public DbPersonGameRepository(
            GameDbContext db,
            IGameRepository gameRepo, IPersonRepository personRepo)
        {
            _db = db;
            _gameRepo = gameRepo;
            _personRepo = personRepo;
        }

        public PersonGame? Read(int ID)
        {
            return _db.PersonGame
          .Include(x => x.Person)
          .Include(x => x.Game)
          .FirstOrDefault(x => x.personGameID == ID);
        }

        public ICollection<PersonGame> ReadAll()
        {
            return _db.PersonGame
         .Include(x => x.Person)
         .Include(x => x.Game)
          .ToList();
        }

        public PersonGame? Create(int personID, int gameID)
        {
            var person = _personRepo.Read(personID);
            if (person == null)
            {
                // The person was not found
                return null;
            }
            var personGame = person.PersonRating
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
            person.PersonRating.Add(PersonGameRating);
            game.PersonRating.Add(PersonGameRating);
            _db.SaveChanges();
            return PersonGameRating;
        }
        public void UpdateGameRating(int personGameID, string Rating)
        {
            var personGame = Read(personGameID);
            if (personGame != null)
            {
                personGame.Rating = Rating;
                _db.SaveChanges();
            }
        }
    }
}
