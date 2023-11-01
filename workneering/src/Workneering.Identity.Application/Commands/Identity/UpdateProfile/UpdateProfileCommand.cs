using MediatR;

namespace Workneering.Identity.Application.Commands.Identity.UpdateProfile;

public class UpdateProfileCommand : IRequest<Unit>
{

    public string? Name { get; set; }
    public string? PhoneNumber { get; set; }
    //public string CurrentPassword { get; }
    //public string NewPassword { get; }
    //public Guid NewPasddsword { get; }
    //public string ConfirmPassword { get; }


}