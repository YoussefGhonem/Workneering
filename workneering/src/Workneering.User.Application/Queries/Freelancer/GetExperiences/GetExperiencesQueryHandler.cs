using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetExperiences
{
    public class GetExperiencesQueryHandler : IRequestHandler<GetExperiencesQuery, List<FreelancerExperienceDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetExperiencesQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<FreelancerExperienceDto>> Handle(GetExperiencesQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new List<FreelancerExperienceDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Experiences).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.Experiences.Adapt<List<FreelancerExperienceDto>>();
            return result;
        }
    }
}
