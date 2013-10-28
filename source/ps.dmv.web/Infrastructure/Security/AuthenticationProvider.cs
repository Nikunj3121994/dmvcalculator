using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using ps.dmv.common.Security;
using System.Security.Claims;
using ps.dmv.interfaces.Managers;

namespace ps.dmv.web.Infrastructure.Security
{
    //TODO refactor to the ServiceLocator
    public class AuthenticationProvider : IAuthenticationProvider
    {
        private IAuthenticationManager _authenticationManager = null;
        private ISecurityManager _securityManager = null;

        public AuthenticationProvider(IAuthenticationManager authenticationManager, ISecurityManager securityManager)
        {
            _authenticationManager = authenticationManager;
            _securityManager = securityManager;
        }

        public async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            ClaimsIdentity identity = await _securityManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public void SignOut()
        {
            _authenticationManager.SignOut();
        }
    }

    public interface IAuthenticationProvider
    {
        Task SignInAsync(ApplicationUser user, bool isPersistent);
    }
}