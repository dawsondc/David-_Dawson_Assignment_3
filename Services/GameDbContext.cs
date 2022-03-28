using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class GameDbContext : DbContext
    {
        public GameDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<CompanyGameDevelopment> CompanyGameDevelopment => Set<CompanyGameDevelopment>();
        public DbSet<Game> Game => Set<Game>();
        public DbSet<Company> Company => Set<Company>();
    }
}
