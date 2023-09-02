using MediatR;
using System.Text.Json.Serialization;

namespace Workneering.User.Application.Commands.Freelancer.Certification.DeleteCertification
{
    public class DeleteCertificationCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
