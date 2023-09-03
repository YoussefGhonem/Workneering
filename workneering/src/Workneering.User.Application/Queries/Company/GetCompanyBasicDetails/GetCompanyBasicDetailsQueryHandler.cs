using Mapster;
using MediatR;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Company.GetCompanyBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCompanyBasicDetailsQuery, CompanyBasicDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<CompanyBasicDetailsDto> Handle(GetCompanyBasicDetailsQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Companies.FirstOrDefault(x => x.Id == request.CompanyId);

            var userservice = await _dbQueryService.GetUserBasicInfo(request.CompanyId, cancellationToken);

            var result = query?.Adapt<CompanyBasicDetailsDto>();
            if (userservice.CountryId != Guid.Empty && userservice.CountryId != null)
            {
                var countruservice = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);
                result.Location.Id = countruservice.Id;
                result.Location.Name = countruservice?.Name;
                result.Location.Language = countruservice?.Language;
                result.Location.Flag = countruservice?.Flag;
                result.Location.City = countruservice?.City;
                result.Location.ZipCode = countruservice?.ZipCode;
            }

            return result;
        }
    }
}
