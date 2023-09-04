using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios
{
    public class FreelancerPortfolioDto
    {
        public Guid Id { get; set; }
        public string ProjectTitle { get; set; }
        public string? ProjectDescription { get; set; }
        public int? StartYear { get; set; }
        public int? EndYear { get; set; }
    }


}
