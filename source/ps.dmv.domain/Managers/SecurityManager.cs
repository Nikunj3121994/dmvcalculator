using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ps.dmv.common.Security;
using ps.dmv.domain.application.Core;
using ps.dmv.infrastructure.Models;
using ps.dmv.interfaces.Managers;

namespace ps.dmv.domain.application.Managers
{
    public class SecurityManager : ManagerBase<object>, ISecurityManager
    {
        public UserManager<ApplicationUser> _userManager { get; private set; }

        public SecurityManager()
        {
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        public async Task<ApplicationUser> GetUserAsync(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(ApplicationUser applicationUser, string defaultAuthenticationTypes)
        {
            return await _userManager.CreateIdentityAsync(applicationUser, defaultAuthenticationTypes);
        }

        public async Task<IdentityResult> CreateRegistrationAsync(ApplicationUser applicationUser, string password)
        {
            return await _userManager.CreateAsync(applicationUser, password);
        }

        public async Task<IdentityResult> RemoveLoginAsync(string userId, UserLoginInfo login)
        {
            return await _userManager.RemoveLoginAsync(userId, login);
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(userId, currentPassword, newPassword);
        }

        public async Task<IdentityResult> AddPasswordAsync(string userId, string password)
        {
            return await _userManager.AddPasswordAsync(userId, password);
        }

        public async Task<ApplicationUser> FindAsync(UserLoginInfo login)
        {
            return await _userManager.FindAsync(login);
        }

        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            return await _userManager.AddLoginAsync(userId, login);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            return await _userManager.CreateAsync(user);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }

        public IList<UserLoginInfo> GetLogins(string userId)
        {
            return _userManager.GetLogins(userId);
        }

        public ApplicationUser FindById(string userId)
        {
            return _userManager.FindById(userId);
        }

        public bool HasPassword(string userId)
        {
            var user = this.FindById(userId);

            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }
    }
}
