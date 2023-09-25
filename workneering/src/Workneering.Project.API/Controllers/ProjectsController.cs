using MediatR;
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
using Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForClient;
using Workneering.Project.Application.Queries.Project.ProjectDetails.GetProjectBasicDetailsForFreelancer;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetProjectClientBasicDetails;
using Workneering.Project.Application.Queries.Proposal.GetProposals;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProjects;

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

        #region Queries

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProjectBasicDetailsForClientDto))]
        public async Task<ActionResult<GetProjectBasicDetailsForClientDto>> GetProjectBasicDetailsForClientQuery([FromQuery] GetProjectBasicDetailsForFreelancerQuery query, Guid id)
        {
            query.ProjectId = id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("{id}/details-for-client")] // for client
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetProjectBasicDetailsForClientDto))]
        public async Task<ActionResult<GetProjectBasicDetailsForClientDto>> GetProjects([FromQuery] GetProjectBasicDetailsForClientQuery query, Guid id)
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
        [HttpGet("{id}/proposals")] // for clients to get project proposals
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProposalsDto>))]
        public async Task<ActionResult<PaginationResult<ProposalsDto>>> GetProposals([FromQuery] GetProposalsQuery query, Guid id)
        {
            query.ProjectId = id;
            query.ClientId = null;
            query.FreelancerId = null;
            return Ok(await Mediator.Send(query, CancellationToken));
        }


        [HttpGet("proposals")] // for clients to get project proposals
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProposalsDto>))]
        public async Task<ActionResult<PaginationResult<ProposalsDto>>> GetProposals([FromQuery] GetProposalsQuery query)
        {
            query.FreelancerId = null;
            query.ProjectId = null;
            query.ClientId = CurrentUser.Id;
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("proposals/freelancer")] // for freelancer to get all proposals freelancer
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<ProposalsDto>))]
        public async Task<ActionResult<PaginationResult<ProposalsDto>>> GetProposalsFreelancer([FromQuery] GetProposalsQuery query)
        {
            query.FreelancerId = CurrentUser.Id;
            query.ProjectId = null;
            query.ClientId = null;
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
        #endregion

    }
}
