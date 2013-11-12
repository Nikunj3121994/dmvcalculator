using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.common.Core;
using ps.dmv.interfaces.Managers;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    public partial class HomeController : BaseDmvController
    {
        public virtual ActionResult Index()
        {
            var dmvManager = ServiceLocator.Instance.Resolve<IDmvCalculationManager>().GetAll();

            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}