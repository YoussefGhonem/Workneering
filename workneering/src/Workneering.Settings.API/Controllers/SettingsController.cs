using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Workneering.Base.API.Controllers;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.Settings.Application.Queries.GetCountries;
using Workneering.Settings.Application.Queries.GetCountriesDropdown;


namespace Workneering.Settings.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SettingsController : BaseController
    {
        public SettingsController(ISender mediator) : base(mediator)
        {
        }



        #region Queries





        /// <summary>
        /// Get settings
        /// </summary>
        /// <returns>Return info of settings</returns>
        [HttpGet("countries/dropdown")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CountriesDropdownDto>))]
        public async Task<ActionResult<List<CountriesDropdownDto>>> GetCountriesDropdown()
        {
            return Ok(await Mediator.Send(new GetCountriesDropdownQuery(), CancellationToken));
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

        #endregion



    }
}