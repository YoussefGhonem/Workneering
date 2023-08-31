using MediatR;

namespace Workneering.Identity.Application.Commands.Identity.ForgetPassword;

public class ForgetPasswordCommand : IRequest<Unit>
{
    public string Email { get; init; }

    public ForgetPasswordCommand(string email)
    {
        Email = email;
    }
}