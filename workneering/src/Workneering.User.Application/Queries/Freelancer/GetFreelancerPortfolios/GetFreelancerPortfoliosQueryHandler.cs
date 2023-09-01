using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerPortfolios
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
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new List<FreelancerPortfolioDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .ThenInclude(x => x.PortfolioFiles).Include(x => x.Portfolios).ThenInclude(x => x.PortfolioSkills)
                .FirstOrDefault(x => x.Id == request.Id);
            try
            {
                Mapper.ApplyMapping();
                var result = query!.Portfolios.Adapt<List<FreelancerPortfolioDto>>();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
