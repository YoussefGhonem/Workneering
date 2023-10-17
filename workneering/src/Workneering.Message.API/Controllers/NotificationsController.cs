using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;

namespace Workneering.Message.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/notifications")]
    public class NotificationsController : BaseController
    {
        public NotificationsController(ISender mediator) : base(mediator)
        {
        }

        #region Commands

        [HttpPut("{id}/read")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateMessageCommand(Guid id)
        {
            return Ok();

        }
        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Unit>> CreateMessageCssommand()
        {
            return Ok();

        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Unit>> CreateMesddsageCssommand()
        {
            return Ok();

        }



        #endregion
    }
}