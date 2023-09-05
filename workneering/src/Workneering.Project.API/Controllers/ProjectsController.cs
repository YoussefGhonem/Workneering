﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Commands.CreateProject;
using Workneering.Project.Application.Commands.CreateProposal;
using Workneering.Project.Application.Commands.UpdateProject;
using Workneering.Project.Application.Commands.Wishlist.CreateWishlist;
using Workneering.Project.Application.Commands.Wishlist.RemoveWishlist;
using Workneering.Project.Application.Queries.Project.GetProjects;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/projects")]
    public class ProjectsController : BaseController
    {
        public ProjectsController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        #region project
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateProjectCommand(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateProjectCommand(UpdateProjectCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region proposal
        [HttpPost("{id}/proposal")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateProposalCommand(CreateProposalCommand command, Guid id)
        {
            command.ProjectId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region wishlist
        [HttpPost("{id}/wishlist")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateWishlistCommand(CreateWishlistCommand command, Guid id)
        {
            command.ProjectId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpDelete("{id}/wishlist")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> RemoveWishlistCommand(RemoveWishlistCommand command, Guid id)
        {
            command.ProjectId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion
        #endregion

        #region Project 
        [HttpGet] // for freelancers
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectListDto>))]
        public async Task<ActionResult<PaginationResult<ProjectListDto>>> GetProjects([FromQuery] GetProjectsQuery query)
        {
            query.ClientId = null;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("clients/{id}")] // to get projects for client id
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectListDto>))]
        public async Task<ActionResult<PaginationResult<ProjectListDto>>> GetProjects([FromQuery] GetProjectsQuery query, Guid id)
        {
            query.ClientId = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("clients")] // get projects for Current client
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectListDto>))]
        public async Task<ActionResult<PaginationResult<ProjectListDto>>> GetClientProjects([FromQuery] GetProjectsQuery query)
        {
            query.ClientId = CurrentUser.Id.Value;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion
    }
}
