using MediatR;
using Mapster;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Base.Application.GlobalExceptions;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.Shared.Core.Identity.CurrentUser;

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
            if (_userDatabaseContext.Companies.Any(x => x.Id != CurrentUser.Id)) return new CompanyBasicDetailsDto();

            var query = _userDatabaseContext.Companies
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            var userservice = await _dbQueryService.GetUserBasicInfo(CurrentUser.Id.Value, cancellationToken);
            var countruservice = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);

            var result = query?.Adapt<CompanyBasicDetailsDto>();
            result.Location.Id = countruservice.Id;
            result.Location.Name = countruservice?.Name;
            result.Location.Language = countruservice?.Language;
            result.Location.Flag = countruservice?.Flag;
            result.Location.City = countruservice?.City;
            result.Location.ZipCode = countruservice?.ZipCode;

            return result;
        }
    }
}
