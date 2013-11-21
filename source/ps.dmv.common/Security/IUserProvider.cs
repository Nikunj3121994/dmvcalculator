using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ps.dmv.common.Security
{
    /// <summary>
    /// IUserProvider
    /// </summary>
    public interface IUserProvider
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        IIdentity GetCurrentUser();

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns></returns>
        string GetCurrentUserId();
    }
}
