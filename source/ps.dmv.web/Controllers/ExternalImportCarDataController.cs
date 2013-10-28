using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.Controllers
{
    public class ExternalImportCarDataController : BaseDmvController
    {
        //
        // GET: /ExternalImportCarData/
        public ActionResult Index()
        {
            return View();
        }
	}
}