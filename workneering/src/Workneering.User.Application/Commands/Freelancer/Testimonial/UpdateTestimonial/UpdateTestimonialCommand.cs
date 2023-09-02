using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.UpdateTestimonial
{
    public class UpdateTestimonialCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessEmail { get; set; }
        public string LinkedInProfile { get; set; }
        public string ClientTitle { get; set; }
        public string? ProjectType { get; set; }
        public string MessageToClient { get; set; }
    }
}
