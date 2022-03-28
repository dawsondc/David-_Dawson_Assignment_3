namespace David__Dawson_Assignment_3.Models.Entities
{
    public class Company
    {
        public int companyID { get; set; }
        public string Name { get; set; } = String.Empty;


        public ICollection<CompanyGameDevelopment> CompanyBudget { get; set; } = new List<CompanyGameDevelopment>();
    }
}
