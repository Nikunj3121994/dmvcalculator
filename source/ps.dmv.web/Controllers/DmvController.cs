using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// DmvController
    /// </summary>
    public partial class DmvController : BaseDmvController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
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
            return PartialView(MVC.Dmv.Views._dmvCalculationForm);
        }

        /// <summary>
        /// DMVs the form lite.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult DmvFormLite()
        {
            return PartialView(MVC.Dmv.Views._dmvCalculationFormLite);
        }

        /// <summary>
        /// DMVs the calculation result.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual ActionResult DmvCalculationResult(int id)
        {
            DmvCalculationResult dmvCalculationResult = ServiceLocator.Instance.Resolve<IDmvCalculationManager>().Get(id);

            return PartialView(MVC.Dmv.Views.DmvCalculationResult, dmvCalculationResult);
        }
	}
}