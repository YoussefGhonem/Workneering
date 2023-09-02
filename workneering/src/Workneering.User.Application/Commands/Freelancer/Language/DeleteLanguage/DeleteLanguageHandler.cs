using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Language.DeleteLanguage
{
    public class DeleteLanguageHandler : IRequestHandler<DeleteLanguageCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteLanguageHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Languages).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveLanguages(request.Ids);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
