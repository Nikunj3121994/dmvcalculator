using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// DmvController
    /// </summary>
    public partial class DmvController : Controller
    {
        /// <summary>
        /// DMVs the form.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult DmvForm()
        {
            return PartialView(MVC.Dmv.Views._dmvForm);
        }
	}
}