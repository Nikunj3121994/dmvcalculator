using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using ps.dmv.common.Core;
using ps.dmv.common.Exceptions;
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
            if (!String.IsNullOrEmpty(importMobileDe.Url) && !importMobileDe.Url.Contains("suchen.mobile.de/auto-inserat"))
            {
                this.ModelState.AddModelError("Url", "URL ni iz portala mobile.de");
            }

            if (!this.ModelState.IsValid)
            {
                return View(importMobileDe);
            }

            DmvCalculationResult dmvCalculationResult = null;

            try
            {
                dmvCalculationResult = await ServiceLocator.Instance.Resolve<IMobileDeManager>().ImportCarData(importMobileDe);
            }
            catch (BusinessValidationException businessValidationException)
            {
                this.ModelState.AddModelError(String.Empty, "Napaka pri uvozu. Manjkajoči podatki v avto oglasu. Poizkusite z drugim avto oglasom.");

                foreach (ValidationResult validationResult in businessValidationException.ValidationResultList)
                {
                    this.ModelState.AddModelError(String.Empty, validationResult.Message);//TODO add it into ifra
                }

                return View(importMobileDe);
            }

            return RedirectToAction(MVC.Dmv.DmvCalculationResult(dmvCalculationResult.DmvCalculation.Id));
        }
	}
}