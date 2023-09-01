using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.valueobjects;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailabilityHoursPerWeek
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<UpdateAvailabilityHoursPerWeekCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerEducationDetailsQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateAvailabilityHoursPerWeekCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;
            var query = await _userDatabaseContext.Freelancers.FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            var map = request.Adapt<Availability>();
            //query!.UpdateAvailability(request.HoursPerWeek, request.DateForNewWork, request.ContractToHire);
            query!.UpdateAvailability(map);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
