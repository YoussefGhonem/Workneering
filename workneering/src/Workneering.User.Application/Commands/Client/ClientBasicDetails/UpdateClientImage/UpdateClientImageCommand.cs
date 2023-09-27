using MediatR;
using Microsoft.AspNetCore.Http;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientImage
{
    public class UpdateClientImageCommand : IRequest<Unit>
    {
        public IFormFile Image { get; set; }

    }
}
