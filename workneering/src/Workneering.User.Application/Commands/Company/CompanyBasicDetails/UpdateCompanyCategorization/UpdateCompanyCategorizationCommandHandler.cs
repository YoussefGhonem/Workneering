using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyCategorization
{
    public class UpdateCompanyCategorizationCommandHandler : IRequestHandler<UpdateCompanyCategorizationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public UpdateCompanyCategorizationCommandHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateCompanyCategorizationCommand request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Companies
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            query.UpdateCategory(request.CategoryIds);
            query.UpdateSubCategory(request.SubCategoryIds);
            query.UpdateSkills(request.SkillIds);

            return Unit.Value;
        }
    }
}
