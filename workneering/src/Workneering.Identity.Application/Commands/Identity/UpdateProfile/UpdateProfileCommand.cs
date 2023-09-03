using MediatR;

namespace Workneering.Identity.Application.Commands.Identity.UpdateProfile;

public class UpdateProfileCommand : IRequest<Unit>
{

    public string FirstName { get; }
    public string LastName { get; }
    //public string CurrentPassword { get; }
    //public string NewPassword { get; }
    //public Guid NewPasddsword { get; }
    //public string ConfirmPassword { get; }


}