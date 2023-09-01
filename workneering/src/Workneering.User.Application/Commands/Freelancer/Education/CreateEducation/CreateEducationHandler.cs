using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Education.CreateEducation
{
    public class CreateEducationHandler : IRequestHandler<CreateEducationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public CreateEducationHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Education>();
            query!.AddEducation(result);
            _userDatabaseContext?.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
