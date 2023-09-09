using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Language.CreateLanguage
{
    public class CreateLanguageHandler : IRequestHandler<CreateLanguageCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateLanguageHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            var query = 
                _userDatabaseContext.Freelancers.Include(x => x.Languages)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Language>();
            result.Id = request.LanguageId;
            query!.AddLanguage(result);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
