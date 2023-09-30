using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetPrimaryIndustry
{
    internal class GetPrimaryIndustryQueryHandler : IRequestHandler<GetPrimaryIndustryQuery, List<PrimaryIndustryDto>>
    {
        private readonly SettingsDbContext _context;

        public GetPrimaryIndustryQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrimaryIndustryDto>> Handle(GetPrimaryIndustryQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Industries.AsNoTracking().ToListAsync(cancellationToken);

            var dataList = list.Adapt<List<PrimaryIndustryDto>>();

            return dataList;
        }
    }
}
