using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVideoIntroduction
{
    public class UpdateVideoIntroductionCommand : IRequest<Unit>
    {
        public string VideoIntroductionLinkYoutube { get; set; }
        public TypeOfVideoEnum VideoIntroductionTypeOfVideo { get; set; }

    }
}
