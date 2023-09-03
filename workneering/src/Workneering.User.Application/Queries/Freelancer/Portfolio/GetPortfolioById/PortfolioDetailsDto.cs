using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetPortfolioById
{
    public class PortfolioDetailsDto
    {
        public SpecialtyEnum RelatedSpecializedProfile { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public TemplateEnum Template { get; set; }
        public List<FreelancerPortfolioSkillDto> PortfolioSkills { get; set; }
        public List<FreelancerPortfolioFileDto> PortfolioFiles { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectURL { get; set; }
        public string? Role { get; set; }
        public string? ProjectTaskDescription { get; set; }
        public string? ProjectSolutionDescription { get; set; }
        public string? ProjectDescription { get; set; }
        public string? YouTubeLink { get; set; }
        public string? FileCaption { get; set; }

    }

    public class FreelancerPortfolioSkillDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
    public class FreelancerPortfolioFileDto
    {

    }
}
