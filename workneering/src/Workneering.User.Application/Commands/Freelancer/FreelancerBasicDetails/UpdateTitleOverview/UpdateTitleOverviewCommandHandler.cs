using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        var user = await _userDatabaseContext.Freelancers
                            .Include(c => c.Portfolios).AsSplitQuery()
                            .Include(c => c.Educations).AsSplitQuery()
                            .Include(c => c.Certifications).AsSplitQuery()
                            .Include(c => c.Languages).AsSplitQuery()
                            .Include(c => c.Experiences).AsSplitQuery()
                            .Include(c => c.Categories).AsSplitQuery()
                            .Include(c => c.EmploymentHistory).AsSplitQuery()
                            .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
        user.UpdateTitleOverview(request.TitleOverview);
        user.UpdateAllPointAndPercentage(user);
        _userDatabaseContext.Attach(user);
        await _userDatabaseContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
