using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.DeleteExperiences
{
    public class DeleteExperiencesHandler : IRequestHandler<DeleteExperiencesCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public DeleteExperiencesHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(DeleteExperiencesCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Experiences).FirstOrDefault(x => x.Id == CurrentUser.Id);
            query.RemoveExperience(request.ExperienceId);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
