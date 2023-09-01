using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateOverviewDescription
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateOverviewDescriptionCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateOverviewDescriptionCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;
            var query = await _userDatabaseContext.Freelancers.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            query!.UpdateOverviewDescription(request.OverviewDescription);
            return Unit.Value;
        }
    }
}
