using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitleOverview;

public class UpdateTitleOverviewCommandHandler : IRequestHandler<UpdateTitleOverviewCommand>
{
    private readonly UserDatabaseContext _userDatabaseContext;

    public UpdateTitleOverviewCommandHandler(UserDatabaseContext userDatabaseContext)
    {
        _userDatabaseContext = userDatabaseContext;
    }

    public async Task<Unit> Handle(UpdateTitleOverviewCommand request, CancellationToken cancellationToken)
    {
        var user = await _userDatabaseContext.Freelancers.FirstAsync(x => x.Id == CurrentUser.Id);
        user.UpdateTitleOverview(request.TitleOverview);
        _userDatabaseContext.Attach(user);
        await _userDatabaseContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
