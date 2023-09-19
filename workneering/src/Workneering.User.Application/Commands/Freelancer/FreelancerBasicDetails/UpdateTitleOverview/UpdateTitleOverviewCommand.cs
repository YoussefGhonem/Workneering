using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitleOverview;

public class UpdateTitleOverviewCommand : IRequest
{
    public string TitleOverview { get; set; }
}
