using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateHourlyRate
{
    public class UpdateHourlyRateCommand : IRequest<Unit>
    {
        public decimal HourlyRate { get; set; }

    }
}
