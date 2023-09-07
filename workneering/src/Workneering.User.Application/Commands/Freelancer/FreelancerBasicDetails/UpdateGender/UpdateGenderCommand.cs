using MediatR;
using Workneering.Base.Helpers.Enums;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateGender;

public class UpdateGenderCommand : IRequest
{
    public GenderEnum Gender { get; set; }
}
