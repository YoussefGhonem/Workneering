namespace Workneering.Project.Application.Services.Models
{
    public class ClientInfoForProjectDetails
    {
        public Guid Id { get; set; }
        public int? IsCompany { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CountryName { get; set; }
    }
}
