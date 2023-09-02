using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
{
    public class UpdateFreelancerPortfolioCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public SpecialtyEnum RelatedSpecializedProfile { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public TemplateEnum Template { get; set; }
        public List<FreelancerPortfolioSkillUpdateDto> PortfolioSkills { get; set; }
        public List<FreelancerPortfolioFileUpdateDto> PortfolioFiles { get; set; }
        public string? ProjectTitle { get; set; }
        public string? ProjectURL { get; set; }
        public string? Role { get; set; }
        public string? ProjectTaskDescription { get; set; }
        public string? ProjectSolutionDescription { get; set; }
        public string? ProjectDescription { get; set; }
        public string? YouTubeLink { get; set; }
        public string? FileCaption { get; set; }
    }
    public class FreelancerPortfolioSkillUpdateDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class FreelancerPortfolioFileUpdateDto
    {

    }
}
