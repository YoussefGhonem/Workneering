using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerSkills
{
    public class GetFreelancerSkillsQueryHandler : IRequestHandler<GetFreelancerSkillsQuery, List<FreelancerSkillDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerSkillsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<FreelancerSkillDto>> Handle(GetFreelancerSkillsQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return new List<FreelancerSkillDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.FreelancerSkills).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = query!.FreelancerSkills.Adapt<List<FreelancerSkillDto>>();
            return result;
        }
    }
}
