using MediatR;
using Workneering.Shared.Core.Identity.Enums;

namespace Workneering.User.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid?>
    {
        public Guid Id { get; set; }
        public RolesEnum Role { get; set; }
        public string Name { get; set; }

        public CreateUserCommand(Guid id, RolesEnum role, string name)
        {
            Id = id;
            Role = role;
            Name = name;
        }
    }
}