//using MediatR;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Workneering.Base.API.Controllers;
//using Workneering.Identity.Application.Commands.Identity.Login;
//using Workneering.Identity.Application.Commands.Message.CreateMessage;
//using Workneering.Identity.Application.Queries.GetProfileDetails;

//namespace Workneering.Identity.API.Controllers
//{
//    [ApiVersion("1.0")]
//    [Authorize]
//    [Route("api/v{version:apiVersion}/messages")]
//    public class MessagesController : BaseController
//    {
//        public MessagesController(ISender mediator) : base(mediator)
//        {
//        }

//        #region Commands
//        [HttpPost("sender/{senderId}/recipient/{recipientId}")]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
//        public async Task<ActionResult<string>> CreateMessageCommand(CreateMessageCommand command, Guid senderId, Guid recipientId)
//        {
//            command.SenderId = senderId;
//            command.RecipientId = recipientId;
//            return Ok(await Mediator.Send(command, CancellationToken));
//        }


//        #endregion

//        #region Queries

//        #endregion
//    }
//}