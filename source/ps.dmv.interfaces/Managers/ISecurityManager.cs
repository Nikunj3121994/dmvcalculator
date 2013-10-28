using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ps.dmv.common.Security;

namespace ps.dmv.interfaces.Managers
{
    public interface ISecurityManager
    {
        Task<ApplicationUser> GetUserAsync(string userName, string password);

        Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser applicationUser, string defaultAuthenticationTypes);

        Task<IdentityResult> CreateRegistrationAsync(ApplicationUser applicationUser, string password);

        Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login);

        Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);

        Task<IdentityResult> AddPasswordAsync(string userId, string password);

        Task<ApplicationUser> FindAsync(UserLoginInfo login);

        Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login);

        Task<IdentityResult> CreateAsync(ApplicationUser user);

        void Dispose();

        IList<UserLoginInfo> GetLogins(string userId);

        ApplicationUser FindById(string userId);

        bool HasPassword(string userId);
    }
}
