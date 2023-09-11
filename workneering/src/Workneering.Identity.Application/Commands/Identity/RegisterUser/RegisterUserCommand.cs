using MediatR;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.Identity.Application.Commands.Identity.RegisterUser
{
    public class RegisterUserCommand : IRequest<Guid?>
    {
        public RolesEnum Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public RegisterUserCommand(string email, string password, RolesEnum role,
            string name )
        {
            Email = email;
            Password = password;
            Role = role;
            Name = name;
        }
    }
}