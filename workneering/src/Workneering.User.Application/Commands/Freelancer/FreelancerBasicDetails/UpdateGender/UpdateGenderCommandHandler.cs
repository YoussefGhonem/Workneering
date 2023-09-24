using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateGender;

public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand>
{
    private readonly UserDatabaseContext _userDatabaseContext;
    public UpdateGenderCommandHandler(UserDatabaseContext userDatabaseContext)
    {
        _userDatabaseContext = userDatabaseContext;
    }
    public async Task<Unit> Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
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
        user.UpdateGender(request.Gender);
        user.UpdateAllPointAndPercentage(user);
        _userDatabaseContext.Freelancers.Attach(user);
        _userDatabaseContext?.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
