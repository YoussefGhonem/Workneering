using MediatR;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.User.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid?>
    {
        public Guid Id { get; set; }
        public RolesEnum Role { get; set; }

        public CreateUserCommand(Guid id, RolesEnum role)
        {
            Id = id;
            Role = role;
        }
    }
}