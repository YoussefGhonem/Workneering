using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetCountriesDropdown
{
    public class
        GetCountriesDropdownQueryHandler : IRequestHandler<GetCountriesDropdownQuery, List<CountriesDropdownDto>>
    {
        private readonly SettingsDbContext _context;

        public GetCountriesDropdownQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountriesDropdownDto>> Handle(GetCountriesDropdownQuery request,
            CancellationToken cancellationToken)
        {
            var setting = await _context.Countries
                .AsNoTracking()
                .ToListAsync(cancellationToken: cancellationToken);

            var countriesDto = setting.Adapt<List<CountriesDropdownDto>>();
            return countriesDto;
        }
    }
}