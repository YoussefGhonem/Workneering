using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetLanguagesDropdown;

internal sealed class GetLanguagesDropdownQueryHandler :
    IRequestHandler<GetLanguagesDropdownQuery, List<LanguagesDropdownDto>>
{
    private readonly SettingsDbContext _context;

    public GetLanguagesDropdownQueryHandler(SettingsDbContext context)
    {
        _context = context;
    }
    public async Task<List<LanguagesDropdownDto>> Handle(GetLanguagesDropdownQuery request, CancellationToken cancellationToken)
    {
        var languagesDto = await _context.Languages
              .AsNoTracking()
              .Select(x => new LanguagesDropdownDto(x.Id, x.Code, x.Name, x.Name))
              .ToListAsync(cancellationToken: cancellationToken);

        return languagesDto;
    }
}
