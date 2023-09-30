using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities.Claims
{
    // This represents the class that defines the claims associated with a user.
    // Claims are key-value pairs that represent additional information about a user,
    // such as their role, permissions, or any other custom data.
    public class UserClaim : IdentityUserClaim<Guid>
    {
        public virtual User User { get; set; }
    }
}
