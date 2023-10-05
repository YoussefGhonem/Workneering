using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Commands.Message.CreateMessage;
using Workneering.Message.Application.Commands.Message.DeleteMessage;
using Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer;
using Workneering.Message.Application.Queries.GlopalChat.GetGlopalChat;
using Workneering.Message.Application.Queries.Message.GetConversation;
using Workneering.Message.Application.Queries.Message.GetCountUnreadMessages;

namespace Workneering.Message.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/glopal-chat")]
    public class GlopalChatController : BaseController
    {
        public GlopalChatController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [HttpPost("{projectId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateMessageCommand([FromForm] CreateMessageCommand command, Guid projectId)
        {
            command.ProjectId = projectId;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteMessageCommand(Guid id)
        {
            var command = new DeleteMessageCommand();
            command.MessageId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region Queries
        [HttpGet("{roomId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<GlopalChatDto>))]
        public async Task<ActionResult<PaginationResult<GlopalChatDto>>> GetGlopalChat([FromQuery] GetGlopalChatQuery query, Guid roomId)
        {
            query.RoomId = roomId;
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("rooms")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<RoomsDto>))]
        public async Task<ActionResult<PaginationResult<RoomsDto>>> GeRoomsQuery()
        {
            return Ok(await Mediator.Send(new GeRoomsQuery(), CancellationToken));
        }


        #endregion
    }
}