using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;

namespace Workneering.Message.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/chat")]
    public class GlopalChatController : BaseController
    {
        public GlopalChatController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [HttpPost("{roomId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateMessageCommand(Guid roomId)
        {
            return Ok();

        }

        [HttpPut("{roomId}/read")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReadCommand(Guid roomId)
        {
            return Ok();

        }
        #endregion

        #region Queries
        [HttpGet("{roomId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReadComman2d(Guid roomId)
        {
            return Ok();

        }
        [HttpGet("{roomId}/count-unread")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReadCommandd(Guid roomId)
        {
            return Ok();

        }
        [HttpGet("rooms/count")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsRedadCommand()
        {
            return Ok();

        }

        [HttpGet("rooms/client")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReddadCommand()
        {
            return Ok();

        }

        [HttpGet("rooms/company")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsRedadComdmand(Guid roomId)
        {
            return Ok();

        }


        [HttpGet("rooms/freelancer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReddadCommand(Guid roomId)
        {
            return Ok();

        }


        [HttpGet("user-info/{roomId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> MarkRoomAsReddadffCommand(Guid roomId)
        {
            return Ok();

        }



        #endregion
    }
}