using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Web;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.ForgetPassword;

public class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly IdentityDatabaseContext _context;

    public ForgetPasswordCommandHandler(UserManager<User> userManager, IdentityDatabaseContext context)
    {
        _userManager = userManager;
        _userManager = userManager;
        _context = context;
    }

    public async Task<Unit> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var encodedToken = HttpUtility.UrlEncode(token);

        // send email

        return Unit.Value;
    }
}