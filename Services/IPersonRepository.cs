using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public interface IPersonRepository
    {
        Person? Read(int ID);
        ICollection<Person> ReadAll();
    }
}
