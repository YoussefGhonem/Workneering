using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Identity.Application.Commands.Identity.ChangePassword;
using Workneering.Identity.Application.Commands.Identity.ForgetPassword;
using Workneering.Identity.Application.Commands.Identity.Login;
using Workneering.Identity.Application.Commands.Identity.RegisterUser;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class IdentityController : BaseController
    {
        public IdentityController(ISender mediator) : base(mediator)
        {
        }

        #region Commands

        [AllowAnonymous]
        [HttpPost("login"), Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> Login(LoginCommand command)
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
        [HttpPost("{email}/forgot-password")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> ForgotPassword(string email)
        {
            return Ok(await Mediator.Send(new ForgetPasswordCommand(email), CancellationToken));
        }

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
    }
}