using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ps.dmv.web.Controllers
{
    public class DmvApiController : ApiController
    {
        public DmvApiController()
        {
            
        }

        public List<string> Get()
        {
            List<string> listOfItems = new List<string>() { { "coffee pot S" }, { "nerf gun S" }, { "phone S" } };

    //{ "description": "coffee pot" },
    //{ "description": "nerf gun" },
    //{ "description": "phone" }
    //];

            return listOfItems;
        }

        public HttpResponseMessage Get(int id)
        {
            // ...

            return new HttpResponseMessage();
        }
    }
}
