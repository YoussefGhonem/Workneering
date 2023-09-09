using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetLanguages;

public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<GetLanguagesDto>>
{
    private readonly SettingsDbContext _context;

    public GetLanguagesQueryHandler(SettingsDbContext context)
    {
        _context=context;
    }

    public async Task<List<GetLanguagesDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
    {
        var languages = await _context.Languages.AsNoTracking().ToListAsync(cancellationToken);

        var dataList = languages.Adapt<List<GetLanguagesDto>>();

        return dataList;
    }
}
