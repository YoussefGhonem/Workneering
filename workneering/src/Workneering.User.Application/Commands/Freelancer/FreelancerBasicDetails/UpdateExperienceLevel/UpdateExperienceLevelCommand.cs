using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateExperienceLevel
{
    public class UpdateExperienceLevelCommand : IRequest<Unit>
    {
        public ExperienceLevelEnum ExperienceLevel { get; set; }

    }
}
