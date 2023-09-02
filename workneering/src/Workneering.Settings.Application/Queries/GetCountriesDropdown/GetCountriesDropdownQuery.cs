using MediatR;

namespace Workneering.Settings.Application.Queries.GetCountriesDropdown
{
    public class GetCountriesDropdownQuery : IRequest<List<CountriesDropdownDto>>
    {
    }
}