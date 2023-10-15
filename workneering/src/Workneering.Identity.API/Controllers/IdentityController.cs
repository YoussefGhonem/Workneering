using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Identity.Application.Commands.Identity.ChangePassword;
using Workneering.Identity.Application.Commands.Identity.Login;
using Workneering.Identity.Application.Commands.Identity.LoginWithThirdPart;
using Workneering.Identity.Application.Commands.Identity.RegisterUser;
using Workneering.Identity.Application.Commands.Identity.RegisterWiththirdPart;
using Workneering.Identity.Application.Commands.Identity.UpdateProfile;
using Workneering.Identity.Application.Queries.GetProfileDetails;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/identity")]
    public class IdentityController : BaseController
    {
        public IdentityController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> Login(LoginCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [AllowAnonymous]
        [HttpPost("login-with-third-part")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> LoginWithThirdPart(LoginWithThirdPartCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [AllowAnonymous]
        [HttpPost("register-with-third-part")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> LoginWithThirdPart(RegisterWiththirdPartCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [AllowAnonymous]
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid?))]
        public async Task<ActionResult<Guid?>> RegisterUser(RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [AllowAnonymous]
        [HttpPut("profile")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid?))]
        public async Task<ActionResult<Guid?>> UpdateProfileCommand(UpdateProfileCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        //[AllowAnonymous]
        //[HttpPost("{email}/forgot-password")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        //public async Task<ActionResult<Unit>> ForgotPassword(string email)
        //{
        //    return Ok(await Mediator.Send(new ForgetPasswordCommand(email), CancellationToken));
        //}

        [Authorize]
        [HttpPut("change-password")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> ChangeMyPassword(ChangePasswordCommand command)
        {
            command.UserId = CurrentUser.Id ?? Guid.Empty;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region Queries
        [AllowAnonymous]
        [HttpGet("profile-details")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProfileDetailsDto))]
        public async Task<ActionResult<GetProfileDetailsDto>> GetProfileDetailsQuery()
        {
            var command = new GetProfileDetailsQuery();
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion
    }
}