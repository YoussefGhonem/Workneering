using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Client.ClientBasicDetails.UpdateClientCategorization
{
    public class UpdateClientCategorizationCommandHandler : IRequestHandler<UpdateClientCategorizationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public UpdateClientCategorizationCommandHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateClientCategorizationCommand request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Clients
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            query.UpdateCategory(request.CategoryIds);
            query.UpdateSubCategory(request.SubCategoryIds);
            query.UpdateSkills(request.SkillIds);
            query!.UpdateAllPointAndPercentage();

            _userDatabaseContext.Clients.Attach(query);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
