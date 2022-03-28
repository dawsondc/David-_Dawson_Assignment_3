using System.ComponentModel.DataAnnotations;

namespace David__Dawson_Assignment_3.Models.Entities
{
    public class PersonGame
    {
        public int personGameID { get; set; }
        [StringLength(32)]
        public string Rating { get; set; } = String.Empty;


        public int gameID { get; set; }
        public Game? Game { get; set; }


        public int personID { get; set; }
        public Person? Person { get; set; }
    }
}
