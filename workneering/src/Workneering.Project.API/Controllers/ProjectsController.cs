﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Project.Application.Commands.CreateProject;
using Workneering.Project.Application.Commands.CreateProposal;
using Workneering.Project.Application.Commands.DeleteProject;
using Workneering.Project.Application.Commands.RemoveProjectAttachment;
using Workneering.Project.Application.Commands.UpdateProject;
using Workneering.Project.Application.Commands.UpdateStatusProposal;
using Workneering.Project.Application.Commands.Wishlist.CreateWishlist;
using Workneering.Project.Application.Commands.Wishlist.RemoveWishlist;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProposals;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectActivity;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails;
using Workneering.Project.Application.Queries.Project.GetProjects;
using Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectAttachments;
using Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer;
using Workneering.Project.Application.Queries.Proposal.GetProposals;
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
        [HttpDelete("{id}/attachments/{key}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> RemoveProjectAttachmentCommand(Guid id, string key)
        {
            return Ok(await Mediator.Send(new RemoveProjectAttachmentCommand { ProjectId = id, Key = key }, CancellationToken));
        }
        [HttpPut("{id}/proposals/{proposalId}/accept/{assginedFreelancerId}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> AcceptStatusProposalCommand(Guid id, Guid proposalId, Guid assginedFreelancerId)
        {
            return Ok(await Mediator.Send(new UpdateStatusProposalCommand { ProjectId = id, ProposalId = proposalId, Status = Domain.Enums.ProposalStatusEnum.Accepted, AssginedFreelancerId = assginedFreelancerId }, CancellationToken));
        }
        [HttpPut("{id}/proposals/{proposalId}/reject")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> RejectStatusProposalCommand(Guid id, Guid proposalId)
        {
            return Ok(await Mediator.Send(new UpdateStatusProposalCommand { ProjectId = id, ProposalId = proposalId, Status = Domain.Enums.ProposalStatusEnum.Rejected }, CancellationToken));
        }
        #region project
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateProjectCommand([FromForm] CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteProjectCommand(Guid id)
        {
            var command = new DeleteProjectCommand();
            command.Id = id;
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

        #region Queries
        [HttpGet("{id}/activities")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectActivitiesDto>))]
        public async Task<ActionResult<PaginationResult<ProjectActivitiesDto>>> GetProjectActivitiesQuery(Guid id)
        {
            return Ok(await Mediator.Send(new GetProjectActivitiesQuery { ProjectId = id }, CancellationToken));
        }
        #region Activities

        #endregion

        #region Project 
        #region List
        [HttpGet] // for freelancers
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectListDto>))]
        public async Task<ActionResult<PaginationResult<ProjectListDto>>> GetProjects([FromQuery] GetProjectsQuery query)
        {
            query.ClientId = null;
            query.IsFreelancer = true;
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

        #region Details
        [HttpGet("{id}/details-for-freelancer")] // for freelancers
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectAttachmentsDto))]
        public async Task<ActionResult<ProjectAttachmentsDto>> GetProjectBasicDetailsForClientQuery([FromQuery] GetProjectBasicDetailsForFreelancerQuery query, Guid id)
        {
            query.ProjectId = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("{id}/details-for-client")] // for client
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectAttachmentsDto))]
        public async Task<ActionResult<ProjectAttachmentsDto>> GetProjects([FromQuery] GetProjectAttachmentsQuery query, Guid id)
        {
            query.ProjectId = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion
        #endregion

        #region Wishlist
        [HttpGet("wishlist")] // for freelancers
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectListDto>))]
        public async Task<ActionResult<PaginationResult<ProjectListDto>>> GetWishListProjects([FromQuery] GetProjectsQuery query)
        {
            query.ClientId = null;
            query.IsWishlist = true;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

        #region Proposals

        [HttpGet("freelancer/proposals")] // for freelancer to get all proposals freelancer
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProjectProposalsDto>))]
        public async Task<ActionResult<PaginationResult<ProjectProposalsDto>>> GetProposalsFreelancer([FromQuery] GetProposalsQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

        #region Client 
        [HttpGet("{id}/client/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProjectClientBasicDetailsDto))]
        public async Task<ActionResult<ProjectClientBasicDetailsDto>> GetProjectClientBasicDetails(Guid id)
        {
            return Ok(await Mediator.Send(new GetProjectClientBasicDetailsQuery { ProjectId = id }, CancellationToken));
        }
        [HttpGet("client")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ClientProjectsDto>))]
        public async Task<ActionResult<ProjectClientBasicDetailsDto>> GetClientProjectsQuery([FromQuery] GetClientProjectsQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

        [HttpGet("{id}/attachments")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ProjectAttachmentsDto>))]
        public async Task<ActionResult<List<ProjectAttachmentsDto>>> GetProjectAttachmentsQuery(Guid id)
        {
            return Ok(await Mediator.Send(new GetProjectAttachmentsQuery { ProjectId = id }, CancellationToken));
        }

        [HttpGet("{id}/client-proposals")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ClientProposalsListDto>))]
        public async Task<ActionResult<PaginationResult<ClientProposalsListDto>>> GetClientProposalsQuery([FromQuery] GetClientProposalsQuery query, Guid id)
        {
            query.ProjectId = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        #endregion

    }
}
