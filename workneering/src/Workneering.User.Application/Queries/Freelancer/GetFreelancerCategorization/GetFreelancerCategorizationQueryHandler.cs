using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategorization
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerCategorizationnQuery, FreelancerCategorizationDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<FreelancerCategorizationDto> Handle(GetFreelancerCategorizationnQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == request.FreelancerId);

            var result = query?.Adapt<FreelancerCategorizationDto>();
            result.CategoryIds = query!.Categories.Select(x => x.CategoryId).ToList();
            result.SubCategoryIds = query!.SubCategories.Select(x => x.SubCategoryId).ToList();
            result.SkillIds = query!.Skills.Select(x => x.SkillId).ToList();

            return result;
        }
    }
}
