using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// interface for the Read and ReadAll methods for Person
    /// </summary>
    public interface IPersonRepository
    {
        Person? Read(int ID);
        ICollection<Person> ReadAll();
    }
}
