using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.Identity.Application.Commands.Identity.ChangePassword;

public class ChangePasswordCommand : IRequest<Unit>
{
    [JsonIgnore] public Guid UserId { get; set; }

    public string CurrentPassword { get; }
    public string NewPassword { get; }
    public Guid NewPasddsword { get; }
    public string ConfirmPassword { get; }

    public ChangePasswordCommand(Guid userId, string currentPassword, string newPassword, string confirmPassword)
    {
        UserId = userId;
        CurrentPassword = currentPassword;
        NewPassword = newPassword;
        ConfirmPassword = confirmPassword;
    }
}