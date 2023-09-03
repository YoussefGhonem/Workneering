using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetLanguages
{
    public class GetLanguagesQueryHandler : IRequestHandler<GetLanguagesQuery, List<LanguagesListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetLanguagesQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<LanguagesListDto>> Handle(GetLanguagesQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return new List<LanguagesListDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Categories).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = query!.Categories.Adapt<List<LanguagesListDto>>();
            return result;
        }
    }
}
