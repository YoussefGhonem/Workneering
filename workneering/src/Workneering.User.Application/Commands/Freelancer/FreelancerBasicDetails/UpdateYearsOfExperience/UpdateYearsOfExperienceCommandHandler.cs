using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateYearsOfExperience;

public class UpdateYearsOfExperienceCommandHandler : IRequestHandler<UpdateYearsOfExperienceCommand, Unit>
{
    private readonly UserDatabaseContext _userDatabaseContext;

    public UpdateYearsOfExperienceCommandHandler(UserDatabaseContext userDatabaseContext)
    {
        _userDatabaseContext = userDatabaseContext;
    }
    public async Task<Unit> Handle(UpdateYearsOfExperienceCommand request, CancellationToken cancellationToken)
    {
        if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;
        var query = await _userDatabaseContext
                        .Freelancers
                        .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
        query!.UpdateYearsOfExperience(request.YearsOfExperience);
        _userDatabaseContext.Freelancers.Attach(query);
        _userDatabaseContext?.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

