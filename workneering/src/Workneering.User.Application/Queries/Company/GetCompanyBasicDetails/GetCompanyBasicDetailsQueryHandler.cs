using Mapster;
using MediatR;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Settings.Application.Queries.GetPrimaryIndustry;
using Workneering.User.Application.Commands.CreateUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Company.GetCompanyBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetCompanyBasicDetailsQuery, CompanyBasicDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;
        private readonly IStorageService _storageService;
        private readonly IMediator _mediator;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext,
            IDbQueryService dbQueryService, IStorageService storageService, IMediator mediator)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
            _storageService = storageService;
            _mediator = mediator;
        }
        public async Task<CompanyBasicDetailsDto> Handle(GetCompanyBasicDetailsQuery request, CancellationToken cancellationToken)
        {
            var Inds = new List<PrimaryIndustryDto>();
            var query = _userDatabaseContext.Companies.FirstOrDefault(x => x.Id == request.CompanyId);
            var userservice = await _dbQueryService.GetUserBasicInfo(request.CompanyId, cancellationToken);

            if (query!.IndustryId != null)
            {
                var command = new GetPrimaryIndustryQuery();
                Inds = await _mediator.Send(command, cancellationToken);
            }
            

            var result = query?.Adapt<CompanyBasicDetailsDto>();
            result.CategoryId = query!.Categories?.FirstOrDefault()?.CategoryId;
            if (query!.IndustryId != null)
            { 
                result.IndustryName = Inds!.First(x => x.Id == query!.IndustryId).Name;
            }else
            {
                result.IndustryName = "";
            }
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
            var storedFiles = await _storageService.DownloadFileUrl(query!.ImageDetails?.Key);
            result.ImageUrl = storedFiles;
            return result;
        }
    }
}
