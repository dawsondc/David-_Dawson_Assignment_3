namespace David__Dawson_Assignment_3.Models.Entities
{
    public class Game
    {
        public int gameID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Genre  { get; set; } = String.Empty;


        public ICollection<PersonGame> PersonRating { get; set; } = new List<PersonGame>();
    }
}
