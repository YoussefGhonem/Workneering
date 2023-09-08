using Workneering.Project.Application.Services.Models;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer
{
    public class ProjectBasicDetailsForFreelancerDto
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string ClientType { get; set; }
        public string? ProjectType { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string? ProjectTitle { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? ProjectDuration { get; set; }
        public ProjectBudgetEnum? ProjectBudgetEnum { get; set; }
        public string? ProjectBudget { get; set; }
        public decimal? ProjectFixedBudgetPrice { get; set; }
        public decimal? ProjectHourlyFromPrice { get; set; }
        public decimal? PprojectHourlyToPrice { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? DueDate { get; set; }
        public string? ProjectDescription { get; set; }

        public bool IsSaved { get; set; } = false;
        public ClientInfoForProjectDetailsDto ClientInfo { get; set; } = new();
        public List<CategoriesDto>? Categories { get; set; } = new();
        public List<SubCategoriesDto>? SubCategories { get; set; } = new();
        public List<SkillsDto>? Skills { get; set; } = new();
    }
    public class ClientInfoForProjectDetailsDto
    {
        public Guid Id { get; set; }
        public bool IsCompany { get; set; } = false;
        public string Name { get; set; }
        public string? IndustryName { get; set; }
        public string Title { get; set; }
        public string TitleOverview { get; set; }
        public string CountryName { get; set; }
        public int CompanySize { get; set; }
        public int NumOfProjects { get; set; }
        public DateTimeOffset FoundedIn { get; set; }
    }
    public class CategoriesDto
    {
        public Guid? CategoryId { get; set; }
        public string? Name { get; set; } = null;
    }
    public class SubCategoriesDto
    {
        public Guid? SubCategoryId { get; set; }
        public string? Name { get; set; } = null;
    }
    public class SkillsDto
    {
        public Guid? SkillId { get; set; }
        public string? Name { get; set; } = null;
    }
}
