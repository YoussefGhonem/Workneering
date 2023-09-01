using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerEducationDetailsQuery, EducationDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<EducationDetailsDto> Handle(GetFreelancerEducationDetailsQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new EducationDetailsDto();

            var query = _userDatabaseContext.Freelancers.FirstOrDefault(x => x.Id == request.Id);
            var result = query.Adapt<EducationDetailsDto>();
            return result;
        }
    }
}
