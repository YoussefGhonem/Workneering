using MediatR;
using System.Text.Json.Serialization;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Application.Commands.CreateProposal
{
    public class CreateProposalCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public Guid? FreelancerId { get; set; }
        [JsonIgnore]
        public Guid? ProjectId { get; set; }
        public string? CoverLetter { get; set; }
        public ProposalDurationEnum? ProposalDuration { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? TotalBid { get; set; }
    }
}
