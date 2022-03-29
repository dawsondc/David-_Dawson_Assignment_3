using System.ComponentModel;

namespace David__Dawson_Assignment_3.Models.Entities
{
    public class Person
    {
        [DisplayName("ID")]
        public int personID { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; } = String.Empty;
        [DisplayName("Last Name")]
        public string LastName { get; set; } = String.Empty;


        public ICollection<PersonGame> GameRating { get; set; } = new List<PersonGame>();
    }
}
