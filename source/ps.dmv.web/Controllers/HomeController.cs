using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.common.Core;
using ps.dmv.common.Helpers;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

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
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        /// <summary>
        /// Contacts this instance.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Latests the DMV calculations.
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult LatestDmvCalculations()
        {
            //TODO: Refactor to get data via AJAX
            List<DmvCalculation> dmvCalculationList = ServiceLocator.Instance.Resolve<IDmvCalculationManager>().GetAll(DmvConstants.InitialPageIndex, DmvConstants.LatestDmvCalculationsNumber);

            return PartialView(MVC.Home.Views._LatestDmvCalculations, dmvCalculationList);
        }
    }
}