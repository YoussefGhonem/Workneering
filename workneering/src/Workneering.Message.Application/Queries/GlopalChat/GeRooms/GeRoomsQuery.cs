using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForFreelancer
{
    public class GeRoomsQuery : BaseFilterDto, IRequest<PaginationResult<RoomsDto>>
    {

    }
}
