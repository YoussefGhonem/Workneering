using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{
    public class CreatePortfolioCommand : IRequest<Unit>
    {
        public SpecialtyEnum RelatedSpecializedProfile { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public TemplateEnum Template { get; set; }
        public List<FreelancerPortfolioSkillCreateDto> PortfolioSkills { get; set; }
        public List<FreelancerPortfolioFileCreateDto> PortfolioFiles { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectURL { get; set; }
        public string? Role { get; set; }
        public string? ProjectTaskDescription { get; set; }
        public string? ProjectSolutionDescription { get; set; }
        public string? ProjectDescription { get; set; }
        public string? YouTubeLink { get; set; }
        public string? FileCaption { get; set; }

    }

    public class FreelancerPortfolioSkillCreateDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class FreelancerPortfolioFileCreateDto
    {

    }
}
