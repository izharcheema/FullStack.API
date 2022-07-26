namespace FullStack.API.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyEmail { get; set; }
        public long CompanyPhone { get; set; }
        public long NumberOfEmployees { get; set; }
        public string CompanyAddress { get; set; }

    }
}
