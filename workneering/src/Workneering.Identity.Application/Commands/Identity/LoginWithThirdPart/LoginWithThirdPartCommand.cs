using MediatR;

namespace Workneering.Identity.Application.Commands.Identity.LoginWithThirdPart
{
    public class LoginWithThirdPartCommand : IRequest<string>
    {
        public string provider { get; set; }
        public string userId { get; set; }
        public string accessToken { get; set; }

    }
}