using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerBasicDetailsQuery, FreelancerBasicDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<FreelancerBasicDetailsDto> Handle(GetFreelancerBasicDetailsQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new FreelancerBasicDetailsDto();

            var query = _userDatabaseContext.Freelancers
                .Include(x => x.Languages)
                .Include(x => x.Certifications)
                .FirstOrDefault(x => x.Id == request.Id);

            var userservice = await _dbQueryService.GetUserBasicInfo(CurrentUser.Id.Value, cancellationToken);
            var countruservice = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);

            var result = query?.Adapt<FreelancerBasicDetailsDto>();
            result.NumberOfCertification = query?.Certifications.Count();
            result.NumberOfLanguages = query?.Languages.Count();
            result.LocationFlag = countruservice?.Flag;

            return result;
        }
    }
}
