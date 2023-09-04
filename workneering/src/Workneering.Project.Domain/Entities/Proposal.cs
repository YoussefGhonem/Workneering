using Workneering.Base.Domain.Common;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Domain.Entities
{
    public record Proposal : BaseEntity
    {

        private Guid? _freelancerId;
        private string? _coverLetter;
        private ProposalDurationEnum? _proposalDuratio;
        // if type project and client make the project with buget
        private decimal? _totalBid;
        // if type project and client make the project with hourly
        private decimal? _hourlyRate;

        public Proposal(Guid? freelancerId, string? coverLetter, ProposalDurationEnum? proposalDuratio, decimal? totalBid = null)
        {
            _freelancerId = freelancerId;
            _coverLetter = coverLetter;
            _proposalDuratio = proposalDuratio;
            _totalBid = totalBid;
        }
        #region MyRegion
        public string? CoverLetter { get => _coverLetter; set => _coverLetter = value; }
        public Guid? FreelancerId { get => _freelancerId; set => _freelancerId = value; }
        public ProposalDurationEnum? ProposalDuratio { get => _proposalDuratio; set => _proposalDuratio = value; }
        public decimal? HourlyRate { get => _hourlyRate; set => _hourlyRate = value; }
        public decimal? TotalBid { get => _totalBid; set => _totalBid = value; }
        #endregion

    }
}
