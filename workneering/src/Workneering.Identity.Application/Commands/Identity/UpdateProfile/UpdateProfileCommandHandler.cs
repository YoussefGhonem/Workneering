using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Workneering.Identity.Application.Services.DbQueryService;

namespace Workneering.Identity.Application.Commands.Identity.UpdateProfile;

public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Unit>
{
    private readonly IdentityDatabaseContext _identityDatabase;
    private readonly IMediator _mediator;
    private readonly IDbQueryService _dbQueryService;


    public UpdateProfileCommandHandler(IMediator mediator, IdentityDatabaseContext context, IDbQueryService dbQueryService)
    {
        _identityDatabase = context;
        _mediator = mediator;
        _dbQueryService = dbQueryService;
    }

    public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var user = await _identityDatabase.Users.FirstAsync(b => b.Id == CurrentUser.Id, cancellationToken);
        //user.SetName(request!.name);
        user.UpdatePhoneNumber(request!.PhoneNumber);
        user.UpdateName(request.Name);
        // _identityDatabase.Users.Attach(user);
        //var command = new ChangePasswordCommand(user.Id, request.CurrentPassword, request.NewPassword, request.ConfirmPassword);
        //await _mediator.Send(command, cancellationToken);
        await _dbQueryService.UpdateUserName(user.Id, request.Name, CurrentUser.Roles!.FirstOrDefault().ToString(), cancellationToken);
        await _identityDatabase.SaveChangesAsync(cancellationToken);


        return Unit.Value;


    }

}