using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateYearsOfExperience
{
    public class UpdateYearsOfExperienceCommand : IRequest<Unit>
    {
        public decimal YearsOfExperience { get; set; }
    }
}
