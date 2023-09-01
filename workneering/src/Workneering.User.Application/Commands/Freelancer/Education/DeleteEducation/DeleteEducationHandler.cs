using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Education.DeleteEducation
{
    public class DeleteEducationHandler : IRequestHandler<DeleteEducationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteEducationHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveEducation(request.Id);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
