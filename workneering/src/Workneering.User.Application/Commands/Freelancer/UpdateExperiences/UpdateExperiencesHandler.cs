using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.UpdateExperiences
{
    public class UpdateExperiencesHandler : IRequestHandler<UpdateExperienceCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateExperiencesHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.Experiences).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.Experiences.Adapt<Unit>();
            return result;
        }
    }
}
