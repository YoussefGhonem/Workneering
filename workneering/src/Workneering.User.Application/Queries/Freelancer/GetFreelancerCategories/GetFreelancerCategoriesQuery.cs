using MediatR;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategories
{
    public class GetFreelancerCategoriesQuery : IRequest<FreelancerCategoryDto>
    {
        public Guid? FreelancerId { get; set; }
    }
}
