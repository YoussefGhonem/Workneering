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
            var query = await _userDatabaseContext.Freelancers
                             .Include(c => c.Portfolios).AsSplitQuery()
                             .Include(c => c.Educations).AsSplitQuery()
                             .Include(c => c.Certifications).AsSplitQuery()
                             .Include(c => c.Languages).AsSplitQuery()
                             .Include(c => c.Experiences).AsSplitQuery()
                             .Include(c => c.Categories).AsSplitQuery()
                             .Include(c => c.EmploymentHistory).AsSplitQuery()
                             .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);
            var result = request.Adapt<Domain.Entites.Language>();
            result.Id = request.LanguageId;
            query!.AddLanguage(result);
            query.UpdateAllPointAndPercentage(query);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
