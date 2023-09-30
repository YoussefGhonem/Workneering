using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities.Claims
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
