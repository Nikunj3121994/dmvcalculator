using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ps.dmv.common.Security
{
    /// <summary>
    /// UserProvider
    /// </summary>
    public class UserProvider : IUserProvider
    {
        /// <summary>
        /// Gets the current user.
        /// </summary>
        /// <returns></returns>
        public IIdentity GetCurrentUser()
        {
            return HttpContext.Current.User.Identity;
        }

        /// <summary>
        /// Gets the current user identifier.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentUserId()
        {
            return this.GetCurrentUser().GetUserId();
        }
    }

}
