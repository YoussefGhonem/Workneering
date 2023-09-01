using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerPortfolios;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerSkills;

namespace Workneering.User.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FreelancersController : BaseController
    {
        public FreelancersController(ISender mediator) : base(mediator)
        {
        }

        #region Commands

        //[Authorize]
        //[HttpPut("change-password")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        //public async Task<ActionResult<Unit>> ChangeMyPassword(ChangePasswordCommand command)
        //{
        //    command.UserId = CurrentUser.Id ?? Guid.Empty;
        //    return Ok(await Mediator.Send(command, CancellationToken));
        //}

        #endregion

        #region Queries
        //[Authorize]
        [HttpGet("{id}/profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FreelancerBasicDetailsDto))]
        public async Task<ActionResult<FreelancerBasicDetailsDto>> GetFreelancerBasicDetailsQuery(Guid id)
        {
            var query = new GetFreelancerBasicDetailsQuery { Id = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("{id}/profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EducationDetailsDto>))]
        public async Task<ActionResult<List<EducationDetailsDto>>> GetFreelancerEducationDetailsQuery(Guid id)
        {
            var query = new GetFreelancerEducationDetailsQuery { Id = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("{id}/profile/portfolios")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerPortfolioDto>))]
        public async Task<ActionResult<List<FreelancerPortfolioDto>>> GetFreelancerPortfoliosQuery(Guid id)
        {
            var query = new GetFreelancerPortfoliosQuery { Id = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("{id}/profile/skills")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerSkillDto>))]
        public async Task<ActionResult<List<FreelancerSkillDto>>> GetFreelancerSkillsQuery(Guid id)
        {
            var query = new GetFreelancerSkillsQuery { Id = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        #endregion
    }
}