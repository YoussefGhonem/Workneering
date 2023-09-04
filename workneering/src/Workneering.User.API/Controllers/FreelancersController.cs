﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Commands.Freelancer.Category.CreateCategory;
using Workneering.User.Application.Commands.Freelancer.Category.DeleteCategory;
using Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory;
using Workneering.User.Application.Commands.Freelancer.Certification.CreateCertification;
using Workneering.User.Application.Commands.Freelancer.Certification.DeleteCertification;
using Workneering.User.Application.Commands.Freelancer.Certification.UpdateCertification;
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
using Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage;
using Workneering.User.Application.Commands.Freelancer.Language.DeleteLanguage;
using Workneering.User.Application.Commands.Freelancer.Portfolio.CreatePortfolio;
using Workneering.User.Application.Commands.Freelancer.Portfolio.DeletePortfolio;
using Workneering.User.Application.Commands.Freelancer.Portfolio.UpdatePortfolio;
using Workneering.User.Application.Commands.Freelancer.Skills.UpdateFreelancerSkills;
using Workneering.User.Application.Queries.Freelancer.GetCertifications;
using Workneering.User.Application.Queries.Freelancer.GetEducations;
using Workneering.User.Application.Queries.Freelancer.GetEmploymentHistory;
using Workneering.User.Application.Queries.Freelancer.GetExperiences;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories;
using Workneering.User.Application.Queries.Freelancer.GetFreelancerSkills;
using Workneering.User.Application.Queries.Freelancer.GetLanguages;
using Workneering.User.Application.Queries.Freelancer.Portfolio.GetFreelancerPortfolios;
using Workneering.User.Application.Queries.Freelancer.Portfolio.GetPortfolioById;

namespace Workneering.User.API.Controllers
{
    [ApiVersion("1.0")]
    [Authorize]
    [Route("api/v{version:apiVersion}/freelancers")]
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
        [HttpPost("{id}/profile/employment-history")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateEmploymentHistoryCommand(CreateEmploymentHistoryCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/employment-history")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateEmploymentHistoryCommand(UpdateEmploymentHistoryCommand command, Guid id)
        {
            command.EmploymentHistoryId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/employment-history")]
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

        [HttpPut("{id}/profile/experiences")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateExperienceCommand(UpdateExperienceCommand command, Guid id)
        {
            command.ExperienceId = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/experiences")]
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

        [HttpPut("profile/categories/{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCategoryCommand(UpdateCategoryCommand command, Guid id)
        {
            command.CategoryId = id;
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

        [HttpPut("{id}/profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateEducationCommand(UpdateEducationCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/educations")]
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

        #region Portfolios

        [HttpPost("profile/portfolios")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreatePortfolioCommand(CreatePortfolioCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/portfolios")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateFreelancerPortfolioCommand(UpdateFreelancerPortfolioCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/portfolios")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeletePortfolioCommand(DeletePortfolioCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region skills

        [HttpPut("profile/skills")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateFreelancerSkillsCommand(UpdateFreelancerSkillsCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        #endregion



        #region Certifications

        [HttpPost("profile/certifications")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateCertificationCommand(CreateCertificationCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpPut("{id}/profile/certifications")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> UpdateCertificationCommand(UpdateCertificationCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }

        [HttpDelete("{id}/profile/certifications")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteCertificationCommand(DeleteCertificationCommand command, Guid id)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion

        #region Language

        [HttpPost("profile/languages")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> CreateLanguageCommand(CreateLanguageCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }


        [HttpDelete("profile/languages")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Unit))]
        public async Task<ActionResult<Unit>> DeleteLanguageCommand(DeleteLanguageCommand command)
        {
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
            var query = new GetFreelancerBasicDetailsQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("profile/certifications")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CertificationListDto>))]
        public async Task<ActionResult<List<CertificationListDto>>> GetCertificationsQuery()
        {
            var query = new GetCertificationsQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("profile/languages")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LanguagesListDto>))]
        public async Task<ActionResult<List<LanguagesListDto>>> GetLanguagesQuery()
        {
            var query = new GetLanguagesQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        //[Authorize]
        [HttpGet("profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EducationListDto>))]
        public async Task<ActionResult<List<EducationListDto>>> GetFreelancerEducationDetailsQuery()
        {
            var query = new GetEducationsQuery() { FreelancerId = CurrentUser.Id.Value };
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
            var query = new GetFreelancerPortfoliosQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("profile/portfolios/{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioDetailsDto))]
        public async Task<ActionResult<PortfolioDetailsDto>> GetPortfolioById(Guid id)
        {
            var query = new GetPortfolioByIdQuery() { Id = id, FreelancerId = CurrentUser.Id.Value };
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
            var query = new GetFreelancerSkillsQuery() { FreelancerId = CurrentUser.Id.Value };
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
            var query = new GetEmploymentHistoryQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("profile/experiences")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerExperienceDto>))]
        public async Task<ActionResult<List<FreelancerExperienceDto>>> GetExperiencesQuery()
        {
            var query = new GetExperiencesQuery() { FreelancerId = CurrentUser.Id.Value };
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
            var query = new GetFreelancerCategoriesQuery() { FreelancerId = CurrentUser.Id.Value };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        #endregion

        #region Queries profile by Id
        //[Authorize]
        [HttpGet("{id}/profile/basic-details")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FreelancerBasicDetailsDto))]
        public async Task<ActionResult<FreelancerBasicDetailsDto>> GetFreelancerBasicDetailsQuery(Guid id)
        {
            var query = new GetFreelancerBasicDetailsQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("{id}/profile/certifications")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CertificationListDto>))]
        public async Task<ActionResult<List<CertificationListDto>>> GetCertificationsQuery(Guid id)
        {
            var query = new GetCertificationsQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("{id}/profile/languages")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LanguagesListDto>))]
        public async Task<ActionResult<List<LanguagesListDto>>> GetLanguagesQuery(Guid id)
        {
            var query = new GetLanguagesQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        //[Authorize]
        [HttpGet("{id}/profile/educations")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EducationListDto>))]
        public async Task<ActionResult<List<EducationListDto>>> GetFreelancerEducationDetailsQuery(Guid id)
        {
            var query = new GetEducationsQuery() { FreelancerId = id };
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
            var query = new GetFreelancerPortfoliosQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        [HttpGet("{userId}/profile/portfolios/{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PortfolioDetailsDto))]
        public async Task<ActionResult<PortfolioDetailsDto>> GetPortfolioById(Guid id, Guid userId)
        {
            var query = new GetPortfolioByIdQuery() { Id = id, FreelancerId = userId };
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
            var query = new GetFreelancerSkillsQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("{id}/profile/employment-history")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmploymentHistoryDto>))]
        public async Task<ActionResult<List<EmploymentHistoryDto>>> GetEmploymentHistoryQuery(Guid id)
        {
            var query = new GetEmploymentHistoryQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("{id}/profile/experiences")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerExperienceDto>))]
        public async Task<ActionResult<List<FreelancerExperienceDto>>> GetExperiencesQuery(Guid id)
        {
            var query = new GetExperiencesQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        //[Authorize]
        [HttpGet("{id}/profile/categories")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<FreelancerCategoryDto>))]
        public async Task<ActionResult<List<FreelancerCategoryDto>>> GetFreelancerCategoriesQuery(Guid id)
        {
            var query = new GetFreelancerCategoriesQuery() { FreelancerId = id };
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        #endregion
    }
}