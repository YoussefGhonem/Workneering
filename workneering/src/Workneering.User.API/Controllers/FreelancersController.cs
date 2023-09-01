using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Commands.Freelancer.Category.CreateCategory;
using Workneering.User.Application.Commands.Freelancer.Category.DeleteCategory;
using Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory;
using Workneering.User.Application.Commands.Freelancer.Education.CreateEducation;
using Workneering.User.Application.Commands.Freelancer.Education.DeleteEducation;
using Workneering.User.Application.Commands.Freelancer.Education.UpdateEducation;
using Workneering.User.Application.Commands.Freelancer.EmploymentHistory.CreateEmploymentHistory;
using Workneering.User.Application.Commands.Freelancer.EmploymentHistory.DeleteEmploymentHistory;
using Workneering.User.Application.Commands.Freelancer.EmploymentHistory.UpdateEmploymentHistory;
using Workneering.User.Application.Commands.Freelancer.Experiences.CreateExperience;
using Workneering.User.Application.Commands.Freelancer.Experiences.DeleteExperiences;
using Workneering.User.Application.Commands.Freelancer.Experiences.UpdateExperiences;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailabilityHoursPerWeek;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateExperienceLevel;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateHourlyRate;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateOverviewDescription;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitle;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVideoIntroduction;
using Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVisibility;
using Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory;
using Workneering.User.Application.Queries.Freelancer.GetExperiences;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories;
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

        #region Update Basic Details
        [HttpPut("profile/availability")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateAvailabilityHoursPerWeekCommand(UpdateAvailabilityHoursPerWeekCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/experience-level")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateExperienceLevelCommand(UpdateExperienceLevelCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/hourly-rate")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateHourlyRateCommand(UpdateHourlyRateCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/description")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateOverviewDescriptionCommand(UpdateOverviewDescriptionCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/title")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateFreelancerTitleCommand(UpdateFreelancerTitleCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        [HttpPut("profile/video-introduction")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateVideoIntroductionCommand(UpdateVideoIntroductionCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("profile/visibility")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateVisibilityCommand(UpdateVisibilityCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion

        #region employment-history
        [HttpPost("{id}/profile/employment-history")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateEmploymentHistoryCommand(CreateEmploymentHistoryCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/employment-history")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateEmploymentHistoryCommand(UpdateEmploymentHistoryCommand command, Guid id)
        {
            command.EmploymentHistoryId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/employment-history")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteEmploymentHistoryCommand(DeleteEmploymentHistoryCommand command, Guid id)
        {
            command.EmploymentHistoryId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region Experience

        [HttpPost("profile/experiences")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateExperienceCommand(CreateExperienceCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/experiences")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateExperienceCommand(UpdateExperienceCommand command, Guid id)
        {
            command.ExperienceId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/experiences")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteExperienceCommand(DeleteExperiencesCommand command, Guid id)
        {
            command.ExperienceId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region Category

        [HttpPost("profile/categories")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateExperienceCommand(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/categories")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCategoryCommand(UpdateCategoryCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/categories")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteCategoryCommand(DeleteCategoryCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region Education

        [HttpPost("profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateEducationCommand(CreateEducationCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/educations")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateEducationCommand(UpdateEducationCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/educations")] // id : EmploymentHistoryId
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteEducationCommand(DeleteEducationCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion


        #endregion

        #region Queries
        //[Authorize]
        [HttpGet("profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FreelancerBasicDetailsDto))]
        public async Task<ActionResult<FreelancerBasicDetailsDto>> GetFreelancerBasicDetailsQuery()
        {
            var query = new GetFreelancerBasicDetailsQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EducationDetailsDto>))]
        public async Task<ActionResult<List<EducationDetailsDto>>> GetFreelancerEducationDetailsQuery()
        {
            var query = new GetFreelancerEducationDetailsQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("profile/portfolios")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerPortfolioDto>))]
        public async Task<ActionResult<List<FreelancerPortfolioDto>>> GetFreelancerPortfoliosQuery()
        {
            var query = new GetFreelancerPortfoliosQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("profile/skills")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerSkillDto>))]
        public async Task<ActionResult<List<FreelancerSkillDto>>> GetFreelancerSkillsQuery()
        {
            var query = new GetFreelancerSkillsQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("profile/employment-history")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmploymentHistoryDto>))]
        public async Task<ActionResult<List<EmploymentHistoryDto>>> GetEmploymentHistoryQuery()
        {
            var query = new GetEmploymentHistoryQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("profile/experiences")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerExperienceDto>))]
        public async Task<ActionResult<List<FreelancerExperienceDto>>> GetExperiencesQuery()
        {
            var query = new GetExperiencesQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("profile/categories")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerCategoryDto>))]
        public async Task<ActionResult<List<FreelancerCategoryDto>>> GetFreelancerCategoriesQuery()
        {
            var query = new GetFreelancerCategoriesQuery { Id = CurrentUser.Id!.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        #endregion
    }
}