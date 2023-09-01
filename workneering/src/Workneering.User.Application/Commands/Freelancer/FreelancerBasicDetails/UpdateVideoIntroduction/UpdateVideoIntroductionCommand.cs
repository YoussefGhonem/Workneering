using MediatR;
using Workneering.User.Domain.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateVideoIntroduction
{
    public class UpdateVideoIntroductionCommand : IRequest<Unit>
    {
        public string? LinkYoutube { get; set; }
        public TypeOfVideoEnum? TypeOfVideo { get; set; }

    }
}
