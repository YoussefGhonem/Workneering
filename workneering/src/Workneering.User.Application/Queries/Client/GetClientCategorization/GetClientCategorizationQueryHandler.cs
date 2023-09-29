using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Client.GetClientCategorization
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetClientCategorizationQuery, ClientCategorizationDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<ClientCategorizationDto> Handle(GetClientCategorizationQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Clients
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == request.ClientId);

            var userservice = await _dbQueryService.GetUserBasicInfo(request.ClientId, cancellationToken);
            //var result = query?.Adapt<ClientCategorizationDto>();
            //result.Categories = query!.Categories.Select(x => x.CategoryId).ToList();
            //result.SubCategoryIds = query!.SubCategories.Select(x => x.SubCategoryId).ToList();
            //result.SkillIds = query!.Skills.Select(x => x.SkillId).ToList();

            var result = await _dbQueryService.GetCategorizationAsync(query!.Categories.Select(x => x.CategoryId),
            query!.SubCategories.Select(x => x.SubCategoryId),
            query!.Skills.Select(x => x.SkillId), cancellationToken);
            var returnvalue = result?.Adapt<ClientCategorizationDto>();

            return returnvalue;
        }
    }
}
