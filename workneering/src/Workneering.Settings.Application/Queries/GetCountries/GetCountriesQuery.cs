using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Settings.Application.Queries.GetCountries
{
    public class GetCountriesQuery : BaseFilterDto, IRequest<PaginationResult<CountriesDto>>
    {
        public string? Name { get; set; }
        public bool? IsActive { get; set; }
    }
}