using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyBasicDetails;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyDescription;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhoAreWe;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateOverviewDescription;
using Workneering.User.Application.Queries.Company.GetCompanyBasicDetails;

namespace Workneering.User.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/companies")]
    public class CompaniesController : BaseController
    {
        public CompaniesController(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [HttpPut("profile/description")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCompanyDescriptionCommand(UpdateCompanyDescriptionCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCompanyBasicDetailsCommand(UpdateCompanyBasicDetailsCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/who-are-we")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateWhoAreWeCommand(UpdateWhoAreWeCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region Queries
        [HttpGet("profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyBasicDetailsDto))]
        public async Task<ActionResult<CompanyBasicDetailsDto>> GetCompanyBasicDetailsQuery()
        {
            var query = new GetCompanyBasicDetailsQuery();
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        #endregion

    }
}