using Mapster;
using MediatR;
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
            result.CategoryId = query!.Categories?.FirstOrDefault()?.CategoryId;
            // Country Info
            if (userservice.CountryId != Guid.Empty && userservice.CountryId != null)
            {
                var countryInfo = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);
                var id = countryInfo?.Id;
                result.Location.Id = id;
                result.Location.Name = countryInfo?.Name;
                result.Location.Flag = countryInfo?.Flag;

            }
            // Address Info
            var userAddress = await _dbQueryService.GetAddressUser(request.CompanyId, cancellationToken);
            result.Address.Address = userAddress?.Address;
            result.Address.City = userAddress?.City;
            result.Address.ZipCode = userAddress?.ZipCode;

            return result;
        }
    }
}
