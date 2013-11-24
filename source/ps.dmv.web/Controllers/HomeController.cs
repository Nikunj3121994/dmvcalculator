using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;
using ps.dmv.web.Infrastructure.Enums;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// HomeController
    /// </summary>
    public partial class HomeController : BaseDmvController
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
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("O-Nas")]
        public virtual ActionResult About()
        {
            return View(MVC.Home.Views.About);
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        [ActionName("Kontakt")]
        public virtual ActionResult Contact()
        {
            return View(MVC.Home.Views.Contact);
        }

        /// <summary>
        /// Latests the DMV calculations.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="displayMode">The display mode.</param>
        /// <param name="calculationDisplayModeEnum"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult LatestDmvCalculations(int number, CalculationDisplayModeEnum calculationDisplayModeEnum, int? index)
        {
            //TODO: Refactor to get data via AJAX

            int pageIndex = index.HasValue ? index.Value - 1 : 0;
            
            List<DmvCalculation> dmvCalculationList = ServiceLocator.Instance.Resolve<IDmvCalculationManager>().GetAll(pageIndex, number);

            if (calculationDisplayModeEnum == CalculationDisplayModeEnum.Simple)
            {
                return PartialView(MVC.Home.Views._LatestDmvCalculations, dmvCalculationList);
            }
            else if (calculationDisplayModeEnum == CalculationDisplayModeEnum.Advanced)
            {
                return PartialView(MVC.Home.Views._LatestDmvCalculationsAdvanced, dmvCalculationList);
            }
            else
            {
                throw new Exception("Not known CalculationDisplayMode: " + calculationDisplayModeEnum);
            }
        }

        /// <summary>
        /// Latests the mobile de calculations.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="displayMode"></param>
        /// <param name="calculationDisplayModeEnum"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult LatestMobileDeCalculations(int number, CalculationDisplayModeEnum calculationDisplayModeEnum, int? index)
        {
            //TODO: Refactor to get data via AJAX

            int pageIndex = index.HasValue ? index.Value - 1 : 0;
            
            List<MobileDeCar> mobileDeCalculationList = ServiceLocator.Instance.Resolve<IMobileDeManager>().GetAll(pageIndex, number);
            
            if (calculationDisplayModeEnum == CalculationDisplayModeEnum.Simple)
            {
                return PartialView(MVC.Home.Views._LatestMobileDeCalculations, mobileDeCalculationList);
            }
            else if (calculationDisplayModeEnum == CalculationDisplayModeEnum.Advanced)
            {
                return PartialView(MVC.Home.Views._LatestMobileDeCalculationsAdvanced, mobileDeCalculationList);
            }
            else
            {
                throw new Exception("Not known CalculationDisplayMode: " + calculationDisplayModeEnum);
            }
        }
    }
}