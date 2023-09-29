using Mapster;
using MediatR;
using Workneering.Base.Helpers.Extensions;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetFreelancerBasicDetailsQuery, FreelancerBasicDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext,
            IDbQueryService dbQueryService, IStorageService storageService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
            _storageService = storageService;
        }
        public async Task<FreelancerBasicDetailsDto> Handle(GetFreelancerBasicDetailsQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.FirstOrDefault(x => x.Id == request.FreelancerId);

            var userservice = await _dbQueryService.GetUserBasicInfo(request.FreelancerId, cancellationToken);

            var result = query?.Adapt<FreelancerBasicDetailsDto>();
            // Country Info
            if (userservice.CountryId != Guid.Empty && userservice.CountryId != null)
            {
                var countruservice = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);
                result.Location.Id = countruservice?.Id;
                result.Location.Name = countruservice?.Name;
                result.Location.Flag = countruservice?.Flag;
            }
            // Address Info
            var userAddress = await _dbQueryService.GetAddressUser(request.FreelancerId, cancellationToken);
            result.Address.Address = userAddress?.Address;
            result.Address.City = userAddress?.City;
            result.Address.ZipCode = userAddress?.ZipCode;
            var storedFiles = await _storageService.DownloadFileUrl(query!.ImageDetails?.Key);
            result.ImageUrl = storedFiles;
            return result;
        }
    }
}
