using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetEducations
{
    public class GetEducationsQueryHandler : IRequestHandler<GetEducationsQuery, List<EducationListDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetEducationsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<EducationListDto>> Handle(GetEducationsQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == request.FreelancerId);
            var result = query!.Educations.Adapt<List<EducationListDto>>();
            return result;
        }
    }
}
