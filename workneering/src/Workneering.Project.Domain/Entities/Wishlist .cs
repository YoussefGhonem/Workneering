using Workneering.Base.Domain.Common;

namespace Workneering.Project.Domain.Entities
{
    public record Wishlist : BaseEntity
    {
        private Guid? _freelancerId;
        public Wishlist(Guid? freelancerId)
        {
            _freelancerId = freelancerId;
        }
        public Wishlist()
        {

        }
        public Guid? FreelancerId { get => _freelancerId; private set => _freelancerId = value; }
    }
}
