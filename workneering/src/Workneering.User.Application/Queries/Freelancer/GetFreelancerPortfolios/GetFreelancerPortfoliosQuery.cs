using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerPortfolios
{
    public class GetFreelancerPortfoliosQuery : IRequest<List<FreelancerPortfolioDto>>
    {
        public Guid Id { get; set; }
    }
}
