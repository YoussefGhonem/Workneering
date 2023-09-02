using Workneering.Base.Domain.Common;

namespace Workneering.User.Domain.Entites
{
    public record Company : BaseEntity
    {

        public Company()
        {

        }
        public Company(Guid id)
        {
            Id = id;
        }
    }
}
