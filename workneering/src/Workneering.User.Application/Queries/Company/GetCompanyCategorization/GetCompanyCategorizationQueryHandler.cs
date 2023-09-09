using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Queries.Company.GetCompanyBasicDetails;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Company.GetCompanyCategorization
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCompanyCategorizationQuery, CategorizationDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<CategorizationDto> Handle(GetCompanyCategorizationQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Companies
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == request.CompanyId);

           var result =  await _dbQueryService.GetCategorizationAsync(query!.Categories.Select(x => x.CategoryId),
                 query!.SubCategories.Select(x => x.SubCategoryId),
                 query!.Skills.Select(x => x.SkillId), cancellationToken);
          
            return result;
        }
    }
}
