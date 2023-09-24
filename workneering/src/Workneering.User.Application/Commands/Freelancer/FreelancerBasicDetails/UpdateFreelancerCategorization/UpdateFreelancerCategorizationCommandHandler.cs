using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Application.Services.DbQueryService;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Commands.Freelancer.FreelancerBasicDetails.UpdateFreelancerCategorization
{
    public class UpdateFreelancerCategorizationCommandHandler : IRequestHandler<UpdateFreelancerCategorizationCommand, Unit>
    {
        private readonly UserDatabaseContext _userDatabaseContext;
        private readonly IDbQueryService _dbQueryService;

        public UpdateFreelancerCategorizationCommandHandler(UserDatabaseContext userDatabaseContext, IDbQueryService dbQueryService)
        {
            _userDatabaseContext = userDatabaseContext;
            _dbQueryService = dbQueryService;
        }
        public async Task<Unit> Handle(UpdateFreelancerCategorizationCommand request, CancellationToken cancellationToken)
        {
            var query = await _userDatabaseContext.Freelancers
                        .Include(c => c.Portfolios).AsSplitQuery()
                        .Include(c => c.Educations).AsSplitQuery()
                        .Include(c => c.Certifications).AsSplitQuery()
                        .Include(c => c.Languages).AsSplitQuery()
                        .Include(c => c.Experiences).AsSplitQuery()
                        .Include(c => c.Categories).AsSplitQuery()
                        .Include(x => x.Skills).AsSplitQuery()
                        .Include(x => x.SubCategories).AsSplitQuery()
                        .Include(x => x.EmploymentHistory).AsSplitQuery()
                        .FirstOrDefaultAsync(x => x.Id == CurrentUser.Id, cancellationToken: cancellationToken);

            query!.UpdateCategory(request.CategoryIds);
            query.UpdateSubCategory(request.SubCategoryIds);
            query.UpdateSkills(request.SkillIds);
            query.UpdateAllPointAndPercentage(query);


            await _userDatabaseContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
