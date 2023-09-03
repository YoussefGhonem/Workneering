using MediatR;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid?>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateUserCommandHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }

        public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Role == Shared.Core.Identity.Enums.RolesEnum.Client)
            {
                var user = new Client(request.Id);
                await _userDatabaseContext.Clients.AddAsync(user);

            }
            else if (request.Role == Shared.Core.Identity.Enums.RolesEnum.Company)
            {
                var user = new Workneering.User.Domain.Entites.Company(request.Id, request.Name);
                await _userDatabaseContext.Companies.AddAsync(user);
            }
            else
            {
                var user = new Workneering.User.Domain.Entites.Freelancer(request.Id, request.Name);
                await _userDatabaseContext.Freelancers.AddAsync(user);
            }

            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return request.Id;
        }
    }
}