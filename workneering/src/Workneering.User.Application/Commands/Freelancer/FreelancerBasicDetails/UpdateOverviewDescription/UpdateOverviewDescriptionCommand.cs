using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateOverviewDescription
{
    public class UpdateOverviewDescriptionCommand : IRequest<Unit>
    {
        public string OverviewDescription { get; set; }

    }
}
