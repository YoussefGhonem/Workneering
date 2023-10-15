using Mapster;
using MediatR;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Packages.Storage.AWS3.Services;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Queries.GetProfileDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProfileDetailsQuery, GetProfileDetailsDto>
    {
        private readonly IdentityDatabaseContext _identityDatabase;
        private readonly IStorageService _storageService;

        public GetFreelancerEducationDetailsQueryHandler(IdentityDatabaseContext userDatabaseContext, IStorageService storageService)
        {
            _identityDatabase = userDatabaseContext;
            _storageService = storageService;
        }
        public async Task<GetProfileDetailsDto> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            var id = CurrentUser.Id;
            var query = _identityDatabase.Users.FirstOrDefault(x => x.Id == CurrentUser.Id);
            if (query is null)
            {
               return new GetProfileDetailsDto();
            }

            var result = query?.Adapt<GetProfileDetailsDto>();
            return result;
        }
    }
}
