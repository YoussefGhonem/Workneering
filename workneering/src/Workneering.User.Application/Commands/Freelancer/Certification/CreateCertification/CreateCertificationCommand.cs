using MediatR;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Certification.CreateCertification
{
    public class CreateCertificationCommand : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PassedDate { get; set; }
    }
}
