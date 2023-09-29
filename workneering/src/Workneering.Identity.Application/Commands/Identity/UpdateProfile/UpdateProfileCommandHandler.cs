using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Commands.Identity.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Unit>
{
    private readonly IdentityDatabaseContext _identityDatabase;
    private readonly IMediator _mediator;


    public UpdateProfileCommandHandler(IMediator mediator, IdentityDatabaseContext context)
    {
        _identityDatabase = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityDatabase.Users.FirstAsync(b => b.Id == CurrentUser.Id, cancellationToken);

        user.SetName(request.FirstName + request.LastName);
        //var command = new ChangePasswordCommand(user.Id, request.CurrentPassword, request.NewPassword, request.ConfirmPassword);
        //await _mediator.Send(command, cancellationToken);

        await _identityDatabase.SaveChangesAsync(cancellationToken);


        return Unit.Value;


    }

}