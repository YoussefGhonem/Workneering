using MediatR;
using Microsoft.AspNetCore.Identity;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly IdentityDatabaseContext _context;

    public ChangePasswordCommandHandler(UserManager<User> userManager, IdentityDatabaseContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        if (result.Succeeded)
        {
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

        var errors = result.Errors.Select(x => x.Description).ToList();
        throw new Exception(string.Join(",", errors));
    }

}