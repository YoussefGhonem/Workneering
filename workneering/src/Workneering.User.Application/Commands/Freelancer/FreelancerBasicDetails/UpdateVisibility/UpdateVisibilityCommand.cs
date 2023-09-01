using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVisibility
{
    public class UpdateVisibilityCommand : IRequest<Unit>
    {
        public VisibilityEnum Visibility { get; set; }

    }
}
