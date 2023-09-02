using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Testimonial.ReplyTestimonial
{
    public class ReplyTestimonialHandler : IRequestHandler<ReplyTestimonialCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public ReplyTestimonialHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(ReplyTestimonialCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Testimonials).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.UpdateTestimonialReplyClient(request.Id, request.ReplyMessage);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            // send mail to freelancer
            return Unit.Value;
        }
    }
}
