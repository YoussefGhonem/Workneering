using MediatR;
using Microsoft.AspNetCore.Http;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateClientImage
{
    public class UpdateFreelancerImageCommand : IRequest<Unit>
    {
        public IFormFile Image { get; set; }

    }
}
