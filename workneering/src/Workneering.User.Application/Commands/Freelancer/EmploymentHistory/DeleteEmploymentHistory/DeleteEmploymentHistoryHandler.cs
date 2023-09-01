using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.DeleteEmploymentHistory
{
    public class DeleteEmploymentHistoryHandler : IRequestHandler<DeleteEmploymentHistoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteEmploymentHistoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.EmploymentHistory).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveEmploymentHistory(request.EmploymentHistoryId);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
