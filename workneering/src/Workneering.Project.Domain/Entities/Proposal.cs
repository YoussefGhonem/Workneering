using Workneering.Base.Domain.Common;
using Workneering.Project.Domain.Enums;

namespace Workneering.Project.Domain.Entities
{
    public record Proposal : BaseEntity
    {

        private Guid? _freelancerId;
        private string? _coverLetter;
        private ProposalDurationEnum? _proposalDuratio;
        private ProposalStatusEnum? _proposalStatus;
        // if type project and client make the project with buget
        private decimal? _totalBid;
        // if type project and client make the project with hourly
        private decimal? _hourlyRate;
        public Proposal()
        {

        }
        public Proposal(Guid? freelancerId, string? coverLetter,
            ProposalDurationEnum? proposalDuratio, decimal? totalBid = null, decimal? hourlyRate = null)
        {
            _freelancerId = freelancerId;
            _coverLetter = coverLetter;
            _proposalDuratio = proposalDuratio;
            _totalBid = totalBid;
            _hourlyRate = hourlyRate;
            _proposalStatus = ProposalStatusEnum.Submitted;
        }
        #region MyRegion
        public string? CoverLetter { get => _coverLetter; private set => _coverLetter = value; }
        public Guid? FreelancerId { get => _freelancerId; private set => _freelancerId = value; }
        public decimal? HourlyRate { get => _hourlyRate; private set => _hourlyRate = value; }
        public decimal? TotalBid { get => _totalBid; private set => _totalBid = value; }
        public ProposalDurationEnum? ProposalDuration { get => _proposalDuratio; private set => _proposalDuratio = value; }
        public ProposalStatusEnum? ProposalStatus { get => _proposalStatus; private set => _proposalStatus = value; }
        #endregion

        #region Public Methods
        public void UpdateProposalStatus(ProposalStatusEnum field)
        {
            _proposalStatus = field;
        }
        #endregion
    }
}
