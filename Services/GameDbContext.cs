using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonGame> PersonGame => Set<PersonGame>();
        public DbSet<Game> Game => Set<Game>();
        public DbSet<Person> Person => Set<Person>();
    }
}
