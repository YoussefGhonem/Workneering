using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Experiences.UpdateExperiences
{
    public class UpdateExperienceHandler : IRequestHandler<UpdateExperienceCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateExperienceHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Experiences).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Experience>();
            query.UpdateExperience(request.ExperienceId, result);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
