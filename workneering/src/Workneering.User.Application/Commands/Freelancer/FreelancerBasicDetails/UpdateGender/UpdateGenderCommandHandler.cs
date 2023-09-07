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
        var user = await _userDatabaseContext.Freelancers.FirstAsync(x => x.Id == CurrentUser.Id);
        user.UpdateGender(request.Gender);
        _userDatabaseContext.Freelancers.Attach(user);
        _userDatabaseContext?.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
