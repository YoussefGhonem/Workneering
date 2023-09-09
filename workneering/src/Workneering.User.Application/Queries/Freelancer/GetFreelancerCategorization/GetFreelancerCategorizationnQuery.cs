using MediatR;
using Workneering.User.Application.Queries.Company.GetCompanyCategorization;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancerCategorization
{
    public class GetFreelancerCategorizationnQuery : IRequest<CategorizationDto>
    {
        public Guid FreelancerId { get; set; }
    }
}
