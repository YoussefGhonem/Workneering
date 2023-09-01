using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitle
{
    public class UpdateFreelancerTitleCommand : IRequest<Unit>
    {

        public string Title { get; set; }

    }
}
