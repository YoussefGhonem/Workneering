using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;
using Workneering.Shared.Core.Identity.CurrentUser;

namespace Workneering.User.Application.Commands.Freelancer.EmploymentHistory.CreateEmploymentHistory
{
    public class CreateEmploymentHistoryHandler : IRequestHandler<CreateEmploymentHistoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateEmploymentHistoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreateEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.EmploymentHistory).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.EmploymentHistory>();
            query!.AddEmploymentHistory(result);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
