using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly IConfiguration _configuration;

        public LoginCommandHandler(IdentityDatabaseContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            if (user == null) return "";

            var token = JsonWebTokenGeneration.GenerateJwtToken(_configuration, user);

            await _context.SaveChangesAsync(user.Id, cancellationToken);

            return token;
        }
    }
}