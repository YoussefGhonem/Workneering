using MediatR;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.CreateTestimonial
{
    public class CreateTestimonialCommand : IRequest<Unit>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessEmail { get; set; }
        public string LinkedInProfile { get; set; }
        public string ClientTitle { get; set; }
        public string? ProjectType { get; set; }
        public string MessageToClient { get; set; }
    }
}
