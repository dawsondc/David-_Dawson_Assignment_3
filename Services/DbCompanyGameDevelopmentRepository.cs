using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class DbCompanyGameDevelopmentRepository : ICompanyGameDevelopmentRepository
    {
        private readonly GameDbContext _db;
        private readonly IGameRepository _gameRepo;
        private readonly ICompanyRepository _companyRepo;

        public DbCompanyGameDevelopmentRepository(
            GameDbContext db,
            IGameRepository gameRepo, ICompanyRepository companyRepo)
        {
            _db = db;
            _gameRepo = gameRepo;
            _companyRepo = companyRepo;
        }

        public CompanyGameDevelopment? Read(int ID)
        {
            return _db.CompanyGameDevelopment
          .Include(x => x.Company)
          .Include(x => x.Game)
          .FirstOrDefault(x => x.ID == ID);
        }

        public ICollection<CompanyGameDevelopment> ReadAll()
        {
            return _db.CompanyGameDevelopment
         .Include(x => x.Company)
         .Include(x => x.Game)
          .ToList();
        }

        public CompanyGameDevelopment? Create(int compnayID, int gameID)
        {
            var company = _companyRepo.Read(compnayID);
            if (company == null)
            {
                // The company was not found
                return null;
            }
            var companyGame = company.CompanyBudget
                .FirstOrDefault(x => x.gameID == gameID);
            if (companyGame != null)
            {
                // The company already has a game budget for this course
                return null;
            }
            var game = _gameRepo.Read(gameID);
            if (game == null)
            {
                // The game was not found
                return null;
            }
            var companyGameDevelopment = new CompanyGameDevelopment
            {
                Company = company,
                Game = game
            };
            company.CompanyBudget.Add(companyGameDevelopment);
            game.GameBudget.Add(companyGameDevelopment);
            _db.SaveChanges();
            return companyGameDevelopment;
        }
    }
}
