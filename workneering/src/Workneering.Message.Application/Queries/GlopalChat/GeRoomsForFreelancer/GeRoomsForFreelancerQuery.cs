using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer
{
    public class GeRoomsForFreelancerQuery : BaseFilterDto, IRequest<PaginationResult<FreelancerRoomsDto>>
    {

    }
}
