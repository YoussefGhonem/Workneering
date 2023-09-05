using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.Shared.Core.Identity.CurrentUser;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories
{
    public class GetFreelancerCategoriesQueryHandler : IRequestHandler<GetFreelancerCategoriesQuery, FreelancerCategoryDto>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerCategoriesQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<FreelancerCategoryDto> Handle(GetFreelancerCategoriesQuery request, CancellationToken cancellationToken)
        {

            var query = _userDatabaseContext.Freelancers.Include(x => x.Category).FirstOrDefault(x => x.Id == request.FreelancerId);
            var result = query!.Category.Adapt<FreelancerCategoryDto>();
            return result;
        }
    }
}
