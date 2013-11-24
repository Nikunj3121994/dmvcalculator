using System;
using System.Web;
using System.Web.Mvc;

namespace ps.dmv.common.Attributes
{
    /// <summary>
    /// Represents an attribute that is used to restrict access by non-Ajax callers to an action method.
    /// </summary>
    public class AjaxActionOnlyAttribute : FilterAttribute, IAuthorizationFilter
    {
        #region IAuthorizationFilter Members

        /// <summary>
        /// Called when ajax authorization is required.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            // check if ajax call
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
        }

        #endregion
    }
}
