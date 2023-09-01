using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerPortfolios
{
    public class UpdateFreelancerPortfolioHandler : IRequestHandler<UpdateFreelancerPortfolioCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateFreelancerPortfolioHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateFreelancerPortfolioCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .ThenInclude(x => x.PortfolioFiles).Include(x => x.Portfolios).ThenInclude(x => x.PortfolioSkills)
                .FirstOrDefault(x => x.Id == request.Id);
            try
            {
                Mapper.ApplyMapping();
                var result = query!.Portfolios.Adapt<Unit>();
                return result;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
