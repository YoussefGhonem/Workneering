using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerSkills
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
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.FreelancerSkills).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.FreelancerSkills.Adapt<Unit>();
            return result;
        }
    }
}
