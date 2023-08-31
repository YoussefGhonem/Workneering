using Microsoft.AspNetCore.Identity;
using Workneering.Identity.Domain.Entities;

namespace Workneering.Identity.Domain.Entities.Claims
{
    public class RoleClaim : IdentityRoleClaim<Guid>
    {
        public virtual Role Role { get; set; }
    }
}
