using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public interface ICompanyGameDevelopmentRepository
    {
        CompanyGameDevelopment? Read(int ID);
        ICollection<CompanyGameDevelopment> ReadAll();
        CompanyGameDevelopment? Create(int companyID, int gameID);
    }
}
