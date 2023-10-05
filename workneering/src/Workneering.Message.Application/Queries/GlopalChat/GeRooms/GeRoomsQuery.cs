using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRooms
{
    public class GeRoomsQuery : BaseFilterDto, IRequest<PaginationResult<RoomsDto>>
    {

    }
}
