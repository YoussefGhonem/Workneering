using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Message.Application.Commands.Message.CreateMessage;
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
        [HttpPost("recipient/{recipientId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public async Task<ActionResult<string>> CreateMessageCommand(CreateMessageCommand command, Guid recipientId)
        {
            command.RecipientId = recipientId;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region Queries
        [HttpPost("chat/{recipientId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<GetConversationDto>))]
        public async Task<ActionResult<List<GetConversationDto>>> GetConversationQuery(GetConversationQuery command, Guid recipientId)
        {
            command.RecipientId = recipientId;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPost("chat/count-unread")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CountUnreadMessagesDto))]
        public async Task<ActionResult<CountUnreadMessagesDto>> GetCountUnreadMessagesQuery()
        {
            return Ok(await Mediator.Send(new GetCountUnreadMessagesQuery(), CancellationToken));
        }


        #endregion
    }
}