using David__Dawson_Assignment_3.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace David__Dawson_Assignment_3.Services
{
    public class DbCompanyRepository : ICompanyRepository
    {
        private readonly GameDbContext _db;

        public DbCompanyRepository(GameDbContext db)
        {
            _db = db;
        }
        public Company? Read(int ID)
        {
            return _db.Company
           .Include(x => x.CompanyBudget)
              .ThenInclude(y => y.Game)
           .FirstOrDefault(x => x.companyID == ID);
        }

        public ICollection<Company> ReadAll()
        {
            return _db.Company
           .Include(x => x.CompanyBudget)
              .ThenInclude(y => y.Game)
              .ToList();
        }
    }
}
