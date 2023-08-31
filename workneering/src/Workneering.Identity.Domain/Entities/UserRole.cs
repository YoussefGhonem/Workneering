using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities
{
    // This represents the class that defines the relationship between users and roles.
    // It is used to map which user belongs to which role.
    public class UserRole : IdentityUserRole<Guid>
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
