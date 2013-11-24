using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.common.Attributes;
using ps.dmv.common.Core;
using ps.dmv.domain.data.Entities;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    /// <summary>
    /// StatisticsController
    /// </summary>
    public partial class StatisticsController : BaseDmvController
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
        /// Mosts the popular car brand.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult MostPopularCarBrand()
        {
            CarManufacturerNumberStatistics carManufacturerNumberStatistics = ServiceLocator.Instance.Resolve<IStatisticsManager>().GetMostPopularCarBrandStatistics();

            return PartialView(MVC.Statistics.Views._MostPopularCarBrand, carManufacturerNumberStatistics);
        }

        /// <summary>
        /// Calculations the frequency.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public virtual ActionResult CalculationFrequency()
        {
            CalculationFrequencyStatistics calculationFrequencyStatistics = ServiceLocator.Instance.Resolve<IStatisticsManager>().GetCalculationFrequencyStatistics();

            return PartialView(MVC.Statistics.Views._CalculationFrequency, calculationFrequencyStatistics);
        }
	}
}