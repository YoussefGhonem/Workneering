using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat;
using Workneering.Message.Application.Queries.GetUserInfoForChat;
using Workneering.Message.Application.Queries.GlopalChat.GeRooms;
using Workneering.Message.Application.Queries.GlopalChat.GetGlopalChat;

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
        public async Task<ActionResult<Unit>> CreateMessageCommand([FromForm] CreateGlopalChatCommand command, Guid roomId)
        {
            try
            {
                command.RoomId = roomId;
                return Ok(await Mediator.Send(command, CancellationToken));

            }
            catch (Exception ex)
            {

                throw;
            }
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

        [HttpGet("user-info/{roomId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserInfoForChatDto))]
        public async Task<ActionResult<UserInfoForChatDto>> GetUserInfoForChatQuery(Guid roomId)
        {
            return Ok(await Mediator.Send(new GetUserInfoForChatQuery() { RoomId = roomId }, CancellationToken));
        }


        #endregion
    }
}