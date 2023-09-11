using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateExperienceLevel;

public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateExperienceLevelCommand, Unit>
{
    private readonly UserDatabaseContext _userDatabaseContext;

    public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
    {
        _userDatabaseContext = userDatabaseContext;
    }
    public async Task<Unit> Handle(UpdateExperienceLevelCommand request, CancellationToken cancellationToken)
    {
        var query = await _userDatabaseContext.Freelancers.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
        query!.UpdateExperienceLevel(request.ExperienceLevel);
        _userDatabaseContext.Freelancers.Attach(query);
        _userDatabaseContext?.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
