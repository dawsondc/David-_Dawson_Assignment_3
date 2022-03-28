using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public interface IGameRepository
    {
        Game? Read(int ID);
        ICollection<Game> ReadAll();
    }
}
