using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Message.Application.Commands.Notification.MarkNotificationAsRead;
using Workneering.Message.Application.Queries.Notifications.GeNotifications;
using Workneering.Message.Application.Queries.Notifications.GetUnreadNotificationsCount;

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
        public async Task<ActionResult<Unit>> MarkNotificationAsReadCommand(Guid id)
        {
            var query = new MarkNotificationAsReadCommand();
            query.Id = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<MessageNotificationsDto>))]
        public async Task<ActionResult<PaginationResult<MessageNotificationsDto>>> GeNotificationsQuery([FromQuery] GeNotificationsQuery query)
        {

            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("count")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UnreadNotificationsCountDto))]
        public async Task<ActionResult<UnreadNotificationsCountDto>> GetUnreadNotificationsCountQuery([FromQuery] GetUnreadNotificationsCountQuery query)
        {

            return Ok(await Mediator.Send(query, CancellationToken));
        }


        #endregion
    }
}