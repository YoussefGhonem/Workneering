using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyBasicDetails;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyCategorization;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyDescription;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyImage;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhatDoWeDo;
using Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateWhoAreWe;
using Workneering.User.Application.Queries.Client.GetClientBasicDetails;
using Workneering.User.Application.Queries.Company.GetCompanyBasicDetails;
using Workneering.User.Application.Queries.Company.GetCompanyCategorization;
using Workneering.User.Application.Queries.Company.GetImageUrl;

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
        [HttpPut("profile/image")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateClientImageCommand([FromForm] UpdateCompanyImageCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/description")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCompanyDescriptionCommand(UpdateCompanyDescriptionCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCompanyCategorizationCommand([FromBody] UpdateCompanyCategorizationCommand command)
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

        [HttpPut("profile/what-do-we-do")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateWhatDoWeDoCommand(UpdateWhatDoWeDoCommand command)
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
            var query = new GetCompanyBasicDetailsQuery() { CompanyId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("{id}/profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyBasicDetailsDto))]
        public async Task<ActionResult<CompanyBasicDetailsDto>> GetCompanyBasicDetailsQuery(Guid id)
        {
            var query = new GetCompanyBasicDetailsQuery() { CompanyId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("{id}/profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategorizationDto))]
        public async Task<ActionResult<CategorizationDto>> GetClientCategorizationQuery(Guid id)
        {
            var query = new GetCompanyCategorizationQuery() { CompanyId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("profile/categorization")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategorizationDto))]
        public async Task<ActionResult<CategorizationDto>> GetClientCategorizationQuery()
        {
            var query = new GetCompanyCategorizationQuery() { CompanyId = CurrentUser.Id.Value };
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