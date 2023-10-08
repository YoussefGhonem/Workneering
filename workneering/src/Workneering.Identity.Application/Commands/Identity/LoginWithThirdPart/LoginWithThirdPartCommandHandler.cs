using Google.Apis.Auth;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
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
        private readonly GoogleAuthSettings _googleAuthSettings;
        private readonly LinkedInAuthSettings _linkedInAuthSettings;



        public LoginWithThirdPartCommandHandler(IdentityDatabaseContext context, IConfiguration configuration,
            IDbQueryService dbQueryService, IOptions<FacebookAuthSettings> facebookAuthSettings, IOptions<GoogleAuthSettings> googleAuthSettings, IOptions<LinkedInAuthSettings> linkedInAuthSettings)
        {
            _context = context;
            _configuration = configuration;
            //_dbQueryService = dbQueryService;
            _dbQueryService = dbQueryService;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com")
            };
            _facebookAuthSettings = facebookAuthSettings.Value;
            _googleAuthSettings = googleAuthSettings.Value;
            _linkedInAuthSettings = linkedInAuthSettings.Value;
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
            }else if (request.provider.Equals("linkedin"))
            {
                var DecodeToken = await GetTokenFromCodeLinkedIn(request.accessToken);
                if (DecodeToken == null)
                {
                    return null;
                }
                var userLinkedIn = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(userRole => userRole.Role)
                .Include(user => user.Claims)
                .FirstOrDefaultAsync(u => u.UserName == DecodeToken.Claims["sub"], cancellationToken);
                if (userLinkedIn == null) return null;
                var UserDataLinkedIn = _dbQueryService.GetUserData
                    (userLinkedIn.UserRoles.Select(userRole => new Claim(ClaimTypes.Role, userRole.Role.Name))
                    .FirstOrDefault().Value.ToString(), userLinkedIn, cancellationToken);
                var resultLinkedIn = new UserBaseData()
                {
                    WengazPercentage = UserDataLinkedIn.Result.WengazPercentage,
                    WengazPoint = UserDataLinkedIn.Result.WengazPoint,
                };

                var tokenLinkedIn = JsonWebTokenGeneration.GenerateJwtToken(_configuration, userLinkedIn, resultLinkedIn);
                await _context.SaveChangesAsync(userLinkedIn.Id, cancellationToken);
                return tokenLinkedIn;
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

        private async Task<TokenInfo> GetTokenFromCodeLinkedIn(string code)
        {
            var authorizationCode = $"{code}";
            var clientId = $"{_linkedInAuthSettings.ClientId}";
            var clientSecret = $"{_linkedInAuthSettings.ClientSecret}";
            var redirectUri = $"{"https://workneering.com/auth/third-part-auth?type=login"}";

            var httpClient = new HttpClient();
            var requestContent = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", authorizationCode),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("redirect_uri", redirectUri)
        });

            //  httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            requestContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
            var response = await httpClient.PostAsync("https://www.linkedin.com/oauth/v2/accessToken", requestContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var Response = JsonSerializer.Deserialize<LinkedInReturnAcessToken>(responseContent);
                var Data = GetTokenInfo(Response?.id_token);
                return Data;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(errorContent);
                return null;
            }
        }

        public TokenInfo GetTokenInfo(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            var tokenInfo = new TokenInfo();
            tokenInfo.Claims = new Dictionary<string, string>();

            foreach (var claim in claims)
            {
                tokenInfo.Claims.Add(claim.Type, claim.Value);
            }

            return tokenInfo;
        }
    }
}