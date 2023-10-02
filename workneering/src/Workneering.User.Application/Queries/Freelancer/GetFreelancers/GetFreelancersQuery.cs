using MediatR;
using Workneering.Base.Application.Common.Pagination.models;
using Workneering.User.Application.Queries.Freelancer.GetFreelancers.Filters;

namespace Workneering.User.Application.Queries.Freelancer.GetFreelancers
{
    public class GetFreelancersQuery : FreelancersListFilters, IRequest<PaginationResult<FreelancersListDto>>
    {
    }
}
