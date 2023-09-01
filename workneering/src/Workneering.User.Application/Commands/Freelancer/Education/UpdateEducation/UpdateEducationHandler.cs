using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Education.UpdateEducation
{
    public class UpdateEducationHandler : IRequestHandler<UpdateEducationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateEducationHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Educations).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Domain.Entites.Education>();
            query.UpdateEducation(request.Id, result);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
