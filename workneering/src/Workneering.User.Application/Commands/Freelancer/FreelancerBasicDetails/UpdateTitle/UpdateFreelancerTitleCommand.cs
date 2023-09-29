using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateTitle
{
    public class UpdateFreelancerTitleCommand : IRequest<Unit>
    {

        public string Title { get; set; }

    }
}
