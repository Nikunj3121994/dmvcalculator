using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ps.dmv.common.Security;

namespace ps.dmv.interfaces.Providers
{
    /// <summary>
    /// IAuthenticationProvider
    /// </summary>
    public interface IAuthenticationProvider
    {
        /// <summary>
        /// Signs the in asynchronous.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
        /// <returns></returns>
        Task SignInAsync(ApplicationUser user, bool isPersistent);

        /// <summary>
        /// Signs the out.
        /// </summary>
        void SignOut();
    }
}
