using Mapster;
using MediatR;
using Workneering.Identity.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Identity.Application.Queries.GetProfileDetails
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<GetProfileDetailsQuery, GetProfileDetailsDto>
    {
        private readonly IdentityDatabaseContext _identityDatabase;

        public GetFreelancerEducationDetailsQueryHandler(IdentityDatabaseContext userDatabaseContext)
        {
            _identityDatabase = userDatabaseContext;
        }
        public async Task<GetProfileDetailsDto> Handle(GetProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            if (_identityDatabase.Users.Any(x => x.Id != CurrentUser.Id)) return new GetProfileDetailsDto();

            var query = _identityDatabase.Users.FirstOrDefault(x => x.Id == CurrentUser.Id);

            var result = query?.Adapt<GetProfileDetailsDto>();

            string[] nameParts = query.Name.Split(' ');
            result.FirstName = nameParts[0];
            result.LastName = string.Join(" ", nameParts.Skip(1));
            return result;
        }
    }
}
