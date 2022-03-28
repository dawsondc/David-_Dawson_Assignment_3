namespace David__Dawson_Assignment_3.Models.Entities
{
    public class Person
    {
        public int personID { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;


        public ICollection<PersonGame> PersonRating { get; set; } = new List<PersonGame>();
    }
}
