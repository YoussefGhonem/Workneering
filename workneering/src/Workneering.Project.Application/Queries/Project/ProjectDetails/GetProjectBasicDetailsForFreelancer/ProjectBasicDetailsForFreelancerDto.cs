using Workneering.Project.Application.Services.Models;

namespace Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetails
{
    public class ProjectBasicDetailsForFreelancerDto
    {
        public Guid ClientId { get; set; }
        public bool IsSaved { get; set; } = false;
        public string? ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public bool? IsOpenDueDate { get; set; }
        public string? DueDate { get; set; }
        public decimal? ProjectBudgetPrice { get; set; }
        public string? ProjectStatus { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? ProjectBudget { get; set; }
        public string? ProjectType { get; set; }
        public string? CategoryName { get; set; }
        public string? SubCategoryName { get; set; }
        public ClientInfoForProjectDetails ClientInfo { get; set; } = new();
    }
}
