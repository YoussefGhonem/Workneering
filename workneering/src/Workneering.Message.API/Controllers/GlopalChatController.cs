using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Commands.GlopalChat.CreateGlopalChat;
using Workneering.Message.Application.Commands.GlopalChat.MarkRoomAsRead;
using Workneering.Message.Application.Queries.GetUserInfoForChat;
using Workneering.Message.Application.Queries.GlopalChat.GeRooms;
using Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer;
using Workneering.Message.Application.Queries.GlopalChat.GetCountRoomsUnread;
using Workneering.Message.Application.Queries.GlopalChat.GetCountUnreadRoom;
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

        [HttpPut("{roomId}/read")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<GlopalChatDto>))]
        public async Task<ActionResult<PaginationResult<GlopalChatDto>>> MarkRoomAsReadCommand([FromBody] MarkRoomAsReadCommand query, Guid roomId)
        {
            query.RoomId = roomId;
            return Ok(await Mediator.Send(query, CancellationToken));
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
        [HttpGet("{roomId}/count-unread")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountUnreadRoomDto))]
        public async Task<ActionResult<CountUnreadRoomDto>> GetCountUnreadRoomQuery([FromQuery] GetCountUnreadRoomQuery query, Guid roomId)
        {
            query.RoomId = roomId;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("rooms/count")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountUnreadRoomDto))]
        public async Task<ActionResult<CountUnreadRoomDto>> GetCountRoomsUnreadQuery([FromQuery] GetCountRoomsUnreadQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("rooms/client")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<RoomsDto>))]
        public async Task<ActionResult<PaginationResult<RoomsDto>>> GeRoomsQuery()
        {
            return Ok(await Mediator.Send(new GeRoomsQuery(), CancellationToken));
        }
        [HttpGet("rooms/company")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<RoomsDto>))]
        public async Task<ActionResult<PaginationResult<RoomsDto>>> GeRoomsCompanyQuery()
        {
            return Ok(await Mediator.Send(new GeRoomsQuery(), CancellationToken));
        }

        [HttpGet("rooms/freelancer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<RoomsDto>))]
        public async Task<ActionResult<PaginationResult<RoomsDto>>> GeRoomsForFreelancerQuery()
        {
            return Ok(await Mediator.Send(new GeRoomsForFreelancerQuery(), CancellationToken));
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