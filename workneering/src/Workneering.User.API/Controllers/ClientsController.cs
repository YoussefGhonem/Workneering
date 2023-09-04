﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientDescription;
using Workneering.User.Application.Queries.Client.GetClientBasicDetails;

namespace Workneering.User.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/clients")]
    public class ClientsController : BaseController
    {
        public ClientsController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [HttpPut("profile/description")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientDescriptionCommand(UpdateClientDescriptionCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientBasicDetailsCommand(UpdateClientBasicDetailsCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region Queries
        [HttpGet("profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientBasicDetailsDto))]
        public async Task<ActionResult<ClientBasicDetailsDto>> GetClientBasicDetailsQuery()
        {
            var query = new GetClientBasicDetailsQuery() { ClientId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("{id}/profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientBasicDetailsDto))]
        public async Task<ActionResult<ClientBasicDetailsDto>> GetClientBasicDetailsQuery(Guid id)
        {
            var query = new GetClientBasicDetailsQuery() { ClientId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

    }
}