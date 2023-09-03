using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetPortfolioById
{
    public class GetPortfolioByIdQuery : IRequest<PortfolioDetailsDto>
    {
        public Guid Id { get; set; }
        public Guid? FreelancerId { get; set; }

    }
}
