using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    /// <summary>
    /// interface for the Read and ReadAll methods for games
    /// </summary>
    public interface IGameRepository
    {
        Game? Read(int ID);
        ICollection<Game> ReadAll();
    }
}
