using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.UpdateFreelancerCategories
{
    public class UpdateFreelancerCategoryHandler : IRequestHandler<UpdateFreelancerCategoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateFreelancerCategoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateFreelancerCategoryCommand request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return Unit.Value;

            var query = _userDatabaseContext.Freelancers.Include(x => x.Categories).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.Categories.Adapt<Unit>();
            return result;
        }
    }
}
