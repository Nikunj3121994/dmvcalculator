using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// DmvController
    /// </summary>
    public partial class DmvController : BaseDmvController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

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