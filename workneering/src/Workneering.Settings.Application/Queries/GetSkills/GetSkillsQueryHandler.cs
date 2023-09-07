using Mapster;
using MediatR;
using Workneering.Settings.Application.Services.DbQueryService;
using Workneering.Settings.Infrastructure.Persistence;

namespace Workneering.Settings.Application.Queries.GetSkills
{
    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, List<SkillsDrp>>
    {
        private readonly SettingsDbContext _context;
        private readonly IDbQueryService _dbQueryService;

        public GetSkillsQueryHandler(SettingsDbContext context, IDbQueryService dbQueryService)
        {
            _context = context;
            _dbQueryService = dbQueryService;
        }

        public async Task<List<SkillsDrp>> Handle(GetSkillsQuery request,
            CancellationToken cancellationToken)
        {
            if (request.SubCategoryIds == null)
                return new List<SkillsDrp>();

            var query = _dbQueryService.GetSkillsBuSubCategoriesIds(request.SubCategoryIds);
            var data = query.Adapt<List<SkillsDrp>>();
            return data;
        }
    }
}