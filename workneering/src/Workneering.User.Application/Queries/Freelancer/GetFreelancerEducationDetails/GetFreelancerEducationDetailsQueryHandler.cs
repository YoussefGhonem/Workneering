using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerEducationDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerEducationDetailsQuery, List<EducationDetailsDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<EducationDetailsDto>> Handle(GetFreelancerEducationDetailsQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return new List<EducationDetailsDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = query!.Educations.Adapt<List<EducationDetailsDto>>();
            return result;
        }
    }
}
