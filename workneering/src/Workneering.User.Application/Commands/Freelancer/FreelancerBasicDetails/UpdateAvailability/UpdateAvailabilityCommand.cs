using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateAvailability
{
    public class UpdateAvailabilityCommand : IRequest<Unit>
    {
        public int Availability { get; set; }

    }
}
