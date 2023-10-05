using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Json;
using System.Security.Claims;
using Workneering.Identity.Application.Commands.Identity.Login;
using Workneering.Identity.Application.Commands.Identity.RegisterWiththirdPart;
using Workneering.Identity.Application.Services.DbQueryService;
using Workneering.Identity.Application.Services.DTO;
using Workneering.Identity.Application.Services.Models;
using Workneering.Identity.Domain.Builders;
using Workneering.Identity.Domain.Entities;
using Workneering.Identity.Infrastructure.Helper;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.User.Application.Commands.CreateUser;

namespace Workneering.Identity.Application.Commands.Identity.RegisterWiththirdPart
{
    public class RegisterWiththirdPartHandler : IRequestHandler<RegisterWiththirdPartCommand, string>
    {
        private readonly IdentityDatabaseContext _context;
        private readonly IConfiguration _configuration;
        public readonly IDbQueryService _dbQueryService;
        private readonly GoogleAuthSettings _googleAuthSettings;
       private readonly UserManager<Workneering.Identity.Domain.Entities.User> _userManager;
        //private readonly SignInManager<Workneering.Identity.Domain.Entities.User> _singManager;
        private readonly HttpClient _httpClient;
        public readonly FacebookAuthSettings _facebookAuthSettings;
        private readonly IMediator _mediator;


        public RegisterWiththirdPartHandler(IdentityDatabaseContext context, IConfiguration configuration, IDbQueryService dbQueryService,
            IOptions<GoogleAuthSettings> googleAuthSettings,
            IOptions<FacebookAuthSettings> facebookAuthSettings, UserManager<Domain.Entities.User> userManager, IMediator mediator)
        {
            _context = context;
            _configuration = configuration;
            //_dbQueryService = dbQueryService;
            _dbQueryService = dbQueryService;
            _googleAuthSettings = googleAuthSettings.Value;
            // _singManager = singManager;
            _facebookAuthSettings = facebookAuthSettings.Value;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com")
            };
            _userManager = userManager;
            _mediator = mediator;
        }
        private async Task<bool> FacebookValidateAsync(string accessToken, string userId){
           var facebookKeys = _facebookAuthSettings.AppId + "|" + _facebookAuthSettings.AppSecret;
            var fbresult = await _httpClient.GetFromJsonAsync<FaceBookResultDto>($"debug_token?input_token={accessToken}&access_token={facebookKeys}");
            if (fbresult==null|| fbresult.Data.Is_Valid == false || !fbresult.Data.User_Id.Equals(userId))
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
            if (now>expiration)
            {
                return false;
            }
            if (!payload.Subject.Equals(userId))
            {
                return false;
            }
            return true;
        }

        private async Task<FacebookUserViewModel> VerifyFacebookAccessToken(string accessToken)
        {
            FacebookUserViewModel fbUser = null;
            var fbresult = await _httpClient.GetAsync($"me?access_token={accessToken}");
            if (fbresult.IsSuccessStatusCode)
            {
                var content = await fbresult.Content.ReadAsStringAsync();
                fbUser = Newtonsoft.Json.JsonConvert.DeserializeObject<FacebookUserViewModel>(content);
            }
            return fbUser;
        }

        public async Task<string?> Handle(RegisterWiththirdPartCommand request, CancellationToken cancellationToken)
        {
            var rolesFromDb = await _context.Roles.ToListAsync(cancellationToken);

            if (request.provider.Equals("facebook"))
            {
                if (!FacebookValidateAsync(request.accessToken, request.userId).GetAwaiter().GetResult())
                {
                    return null;
                }
                var usesssr = await _userManager.FindByEmailAsync($"{request.userId}@{request.provider}.com");
                if (usesssr != null)
                {
                    return null;
                }
                var userFaceook = await VerifyFacebookAccessToken(request.accessToken);
                var userBuilder = new CreateUserFactory(userFaceook.name,
               $"{request.userId}@{request.provider}.com")
               .WithRoles(rolesFromDb, request.Role);
                userBuilder.WithProvider(request.provider);
                userBuilder.UserName(request.userId);

                var user = userBuilder.BuildProvider();
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded) throw new Exception(result.Errors.ToString());
                await _context.SaveChangesAsync(user.Id, cancellationToken);
                var command = new CreateUserCommand(user.Id, request.Role, userFaceook.name);
                await _mediator.Send(command, cancellationToken);
                var token = JsonWebTokenGeneration.GenerateJwtToken(_configuration, user);

                return token;
            }
            else if (request.provider.Equals("google"))
            {
                if (!GoogleValidateAsync(request.accessToken, request.userId).GetAwaiter().GetResult())
                {
                    return null;
                }
                var userBuilder = new CreateUserFactory(request.name,
               request.email)
               .WithRoles(rolesFromDb, request.Role);
                userBuilder.WithProvider(request.provider);
                userBuilder.UserName(request.userId);
                var user = userBuilder.BuildProvider();
                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded) throw new Exception(result.Errors.ToString());
                await _context.SaveChangesAsync(user.Id, cancellationToken);
                var command = new CreateUserCommand(user.Id, request.Role, request.name);
                await _mediator.Send(command, cancellationToken);
                var token = JsonWebTokenGeneration.GenerateJwtToken(_configuration, user);

                return token;
            }
            else
            {

                return null;
            }
                               
        }
    }
}