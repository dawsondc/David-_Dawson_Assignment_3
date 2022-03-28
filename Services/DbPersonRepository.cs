using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class DbPersonRepository : IPersonRepository
    {
        private readonly GameDbContext _db;

        public DbPersonRepository(GameDbContext db)
        {
            _db = db;
        }
        public Person? Read(int ID)
        {
            return _db.Person
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Game)
           .FirstOrDefault(x => x.personID == ID);
        }

        public ICollection<Person> ReadAll()
        {
            return _db.Person
           .Include(x => x.PersonRating)
              .ThenInclude(y => y.Game)
              .ToList();
        }
    }
}
