using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Skills.UpdateFreelancerSkills
{
    public class UpdateFreelancerSkillsHandler : IRequestHandler<UpdateFreelancerSkillsCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateFreelancerSkillsHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateFreelancerSkillsCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != CurrentUser.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.FreelancerSkills).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.FreelancerSkills?.Adapt<List<FreelancerSkill>>();
            query!.UpdateFreelancerSkills(result);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
