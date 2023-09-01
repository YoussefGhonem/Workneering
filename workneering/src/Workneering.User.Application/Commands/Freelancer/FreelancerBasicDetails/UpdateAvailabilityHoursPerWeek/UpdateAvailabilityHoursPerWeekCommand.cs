using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailabilityHoursPerWeek
{
    public class UpdateAvailabilityHoursPerWeekCommand : IRequest<Unit>
    {
        public HoursPerWeekEnum? HoursPerWeek { get; set; }
        public DateTimeOffset? DateForNewWork { get; set; } // if Hours Per Week is None
        public bool? ContractToHire { get; set; } = false;

    }
}
