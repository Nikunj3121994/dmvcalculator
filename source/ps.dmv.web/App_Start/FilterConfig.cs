using System.Web;
using System.Web.Mvc;
using ps.dmv.web.Infrastructure.Core;

namespace ps.dmv.web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new DmvHandleErrorAttribute());
        }
    }
}
