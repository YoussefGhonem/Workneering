﻿using Mapster;
using MediatR;
using Workneering.User.Application.Queries.Company.GetCompanyBasicDetails;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Client.GetClientBasicDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetClientBasicDetailsQuery, ClientBasicDetailsDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<ClientBasicDetailsDto> Handle(GetClientBasicDetailsQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Clients.FirstOrDefault(x => x.Id == request.ClientId);

            var userservice = await _dbQueryService.GetUserBasicInfo(request.ClientId, cancellationToken);

            var result = query?.Adapt<ClientBasicDetailsDto>();
            result.CategoryId = query!.Categories?.FirstOrDefault()?.CategoryId;
            // Country Info
            if (userservice.CountryId != Guid.Empty && userservice.CountryId != null)
            {
                var countruservice = await _dbQueryService.GetCountryInfo(userservice.CountryId, cancellationToken);
                result.Location.Id = countruservice?.Id;
                result.Location.Name = countruservice?.Name;
                result.Location.Flag = countruservice?.Flag;
            }
            // Address Info
            var userAddress = await _dbQueryService.GetAddressUser(request.ClientId, cancellationToken);
            result.Address.Address = userAddress?.Address;
            result.Address.City = userAddress?.City;
            result.Address.ZipCode = userAddress?.ZipCode;

            return result;
        }
    }
}