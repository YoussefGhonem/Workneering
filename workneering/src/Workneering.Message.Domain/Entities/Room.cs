using System.Net.Mail;
using Workneering.Base.Domain.Common;

namespace Workneering.Message.Domain.Entities
{
    public record Room : BaseEntity
    {
        private Guid _clientId;
        private Guid _freelancerId;
        private bool _isActive = false;

        public Guid ClientId { get => _clientId; set => _clientId = value; }
        public Guid FreelancerId { get => _freelancerId; set => _freelancerId = value; }
        public bool IsActive { get => _isActive; set => _isActive = value; }

        public Room(Guid clientId, Guid freelancerId)
        {
            _clientId = clientId;
            _freelancerId = freelancerId;
        }
        public Room()
        {

        }

        public void SetIsActive()
        {
            _isActive = true;
        }
    }
}


