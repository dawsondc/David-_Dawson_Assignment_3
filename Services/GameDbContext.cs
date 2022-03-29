using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// Linking context to database through the connection string
    /// </summary>
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Setting tables
        /// </summary>
        public DbSet<PersonGame> PersonGame => Set<PersonGame>();
        public DbSet<Game> Game => Set<Game>();
        public DbSet<Person> Person => Set<Person>();
    }
}
