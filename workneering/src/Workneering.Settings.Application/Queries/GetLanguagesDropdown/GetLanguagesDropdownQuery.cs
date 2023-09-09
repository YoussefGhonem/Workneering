using MediatR;

namespace Workneering.Settings.Application.Queries.GetLanguagesDropdown;

public class GetLanguagesDropdownQuery : IRequest<List<LanguagesDropdownDto>>
{
}
