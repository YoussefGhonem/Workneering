using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Domain.Entites;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.Category.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateCategoryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var query = _userDatabaseContext.Freelancers.Include(x => x.Categories).FirstOrDefault(x => x.Id == CurrentUser.Id);
            var result = request.Adapt<Workneering.User.Domain.Entites.Category>();
            query.UpdateCategory(request.Id, result);
            _userDatabaseContext.Freelancers.Attach(query);
            _userDatabaseContext?.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
