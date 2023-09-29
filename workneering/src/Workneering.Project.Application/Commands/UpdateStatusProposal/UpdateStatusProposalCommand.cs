using MediatR;
using System.Text.Json.Serialization;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Commands.UpdateStatusProposal
{
    public class UpdateStatusProposalCommand : IRequest<Unit>
    {

        [JsonIgnore]
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Guid ProposalId { get; set; }
        public ProposalStatusEnum Status { get; set; }


    }
}
