using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories
{
    public class GetFreelancerCategoriesQuery : IRequest<List<FreelancerCategoryDto>>
    {
        public Guid Id { get; set; }
    }
}
