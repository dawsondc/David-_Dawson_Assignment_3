using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// class to talk to database
    /// </summary>
    public class DbPersonRepository : IPersonRepository
    {
        private readonly GameDbContext _db;

        /// <summary>
        /// instance of repository giving it the DB Context
        /// </summary>
        /// <param name="db">repesents the context file</param>
        public DbPersonRepository(GameDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Implementing Read Method
        /// </summary>
        /// <param name="ID">represents the personID from the person entity</param>
        /// <returns>the selected person details</returns>
        public Person? Read(int ID)
        {
            return _db.Person
           .Include(x => x.GameRating)
              .ThenInclude(y => y.Game)
           .FirstOrDefault(x => x.personID == ID);
        }

        /// <summary>
        /// implementing the ReadAll method
        /// </summary>
        /// <returns>the list of people</returns>
        public ICollection<Person> ReadAll()
        {
            return _db.Person
           .Include(x => x.GameRating)
              .ThenInclude(y => y.Game)
              .ToList();
        }
    }
}
