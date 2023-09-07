using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Base.Helpers.Extensions;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetSubCategories
{
    public class GetSubCategoriesQueryHandler : IRequestHandler<GetSubCategoriesQuery, List<SubCategoriesDrp>>
    {
        private readonly SettingsDbContext _context;

        public GetSubCategoriesQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoriesDrp>> Handle(GetSubCategoriesQuery request,
            CancellationToken cancellationToken)
        {

            var query = await _context.Categories
                  .Include(x => x.SubCategories)
                  .Where(x => request.CategoryIds.AsNotNull().Contains(x.Id))
                  .AsNoTracking()
                  .SelectMany(x => x.SubCategories)
                  .ToListAsync(cancellationToken: cancellationToken);

            var data = query.Adapt<List<SubCategoriesDrp>>();
            return data;
        }
    }
}