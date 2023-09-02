using MediatR;
using System.Text.Json.Serialization;
using Workneering.Shared.Core.Models;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.ReplyTestimonial
{
    public class ReplyTestimonialCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string ReplyMessage { get; set; }

    }
}
