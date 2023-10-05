using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Message.Application.Commands.Message.CreateMessage;
using Workneering.Message.Application.Commands.Message.DeleteMessage;
using Workneering.Message.Application.Queries.Message.GetConversation;
using Workneering.Message.Application.Queries.Message.GetCountUnreadMessages;

namespace Workneering.Message.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/messages")]
    public class MessagesController : BaseController
    {
        public MessagesController(ISender mediator) : base(mediator)
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
        [HttpGet("{projectId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetConversationDto>))]
        public async Task<ActionResult<List<GetConversationDto>>> GetConversationQuery([FromQuery] GetConversationQuery query, Guid projectId)
        {
            query.ProjectId = projectId;
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("{projectId}/count-unread")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountUnreadMessagesDto))]
        public async Task<ActionResult<CountUnreadMessagesDto>> GetCountUnreadMessagesQuery([FromQuery] GetCountUnreadMessagesQuery query, Guid projectId)
        {
            query.ProjectId = projectId;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion
    }
}