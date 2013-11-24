using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ps.dmv.common.Security;
using System.Security.Claims;
using ps.dmv.interfaces.Managers;
using ps.dmv.interfaces.Providers;

namespace ps.dmv.web.Infrastructure.Security
{
    /// <summary>
    /// AuthenticationProvider
    /// </summary>
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private IAuthenticationManager _authenticationManager = null;
        private ISecurityManager _securityManager = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationProvider"/> class.
        /// </summary>
        /// <param name="authenticationManager">The authentication manager.</param>
        /// <param name="securityManager">The security manager.</param>
        public AuthenticationProvider(IAuthenticationManager authenticationManager, ISecurityManager securityManager)
        {
            _authenticationManager = authenticationManager;
            _securityManager = securityManager;
        }

        /// <summary>
        /// Signs the in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
        /// <returns></returns>
        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = await _securityManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        /// <summary>
        /// Signs the out.
        /// </summary>
        public void SignOut()
        {
            _authenticationManager.SignOut();
        }
    }
}