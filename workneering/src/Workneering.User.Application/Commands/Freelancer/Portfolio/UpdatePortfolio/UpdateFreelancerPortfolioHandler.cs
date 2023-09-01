using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
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
                .ThenInclude(x => x.PortfolioFiles).Include(x => x.Portfolios).ThenInclude(x => x.PortfolioSkills)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            Mapper.ApplyMapping();
            var portfolioMap = request.Adapt<Domain.Entites.Portfolio>();
            var mapPortfolioSkills = request.PortfolioSkills.Adapt<List<Domain.Entites.PortfolioSkill>>();
            var mapPortfolioFiles = request.PortfolioSkills.Adapt<List<Domain.Entites.PortfolioFile>>();

            query!.UpdatePortfolio(request.Id, portfolioMap, mapPortfolioSkills, mapPortfolioFiles);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);


            return Unit.Value;


        }
    }
}
