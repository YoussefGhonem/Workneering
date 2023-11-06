using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.UpdateEmploymentHistory
{
    public class UpdateEmploymentHistoryHandler : IRequestHandler<UpdateEmploymentHistoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateEmploymentHistoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.EmploymentHistory).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.EmploymentHistory>();

            query.UpdateEmploymentHistory(request.Id, result);
            _userDatabaseContext.Freelancers.Attach(query);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
