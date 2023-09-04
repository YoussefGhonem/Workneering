using MediatR;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateCountry
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateCountryCommand, Unit>
    {
        private readonly IDbQueryService _dbQueryService;

        public GetFreelancerEducationDetailsQueryHandler(IDbQueryService dbQueryService)
        {
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            await _dbQueryService!.UpdateCountryUser(CurrentUser.Id!.Value, request.CountryId, cancellationToken);

            return Unit.Value;
        }
    }
}
