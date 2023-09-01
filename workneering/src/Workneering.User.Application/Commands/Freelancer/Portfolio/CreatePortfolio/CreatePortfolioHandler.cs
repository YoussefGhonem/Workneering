using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio
{
    public class CreatePortfolioHandler : IRequestHandler<CreatePortfolioCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreatePortfolioHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreatePortfolioCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Portfolios).FirstOrDefault(x => x.Id == CurrentUser.Id);

            Mapper.ApplyMapping();
            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();
            var mapPortfolioSkills = request.PortfolioSkills.Adapt<List<Domain.Entites.PortfolioSkill>>();
            var mapPortfolioFiles = request.PortfolioSkills.Adapt<List<Domain.Entites.PortfolioFile>>();

            query!.AddPortfolio(portfolioMap, mapPortfolioSkills, mapPortfolioFiles);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
