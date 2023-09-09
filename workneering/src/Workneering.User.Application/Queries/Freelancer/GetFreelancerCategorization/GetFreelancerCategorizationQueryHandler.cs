using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Queries.Company.GetCompanyCategorization;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategorization
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerCategorizationnQuery, CategorizationDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<CategorizationDto> Handle(GetFreelancerCategorizationnQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == request.FreelancerId);

            var result = await _dbQueryService.GetCategorizationAsync(query!.Categories.Select(x => x.CategoryId),
                            query!.SubCategories.Select(x => x.SubCategoryId),
                            query!.Skills.Select(x => x.SkillId), cancellationToken);
            return result;
        }
    }
}
