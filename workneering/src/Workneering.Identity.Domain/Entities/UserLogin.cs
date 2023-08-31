using Microsoft.AspNetCore.Identity;

namespace Workneering.Identity.Domain.Entities
{
    // This represents the class that defines external logins for a user,
    // such as logins using external providers like Google, Facebook, etc.
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public virtual User User { get; set; }
    }
}
