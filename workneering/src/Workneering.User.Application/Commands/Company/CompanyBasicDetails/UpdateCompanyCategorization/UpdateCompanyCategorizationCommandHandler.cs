using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Workneering.User.Application.Commands.Company.CompanyBasicDetails.UpdateCompanyCategorization
{
    public class UpdateCompanyCategorizationCommandHandler : IRequestHandler<UpdateCompanyCategorizationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public UpdateCompanyCategorizationCommandHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<Unit> Handle(UpdateCompanyCategorizationCommand request, CancellationToken cancellationToken)
        {

            var company = _userDatabaseContext.Companies
                .Include(x => x.Skills)
                .Include(x => x.Categories)
                .Include(x => x.SubCategories)
                .FirstOrDefault(x => x.Id == CurrentUser.Id);

            company.UpdateCategory(request.CategoryIds);
            company.UpdateSubCategory(request.SubCategoryIds);
            company.UpdateSkills(request.SkillIds);
            company!.UpdateAllPointAndPercentage();
            _userDatabaseContext.Companies.Update(company);
            await _userDatabaseContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
