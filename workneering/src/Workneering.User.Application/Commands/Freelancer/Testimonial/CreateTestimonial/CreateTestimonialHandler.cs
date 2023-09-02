using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.CreateTestimonial
{
    public class CreateTestimonialHandler : IRequestHandler<CreateTestimonialCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateTestimonialHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Testimonials).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Testimonial>();
            query!.AddTestimonial(result);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);

            // send mail for client
            return Unit.Value;
        }
    }
}
