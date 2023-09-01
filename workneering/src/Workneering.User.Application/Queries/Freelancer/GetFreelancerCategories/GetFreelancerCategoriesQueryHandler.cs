using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Workneering.User.Infrastructure.Persistence;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories
{
    public class GetFreelancerCategoriesQueryHandler : IRequestHandler<GetFreelancerCategoriesQuery, List<FreelancerCategoryDto>>
    {
        private readonly UserDatabaseContext _userDatabaseContext;

        public GetFreelancerCategoriesQueryHandler(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public async Task<List<FreelancerCategoryDto>> Handle(GetFreelancerCategoriesQuery request, CancellationToken cancellationToken)
        {
            if (_userDatabaseContext.Freelancers.Any(x => x.Id != request.Id)) return new List<FreelancerCategoryDto>();

            var query = _userDatabaseContext.Freelancers.Include(x => x.Categories).FirstOrDefault(x => x.Id == request.Id);
            var result = query!.Categories.Adapt<List<FreelancerCategoryDto>>();
            return result;
        }
    }
}
