using Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer;

namespace Workneering.Project.Application.Services.Models
{
    public class ClientInfoForProjectDetails
    {
        public Guid Id { get; set; }
        public int? IsCompany { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? TitleOverview { get; set; }
        public string? CountryName { get; set; }
        public string? KeyImage { get; set; }
        public string? ImageUrl { get; set; }
        public CompanySizeEnum CompanySize { get; set; }
        public DateTimeOffset FoundedIn { get; set; }
    }
}
