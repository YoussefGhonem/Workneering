using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Project.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.Project.Application.Commands.Wishlist.RemoveWishlist
{
    public class GetFreelancerEducationDetailsQueryHandler : IRequestHandler<RemoveWishlistCommand, Unit>
    {
        private readonly ProjectsDbContext _context;

        public GetFreelancerEducationDetailsQueryHandler(ProjectsDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(RemoveWishlistCommand request, CancellationToken cancellationToken)
        {
            var query = _context.Projects
                .Include(x => x.Wishlist)
                .FirstOrDefault(x => x.Id == request.ProjectId);

            query.RemoveFromWishlist(CurrentUser.Id);
            _context.Projects.Attach(query);
            _context?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
