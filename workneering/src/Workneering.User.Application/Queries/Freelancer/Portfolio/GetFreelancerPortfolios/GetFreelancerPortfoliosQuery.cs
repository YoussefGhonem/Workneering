using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios
{
    public class GetFreelancerPortfoliosQuery : IRequest<List<FreelancerPortfolioDto>>
    {
    }
}
