using MediatR;
using Workneering.Base.Application.Common.Pagination.models;

namespace Workneering.Project.Application.Queries.ClientProjectDetails.GetClientProposals
{
    public class GetClientProposalsQuery : BaseFilterDto, IRequest<PaginationResult<ClientProposalsListDto>>
    {
        public Guid ProjectId { get; set; }
    }
}
