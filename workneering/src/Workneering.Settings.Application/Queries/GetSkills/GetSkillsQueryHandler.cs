using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workneering.Base.Helpers.Extensions;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetSkills
{
    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, List<SkillsDrp>>
    {
        private readonly SettingsDbContext _context;

        public GetSkillsQueryHandler(SettingsDbContext context)
        {
            _context = context;
        }

        public async Task<List<SkillsDrp>> Handle(GetSkillsQuery request,
            CancellationToken cancellationToken)
        {
            var query = await _context.Categories
                  .Include(x => x.SubCategories)
                  .ThenInclude(x => x.Skills)
                  .Where(x => x.SubCategories.Any(y => request.SubCategoryIds.AsNotNull().Contains(y.Id)))
                  .AsNoTracking()
                  .SelectMany(x => x.SubCategories.SelectMany(x => x.Skills))
                  .ToListAsync(cancellationToken: cancellationToken);

            var data = query.Adapt<List<SkillsDrp>>();
            return data;
        }
    }
}