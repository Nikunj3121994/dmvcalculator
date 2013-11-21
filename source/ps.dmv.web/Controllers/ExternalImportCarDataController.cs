using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// ExternalImportCarDataController
    /// </summary>
    public partial class ExternalImportCarDataController : BaseDmvController
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            ImportMobileDe importMobileDe = new ImportMobileDe();

            return View(importMobileDe);
        }

        /// <summary>
        /// Indexes the specified import mobile de.
        /// </summary>
        /// <param name="importMobileDe">The import mobile de.</param>
        /// <returns></returns>
        [HttpPost]
        public virtual async Task<ActionResult> Index(ImportMobileDe importMobileDe)
        {
            if (!this.ModelState.IsValid)
            {
                return View(importMobileDe);
            }

            DmvCalculationResult dmvCalculationResult = await ServiceLocator.Instance.Resolve<IMobileDeManager>().ImportCarData(importMobileDe);

            return RedirectToAction(MVC.Dmv.DmvCalculationResult(dmvCalculationResult.DmvCalculation.Id));
        }
	}
}