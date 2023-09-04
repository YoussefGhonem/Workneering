using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.Portfolio.GetPortfolioById
{
    public class GetPortfolioByIdQueryHandler : IRequestHandler<GetPortfolioByIdQuery, PortfolioDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetPortfolioByIdQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<PortfolioDetailsDto> Handle(GetPortfolioByIdQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .ThenInclude(x => x.PortfolioFiles)
                .Include(x => x.Portfolios)
                .ThenInclude(x => x.PortfolioSkills)
                .FirstOrDefault(x => x.Id == request.FreelancerId);

            var portfolio = query.Portfolios.FirstOrDefault(x => x.Id == request.Id);

            if (portfolio == null) return new PortfolioDetailsDto();

            Mapper.ApplyMapping();
            var result = portfolio.Adapt<PortfolioDetailsDto>();
            return result;


        }
    }
}
