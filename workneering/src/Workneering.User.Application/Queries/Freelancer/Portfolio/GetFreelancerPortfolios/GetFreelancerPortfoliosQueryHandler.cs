using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios
{
    public class GetFreelancerPortfoliosQueryHandler : IRequestHandler<GetFreelancerPortfoliosQuery, List<FreelancerPortfolioDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerPortfoliosQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<FreelancerPortfolioDto>> Handle(GetFreelancerPortfoliosQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .FirstOrDefault(x => x.Id == request.FreelancerId);

            var result = query!.Portfolios.Adapt<List<FreelancerPortfolioDto>>();
            return result;


        }
    }
}
