using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Workneering.Identity.Infrastructure.Persistence;
using System.Security.Claims;
using Mapster;
using Workneering.Identity.Application.Services.Models;
using Workneering.Identity.Application.Services.DbQueryService;

namespace Workneering.Identity.Application.Commands.Identity.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly IConfiguration _configuration;
		public readonly IDbQueryService _dbQueryService;


		public LoginCommandHandler(IdentityDatabaseContext context, IConfiguration configuration, IDbQueryService dbQueryService)
		{
			_context = context;
			_configuration = configuration;
			//_dbQueryService = dbQueryService;
			_dbQueryService = dbQueryService;
		}

		public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);
            if (user == null) return "";

            var UserData = _dbQueryService.GetUserData
                (user.UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Name))
                .FirstOrDefault().Value.ToString(), user, cancellationToken);
            var result = new UserBaseData()
            {
                WengazPercentage = UserData.Result.WengazPercentage,
                WengazPoint = UserData.Result.WengazPoint,
            };

            var token = JsonWebTokenGeneration.GenerateJwtToken(_configuration, user, result);

            await _context.SaveChangesAsync(user.Id, cancellationToken);

            return token;
        }
    }
}