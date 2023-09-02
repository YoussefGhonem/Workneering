using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.DeleteTestimonial
{
    public class DeleteTestimonialHandler : IRequestHandler<DeleteTestimonialCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteTestimonialHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Testimonials).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveTestimonial(request.Id);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
