namespace David__Dawson_Assignment_3.Models.Entities
{
    public class CompanyGameDevelopment
    {
        public int ID { get; set; }
        public string Budget { get; set; } = String.Empty;


        public int gameID { get; set; }
        public Game? Game { get; set; }


        public int companyID { get; set; }
        public Company? Company { get; set; }
    }
}
