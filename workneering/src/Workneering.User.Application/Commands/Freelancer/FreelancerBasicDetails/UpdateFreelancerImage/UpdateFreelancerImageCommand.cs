using MediatR;
using Microsoft.AspNetCore.Http;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateFreelancerImage
{
    public class UpdateFreelancerImageCommand : IRequest<Unit>
    {
        public IFormFile Image { get; set; }

    }
}
