using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerPortfolios
{
    public class FreelancerPortfolioDto
    {
        public Guid Id { get; set; }
        public string? ProjectTitle { get; set; }
        public TemplateEnum Template { get; set; }
        public SpecialtyEnum RelatedSpecializedProfile { get; set; }
        public DateTimeOffset? CompletionDate { get; set; }
        public List<FreelancerPortfolioSkillDto> PortfolioSkills { get; set; }
        public List<FreelancerPortfolioFileDto> PortfolioFiles { get; set; }
    }

    public class FreelancerPortfolioSkillDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
    public class FreelancerPortfolioFileDto
    {

    }
}
