using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public interface ICompanyRepository
    {
        Company? Read(int ID);
        ICollection<Company> ReadAll();
    }
}
