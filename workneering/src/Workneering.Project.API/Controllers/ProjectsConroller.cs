using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Project.Application.Commands.CreateProject;

namespace Workneering.Project.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/projects")]
    public class ProjectsConroller : BaseController
    {
        public ProjectsConroller(ISender mediator) : base(mediator)
        {
        }

        #region Commands
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateProjectCommand(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion
    }
}
