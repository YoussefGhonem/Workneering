using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetLanguages
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<LanguagesListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;
        public GetLanguagesQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<List<LanguagesListDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers
                .Include(x => x.Languages).FirstOrDefault(x => x.Id == request.FreelancerId);

            var languages = await _dbQueryService.GetLanguagesAsync(query.Languages.Select(x => x.Id).ToList());
            
            var result = query!.Languages.Adapt<List<LanguagesListDto>>();
            result.ForEach(r =>
            {
                r.Name = languages.Find(x => x.Id == r.Id)?.Name;
            });
            return result;
        }
    }
}
