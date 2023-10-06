using Google.Apis.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Security.Claims;
using Workneering.Identity.Application.Commands.Identity.Login;
using Workneering.Identity.Application.Commands.Identity.LoginWithThirdPart;
using Workneering.Identity.Application.Services.DbQueryService;
using Workneering.Identity.Application.Services.DTO;
using Workneering.Identity.Application.Services.Models;
using Workneering.Identity.Infrastructure.Helper;
using Workneering.Identity.Infrastructure.Persistence;

namespace Workneering.Identity.Application.Commands.Identity.LoginWithThirdPart
{
    public class LoginWithThirdPartCommandHandler : IRequestHandler<LoginWithThirdPartCommand, string>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public readonly IDbQueryService _dbQueryService;
        private readonly HttpClient _httpClient;
        public readonly FacebookAuthSettings _facebookAuthSettings;
        public readonly GoogleAuthSettings _googleAuthSettings;


        public LoginWithThirdPartCommandHandler(IdentityDatabaseContext context, IConfiguration configuration, GoogleAuthSettings googleAuthSettings,
            IDbQueryService dbQueryService, IOptions<FacebookAuthSettings> facebookAuthSettings)
        {
            _context = context;
            _configuration = configuration;
            //_dbQueryService = dbQueryService;
            _dbQueryService = dbQueryService;
            _googleAuthSettings = googleAuthSettings;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com")
            };
            _facebookAuthSettings = facebookAuthSettings.Value;
        }

        public async Task<string> Handle(LoginWithThirdPartCommand request, CancellationToken cancellationToken)
        {
            if (request.provider.Equals("facebook"))
            {
                if (!FacebookValidateAsync(request.accessToken, request.userId).GetAwaiter().GetResult())
                {
                    return null;
                }
            }
            else if (request.provider.Equals("google"))
            {
                if (!GoogleValidateAsync(request.accessToken, request.userId).GetAwaiter().GetResult())
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
            var user = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(u => u.UserName == request.userId, cancellationToken);
            if (user == null) return null;

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
        private async Task<bool> FacebookValidateAsync(string accessToken, string userId)
        {
            var facebookKeys = _facebookAuthSettings.AppId + "|" + _facebookAuthSettings.AppSecret;
            var fbresult = await _httpClient.GetFromJsonAsync<FaceBookResultDto>($"debug_token?input_token={accessToken}&access_token={facebookKeys}");
            if (fbresult == null || fbresult.Data.Is_Valid == false || !fbresult.Data.User_Id.Equals(userId))
            {
                return false;
            }
            return true;
        }
        private async Task<bool> GoogleValidateAsync(string accessToken, string userId)
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(accessToken);

            if (!payload.Audience.Equals(_googleAuthSettings.ClientId))
            {
                return false;
            }
            if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
            {
                return false;
            }
            if (payload.ExpirationTimeSeconds == null)
            {
                return false;
            }
            DateTime now = DateTime.Now.ToUniversalTime();
            DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
            if (now > expiration)
            {
                return false;
            }
            if (!payload.Subject.Equals(userId))
            {
                return false;
            }
            return true;
        }
    }
}