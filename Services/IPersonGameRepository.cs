using David__Dawson_Assignment_3.Models.Entities;

namespace David__Dawson_Assignment_3.Services
{
    public interface IPersonGameRepository
    {
        PersonGame? Read(int ID);
        ICollection<PersonGame> ReadAll();
        PersonGame? Create(int personID, int gameID);
        void UpdateGameRating(int personGameID, string rating);
        void Remove(int personID, int personGameID);
    }
}
