using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetCategories
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoriesDrp>>
    {
        private readonly SettingsDbContext _context;

        public GetCategoriesQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriesDrp>> Handle(GetCategoriesQuery request,
            CancellationToken cancellationToken)
        {
            var setting = await _context.Categories
                  .AsNoTracking()
                  .ToListAsync(cancellationToken: cancellationToken);

            var data = setting.Adapt<List<CategoriesDrp>>();
            return data;
        }
    }
}