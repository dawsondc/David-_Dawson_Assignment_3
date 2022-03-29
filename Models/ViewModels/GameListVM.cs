using System.ComponentModel;

namespace David__Dawson_Assignment_3.Models.ViewModels
{
    public class GameListVM
    {
        [DisplayName("Person")]
        public string? Person { get; set; }
        [DisplayName("Game")]
        public string? Game { get; set; }
        [DisplayName("Rating")]
        public string? Rating { get; set; }
    }
}
