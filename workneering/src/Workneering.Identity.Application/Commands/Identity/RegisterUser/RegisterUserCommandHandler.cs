using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Workneering.Identity.Domain.Builders;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid?>
    {
        private readonly UserManager<User> _userManager;
        private readonly IdentityDatabaseContext _identityDbContext;

        public RegisterUserCommandHandler(UserManager<User> userManager, IdentityDatabaseContext identityDatabase)
        {
            _userManager = userManager;
            _identityDbContext = identityDatabase;
        }

        public async Task<Guid?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var rolesFromDb = await _identityDbContext.Roles.ToListAsync(cancellationToken);

            var userBuilder = new CreateUserFactory(request.FirstName, request.LastName, request.Email, request.CountryName)
                .WithRoles(rolesFromDb, request.Role);
            var user = userBuilder.Build();
            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new Exception(result.Errors.ToString());
            await _identityDbContext.SaveChangesAsync(user.Id, cancellationToken);

            return user.Id;
        }
    }
}