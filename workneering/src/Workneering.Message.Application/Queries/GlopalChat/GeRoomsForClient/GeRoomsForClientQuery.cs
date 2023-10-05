using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Message.Application.Queries.GlopalChat.GeRoomsForClient
{
    public class GeRoomsForClientQuery : BaseFilterDto, IRequest<PaginationResult<RoomsForClientDto>>
    {

    }
}
