using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio
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
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();

            query!.UpdatePortfolio(request.Id, portfolioMap);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);

            return Unit.Value;


        }
    }
}
