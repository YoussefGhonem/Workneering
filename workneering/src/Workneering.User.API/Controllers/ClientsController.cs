﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientBasicDetails;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientCategorization;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientDescription;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientImage;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhatDoIdo;
using Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientWhoIAm;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyImage;
using Workneering.User.Application.Queries.Client.GetClientBasicDetails;
using Workneering.User.Application.Queries.Client.GetClientCategorization;
using Workneering.User.Application.Queries.Client.GetImageUrl;

namespace Workneering.User.API.Controllers
{
    [ApiVersion("1.0")]
    //  [Authorize]
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
        [HttpPut("profile/image")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientImageCommand([FromForm] UpdateClientImageCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/who-i-am")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientWhoIAmCommand(UpdateClientWhoIAmCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/what-do-i-do")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientWhatDoIdoCommand(UpdateClientWhatDoIdoCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientCategorizationCommand(UpdateClientCategorizationCommand command)
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
        [HttpGet("{id}/profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientCategorizationDto))]
        public async Task<ActionResult<ClientBasicDetailsDto>> GetClientCategorizationQuery(Guid id)
        {
            var query = new GetClientCategorizationQuery() { ClientId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClientCategorizationDto))]
        public async Task<ActionResult<ClientBasicDetailsDto>> GetClientCategorizationQuery()
        {
            var query = new GetClientCategorizationQuery() { ClientId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("profile/image-url")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetImageUrlDto))]
        public async Task<ActionResult<GetImageUrlDto>> GetImageUrlQuery()
        {
            var query = new GetImageUrlQuery() { ClientId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

    }
}