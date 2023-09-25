using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects
{
    public class ClientProjectsDto
    {
        public Guid? Id { get; set; }
        public string? ProjectTitle { get; set; }
        public Guid? AssginedFreelancerId { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public ProjectBudgetEnum? ProjectBudget { get; set; }
        public ProjectStatusEnum? ProjectStatus { get; set; }
        public string? ExperienceLevel { get; set; }
        public int NumberOfProposals { get; set; }
        public AssginedFreelancerDto AssginedFreelancer { get; set; }
    }
    public class AssginedFreelancerDto
    {
        public Guid? FreelancerId { get; set; }
        public string? Name { get; set; } = null;
        public string? Title { get; set; } = null;
        public string? CountryName { get; set; } = null;
    }
}
