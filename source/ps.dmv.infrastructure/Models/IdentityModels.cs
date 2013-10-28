using Microsoft.AspNet.Identity.EntityFramework;
using ps.dmv.common.Security;

namespace ps.dmv.infrastructure.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    }
}