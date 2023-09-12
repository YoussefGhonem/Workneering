using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Settings.Application.Queries.GetCategories;
using Workneering.Settings.Application.Queries.GetCountries;
using Workneering.Settings.Application.Queries.GetCountriesDropdown;
using Workneering.Settings.Application.Queries.GetLanguages;
using Workneering.Settings.Application.Queries.GetPrimaryIndustry;
using Workneering.Settings.Application.Queries.GetLanguagesDropdown;
using Workneering.Settings.Application.Queries.GetSkills;
using Workneering.Settings.Application.Queries.GetSubCategories;

namespace Workneering.Settings.API.Controllers
{
    [ApiVersion("1.0")]
    //[Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SettingsController : BaseController
    {
        public SettingsController(ISender mediator) : base(mediator)
        {
        }

        #region Queries

        //[HttpGet("countries/dropdown")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountriesDropdownDto>))]
        //public async Task<ActionResult<List<CountriesDropdownDto>>> GetCountriesDropdown()
        //{
        //    return Ok(await Mediator.Send(new GetCountriesDropdownQuery(), CancellationToken));
        //}
        [HttpGet("languages/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<LanguagesDropdownDto>))]
        public async Task<ActionResult<List<LanguagesDropdownDto>>> GetLanguagesDropdown()
        {
            return Ok(await Mediator.Send(new GetLanguagesDropdownQuery(), CancellationToken));
        }
        [HttpGet("categories/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoriesDrp>))]
        public async Task<ActionResult<List<CategoriesDrp>>> GetCategoriesQuery()
        {
            return Ok(await Mediator.Send(new GetCategoriesQuery(), CancellationToken));
        }

        [HttpGet("subcategories/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoriesDrp>))]
        public async Task<ActionResult<List<SubCategoriesDrp>>> GetSubCategories([FromQuery] GetSubCategoriesQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }
        [HttpGet("skills/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<SkillsDrp>))]
        public async Task<ActionResult<List<SkillsDrp>>> GetSkills([FromQuery] GetSkillsQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }




        [HttpGet("timezone/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        public async Task<ActionResult<List<string>>> GetTimeZonesDropdown()
        {
            return Ok(TimeZoneInfo.GetSystemTimeZones().Select(x => x.Id).ToList());
        }

        /// <summary>
        /// Get settings
        /// </summary>
        /// <returns>Return info of settings</returns>
        //[Authorize(Roles = $"{Roles.SuperAdmin}, {Roles.LocalAdmin}")]
        [HttpGet("countries")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResult<CountriesDto>))]
        public async Task<ActionResult<Unit>> GetCountriesQuery([FromQuery] GetCountriesQuery query)
        {
            return Ok(await Mediator.Send(query, CancellationToken));
        }

        //[HttpGet("languages/dropdown")]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<string>))]
        //public async Task<ActionResult<List<GetLanguagesDto>>> GetLanguages()
        //{
        //    return Ok(await Mediator.Send(new GetLanguagesQuery(), CancellationToken));
        //}

        [HttpGet("industries/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PrimaryIndustryDto>))]
        public async Task<ActionResult<List<PrimaryIndustryDto>>> GetIndustriesDropdown()
        {
            return Ok(await Mediator.Send(new GetPrimaryIndustryQuery(), CancellationToken));
        }

        #endregion



    }
}